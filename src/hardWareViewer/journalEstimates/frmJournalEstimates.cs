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
    /// <summary>Код формы журнала смет.</summary>
    public partial class frmJournalEstimates : Form
    {
        public frmJournalEstimates()
        {
            InitializeComponent();
            dtpStart.Value = dtpStart.Value.AddDays(-7);
            dgvData.AutoGenerateColumns = false;
            view_element();
            get_status(); 
            get_data();

            DataTable dtExp = readSQL.getExpBalance();
            foreach (DataRow item in dtExp.Rows)
            {
                int id = Convert.ToInt32(item["id"]);
                MessageBox.Show("Превышено ожидание\nпостановки на баланс\nоборудование из сметы №" + id, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DataTable dtData;
        private void get_data()
        {
            
            dtData = readSQL.getEstimate(dtpStart.Value,dtpEnd.Value);
            filter();
            dgvData.DataSource = dtData;
        }
        
        private void get_status()
        {
            DataTable dtStatus = readSQL.getStatus("estimate");

            DataColumn col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;
            dtStatus.Columns.Add(col);
            dtStatus.Rows.Add(-1, "Все", 0);
            dtStatus.DefaultView.Sort = "main asc";

            cbStatus.DataSource = dtStatus;
            cbStatus.DisplayMember = "cName";
            cbStatus.ValueMember = "id";
        }

        private void filter()
        {
            try
            {
                string filter = "";

                filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Convert(id, System.String) like '%{0}%'", tbNumber.Text.Trim());
                filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("EstimateName like '%{0}%'", tbName.Text.Trim());
                filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("objectName like '%{0}%'", tbObject.Text.Trim());

                if (cbStatus.SelectedIndex != 0)
                    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Status = {0}", cbStatus.SelectedValue);


                //if (cbLocation.SelectedIndex != 0)
                //    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Status = {0}", cbLocation.SelectedValue);

                //if (cbResponsibles.SelectedIndex != 0)
                //    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Status = {0}", cbResponsibles.SelectedValue);

                dtData.DefaultView.RowFilter = filter;

            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -9999";
            }

            btAddDoc.Enabled = btDel.Enabled = btEdit.Enabled = dtData.DefaultView.Count != 0;
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAddEstimates frm = new frmAddEstimates();
            frm.setCreate();
            frm.Text = "Добавить содержимое сметы";
            if (DialogResult.OK == frm.ShowDialog())
                get_data();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                frmAddEstimates frm = new frmAddEstimates();
                frm.Text = "Редактировать содержимое сметы";
                frm.setRow(dtData.DefaultView[dgvData.CurrentRow.Index]);
                if (DialogResult.OK == frm.ShowDialog())                
                    get_data();
                
            }
        }
    
        private void view_element()
        {
            switch(config.statusCode)
            {
                case "оп":
                    btAdd.Visible=btEdit.Visible=btDel.Visible=true;

                    btPrintMemo.Visible = btPrintMemo.Enabled = true;
                    btPrintEstimate.Visible = btPrintEstimate.Enabled = true;
                    btBalance.Visible = btBalance.Enabled = true;
                    break;
                case "кнт":
                    btAdd.Visible=btEdit.Visible=btDel.Visible=false;
                    btEdit.Visible = true;

                    btPrintMemo.Visible = btPrintMemo.Enabled = true;
                    btPrintEstimate.Visible = btPrintEstimate.Enabled = true;
                    btBalance.Visible = btBalance.Enabled = true;
                    break;
                case "адм":
                    btAdd.Visible=btEdit.Visible=btDel.Visible=false;
                    btEdit.Visible = true;

                    btPrintMemo.Visible = btPrintMemo.Enabled = true;
                    btPrintEstimate.Visible = btPrintEstimate.Enabled = true;
                    btBalance.Visible = btBalance.Enabled = false;
                    break;
                default:
                    btAdd.Visible=btEdit.Visible=btDel.Visible=false;
                    btEdit.Visible = true;
                    break;
            }
        }

        private void btAddDoc_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                frmAddDoc frm = new frmAddDoc();
                frm.setId_journal(id);
                frm.setTypeScan(1);
                if (DialogResult.OK == frm.ShowDialog())
                    get_data();
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            get_data();
        }
        DataTable dtTableStatus;
        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            int statusEstimate = -1;
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                statusEstimate = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["Status"].ToString());
            }
            dtTableStatus = readSQL.getTableStatusEstimat(statusEstimate,1);
            if (dtTableStatus != null && dtTableStatus.Rows.Count > 0)
            {
                btDown.Enabled = dtTableStatus.Rows[0]["undoStatus"] != DBNull.Value;
                btNextStatus.Enabled = dtTableStatus.Rows[0]["nextStatus"] != DBNull.Value;
            }
            else
            {
                btDown.Enabled = btNextStatus.Enabled = false;
            }

            btDel.Enabled = btEdit.Enabled = (config.statusCode.Equals("оп") && (statusEstimate == 0 || statusEstimate == 5));
            
            if (config.statusCode.Equals("оп"))
                btEdit.Enabled = (config.statusCode.Equals("оп") && (statusEstimate == 3 || statusEstimate == 0 || statusEstimate == 5));

            if (config.statusCode.Equals("кнт"))
                btEdit.Enabled = (config.statusCode.Equals("кнт") && statusEstimate == 3);

            if (config.statusCode.Equals("адм"))
                btEdit.Enabled = (config.statusCode.Equals("адм") && statusEstimate == 3);

            try
            {
                if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
                {
                    tbControl.Text = dtData.DefaultView[dgvData.CurrentRow.Index]["fioControl"].ToString();
                    tbSecre.Text = dtData.DefaultView[dgvData.CurrentRow.Index]["fioSecret"].ToString();
                    tbComment.Text = dtData.DefaultView[dgvData.CurrentRow.Index]["Comment"].ToString();
                }
            }
            catch
            {
                tbControl.Text = "";
                tbSecre.Text = "";
                tbComment.Text = "";
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    
        private bool isGetData=false;
        private DataTable dtSend;
        public void getEstimate()
        {
            this.Text = "Выбор сметы для добавления оборудования в акт приема-передачи МОЛ";
            foreach (Control cnt in this.Controls)
                if (cnt is Button)
                {
                    cnt.Visible = cnt.Name.Equals(btClose.Name);
                }
            isGetData = true;
        }

        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                if (isGetData)
                {
                    frmAddEstimates frm = new frmAddEstimates();
                    frm.Text = "Выбор оборудования в акт приема-передачи МОЛ";
                    frm.setRow(dtData.DefaultView[e.RowIndex]);
                    frm.getEstimate();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        dtSend = frm.getDataTable().Copy();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    frmAddEstimates frm = new frmAddEstimates();
                    frm.Text = "Просмотр оборудования в смете";
                    frm.setRow(dtData.DefaultView[e.RowIndex]);
                    frm.setView();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                    }
                }
            }
        }

        public DataTable getDataTable()
        {
            return dtSend;
        }

        private void btNextStatus_Click(object sender, EventArgs e)
        {
            if (config.statusCode.Equals("кнт") && !Convert.ToBoolean(dtData.DefaultView[dgvData.CurrentRow.Index]["isScan"].ToString()) && Convert.ToDecimal(dtData.DefaultView[dgvData.CurrentRow.Index]["sumEstimate"].ToString()) != 0)
            {
                MessageBox.Show("Для потверждения сметы\nтребуется прикрепить скан\nслужебной записки на деньги", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string comment;
            try
            {
                comment = dtData.DefaultView[dgvData.CurrentRow.Index]["Comment"].ToString();
            }
            catch
            {
                comment = "";
            }

            int statusEstimate = -1;
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                statusEstimate = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["Status"].ToString());
            }
            dtTableStatus = readSQL.getTableStatusEstimat(statusEstimate, 1);
            if (dtTableStatus != null && dtTableStatus.Rows.Count > 0 && dtTableStatus.Rows[0]["nextStatus"] != DBNull.Value)
            {
                int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                statusEstimate = int.Parse(dtTableStatus.Rows[0]["nextStatus"].ToString());
                string test= dtTableStatus.Rows[0]["nextStatus"].ToString();
                readSQL.changeStatusEstimate(id, statusEstimate,"");
                // Добавление комментария оператором
                if (config.statusCode.Equals("оп"))
                {
                    frmAddComment frmCom = new frmAddComment();
                    if (frmCom.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    comment += DateTime.Now + " Оператор : " + frmCom.comment;
                }

                if (statusEstimate == 2)
                    readSQL.deleteChangeEstimateCheck(id);

                readSQL.changeStatusEstimate(id, statusEstimate, comment);
                get_data();
            }
        }

        private void btAccept_Click(object sender, EventArgs e)
        {

        }

        private void btDown_Click(object sender, EventArgs e)
        {
            string comment;
            try
            {
                comment = dtData.DefaultView[dgvData.CurrentRow.Index]["Comment"].ToString();
            }
            catch
            {
                comment = "";
            }

            int statusEstimate = -1;
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                statusEstimate = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["Status"].ToString());
            }
            dtTableStatus = readSQL.getTableStatusEstimat(statusEstimate, 1);
            if (dtTableStatus != null && dtTableStatus.Rows.Count > 0 && dtTableStatus.Rows[0]["undoStatus"] != DBNull.Value)
            {               
                int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                statusEstimate = int.Parse(dtTableStatus.Rows[0]["undoStatus"].ToString());
                if (config.statusCode.Equals("кнт") || config.statusCode.Equals("адм"))
                {
                    frmAddComment frmCom = new frmAddComment();
                    if (frmCom.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    comment += DateTime.Now + " Контролер: " + frmCom.comment;
                }
                readSQL.changeStatusEstimate(id, statusEstimate, comment);
                get_data();
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

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void cbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                int statusSelect = 0;
                if (dtData.DefaultView[e.RowIndex]["Status"] != DBNull.Value)
                    statusSelect = (int)dtData.DefaultView[e.RowIndex]["Status"];

                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;

                // Раскраска относительно колонок 
                switch (statusSelect)
                {
                    case 1: // Смета потверждена оператором
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = pOpOk.BackColor;
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = pOpOk.BackColor;
                        break;
                    case 5: // Смета не подтверждена контролером
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = pKntNo.BackColor;
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = pKntNo.BackColor;
                        break;
                    case 2: // Смета подтверждена контролером
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = pKntOk.BackColor;
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = pKntOk.BackColor;
                        break;
                    case 3: // Средства выделены (администратор)
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = pAdmCash.BackColor;
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = pAdmCash.BackColor;
                        break;
                    case 4: // Все поставленно на баланс 
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = pAllBal.BackColor;
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = pAllBal.BackColor;
                        break;
                    default:
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                        dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                        break;
                }
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

        /// <summary>
        /// Печать служебной записки на деньги
        /// </summary>
        private void btPrintMemo_Click(object sender, EventArgs e)
        {
            if (dtData != null && dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData.DefaultView.Count != 0)
            {
                DataTable dtDataReport = readSQL.getContentEstimate(int.Parse(dgvData.CurrentRow.Cells["cNumber"].Value.ToString()));
                //DataTable dtDataDep = readSQL.getSingleDepartamens(Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["id_Dep"].ToString()));

                reports.memoReport.frmMemoReport frm = new reports.memoReport.frmMemoReport(dtData.DefaultView[dgvData.CurrentRow.Index], dtDataReport.Select("Purchase not in (2,3)").CopyToDataTable());
                frm.Text = "Служебная записка на деньги";
                frm.Show();
            }
        }

        private void dgvData_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            // Всплывающая подсказка на название сметы
            if (e.RowIndex != -1 && dgvData.Rows[e.RowIndex].Cells["cName"].ColumnIndex == e.ColumnIndex)
                dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Открытие формы сканов при их наличии
            if (e.RowIndex != -1 && dgvData.Rows[e.RowIndex].Cells["cScan"].ColumnIndex == dgvData.CurrentCell.ColumnIndex)
            {
                int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                frmAddDoc frm = new frmAddDoc();
                frm.setId_journal(id);
                frm.setTypeScan(1);
                if (DialogResult.OK == frm.ShowDialog())
                    get_data();
            }
        }

        /// <summary>
        /// Печать сметы
        /// </summary>
        private void btPrintEstimate_Click(object sender, EventArgs e)
        {
            if (dtData != null && dgvData.CurrentRow != null && dgvData.CurrentRow.Index >= 0)
            {
                DataRow dtCurrent = dtData.DefaultView[dgvData.CurrentRow.Index].Row;
                estimateReport report = new estimateReport(dtCurrent);
            }
        }

        private void btBalance_Click(object sender, EventArgs e)
        {
            if (dtData != null && dgvData.CurrentRow != null && dgvData.CurrentRow.Index >= 0)
            {
                DataRow dtCurrent = dtData.DefaultView[dgvData.CurrentRow.Index].Row;
                balanceReport report = new balanceReport(Convert.ToInt32(dtCurrent["id"].ToString()), Convert.ToDateTime(dtCurrent["DateEdit"].ToString()));
            }
        }

        private void tbObject_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void tbDep_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void btDel_Click(object sender, EventArgs e)
        {

        }
    }
}
