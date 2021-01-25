using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hardWareViewer.listHardware
{
    public partial class frmListPreFilter : Form
    {
        public List<string> listFiler { private set; get; }
        public frmListPreFilter()
        {
            InitializeComponent();
            listFiler = new List<string>();
        }

        private void frmListPreFilter_Load(object sender, EventArgs e)
        {

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            foreach (Control cnt in this.Controls)
            {
                if (!cnt.Visible) continue;

                if (cnt is CheckBox)
                {
                    if ((cnt as CheckBox).Checked)
                        listFiler.Add(cnt.Text);
                }

                if (cnt is GroupBox)
                {
                    foreach (Control cnt1 in cnt.Controls)
                    {
                        if (cnt1 is CheckBox)
                        {
                            if ((cnt1 as CheckBox).Checked)
                                listFiler.Add(cnt1.Text);
                        }
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
        }


    }
}
