using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hardWareViewer
{
    public partial class frmAddComment : Form
    {
        public string comment { set; get; }

        public frmAddComment()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbComment.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо ввести комментарий!","Информирование",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            comment = tbComment.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }

        private void tbComment_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
