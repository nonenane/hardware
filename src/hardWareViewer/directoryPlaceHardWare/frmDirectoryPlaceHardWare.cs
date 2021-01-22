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
    public partial class frmDirectoryPlaceHardWare : Form
    {
        public frmDirectoryPlaceHardWare()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;        
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAddPlaceHardWare frm = new frmAddPlaceHardWare();
            frm.Text = "Добавить местоположение";
            if (DialogResult.OK == frm.ShowDialog())
            {
                get_data();
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                frmAddPlaceHardWare frm = new frmAddPlaceHardWare();
                frm.Text = "Редактировать местоположение";
                frm.setRow(dtData.DefaultView[dgvData.CurrentRow.Index]);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    get_data();
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Удалить запись?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                    string cName = dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString();
                    bool isActiveStatus = bool.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"].ToString());
                    int id_object = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id_object"];
                    DataTable dtResult = readSQL.setLocation(id, cName, id_object, 2, true);

                    if (dtResult != null && dtResult.Rows.Count != 0)
                        if (dtResult.Rows[0]["id"].ToString().Equals("-1"))
                        { MessageBox.Show("Не удалось удалить данные!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        else if (dtResult.Rows[0]["id"].ToString().Equals("-3"))
                        { MessageBox.Show("Запись переведена в " + (isActiveStatus ? "Недействующие" : "Активные") + "!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        else
                        { MessageBox.Show("Запись удалена!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    get_data();
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private DataTable dtData;
        private void get_data()
        {
            dtData = readSQL.getLocation();
            filter();
            dgvData.DataSource = dtData;
        }

        private void filter()
        {
            try {
                string str = "";

                str += string.Format("cName like '%{0}%'", tbName.Text.Trim());

                if ((int)cmbObject.SelectedValue != 0)
                    str += (str.Length != 0 ? " and" : "") + $"id_object = {cmbObject.SelectedValue}";

                if (!chbIsActive.Checked)
                    str += " AND isActive = 1";

                dtData.DefaultView.RowFilter = str;
                btDelete.Enabled = btEdit.Enabled = dtData.DefaultView.Count != 0;
            }
            catch {
                dtData.DefaultView.RowFilter = "id = -9999";
                btDelete.Enabled = btEdit.Enabled = dtData.DefaultView.Count != 0;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtData!=null && dtData.DefaultView.Count!=0)
            {
                Color rColor = Color.White;

                if (!(bool)dtData.DefaultView[e.RowIndex]["isActive"])
                    rColor = pIsActive.BackColor;

                dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                    dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
            }
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            //Рисуем рамку для выделеной строки
            if (dgv.Rows[e.RowIndex].Selected)
            {
                int width = dgv.Width;
                Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
                Rectangle rect = new Rectangle(r.X, r.Y, width - 1, r.Height - 1);

                ControlPaint.DrawBorder(e.Graphics, rect,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
            }
        }

        private void chbIsActive_CheckedChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void frmDirectoryPlaceHardWare_Load(object sender, EventArgs e)
        {
            DataTable dtObject = readSQL.getObject(true);
            cmbObject.DataSource = dtObject;
            cmbObject.DisplayMember = "cName";
            cmbObject.ValueMember = "id";

            get_data();
        }

        private void cmbObject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
        }
    }
}
