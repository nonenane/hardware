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
    public partial class frmAddComponents : Form
    {
        private int id = -1;
        private bool isEdit = false;

        private DataRowView row = null;

        public void setRow(DataRowView _row)
        {
            this.row = _row;
            id = int.Parse(row["id"].ToString());
            tbName.Text = row["cName"].ToString();
            tbDescription.Text = row["Description"].ToString();
            cbType.SelectedValue = row["id_TypeComponents"];

            tbAddFIO.Text = row["nameCreate"].ToString();
            tbAddDate.Text = row["DateCreate"].ToString();
            tbEditFIO.Text = row["nameEditor"].ToString();
            tbEditDate.Text = row["DateEdit"].ToString();
            btAddDoc.Visible = true;
            isEdit = false;
            //chbIsActive.Checked = bool.Parse(row["isComponent"].ToString());
        }
        public frmAddComponents()
        {
            InitializeComponent();
            get_type();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо ввести наименование!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbType.SelectedIndex == -1)
            {
                MessageBox.Show("Необходимо выбрать Тип комплектующего!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id_type = int.Parse(cbType.SelectedValue.ToString());
            DataTable dtResult = readSQL.setComponents(id,
                tbName.Text.Trim(),
                tbDescription.Text.Trim(),
                id_type,
                1,
                true
                );
            if (dtResult == null && dtResult.Rows.Count == 0 && dtResult.Rows[0]["id"].ToString().Equals("-1"))
            {
                MessageBox.Show("Не удалось сохранить данные", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (dtResult.Rows[0]["id"].ToString().Equals("-2"))
            {
                MessageBox.Show("Такое наименование присутствует в Базе!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Данные сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isEdit = false;
            this.DialogResult = DialogResult.OK;
        }

        private DataTable dtType;
        private void get_type()
        {
            dtType = readSQL.getTypeComponents();
            cbType.DataSource = dtType;
            cbType.DisplayMember = "cName";
            cbType.ValueMember = "id";
            cbType.SelectedIndex = -1;
        }

        private void btAddDoc_Click(object sender, EventArgs e)
        {
            frmAddDoc frm = new frmAddDoc();
            frm.setId_journal(id);
            frm.setTypeScan(9);
            frm.ShowDialog();
               
        }

        private void cbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            isEdit = true;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            isEdit = true;
        }

        private void frmAddComponents_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (isEdit && MessageBox.Show("Закрыть форму без сохранения?", "Инфомирование", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No);
        }
    }
}
