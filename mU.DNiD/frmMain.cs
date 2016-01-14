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
                //ScanFile();
                bw.RunWorkerAsync();
            }
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            reaperButton7.Enabled = true;
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ScanFile();
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
            //ScanFile();
            bw.RunWorkerAsync();
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
                    foreach(var a in data)
                    {
                        Console.WriteLine(a);
                    }
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        var ext = Path.GetExtension(filename).ToLower();
                        //if ((ext == ".exe") || (ext == ".png") || (ext == ".bmp"))
                        //{
                        ret = filename;
                        //}
                    }
                }
            }
            return ret;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_onColorBarColorChanged(object sender, ReaperTheme.ReaperEvents.OnColorBarColorChanged e)
        {

        }

        private void reaperButton7_Click(object sender, EventArgs e)
        {
            //ScanFile();
            reaperButton7.Enabled = false;
            bw.RunWorkerAsync();
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
                            reaperTextbox8.Text = mU.MLib.Utils.dnID.Scan(txtFilePath.Text, Environment.CurrentDirectory + @"\external_sigs.txt").Trim();
                        }
                        else
                        {
                            reaperTextbox8.Text = mU.MLib.Utils.dnID.Scan(txtFilePath.Text).Trim();
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

        private static string GetSectionHeaderName(uint rva, dnlib.PE.PEImage myPe)
        {
            foreach (var section in myPe.ImageSectionHeaders)
            {
                if (rva >= (uint)section.VirtualAddress && rva < (uint)section.VirtualAddress + Math.Max(section.VirtualSize, section.SizeOfRawData))
                    return Encoding.ASCII.GetString(section.Name);
            }
            return "";
        }

        private void reaperButton2_Click(object sender, EventArgs e)
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

        private void reaperButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet!", "Not Yet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void reaperButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet!", "Not Yet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}
