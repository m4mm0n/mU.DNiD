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

using System;
using System.Windows.Forms;
using DNiD2.intClasses;

namespace DNiD2.intForms
{
    using System.Diagnostics;

    public partial class frmProgress : Form
    {
        static Logger log = new Logger(LoggerType.Console_File, "DNiD2.frmProgress");

        private delegate void MaxProgressDelegate(int a);
        public void MaxProgress(int a)
        {
            //Debug.WriteLine("[MaxProgress]");
            log.Log(LogType.Normal, "MaxProgress");
            if (this.InvokeRequired) this.Invoke(new MaxProgressDelegate(this.MaxProgress), new object[] { a });
            else
                this.pBar1.Maximum = a;

        }
        public void SetCurrentProgress(int Percent, string Operation)
        {
            //Debug.WriteLine("[SetCurrentProgress]");
            log.Log(LogType.Normal, "SetCurrentProgress");
            this.pBar1.Value = Percent;
            this.szProgress.Text = Operation;
        }
        public frmProgress(string OperationText)
        {
            //Debug.WriteLine("[frmProgress]");
            log.Log(LogType.Normal, "frmProgress");
            this.InitializeComponent();

            this.Text = OperationText;
        }

        private void frmProgress_Load(object sender, EventArgs e)
        {
            //Debug.WriteLine("[frmProgress_Load]");
            log.Log(LogType.Normal, "frmProgress_Load");
        }
    }
}
