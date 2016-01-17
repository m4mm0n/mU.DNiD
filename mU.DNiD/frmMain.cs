/*
    DNiD 2 - PE Identifier.
    Copyright (C) 2016  mammon

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using DNiD2.intClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNiDGUI
{
    public partial class frmMain : ReaperTheme.ReaperForm
    {
        private string fileToScan;
        private BackgroundWorker bw;

        #region Main Form Functions:
        public frmMain([Optional]string File2Scan)
        {
            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

            InitializeComponent();

            this.DragDrop += FrmMain_DragDrop;
            this.DragEnter += FrmMain_DragEnter;


            if (File2Scan != null)
            {
                fileToScan = File2Scan;
                txtFilePath.Text = fileToScan;
                bw.RunWorkerAsync();
            }
        }
        private void FrmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Okay
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it
        }
        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            if (!bw.IsBusy)
            {
                txtEntrypoint.Text = "";
                txtEPSection.Text = "";
                txtFileOffset.Text = "";
                txtFilePath.Text = "";
                txtFirstBytes.Text = "";
                txtLinkerInfo.Text = "";
                txtSubSystem.Text = "";
                reaperTextbox8.Text = "";

                txtFilePath.Text = GetFilename(e);
                reaperButton7.Enabled = false;
                bw.RunWorkerAsync();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            clsPluginSupport.InitPeidPlugins();
            if (clsPluginSupport.plugPEiD.Count > 0)
                AddNativePlugins(clsPluginSupport.plugPEiD);
        }
        #endregion
        #region Button Functions:
        private void reaperButton7_Click(object sender, EventArgs e)
        {
            reaperButton7.Enabled = false;
            bw.RunWorkerAsync();
        }
        private void reaperButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void reaperButton6_Click(object sender, EventArgs e)
        {
            using (var frm = new DNiD2.intForms.frmAbout())
            {
                frm.ShowDialog();
            }
        }
        private void reaperButton1_Click(object sender, EventArgs e)
        {
            using (var a = new OpenFileDialog())
            {
                if (txtFilePath.Text.Length > 0)
                    a.InitialDirectory = Path.GetDirectoryName(txtFilePath.Text);

                if (a.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = a.FileName;
                    bw.RunWorkerAsync();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (mnuPlugins.Items.Count > 0)
                mnuPlugins.Show(button1, button1.PointToClient(Cursor.Position));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text.Length > 0)
            {
                using (var a = new dnlib.PE.PEImage(File.ReadAllBytes(txtFilePath.Text)))
                {
                    using (var frm = new DNiD2.intForms.frmSecView(a))
                    {
                        frm.ShowDialog();
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet!", "Not Yet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet!", "Not Yet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void mnuPlugins_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            GetNativeFunction(e.ClickedItem.Text);
        }
        #endregion

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            reaperButton7.Enabled = true;
        }
        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ScanFile();
        }
        private static string GetFilename(DragEventArgs e)
        {
            var ret = "";
            var filename = String.Empty;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                var data = ((IDataObject)e.Data).GetData("FileNameW") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        var ext = Path.GetExtension(filename).ToLower();
                        ret = filename;
                    }
                }
            }
            return ret;
        }
        #region Native Plugin Support:
        private void AddNativePlugins(Dictionary<string,string> myPlugins)
        {
            Parallel.ForEach(myPlugins, (a) =>
            {
                mnuPlugins.Items.Add(a.Key);
            });
        }
        private void GetNativeFunction(string plugName)
        {
            var b = txtFilePath.Text;
            Parallel.ForEach(clsPluginSupport.plugPEiD, (a) =>
            {
                if (a.Key == plugName)
                {
                    clsPluginSupport.doPeidPluginJob(a.Value, b, this.Handle);
                    return;
                }
            });
        }
        #endregion
        private static string GetSectionHeaderName(uint rva, dnlib.PE.PEImage myPe)
        {
            var myRet = "";
            Parallel.ForEach(myPe.ImageSectionHeaders, (section) =>
            {
                if (rva >= (uint)section.VirtualAddress && rva < (uint)section.VirtualAddress + Math.Max(section.VirtualSize, section.SizeOfRawData))
                {
                    myRet = Encoding.ASCII.GetString(section.Name);
                    return;
                }
            });
            return myRet;
        }
        private void frmMain_onColorBarColorChanged(object sender, ReaperTheme.ReaperEvents.OnColorBarColorChanged e)
        {

        }

        private delegate void ScanFileDelegate();
        private void ScanFile()
        {
            if (this.InvokeRequired)
                this.Invoke(new ScanFileDelegate(ScanFile));
            else
            {
                try
                {
                    using (var a = new dnlib.PE.PEImage(File.ReadAllBytes(txtFilePath.Text)))
                    {
                        if (File.Exists(Environment.CurrentDirectory + @"\external_sigs.txt"))
                        {
                            clsScanner.SetSignatureDB(false, false, true, Environment.CurrentDirectory + @"\external_sigs.txt");
                            reaperTextbox8.Text = clsScanner.Scan(txtFilePath.Text).Trim();
                        }
                        else
                        {
                            clsScanner.SetSignatureDB(true, false, false);
                            reaperTextbox8.Text = clsScanner.Scan(txtFilePath.Text).Trim();
                        }
                        txtEntrypoint.Text = "0x" + ((uint)a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint).ToString("X8");

                        txtSubSystem.Text = a.ImageNTHeaders.OptionalHeader.Subsystem.ToString();
                        txtEPSection.Text = GetSectionHeaderName((uint)a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint, a);
                        txtFileOffset.Text = "0x" + ((uint)a.ToFileOffset(a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint)).ToString("X8");
                        var b = File.ReadAllBytes(txtFilePath.Text);
                        var c = (int)a.ToFileOffset(a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint);
                        txtFirstBytes.Text = b[c].ToString("X2") + "," + b[c + 1].ToString("X2") + "," + b[c + 2].ToString("X2") + "," + b[c + 3].ToString("X2");
                        txtLinkerInfo.Text = a.ImageNTHeaders.OptionalHeader.MajorLinkerVersion.ToString() + "." + a.ImageNTHeaders.OptionalHeader.MinorLinkerVersion.ToString();
                    }
                }
                catch (Exception ex)
                {
                    reaperTextbox8.Text = "File not supported!";
                }
            }
        }
        private void mnuPlugins_MouseClick(object sender, MouseEventArgs e)
        {
            
        }


    }
}
