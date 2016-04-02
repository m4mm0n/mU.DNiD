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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DNiD2.intForms
{
    using System.Diagnostics;

    using dnlib.PE;

    using SharpDisasm;
    using SharpDisasm.Udis86;

    public partial class frmDisassemblyView : ReaperTheme.ReaperForm
    {

        private uint addr = 0;
        private byte[] bitsRead;
        private BackgroundWorker bw = new BackgroundWorker();
        private frmProgress fProg;

        public frmDisassemblyView(uint addressToDisassemble, byte[] bytesToRead)
        {
            Debug.WriteLine("[frmDisassemblyView]");

            this.addr = addressToDisassemble;
            this.bitsRead = bytesToRead;

            this.InitializeComponent();
            this.bw.DoWork += this.Bw_DoWork;
            this.bw.RunWorkerCompleted += this.Bw_RunWorkerCompleted;
            this.bw.ProgressChanged += this.Bw_ProgressChanged;
            this.bw.WorkerReportsProgress = true;

            this.Load += this.FrmDisassemblyView_Load;
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.WriteLine("[Bw_ProgressChanged]");
            this.fProg.SetCurrentProgress(e.ProgressPercentage, (string)e.UserState);
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Debug.WriteLine("[Bw_RunWorkerCompleted]");
            this.fProg.Close();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Debug.WriteLine("[Bw_DoWork]");
            this.DisassembleTarget(this.bitsRead, ArchitectureMode.x86_32);
        }

        private void DisassembleTarget(byte[] fileBytes, ArchitectureMode mode)
        {
            Debug.WriteLine("[DisassembleTarget]");
            // Create the disassembler
            using (var disasm = new Disassembler(fileBytes, 1024, mode, this.addr, true, Vendor.Any))
            {
                var dis = disasm.Disassemble();
                var i = dis.Count();
                this.fProg.MaxProgress(i);
                var o = 0;
                // Disassemble each instruction and output to console
                foreach (var insn in dis)
                {
                    this.WriteDis(insn.Offset.ToString("X8"), toHex(insn.Bytes), insn.ToString(), insn);
                    this.bw.ReportProgress(o, "Added: " + insn.ToString());
                    o++;
                }
            }
        }

        private ArchitectureMode GetArchitecture(PEImage a)
        {
            Debug.WriteLine("[GetArchitecture]");
            switch (a.ImageNTHeaders.FileHeader.Machine)
            {
                case Machine.I386:
                    return ArchitectureMode.x86_16;
                case Machine.IA64:
                    return ArchitectureMode.x86_64;
                default:
                    return ArchitectureMode.x86_16;
            }
        }

        private void FrmDisassemblyView_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("[FrmDisassemblyView_Load]");
            this.fProg = new frmProgress("Loading DisassemblyView...");
            //fProg.MaxProgress(1024);
            this.bw.RunWorkerAsync();
            this.fProg.ShowDialog();
        }

        private delegate void RefreshListViewDelegate();
        private void RefreshListView()
        {
            Debug.WriteLine("[RefreshListView]");
            if (this.InvokeRequired)
                this.Invoke(new RefreshListViewDelegate(this.RefreshListView));
            else this.listView1.Refresh();
        }

        private static string toHex(byte[] bits)
        {
            Debug.WriteLine("[toHex]");
            var toRet = "";
            foreach (byte bit in bits)
            {
                toRet += bit.ToString("X2");
            }
            return toRet;
        }

        private void WriteDis(string addr, string bytes1, string instruction, Instruction branchType)
        {
            Debug.WriteLine("[WriteDis]");
            var item = new ListViewItem(addr);
            item.SubItems.Add(bytes1);

            switch (branchType.Mnemonic)
            {
                case ud_mnemonic_code.UD_Icall:
                    item.SubItems.Add(instruction, Color.Blue, Color.LightBlue, this.Font);
                    break;
                case ud_mnemonic_code.UD_Ijo:
                case ud_mnemonic_code.UD_Ijno:
                case ud_mnemonic_code.UD_Ijb:
                case ud_mnemonic_code.UD_Ijae:
                case ud_mnemonic_code.UD_Ijz:
                case ud_mnemonic_code.UD_Ijnz:
                case ud_mnemonic_code.UD_Ijbe:
                case ud_mnemonic_code.UD_Ija:
                case ud_mnemonic_code.UD_Ijs:
                case ud_mnemonic_code.UD_Ijns:
                case ud_mnemonic_code.UD_Ijp:
                case ud_mnemonic_code.UD_Ijnp:
                case ud_mnemonic_code.UD_Ijl:
                case ud_mnemonic_code.UD_Ijge:
                case ud_mnemonic_code.UD_Ijle:
                case ud_mnemonic_code.UD_Ijg:
                case ud_mnemonic_code.UD_Ijcxz:
                case ud_mnemonic_code.UD_Ijecxz:
                case ud_mnemonic_code.UD_Ijrcxz:
                case ud_mnemonic_code.UD_Ijmp:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case ud_mnemonic_code.UD_Iret:
                case ud_mnemonic_code.UD_Iretf:
                    item.SubItems.Add(instruction, Color.Red, Color.LightBlue, this.Font);
                    break;
                default:
                    item.SubItems.Add(instruction, Color.Black, Color.White, this.Font);
                    break;
            }
            item.UseItemStyleForSubItems = false;

            this.AddItemToList(item);
        }
        //private void WriteDis(string addr, string bytes1, string instruction, BeaConstants.BranchType branchType)
        //{
        //    var item = new ListViewItem(addr);
        //    item.SubItems.Add(bytes1);

        //    switch (branchType)
        //    {
        //        case BeaConstants.BranchType.CallType:
        //            item.SubItems.Add(instruction, Color.Blue, Color.LightBlue, this.Font);
        //            break;
        //        case BeaConstants.BranchType.JA:
        //        case BeaConstants.BranchType.JB:
        //        case BeaConstants.BranchType.JC:
        //        case BeaConstants.BranchType.JE:
        //        case BeaConstants.BranchType.JECXZ:
        //        case BeaConstants.BranchType.JG:
        //        case BeaConstants.BranchType.JL:
        //        case BeaConstants.BranchType.JmpType:
        //        case BeaConstants.BranchType.JNA:
        //        case BeaConstants.BranchType.JNB:
        //        case BeaConstants.BranchType.JNC:
        //        case BeaConstants.BranchType.JNE:
        //        case BeaConstants.BranchType.JNG:
        //        case BeaConstants.BranchType.JNL:
        //        case BeaConstants.BranchType.JNO:
        //        case BeaConstants.BranchType.JNP:
        //        case BeaConstants.BranchType.JNS:
        //        case BeaConstants.BranchType.JO:
        //        case BeaConstants.BranchType.JP:
        //        case BeaConstants.BranchType.JS:
        //            item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
        //            break;
        //        case BeaConstants.BranchType.RetType:
        //            item.SubItems.Add(instruction, Color.Red, Color.LightBlue, this.Font);
        //            break;
        //        default:
        //            item.SubItems.Add(instruction, Color.Black, Color.White, this.Font);
        //            break;
        //    }
        //    item.UseItemStyleForSubItems = false;

        //    AddItemToList(item);
        //}
        private delegate void AddItemToListDelegate(ListViewItem a);
        private void AddItemToList(ListViewItem myItem)
        {
            Debug.WriteLine("[AddItemToList]");
            if (this.InvokeRequired)
                this.Invoke(new AddItemToListDelegate(this.AddItemToList), new object[] { myItem });
            else this.listView1.Items.Add(myItem);
        }

        private void frmDisassemblyView_onColorBarColorChanged(object sender, ReaperTheme.ReaperEvents.OnColorBarColorChanged e)
        {

        }

        private void reaperButton1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[reaperButton1_Click]");
            this.Close();
        }

        private void copyAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[copyAddressToolStripMenuItem_Click]");
            Clipboard.Clear();
            Clipboard.SetText(this.listView1.SelectedItems[0].SubItems[0].Text);
        }

        private void copyBytesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[copyBytesToolStripMenuItem_Click]");
            Clipboard.Clear();
            Clipboard.SetText(this.listView1.SelectedItems[0].SubItems[1].Text);
        }

        private void copyDisassemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[copyDisassemblyToolStripMenuItem_Click]");
            Clipboard.Clear();
            Clipboard.SetText(this.listView1.SelectedItems[0].SubItems[2].Text);
        }
    }
}
