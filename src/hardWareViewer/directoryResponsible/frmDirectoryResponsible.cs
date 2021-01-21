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
    public partial class frmDirectoryResponsible : Form
    {
        public frmDirectoryResponsible()
        {
            InitializeComponent();
            dgvMOP.AutoGenerateColumns = false;
            dgvPersonal.AutoGenerateColumns = false;
            get_data();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;            
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            foreach (DataRow r in dtMOP.Rows)
            {
                int id = int.Parse(r["id"].ToString());
                int id_kadr = int.Parse(r["id_kadr"].ToString());
                bool isActive = bool.Parse(r["isVisible"].ToString());
                int type = bool.Parse(r["isVisible"].ToString()) ? 1 : 2;

                readSQL.setListResponsibles(id, id_kadr, type, isActive);

            }
            MessageBox.Show("Данные сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private DataTable dtMOP, dtPersonal;
        private void get_data()
        {
            dtMOP = readSQL.getListResponsibles(1);
            dtPersonal = readSQL.getListResponsibles(2);

            dgvMOP.DataSource = dtMOP;
            dgvPersonal.DataSource = dtPersonal;
            filter_mop();
            filter_personal();
            enable_buttons();

        }

        private void btUnder_Click(object sender, EventArgs e)
        {
            int id_kadr = (int)dtMOP.DefaultView[dgvMOP.CurrentRow.Index]["id_kadr"];

            DataRow[] rowPersonal = dtPersonal.Select(string.Format("id_kadr = {0}", id_kadr));
            if (rowPersonal.Count() > 0)
            {
                rowPersonal[0]["isVisible"] = true;
                dtMOP.DefaultView[dgvMOP.CurrentRow.Index]["isVisible"] = false;
            }
            else
            {
                dtMOP.DefaultView[dgvMOP.CurrentRow.Index]["isVisible"] = false;
            }

            dtMOP.AcceptChanges();
            dgvMOP.Update();
            dtPersonal.AcceptChanges();
            dgvPersonal.Update();

            enable_buttons();
        }

        private void btIn_Click(object sender, EventArgs e)
        {
            int id_kadr = (int)dtPersonal.DefaultView[dgvPersonal.CurrentRow.Index]["id_kadr"];

            DataRow[] rowMOP = dtMOP.Select(string.Format("id_kadr = {0}", id_kadr));
            if (rowMOP.Count() > 0)
            {
                rowMOP[0]["isVisible"] = true;
                dtPersonal.DefaultView[dgvPersonal.CurrentRow.Index]["isVisible"] = false;
            }
            else
            {
                dtMOP.ImportRow(dtPersonal.DefaultView.ToTable().Rows[dgvPersonal.CurrentRow.Index]);
                dtPersonal.DefaultView[dgvPersonal.CurrentRow.Index]["isVisible"] = false;
            }


            dtPersonal.AcceptChanges();
            dgvPersonal.Update();

            enable_buttons();
        }

        private void enable_buttons()
        {
            btUnder.Enabled = dtMOP.DefaultView.Count != 0;
            btIn.Enabled = dtPersonal.DefaultView.Count != 0;
        }

        #region "MOP"
        private void tbNameMOP_TextChanged(object sender, EventArgs e)
        {
            filter_mop();
        }

        private void filter_mop()
        {
            try
            {
                string str = "";
                str = string.Format("FIO like '%{0}%'", tbNameMOP.Text.Trim());
                str += " AND isVisible = 1";
                if (!chbIsActiveHardWare.Checked)
                    str += " AND isActive = 1";
                dtMOP.DefaultView.RowFilter = str;
            }
            catch
            {
                dtMOP.DefaultView.RowFilter = "id = -9999";
            }
            enable_buttons();
        }

        private void chbIsActiveHardWare_CheckedChanged(object sender, EventArgs e)
        {
            filter_mop();
        }

        private void dgvMOP_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtMOP != null && dtMOP.DefaultView.Count != 0)
            {
                Color rColor = Color.White;

                if (!(bool)dtMOP.DefaultView[e.RowIndex]["isActive"])
                    rColor = pIsActive.BackColor;

                dgvMOP.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvMOP.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
            }
        }

        private void dgvMOP_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        #endregion

        #region "Personal"
        private void tbNamePersonal_TextChanged(object sender, EventArgs e)
        {
            filter_personal();
        }

        private void filter_personal()
        {
            try
            {
                string str = "";
                str = string.Format("FIO like '%{0}%'", tbNamePersonal.Text.Trim());
                str += " AND isVisible = 1";
                dtPersonal.DefaultView.RowFilter = str;
            }
            catch
            {
                dtPersonal.DefaultView.RowFilter = "id = -9999";
            }
            enable_buttons();
        }

        #endregion

    }
}
