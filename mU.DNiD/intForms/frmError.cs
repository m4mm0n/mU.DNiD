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
    public partial class frmError : ReaperTheme.ReaperForm
    {
        static Logger log = new Logger(LoggerType.Console_File, "DNiD2.frmError");

        public frmError(string error)
        {
            //Debug.WriteLine("[frmError]");
            log.Log(LogType.Normal, "frmError");
            this.InitializeComponent();
            this.reaperTextbox1.Text = error;
        }

        private void frmError_Load(object sender, EventArgs e)
        {
            //Debug.WriteLine("[frmError_Load]");
            log.Log(LogType.Normal, "frmError_Load");
        }

        private void reaperButton1_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("[reaperButton1_Click]");
            log.Log(LogType.Normal, "reaperButton1_Click");
            this.Close();
        }

        private void reaperButton2_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("[reaperButton2_Click]");
            log.Log(LogType.Normal, "reaperButton2_Click");
            Clipboard.Clear();
            Clipboard.SetText(this.reaperTextbox1.Text);
        }
    }
}
