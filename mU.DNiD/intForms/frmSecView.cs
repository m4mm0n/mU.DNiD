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
    public partial class frmSecView : Form
    {
        public frmSecView(dnlib.PE.PEImage myPe)
        {
            InitializeComponent();
            foreach(var a in myPe.ImageSectionHeaders)
            {
                reaperListView1.Items.Add(new ListViewItem( new[] {Encoding.ASCII.GetString(a.Name), ((uint)a.VirtualAddress).ToString("X8"), ((uint)a.VirtualSize).ToString("X8"), ((uint)myPe.ToFileOffset(a.VirtualAddress)).ToString("X8"), (a.SizeOfRawData).ToString("X8"), (a.Characteristics).ToString("X8") }));
            }
        }

        private void frmSecView_Load(object sender, EventArgs e)
        {

        }

        private void reaperButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
