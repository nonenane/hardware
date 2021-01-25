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
    public partial class frmJournalActReceivingTransfer : Form
    {
        public frmJournalActReceivingTransfer()
        {
            InitializeComponent();           
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAddActReceivingTransfer frm = new frmAddActReceivingTransfer();
            frm.Text = "Создать акт приемки передачи материальной ответственности";
            if (DialogResult.OK == frm.ShowDialog())
                get_data();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            get_data();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
               && dtData != null && dtData.DefaultView.Count != 0)
            {
                frmAddActReceivingTransfer frm = new frmAddActReceivingTransfer();
                frm.Text = "Редактировать акт приемки передачи материальной ответственности";               
                frm.setRow(dtData.DefaultView[dgvData.CurrentRow.Index]);
                if (DialogResult.OK == frm.ShowDialog())
                    get_data();
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
                    DataTable dtResult = readSQL.setActReceivingTransfer(id, "", DateTime.Now, "", 0, 2);
                    if (dtResult == null && dtResult.Rows.Count == 0 && dtResult.Rows[0]["id"].ToString().Equals("-1"))
                    {
                        MessageBox.Show("Не удалось удалить данные", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    dgvData.Rows.RemoveAt(dgvData.CurrentRow.Index);
                    get_data();
                }
            }
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Подтвердить запись?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    int statusReceveingTranser = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["Status"].ToString());
                    int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());

                    DataTable dtResult = readSQL.setActReceivingTransfer(id, "", DateTime.Now, "", statusReceveingTranser + 1, 1);
                    if (dtResult == null && dtResult.Rows.Count == 0 && dtResult.Rows[0]["id"].ToString().Equals("-1"))
                    {
                        MessageBox.Show("Не удалось обновить статус", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //dtData.DefaultView[dgvData.CurrentRow.Index]["Status"] = statusReceveingTranser + 1;
                    //dtData.AcceptChanges();
                    //dgvData_SelectionChanged(null, null);
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
                frm.setTypeScan(2);
                if (DialogResult.OK == frm.ShowDialog())
                    get_data();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        
        private DataTable dtData;
        private void get_data()
        {
            dgvData.AutoGenerateColumns = false;
            dtData = readSQL.getActReceivingTransfer(dtpStart.Value, dtpEnd.Value);
            filter();
            dgvData.DataSource = dtData;    
        }

        private void filter()
        {
            try
            {
                string filter = "";

                filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Convert(Number,System.String) like '%{0}%'", tbNumber.Text.Trim());
                filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Comment like '%{0}%'", tbComment.Text.Trim());

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
            dgvData_SelectionChanged(null, null);
        }

        private void init_combobox()
        {
            DataColumn col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;

            DataTable dtStatus = readSQL.getStatus("actReceivingTransferStatus");
            col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;
            dtStatus.Columns.Add(col);
            dtStatus.Rows.Add(-1, "Все", 0);
            dtStatus.DefaultView.Sort = "main asc";
            cbStatus.DataSource = dtStatus;
            cbStatus.DisplayMember = "cName";
            cbStatus.ValueMember = "id";
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            int statusReceveingTranser = -1;
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                statusReceveingTranser = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["Status"].ToString());
            }
            if (config.statusCode.Equals("оп"))
            {
                btAccept.Enabled = statusReceveingTranser == 0;
                btEdit.Enabled = btDel.Enabled = (statusReceveingTranser == 0 || statusReceveingTranser == 1);
            }
            else
                if (config.statusCode.Equals("кнт"))
                {
                    btAccept.Enabled = statusReceveingTranser == 1;
                    btAdd.Enabled = btEdit.Enabled = btDel.Enabled = false;
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
                int statusReceveingTranser = 0;
                if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
                {
                    statusReceveingTranser = int.Parse(dtData.DefaultView[e.RowIndex]["Status"].ToString());
                }
                if (statusReceveingTranser != 2) rColor = pNotAll.BackColor;

                dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
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

        private void frmJournalActReceivingTransfer_Load(object sender, EventArgs e)
        {
            init_combobox();
            get_data();
        }
    }
}
