﻿/*
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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNiD2.intForms
{
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;

    public partial class frmSecView : Form
    {
        private string myPeFileName;
        public frmSecView(dnlib.PE.PEImage myPe, string peFileName)
        {
            Debug.WriteLine("[frmSecView]");
            this.InitializeComponent();
            this.myPeFileName = peFileName;
            foreach (var a in myPe.ImageSectionHeaders)
            {
                this.reaperListView1.Items.Add(new ListViewItem( new[] {Encoding.ASCII.GetString(a.Name), ((uint)a.VirtualAddress).ToString("X8"), ((uint)a.VirtualSize).ToString("X8"), ((uint)myPe.ToFileOffset(a.VirtualAddress)).ToString("X8"), (a.SizeOfRawData).ToString("X8"), (a.Characteristics).ToString("X8") }));
            }
        }

        private void frmSecView_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("[frmSecView_Load]");
        }

        private void reaperButton1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[reaperButton1_Click]");
            this.Close();
        }

        private void dissassembleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[dissassembleToolStripMenuItem_Click]");
            if (this.reaperListView1.SelectedIndices[0] > -1)
            {
                var fileBytes = File.ReadAllBytes(this.myPeFileName);
                var rFileBytes = new byte[int.Parse(this.reaperListView1.SelectedItems[0].SubItems[4].Text, NumberStyles.HexNumber)];
                Array.Copy(fileBytes, int.Parse(this.reaperListView1.SelectedItems[0].SubItems[3].Text, NumberStyles.HexNumber), rFileBytes, 0, rFileBytes.Length);

                using (var a = new frmDisassemblyView(uint.Parse(this.reaperListView1.SelectedItems[0].SubItems[1].Text, NumberStyles.HexNumber), rFileBytes))
                {
                    a.ShowDialog();
                }
            }
        }

        private void hexViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[hexViewToolStripMenuItem_Click]");
            if (this.reaperListView1.SelectedIndices[0] > -1)
            {
                var fileBytes = File.ReadAllBytes(this.myPeFileName);
                var rFileBytes = new byte[int.Parse(this.reaperListView1.SelectedItems[0].SubItems[4].Text, NumberStyles.HexNumber)];
                Array.Copy(fileBytes, int.Parse(this.reaperListView1.SelectedItems[0].SubItems[3].Text, NumberStyles.HexNumber), rFileBytes, 0, rFileBytes.Length);

                using (var a = new frmHexView(uint.Parse(this.reaperListView1.SelectedItems[0].SubItems[1].Text, NumberStyles.HexNumber), rFileBytes))
                {
                    a.ShowDialog();
                }
            }
        }
    }
}
