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

using DNiD2.intClasses.BeaEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNiD2.intForms
{
    public partial class frmDisassemblyView : ReaperTheme.ReaperForm
    {

        private uint addr = 0;
        private byte[] bitsRead;
        private BackgroundWorker bw = new BackgroundWorker();
        private frmProgress fProg;

        public frmDisassemblyView(uint addressToDisassemble, byte[] bytesToRead)
        {
            addr = addressToDisassemble;
            bitsRead = bytesToRead;

            InitializeComponent();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            bw.ProgressChanged += Bw_ProgressChanged;
            bw.WorkerReportsProgress = true;

            this.Load += FrmDisassemblyView_Load;
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            fProg.SetCurrentProgress(e.ProgressPercentage, (string)e.UserState);
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fProg.Close();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var dis = new Disasm
            {
                Archi = 0
            };
            var curAddr = addr;
            var buffy = new UnmanagedBuffer(bitsRead);
            dis.VirtualAddr = curAddr;
            dis.EIP = new IntPtr(buffy.Ptr.ToInt64());
            for (int i = 0; i < 1024; i++)//1kb read :)
            {
                byte[] tmp;
                var result = BeaEngine.Disasm(dis);
                if (result == (int)BeaConstants.SpecialInfo.UNKNOWN_OPCODE)
                {
                    result = 1;
                    tmp = new byte[result];
                    try
                    {
                        Array.Copy(bitsRead, i, tmp, 0, tmp.Length);
                    }
                    catch { }
                    WriteDis("0x" + curAddr.ToString("X8"), toHex(tmp), "??", 0);
                    curAddr += (uint)result;
                    dis.EIP = new IntPtr(dis.EIP.ToInt64() + result);

                    bw.ReportProgress(i, "Added: Unknown code...");
                }
                else
                {
                    tmp = new byte[result];
                    try
                    {
                        Array.Copy(bitsRead, i, tmp, 0, tmp.Length);
                    }
                    catch { }
                    WriteDis("0x" + curAddr.ToString("X8"), toHex(tmp), dis.CompleteInstr, (BeaConstants.BranchType)dis.Instruction.BranchType);
                    curAddr += (uint)result;
                    dis.EIP = new IntPtr(dis.EIP.ToInt64() + result);

                    bw.ReportProgress(i, "Added: " + dis.CompleteInstr);
                }

                RefreshListView();
            }
        }

        private void FrmDisassemblyView_Load(object sender, EventArgs e)
        {
            fProg = new frmProgress("Loading DisassemblyView...");
            fProg.MaxProgress(1024);
            bw.RunWorkerAsync();
            fProg.ShowDialog();
        }

        private delegate void RefreshListViewDelegate();
        private void RefreshListView()
        {
            if (this.InvokeRequired)
                this.Invoke(new RefreshListViewDelegate(RefreshListView));
            else
                listView1.Refresh();
        }

        private static string toHex(byte[] bits)
        {
            var toRet = "";
            foreach (byte bit in bits)
            {
                toRet += bit.ToString("X2");
            }
            return toRet;
        }

        private void WriteDis(string addr, string bytes1, string instruction, BeaConstants.BranchType branchType)
        {
            var item = new ListViewItem(addr);
            item.SubItems.Add(bytes1);

            switch (branchType)
            {
                case BeaConstants.BranchType.CallType:
                    item.SubItems.Add(instruction, Color.Blue, Color.LightBlue, this.Font);
                    break;
                case BeaConstants.BranchType.JA:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JB:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JC:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JE:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JECXZ:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JG:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JL:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JmpType:
                    item.SubItems.Add(instruction, Color.Blue, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JNA:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JNB:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JNC:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JNE:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JNG:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JNL:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JNO:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JNP:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JNS:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JO:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JP:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.JS:
                    item.SubItems.Add(instruction, Color.Red, Color.Yellow, this.Font);
                    break;
                case BeaConstants.BranchType.RetType:
                    item.SubItems.Add(instruction, Color.Red, Color.LightBlue, this.Font);
                    break;
                default:
                    item.SubItems.Add(instruction, Color.Black, Color.White, this.Font);
                    break;
            }
            item.UseItemStyleForSubItems = false;

            AddItemToList(item);
        }
        private delegate void AddItemToListDelegate(ListViewItem a);
        private void AddItemToList(ListViewItem myItem)
        {
            if (this.InvokeRequired)
                this.Invoke(new AddItemToListDelegate(AddItemToList), new object[] { myItem });
            else
                listView1.Items.Add(myItem);
        }

        private void frmDisassemblyView_onColorBarColorChanged(object sender, ReaperTheme.ReaperEvents.OnColorBarColorChanged e)
        {

        }

        private void reaperButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void copyAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(listView1.SelectedItems[0].SubItems[0].Text);
        }

        private void copyBytesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(listView1.SelectedItems[0].SubItems[1].Text);
        }

        private void copyDisassemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(listView1.SelectedItems[0].SubItems[2].Text);
        }
    }
}
