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
using System.ComponentModel;
using System.Windows.Forms;
using DNiD2.intClasses;

namespace DNiD2.intForms
{
    using dnlib.PE;

    public partial class frmPEDetails : Form
    {
        static Logger log = new Logger(LoggerType.Console_File, "DNiD2.frmPEDetails");

        private PEImage MyPEImage;
        private BackgroundWorker myBw = new BackgroundWorker();
        private delegate void MyDelegate(object a);

        public frmPEDetails(PEImage myPe)
        {
            //Debug.WriteLine("[frmPEDetails]");
            log.Log(LogType.Normal, "frmPEDetails");
            MyPEImage = myPe;
            InitializeComponent();
        }

        private void frmPEDetails_Load(object sender, EventArgs e)
        {
            //Debug.WriteLine("[frmPEDetails_Load]");
            log.Log(LogType.Normal, "frmPEDetails_Load");
            this.myBw.WorkerReportsProgress = true;
            this.myBw.DoWork += MyBwOnDoWork;
            this.myBw.RunWorkerCompleted += MyBwOnRunWorkerCompleted;
            this.myBw.RunWorkerAsync();
        }

        private void MyBwOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            //Debug.WriteLine("[MyBwOnRunWorkerCompleted]");
            log.Log(LogType.Normal, "MyBwOnRunWorkerCompleted");
        }

        private void MyBwOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            //Debug.WriteLine("[MyBwOnDoWork]");
            log.Log(LogType.Normal, "MyBwOnDoWork");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this.MyPEImage.ImageNTHeaders.OptionalHeader))
            {
                this.AddDetail(descriptor.Name + ": " + this.GetObj(descriptor.GetValue(this.MyPEImage.ImageNTHeaders.OptionalHeader)));
            }
        }

        private string GetObj(object a)
        {
            //Debug.WriteLine("[GetObj]");
            log.Log(LogType.Normal, "GetObj");
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
            //Debug.WriteLine("[AddDetail]");
            log.Log(LogType.Normal, "AddDetail");
            if (this.InvokeRequired) this.Invoke(new MyDelegate(this.AddDetail), new object[] { a });
            else this.biList.Items.Add(a.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("[button1_Click]");
            log.Log(LogType.Normal, "button1_Click");
            this.Close();
        }
    }
}
