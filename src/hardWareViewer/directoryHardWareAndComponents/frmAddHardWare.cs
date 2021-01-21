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
    public partial class frmAddHardWare : Form
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
            cbType.SelectedValue = row["id_TypeHardWare"];

            tbAddFIO.Text = row["nameCreate"].ToString();
            tbAddDate.Text = row["DateCreate"].ToString();
            tbEditFIO.Text = row["nameEditor"].ToString();
            tbEditDate.Text = row["DateEdit"].ToString();
            btAddDoc.Visible = true;
            cbType_SelectionChangeCommitted(null, null);
            get_data();
            isEdit = false;
            cbNotComponents.Checked = dtData.Rows.Count == 0;
            //chbIsActive.Checked = bool.Parse(row["isComponent"].ToString());
        }
        public frmAddHardWare()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            cbNotComponents_CheckedChanged(null, null);
            get_type();
            get_data();
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
                MessageBox.Show("Необходимо выбрать Тип оборудования!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!cbNotComponents.Checked && dgvData.Rows.Count == 0)
            {
                MessageBox.Show("Необходимо выбрать комплектующие!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int id_type = int.Parse(cbType.SelectedValue.ToString());
            DataTable dtResult = readSQL.setHardWare(id,
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

            id = int.Parse(dtResult.Rows[0]["id"].ToString());

            foreach (DataRow r in dtData.Rows)
            {
                readSQL.setHardwareVsComponents(r["id"], id, r["id_component"], 1);
            }

            foreach (int r in listDel)
            {
                readSQL.setHardwareVsComponents(r, id, -1, 2);
            }

            if (cbNotComponents.Checked)
            {
                foreach (DataRow r in dtData.Rows)
                {
                    readSQL.setHardwareVsComponents(r["id"], id, -1, 2);
                }
            }

            MessageBox.Show("Данные сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isEdit = false;
            this.DialogResult = DialogResult.OK;
        }

        private void cbNotComponents_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNotComponents.Checked)
            {
                gbComponents.Visible = false;
                this.Size = new Size(580, 300);
            }
            else
            {
                gbComponents.Visible = true;
                this.Size = new Size(580, 552);
            }
        }

        private void btAddComponents_Click(object sender, EventArgs e)
        {
            frmDirectoryHardWareAndComponents frm = new frmDirectoryHardWareAndComponents();
            //frm.Text = "Добавить комплектующие";
            frm.setComponentes();
            if (DialogResult.OK == frm.ShowDialog())
            {
                DataRow addRow = dtData.Rows.Add();
                addRow["id"] = -1;
                addRow["cName"] = frm.getSendName();
                addRow["id_component"] = frm.getSendId();              
                dtData.AcceptChanges();
                dgvData.Refresh();
                isEdit = true;
            }
        }

        private void btEditComponents_Click(object sender, EventArgs e)
        {
            frmAddComponents frm = new frmAddComponents();
            frm.Text = "Редактировать комплектующие";
            if (DialogResult.OK == frm.ShowDialog())
            {

            }
        }

        private void btDelComponents_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
             && dtData != null && dtData.DefaultView.Count != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Удалить запись?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                    //string cName = dtHardWare.DefaultView[dgvHardWare.CurrentRow.Index]["cName"].ToString();
                    //string description = dtHardWare.DefaultView[dgvHardWare.CurrentRow.Index]["Description"].ToString();
                    //readSQL.setHardWare(id, cName, description, 0, 2, true);
                    dgvData.Rows.RemoveAt(dgvData.CurrentRow.Index);
                    if (id != -1)
                        listDel.Add(id);
                    isEdit = true;
                    //get_data_hardware();
                }
            }
        }

        private List<Int32> listDel = new List<int>();
        private DataTable dtType;
        private void get_type()
        {
            dtType = readSQL.getTypeHardWare();
            cbType.DataSource = dtType;
            cbType.DisplayMember = "cName";
            cbType.ValueMember = "id";
            cbType.SelectedIndex = -1;
        }
       
        private void btAddDoc_Click(object sender, EventArgs e)
        {            
            frmAddDoc frm = new frmAddDoc();
            frm.setId_journal(id);
            frm.setTypeScan(7);
            frm.ShowDialog();
        }

        private void cbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow[] r = dtType.Select("id = " + cbType.SelectedValue.ToString());
            if (r.Count() > 0)
            {
                bool isComponent = bool.Parse(r[0]["isComponent"].ToString());
                cbNotComponents.Checked = !isComponent;
                cbNotComponents.Enabled = !isComponent;
            }
            else
            {
                cbNotComponents.Checked = true;
                cbNotComponents.Enabled = true;
            }
            isEdit = true;
        }

        private DataTable dtData;
        private void get_data()
        {
            dtData = readSQL.getHardwareVsComponents(id);
            dgvData.DataSource = dtData;
        }

        private void frmAddHardWare_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (isEdit && MessageBox.Show("Закрыть форму без сохранения?", "Инфомирование", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No);
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            isEdit = true;
        }
    }
}
