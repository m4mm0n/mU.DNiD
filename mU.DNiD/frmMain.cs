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
    using System.Diagnostics;

    public partial class frmMain : ReaperForm
    {
        private readonly BackgroundWorker bw;
        private readonly string fileToScan;

        static Logger log = new Logger(LoggerType.Console_File, "DNiD2.frmMain");

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Debug.WriteLine("[Bw_RunWorkerCompleted]");
            log.Log(LogType.Normal, "Bw_RunWorkerCompleted");
            this.reaperButton7.Enabled = true;
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //Debug.WriteLine("[Bw_DoWork]");
            log.Log(LogType.Normal, "Bw_DoWork");
            this.ScanFile();
        }

        private static string GetFilename(DragEventArgs e)
        {
            //Debug.WriteLine("[GetFilename]");
            log.Log(LogType.Normal, "GetFilename");
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                var data = e.Data.GetData("FileNameW") as Array;
                if (data != null && (data.Length == 1) && data.GetValue(0) is string)
                {
                    var filename = ((string[]) data)[0x0];
                    var ext = Path.GetExtension(filename).ToLower();
                    return filename;
                }
            }
            return "";
        }

        private static string GetSectionHeaderName(uint rva, PEImage myPe)
        {
            //Debug.WriteLine("[GetSectionHeaderName]");
            log.Log(LogType.Normal, "GetSectionHeaderName");
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
            //Debug.WriteLine("[ScanFile]");
            log.Log(LogType.Normal, "ScanFile");
            if (this.InvokeRequired) this.Invoke(new ScanFileDelegate(this.ScanFile));
            else
            {
                try
                {
                    using (var a = new PEImage(File.ReadAllBytes(this.txtFilePath.Text)))
                    {
                        var is64 = a.ImageNTHeaders.FileHeader.Machine == Machine.AMD64 |
                                   a.ImageNTHeaders.FileHeader.Machine == Machine.IA64;

                        if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\external_sigs.txt"))
                        {
                            clsScanner.SetSignatureDB(false, false, true,
                                Path.GetDirectoryName(Application.ExecutablePath) + "\\external_sigs.txt");
                            this.reaperTextbox8.Text = clsScanner.Scan(this.txtFilePath.Text).Trim();
                        }
                        else
                        {
                            clsScanner.SetSignatureDB(true, false, false);
                            this.reaperTextbox8.Text = clsScanner.Scan(this.txtFilePath.Text).Trim();
                        }

                        this.txtEntrypoint.Text =
                            is64
                                ? ((ulong) a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint).ToString("X16")
                                : ((uint) a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint).ToString("X8");

                        this.txtSubSystem.Text = a.ImageNTHeaders.OptionalHeader.Subsystem.ToString();
                        this.txtEPSection.Text =
                            GetSectionHeaderName((uint) a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint, a);
                        this.txtFileOffset.Text = is64
                            ? ((ulong) a.ToFileOffset(a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint)).ToString(
                                "X16")
                            : ((uint) a.ToFileOffset(a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint))
                            .ToString("X8");
                        var b = File.ReadAllBytes(this.txtFilePath.Text);
                        var c = (int) a.ToFileOffset(a.ImageNTHeaders.OptionalHeader.AddressOfEntryPoint);
                        this.txtFirstBytes.Text = b[c].ToString("X2") + "," + b[c + 1].ToString("X2") + "," +
                                             b[c + 2].ToString("X2") + "," + b[c + 3].ToString("X2");
                        this.txtLinkerInfo.Text = a.ImageNTHeaders.OptionalHeader.MajorLinkerVersion + "." +
                                             a.ImageNTHeaders.OptionalHeader.MinorLinkerVersion;
                    }
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine("[ScanFile] Exception: " + ex.Message);
                    log.Log(ex, "File not supported exception!");
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
            //Debug.WriteLine("[frmMain]");
            log.Log(LogType.Normal, "frmMain");
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
            //Debug.WriteLine("[FrmMain_DragEnter]");
            log.Log(LogType.Normal, "FrmMain_DragEnter");
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Okay
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it
        }

        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            //Debug.WriteLine("[FrmMain_DragDrop]");
            log.Log(LogType.Normal, "FrmMain_DragDrop");
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
            //Debug.WriteLine("[Form1_Load]");
            log.Log(LogType.Normal, "Form1_Load");
            clsPluginSupport.InitPlugins();
            if (clsPluginSupport.plugins.Count > 0) this.AddNativePlugins(clsPluginSupport.plugins);
        }

        #endregion

        #region Button Functions:

        private void reaperButton7_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("[reaperButton7_Click]");
            log.Log(LogType.Normal, "reaperButton7_Click");
            this.reaperButton7.Enabled = false;
            this.bw.RunWorkerAsync();
        }

        private void reaperButton5_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("[reaperButton5_Click]");
            log.Log(LogType.Normal, "reaperButton5_Click");
            Application.Exit();
        }

        private void reaperButton6_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("[reaperButton6_Click]");
            log.Log(LogType.Normal, "reaperButton6_Click");
            using (var frm = new frmAbout())
            {
                frm.ShowDialog();
            }
        }

        private void reaperButton1_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("[reaperButton1_Click]");
            log.Log(LogType.Normal, "reaperButton1_Click");
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
            //Debug.WriteLine("[button1_Click]");
            log.Log(LogType.Normal, "button1_Click");
            if (this.mnuPlugins.Items.Count > 0) this.mnuPlugins.Show(this.button1, this.button1.PointToClient(Cursor.Position));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("[button2_Click]");
            log.Log(LogType.Normal, "button2_Click");
            if (this.txtFilePath.Text.Length > 0)
            {
                using (var a = new PEImage(File.ReadAllBytes(this.txtFilePath.Text)))
                {
                    using (var frm = new frmSecView(a, this.txtFilePath.Text))
                    {
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("[button3_Click]");
            log.Log(LogType.Normal, "button3_Click");
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
            //Debug.WriteLine("[button4_Click]");
            log.Log(LogType.Normal, "button4_Click");
            using (var frm = new frmPEDetails(new PEImage(File.ReadAllBytes(this.txtFilePath.Text))))
            {
                frm.ShowDialog();
            }
        }

        private void mnuPlugins_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //Debug.WriteLine("[mnuPlugins_ItemClicked]");
            log.Log(LogType.Normal, "mnuPlugins_ItemClicked");
            this.mnuPlugins.Close();
            this.GetNativeFunction(e.ClickedItem.Text);
        }

        #endregion

        #region Native Plugin Support:

        private void AddNativePlugins(Dictionary<string, string> myPlugins)
        {
            //Debug.WriteLine("[AddNativePlugins]");
            log.Log(LogType.Normal, "AddNativePlugins");
            foreach (var a in myPlugins)
            {
                this.mnuPlugins.Items.Add(a.Key);
            }
        }

        private void GetNativeFunction(string plugName)
        {
            //Debug.WriteLine("[GetNativeFunction]");
            log.Log(LogType.Normal, "GetNativeFunction");
            var b = this.txtFilePath.Text;
            foreach (var a in clsPluginSupport.plugins)
            {
                if (a.Key == plugName)
                {
                    clsPluginSupport.doPluginJob(a.Value, b, this);
                    break;
                }
            }
        }

        #endregion
    }
}