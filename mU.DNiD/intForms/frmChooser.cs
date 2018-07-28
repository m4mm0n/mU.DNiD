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

    public partial class frmChooser : Form
    {
        private uint addr = 0;
        private byte[] bitsRead;
        private bool Is64;
        static Logger log = new Logger(LoggerType.Console_File, "DNiD2.frmChooser");

        public frmChooser(uint addressToDisassemble, byte[] bytesToRead, bool is64 = false)
        {
            //Debug.WriteLine("[frmChooser]");
            log.Log(LogType.Normal, "frmChooser");
            this.Is64 = is64;
            this.addr = addressToDisassemble;
            this.bitsRead = bytesToRead;

            this.InitializeComponent();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("[button1_Click]");
            log.Log(LogType.Normal, "button1_Click");
            if (this.radioButton1.Checked)
            {
                using (var frm = new frmDisassemblyView(this.addr, this.bitsRead, this.Is64))
                {
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
            }
            if (this.radioButton2.Checked)
            {
                using(var frm = new frmHexView(this.addr, this.bitsRead))
                {
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
