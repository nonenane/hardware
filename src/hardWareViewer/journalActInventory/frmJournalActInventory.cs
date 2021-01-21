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
    public partial class frmJournalActInventory : Form
    {
        public frmJournalActInventory()
        {
            InitializeComponent();
            btCloseAct.Visible = config.statusCode.Equals("кнт");
            init_combobox();
            get_dateInventory();          
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        
        #region "Дата инвентаризации"

        private DataTable dtDateInventory;

        private void get_dateInventory()
        {
            dtDateInventory = readSQL.getDateInventory();
            dgvDateInventory.AutoGenerateColumns = false;
            dgvDateInventory.DataSource = dtDateInventory;
            if (dtDateInventory != null && dtDateInventory.Rows.Count != 0)
                btAdd.Enabled = true;
        }

        private void btAddDate_Click(object sender, EventArgs e)
        {
            frmAddDateInventory frm = new frmAddDateInventory();
            if (DialogResult.OK == frm.ShowDialog())
                get_dateInventory();
        }

        private void btDelDate_Click(object sender, EventArgs e)
        {
            if (dgvDateInventory.CurrentRow != null && dgvDateInventory.CurrentRow.Index != -1
               && dtDateInventory != null && dtDateInventory.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Удалить запись?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    int id = int.Parse(dtDateInventory.DefaultView[dgvDateInventory.CurrentRow.Index]["id"].ToString());
                    DateTime date = DateTime.Parse(dtDateInventory.DefaultView[dgvDateInventory.CurrentRow.Index]["Date"].ToString());
                    readSQL.setDayInventory(id, date, 2);
                    dgvDateInventory.Rows.RemoveAt(dgvDateInventory.CurrentRow.Index);
                    get_dateInventory();
                }
            }
        }

        private void dgvDateInventory_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvDateInventory.CurrentRow != null && dgvDateInventory.CurrentRow.Index != -1
                && dtDateInventory != null && dtDateInventory.DefaultView.Count != 0)
            {
                //textBox1.Text = dtDateInventory.DefaultView[dgvDateInventory.CurrentRow.Index]["id"].ToString();
                selectIdDateInventory = int.Parse(dtDateInventory.DefaultView[dgvDateInventory.CurrentRow.Index]["id"].ToString());
                selectDateInventory = DateTime.Parse(dtDateInventory.DefaultView[dgvDateInventory.CurrentRow.Index]["Date"].ToString());
                get_data();
            }
            else
            {
                //dgvData.DataSource = null;
                selectIdDateInventory = -1;                
                get_data();
                //textBox1.Text = "";
            }
        }

        #endregion

        private DataTable dtData;
        private int selectIdDateInventory = -1;
        private DateTime selectDateInventory;
        private void get_data()
        {
            dgvData.AutoGenerateColumns = false;
            dtData = readSQL.getActInventory(selectIdDateInventory);
            filter();
            dgvData.DataSource = dtData;
        }

        private void filter()
        {
            try
            {
                string filter = "";

                filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Convert(Number,System.String) like '%{0}%'",tbNumber.Text.Trim());
                filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Comment like '%{0}%'", tbComment.Text.Trim());

                if (cbStatus.SelectedIndex != 0)
                    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Status = {0}", cbStatus.SelectedValue);


                //if (cbLocation.SelectedIndex != 0)
                //    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Status = {0}", cbLocation.SelectedValue);
                
                //if (cbResponsibles.SelectedIndex != 0)
                //    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Status = {0}", cbResponsibles.SelectedValue);

                dtData.DefaultView.RowFilter = filter;
                
            }
            catch {
                dtData.DefaultView.RowFilter = "id = -9999";
            }

            btAddDoc.Enabled = btDel.Enabled = btEdit.Enabled = dtData.DefaultView.Count != 0;
        }

        private void init_combobox()
        {
            DataColumn col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;

            DataTable dtLocation = readSQL.getLocation();
            dtLocation.Columns.Add(col);
            dtLocation.Rows.Add(-1, "Все", true, 0);
            dtLocation.DefaultView.Sort = "main asc";
            cbLocation.DataSource = dtLocation;
            cbLocation.DisplayMember = "cName";
            cbLocation.ValueMember = "id";
            

            DataTable dtResponsibles = readSQL.getListResponsibles(1);
            col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;
            dtResponsibles.Columns.Add(col);
            dtResponsibles.Rows.Add(-1,-1, "Все", true,true, 0);
            dtResponsibles.DefaultView.RowFilter = "isActive = 1";
            dtResponsibles.DefaultView.Sort = "main asc";           
            cbResponsibles.DataSource = dtResponsibles;
            cbResponsibles.DisplayMember = "FIO";
            cbResponsibles.ValueMember = "id";

            DataTable dtStatus = readSQL.getStatus("actStatus");
            col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;
            dtStatus.Columns.Add(col);
            dtStatus.Rows.Add(-1, "Все",  0);
            dtStatus.DefaultView.Sort = "main asc";
            cbStatus.DataSource = dtStatus;
            cbStatus.DisplayMember = "cName";
            cbStatus.ValueMember = "id";
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAddActInventory frm = new frmAddActInventory();
            frm.Text = "Создать акт инвентаризации";
            frm.setDateInventory(selectDateInventory);
            frm.setIdDateInventory(selectIdDateInventory);
            frm.ShowDialog();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
                && dtData != null && dtData.DefaultView.Count != 0)
            {
                frmAddActInventory frm = new frmAddActInventory();
                frm.Text = "Редактировать акт инвентаризации";
                frm.setDateInventory(selectDateInventory);
                frm.setIdDateInventory(selectIdDateInventory);
                frm.setRow(dtData.DefaultView[dgvData.CurrentRow.Index]);
                frm.ShowDialog();
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
                && dtData != null && dtData.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Удалить запись?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                    DataTable dtResult = readSQL.setActInventory(id,
                         selectIdDateInventory,
                         0,
                        DateTime.Now,
                         tbComment.Text.Trim(),
                         1,
                         2
                         );
                    if (dtResult == null && dtResult.Rows.Count == 0 && dtResult.Rows[0]["id"].ToString().Equals("-1"))
                    {
                        MessageBox.Show("Не удалось сохранить данные", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    dgvData.Rows.RemoveAt(dgvData.CurrentRow.Index);
                    get_data();
                }
            }
        }

        private void btAddDoc_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                frmAddDoc frm = new frmAddDoc();
                frm.setId_journal(id);
                frm.setTypeScan(4);
                if (DialogResult.OK == frm.ShowDialog())
                    get_data();
            }
        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void cbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
        }

        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvData.CurrentRow != null && e.RowIndex != -1
                && dtData != null && dtData.DefaultView.Count != 0)
            {
                frmAddActInventory frm = new frmAddActInventory();
                frm.Text = "Просмотр акта инвентаризации";
                frm.setDateInventory(selectDateInventory);
                frm.setIdDateInventory(selectIdDateInventory);
                frm.setRow(dtData.DefaultView[dgvData.CurrentRow.Index]);
                frm.isV();
                frm.ShowDialog();
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

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
           

            if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                Color rColor = Color.White;

                if ((Int32)dtData.DefaultView[e.RowIndex]["Status"] == 0)
                    rColor = pNotAll.BackColor;

                dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
            }
        }

        private void btCloseAct_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
                  && dtData != null && dtData.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Закрыть АКТ?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                    DataTable dtResult = readSQL.setActInventory(id,
                         selectIdDateInventory,
                         0,
                        DateTime.Now,
                         tbComment.Text.Trim(),
                         1,
                         1
                         );
                    if (dtResult == null && dtResult.Rows.Count == 0 && dtResult.Rows[0]["id"].ToString().Equals("-1"))
                    {
                        MessageBox.Show("Не удалось сохранить данные", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    get_data();
                }
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpStart.Value >= dtpEnd.Value)
                {
                    dtpEnd.Value = dtpStart.Value;
                }
            }
            catch { };
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpStart.Value >= dtpEnd.Value)
                {
                    dtpStart.Value = dtpEnd.Value;
                }
            }
            catch { };
        }

        
    }
}
