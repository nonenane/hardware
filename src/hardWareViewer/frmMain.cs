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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.Text = "\"" + Nwuram.Framework.Settings.Connection.ConnectionSettings.ProgramName + "\", \"" + Nwuram.Framework.Settings.User.UserSettings.User.Status + "\", " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername + "";
        }

        private void tsmiDirectoryResponsible_Click(object sender, EventArgs e)
        {
            frmDirectoryResponsible frm = new frmDirectoryResponsible();
            frm.ShowDialog();
        }

        private void tsmiDirectoryPlaceHardWare_Click(object sender, EventArgs e)
        {
            frmDirectoryPlaceHardWare frm = new frmDirectoryPlaceHardWare();
            frm.ShowDialog();
        }

        private void tsmiDirectoryTypeHardWare_Click(object sender, EventArgs e)
        {
            frmDirectoryTypeHardWare frm = new frmDirectoryTypeHardWare();
            frm.ShowDialog();
        }

        private void tsmDirectoryTypeComponents_Click(object sender, EventArgs e)
        {
            frmDirectoryTypeComponents frm = new frmDirectoryTypeComponents();
            frm.ShowDialog();
        }

        private void tsmiDirectoryHardWareAndComponents_Click(object sender, EventArgs e)
        {
            frmDirectoryHardWareAndComponents frm = new frmDirectoryHardWareAndComponents();
            frm.setDirectory();
            frm.ShowDialog();
        }

        private void tsmiJournalEstimates_Click(object sender, EventArgs e)
        {
            frmJournalEstimates frm = new frmJournalEstimates();
            frm.ShowDialog();
        }

        private void tsmiJournalActInventory_Click(object sender, EventArgs e)
        {
            frmJournalActInventory frm = new frmJournalActInventory();
            frm.ShowDialog();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiJournalActWriteOff_Click(object sender, EventArgs e)
        {
            frmJournalActWriteOff frm = new frmJournalActWriteOff();
            frm.Text = tsmiJournalActWriteOff.Text;
            frm.ShowDialog();
        }

        private void tsmiListHardware_Click(object sender, EventArgs e)
        {
            frmListHardware frm = new frmListHardware();            
            frm.ShowDialog();
        }

        private void tsmiJournalActReceivingTransfer_Click(object sender, EventArgs e)
        {
            frmJournalActReceivingTransfer frm = new frmJournalActReceivingTransfer();
            frm.ShowDialog();

        }

        private void tsmiDirectoryObject_Click(object sender, EventArgs e)
        {
            frmDirectoryObject frm = new frmDirectoryObject();
            frm.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("Закрыть программу?","Выход",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tsmiContolScaner.Visible = config.statusCode.Equals("оп") || config.statusCode.Equals("кнт");
        }

        private void tsmiContolScaner_Click(object sender, EventArgs e)
        {
            new scaners.frmContScaner().ShowDialog();
        }
    }
}
