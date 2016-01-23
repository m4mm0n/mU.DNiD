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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dnlib.PE;
using DNiD2.intClasses;
using DNiD2.intForms;
using ReaperTheme;

namespace DNiDGUI
{
    public partial class frmMain : ReaperForm
    {
        private readonly BackgroundWorker bw;
        private readonly string fileToScan;

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.reaperButton7.Enabled = true;
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            this.ScanFile();
        }

        private static string GetFilename(DragEventArgs e)
        {
            var ret = "";
            var filename = string.Empty;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                var data = e.Data.GetData("FileNameW") as Array;
                if (data != null && (data.Length == 1) && data.GetValue(0) is string)
                {
                    filename = ((string[]) data)[0x0];
                    var ext = Path.GetExtension(filename).ToLower();
                    ret = filename;
                }
            }
            return ret;
        }

        private static string GetSectionHeaderName(uint rva, PEImage myPe)
        {
            var myRet = "";
            Parallel.ForEach(myPe.ImageSectionHeaders, section =>
            {
                if (rva >= (uint) section.VirtualAddress &&
                    rva < (uint) section.VirtualAddress + Math.Max(section.VirtualSize, section.SizeOfRawData))
                {
                    myRet = Encoding.ASCII.GetString(section.Name);
                }
            });
            return myRet;
        }

        private void frmMain_onColorBarColorChanged(object sender, ReaperEvents.OnColorBarColorChanged e)
        {
        }

        private void ScanFile()
        {
            if (this.InvokeRequired) this.Invoke(new ScanFileDelegate(this.ScanFile));
            else
            {
                try
                {
                    using (var a = new PEImage(File.ReadAllBytes(this.txtFilePath.Text)))
                    {
                        if (File.Exists(Environment.CurrentDirectory + @"\external_sigs.txt"))
                        {
                            clsScanner.SetSignatureDB(false, false, true,
                                Environment.CurrentDirectory + @"\external_sigs.txt");
                            this.reaperTextbox8.Text = clsScanner.Scan(this.txtFilePath.Text).Trim();
                        }
                        else
                        {
                            clsScanner.SetSignatureDB(true, false, false);
                            this.reaperTextbox8.Text = clsScanner.Scan(this.txtFilePath.Text).Trim();
                        }
                        this.txtEntrypoint.Text = ((uint) a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint).ToString("X8");

                        this.txtSubSystem.Text = a.ImageNTHeaders.OptionalHeader.Subsystem.ToString();
                        this.txtEPSection.Text =
                            GetSectionHeaderName((uint) a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint, a);
                        this.txtFileOffset.Text =
                            ((uint) a.ToFileOffset(a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint)).ToString("X8");
                        var b = File.ReadAllBytes(this.txtFilePath.Text);
                        var c = (int) a.ToFileOffset(a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint);
                        this.txtFirstBytes.Text = b[c].ToString("X2") + "," + b[c + 1].ToString("X2") + "," +
                                             b[c + 2].ToString("X2") + "," + b[c + 3].ToString("X2");
                        this.txtLinkerInfo.Text = a.ImageNTHeaders.OptionalHeader.MajorLinkerVersion + "." +
                                             a.ImageNTHeaders.OptionalHeader.MinorLinkerVersion;
                    }
                }
                catch
                {
                    this.reaperTextbox8.Text = "File not supported!";
                }
            }
        }

        private void mnuPlugins_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private delegate void ScanFileDelegate();

        #region Main Form Functions:

        public frmMain([Optional] string File2Scan)
        {
            this.bw = new BackgroundWorker();
            this.bw.DoWork += this.Bw_DoWork;
            this.bw.RunWorkerCompleted += this.Bw_RunWorkerCompleted;

            this.InitializeComponent();

            this.DragDrop += this.FrmMain_DragDrop;
            this.DragEnter += this.FrmMain_DragEnter;


            if (File2Scan != null)
            {
                this.fileToScan = File2Scan;
                this.txtFilePath.Text = this.fileToScan;
                this.bw.RunWorkerAsync();
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
            if (!this.bw.IsBusy)
            {
                this.txtEntrypoint.Text = "";
                this.txtEPSection.Text = "";
                this.txtFileOffset.Text = "";
                this.txtFilePath.Text = "";
                this.txtFirstBytes.Text = "";
                this.txtLinkerInfo.Text = "";
                this.txtSubSystem.Text = "";
                this.reaperTextbox8.Text = "";

                this.txtFilePath.Text = GetFilename(e);
                this.reaperButton7.Enabled = false;
                this.bw.RunWorkerAsync();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsPluginSupport.InitPeidPlugins();
            if (clsPluginSupport.plugPEiD.Count > 0) this.AddNativePlugins(clsPluginSupport.plugPEiD);
        }

        #endregion

        #region Button Functions:

        private void reaperButton7_Click(object sender, EventArgs e)
        {
            this.reaperButton7.Enabled = false;
            this.bw.RunWorkerAsync();
        }

        private void reaperButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reaperButton6_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAbout())
            {
                frm.ShowDialog();
            }
        }

        private void reaperButton1_Click(object sender, EventArgs e)
        {
            using (var a = new OpenFileDialog())
            {
                if (this.txtFilePath.Text.Length > 0)
                    a.InitialDirectory = Path.GetDirectoryName(this.txtFilePath.Text);

                if (a.ShowDialog() == DialogResult.OK)
                {
                    this.txtFilePath.Text = a.FileName;
                    this.bw.RunWorkerAsync();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.mnuPlugins.Items.Count > 0) this.mnuPlugins.Show(this.button1, this.button1.PointToClient(Cursor.Position));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtFilePath.Text.Length > 0)
            {
                using (var a = new PEImage(File.ReadAllBytes(this.txtFilePath.Text)))
                {
                    using (var frm = new frmSecView(a))
                    {
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var a = File.ReadAllBytes(this.txtFilePath.Text);
            var b = new byte[1024];
            Array.Copy(a, uint.Parse(this.txtFileOffset.Text, NumberStyles.HexNumber), b, 0, 1024);
            using (var frm = new frmChooser(uint.Parse(this.txtEntrypoint.Text, NumberStyles.HexNumber), b))
            {
                frm.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet!", "Not Yet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void mnuPlugins_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.GetNativeFunction(e.ClickedItem.Text);
        }

        #endregion

        #region Native Plugin Support:

        private void AddNativePlugins(Dictionary<string, string> myPlugins)
        {
            foreach (var a in myPlugins)
            {
                this.mnuPlugins.Items.Add(a.Key);
            }
        }

        private void GetNativeFunction(string plugName)
        {
            var b = this.txtFilePath.Text;
            foreach (var a in clsPluginSupport.plugPEiD)
            {
                if (a.Key == plugName)
                {
                    clsPluginSupport.doPeidPluginJob(a.Value, b, this.Handle);
                    break;
                }
            }
        }

        #endregion
    }
}