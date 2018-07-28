/*
    DNiD 2 - PE Identifier.
    Copyright (C) 2018  mammon

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
using System.ComponentModel;
using System.Windows.Forms;

namespace DNiD2.intForms
{
    public partial class frmHexView : Form
    {
        static Logger log = new Logger(LoggerType.Console_File, "DNiD2.frmHexView");

        private uint addr = 0;
        private byte[] bitsRead;

        private BackgroundWorker bw = new BackgroundWorker();
        private frmProgress fProg;

        public frmHexView(uint addressToDisassemble, byte[] bytesToRead)
        {
            //Debug.WriteLine("[frmHexView]");
            log.Log(LogType.Normal, "frmHexView");
            this.addr = addressToDisassemble;
            this.bitsRead = bytesToRead;

            this.InitializeComponent();

            this.bw.ProgressChanged += this.Bw_ProgressChanged;
            this.bw.RunWorkerCompleted += this.Bw_RunWorkerCompleted;
            this.bw.DoWork += this.Bw_DoWork;
            this.bw.WorkerReportsProgress = true;
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //Debug.WriteLine("[Bw_DoWork]");
            log.Log(LogType.Normal, "Bw_DoWork");
            this.hexBox1.ByteProvider = new Be.Windows.Forms.DynamicByteProvider(this.bitsRead);
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Debug.WriteLine("[Bw_RunWorkerCompleted]");
            log.Log(LogType.Normal, "Bw_RunWorkerCompleted");
            this.fProg.Close();
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Debug.WriteLine("[Bw_ProgressChanged]");
            log.Log(LogType.Normal, "Bw_ProgressChanged");
            this.fProg.SetCurrentProgress(e.ProgressPercentage, (string)e.UserState);
        }

        private void frmHexView_Load(object sender, EventArgs e)
        {
            //Debug.WriteLine("[frmHexView_Load]");
            log.Log(LogType.Normal, "frmHexView_Load");
            this.fProg = new frmProgress("Loading HewView...");
            this.fProg.MaxProgress(64);
            this.bw.RunWorkerAsync();
            this.fProg.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("[button1_Click]");
            log.Log(LogType.Normal, "button1_Click");
            this.Close();
        }
    }
}
