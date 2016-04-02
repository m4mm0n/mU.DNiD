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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNiD2.intForms
{
    using System.Diagnostics;

    using dnlib.PE;

    using DNiD2.intClasses;

    public partial class frmPEDetails : Form
    {
        private PEImage MyPEImage;
        private BackgroundWorker myBw = new BackgroundWorker();
        private delegate void MyDelegate(object a);

        public frmPEDetails(PEImage myPe)
        {
            Debug.WriteLine("[frmPEDetails]");
            MyPEImage = myPe;
            InitializeComponent();
        }

        private void frmPEDetails_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("[frmPEDetails_Load]");
            this.myBw.WorkerReportsProgress = true;
            this.myBw.DoWork += MyBwOnDoWork;
            this.myBw.RunWorkerCompleted += MyBwOnRunWorkerCompleted;
            this.myBw.RunWorkerAsync();
        }

        private void MyBwOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            Debug.WriteLine("[MyBwOnRunWorkerCompleted]");

        }

        private void MyBwOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            Debug.WriteLine("[MyBwOnDoWork]");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this.MyPEImage.ImageNTHeaders.OptionalHeader))
            {
                this.AddDetail(descriptor.Name + ": " + this.GetObj(descriptor.GetValue(this.MyPEImage.ImageNTHeaders.OptionalHeader)));
            }
        }

        private string GetObj(object a)
        {
            Debug.WriteLine("[GetObj]");
            var c = "";
            try
            {
                var b = (ImageDataDirectory[])a;
                return b.Length.ToString();
            }
            catch
            {
                if (a.ToString().isUint() != (uint)0xFFFFFFFF) c = a.ToString().isUint().ToString("X8");
            }
            return c;
        }
        private void AddDetail(object a)
        {
            Debug.WriteLine("[AddDetail]");
            if (this.InvokeRequired) this.Invoke(new MyDelegate(this.AddDetail), new object[] { a });
            else this.biList.Items.Add(a.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[button1_Click]");
            this.Close();
        }
    }
}
