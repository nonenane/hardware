using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hardWareViewer.listHardware
{
    public partial class frmDeleteComment : Form
    {
        public string Comment { get; set; }
        public frmDeleteComment()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Comment = tbComment.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
