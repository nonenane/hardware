using Nwuram.Framework.Logging;
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
    public partial class frmJournalActWriteOff : Form
    {
        public frmJournalActWriteOff()
        {
            InitializeComponent();           
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            //frmAddActWriteOff frm = new frmAddActWriteOff();
            //frm.Text = "Создать акт списания";
            //frm.ShowDialog();
            config.Reason = "";
            frmListHardware frm = new frmListHardware();
            frm.isStatusFirst = true;
            frm.setSelectStatus();
            if (DialogResult.OK == frm.ShowDialog())
                get_data();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
                && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id_actWriteOff = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];

                config.Reason = dtData.DefaultView[dgvData.CurrentRow.Index]["Reason"].ToString();

                frmListHardware frm = new frmListHardware();
                frm.isStatusFirst = true;
                frm.setSelectStatus(id_actWriteOff);
                if (DialogResult.OK == frm.ShowDialog())
                    get_data();

                //frmAddActWriteOff frm = new frmAddActWriteOff();
                //frm.Text = "Редактировать акт списания";              
                //frm.setRow(dtData.DefaultView[dgvData.CurrentRow.Index]);
                //frm.ShowDialog();
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
               && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                DataTable dtResult = readSQL.validateActWriteOff(id);

                if (dtResult == null || dtResult.Rows.Count == 0 || dtResult.Rows[0]["id"].ToString().Equals("-1"))
                {
                    MessageBox.Show("Запись уже удалена другим пользователем.", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    get_data();
                    return;
                }

                if (DialogResult.Yes == MessageBox.Show("Удалить выбранную запись?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    dtResult = readSQL.validateActWriteOff(id);

                    if (dtResult == null || dtResult.Rows.Count == 0 || dtResult.Rows[0]["id"].ToString().Equals("-1"))
                    {
                        MessageBox.Show("Запись уже удалена другим пользователем.", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        get_data();
                        return;
                    }

                    DataTable dtTmp = readSQL.getActWriteOff(DateTime.Now, DateTime.Now, id);
                    Logging.StartFirstLevel(33);
                    Logging.Comment("Удаление акта списания");
                    if (dtTmp != null && dtTmp.Rows.Count > 0)
                    {
                        Logging.Comment("Заголовок акта:");
                        Logging.Comment($"Id акта: {id}");
                        Logging.Comment($"Номер акта: {dtTmp.Rows[0]["Number"]}");
                        Logging.Comment($"Дата создания акта: {dtTmp.Rows[0]["Date"]}");
                        Logging.Comment($"Причина списания: { dtTmp.Rows[0]["Reason"]}");
                        Logging.Comment($"Статуса акта Id:{dtTmp.Rows[0]["Status"]}; Наименование:{dtTmp.Rows[0]["nameStatus"]}");
                    }

                    DataTable dtDataBody = readSQL.getContentWriteOff(id);
                    if (dtDataBody != null && dtDataBody.Rows.Count > 0)
                    {
                        Logging.Comment("Содержимое акта:");
                        foreach (DataRow row in dtDataBody.Rows)
                        {
                            Logging.Comment($"Id оборудования: {row["id_Hardware"]}");
                            Logging.Comment($"Инвентаризационный номер: {row["InventoryNumber"]}");
                            Logging.Comment($"EAN: {row["EAN"]}");
                            Logging.Comment($"Наименование: {row["cName"]}");
                            Logging.Comment($"Оборудование/комплектующие: {row["nameType"]}");
                            Logging.Comment($"Местоположение Id:{row["id_Location"]}; Наименование:{row["nameLocation"]}");
                            Logging.Comment($"Ответственный  Id:{row["id_Responsible"]}; ФИО:{row["FIO"]}");
                        }
                    }
                    Logging.StopFirstLevel();

                    dtResult = readSQL.setActWriteOff(id, "", true);

                    if (dtResult == null || dtResult.Rows.Count == 0 || dtResult.Rows[0]["id"].ToString().Equals("-1"))
                    {
                        MessageBox.Show("Не удалось удалить данные!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                frm.setTypeScan(3);
                if (DialogResult.OK == frm.ShowDialog())
                    get_data();
            }
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
            && dtData != null && dtData.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Отклонить акт?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                    int status = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["Status"].ToString());
                    status = status - 1;
                    DataTable dtResult = readSQL.updateStatusActWriteOff(id, status);

                    if (dtResult == null || dtResult.Rows.Count == 0 || dtResult.Rows[0]["id"].ToString().Equals("-1"))
                    {
                        MessageBox.Show("Не удалось обновить данные!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    setLogChangeStatus();

                    dgvData.Rows.RemoveAt(dgvData.CurrentRow.Index);
                    get_data();
                }
            }
        }

        private void btNextStatus_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
               && dtData != null && dtData.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Передать акт дальше?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                    int status = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["Status"].ToString());
                    status = status + 1;
                    DataTable dtResult = readSQL.updateStatusActWriteOff(id, status);
                           
                    if (dtResult == null || dtResult.Rows.Count == 0 || dtResult.Rows[0]["id"].ToString().Equals("-1"))
                    {
                        MessageBox.Show("Не удалось обновить данные!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;                    
                    }
                    setLogChangeStatus();

                    dgvData.Rows.RemoveAt(dgvData.CurrentRow.Index);
                    get_data();
                }
            }
        }

        private void setLogChangeStatus()
        {
            int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
            int status = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["Status"].ToString());
            string nameStatus = dtData.DefaultView[dgvData.CurrentRow.Index]["nameStatus"].ToString();

            DataTable dtTmp = readSQL.getActWriteOff(DateTime.Now, DateTime.Now, id);
            Logging.StartFirstLevel(540);
            Logging.Comment("Подтверждение акта");
            if (dtTmp != null && dtTmp.Rows.Count > 0)
            {
                Logging.Comment("Заголовок акта:");
                Logging.Comment($"Id акта: {id}");
                Logging.Comment($"Номер акта: {dtTmp.Rows[0]["Number"]}");
                Logging.Comment($"Дата создания акта: {dtTmp.Rows[0]["Date"]}");
                Logging.Comment($"Причина списания: { dtTmp.Rows[0]["Reason"]}");
                Logging.VariableChange($"Статуса акта Id",dtTmp.Rows[0]["Status"], status);
                Logging.VariableChange($"Статуса акта Наименование:", dtTmp.Rows[0]["nameStatus"], nameStatus);
            }
            Logging.StopFirstLevel();
        }

        private DataTable dtData;
        private void get_data()
        {
            dgvData.AutoGenerateColumns = false;
            dtData = readSQL.getActWriteOff(dtpStart.Value, dtpEnd.Value);
            filter();
            dgvData.DataSource = dtData;
        }

        private void filter()
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                btView.Enabled = btPrint.Enabled = btAddDoc.Enabled = btDel.Enabled = btEdit.Enabled = false;
                dgvData_SelectionChanged(null, null);
                return;
            }

            try
            {
                string filter = "";

                filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Convert(Number,System.String) like '%{0}%'", tbNumber.Text.Trim());
                //filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Comment like '%{0}%'", tbComment.Text.Trim());

                if (cbStatus.SelectedIndex != 0)
                    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Status = {0}", cbStatus.SelectedValue);


                //if (cbLocation.SelectedIndex != 0)
                //    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Status = {0}", cbLocation.SelectedValue);

                //if (cbResponsibles.SelectedIndex != 0)
                //    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Status = {0}", cbResponsibles.SelectedValue);

                dtData.DefaultView.RowFilter = filter;
                dtData.DefaultView.Sort = "Date asc, Number asc";
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                dtData.DefaultView.RowFilter = "id = -9999";
            }

            btView.Enabled =  btPrint.Enabled = btAddDoc.Enabled = btDel.Enabled = btEdit.Enabled = dtData.DefaultView.Count != 0;           
            dgvData_SelectionChanged(null, null);
        }

        private void init_combobox()
        {
            DataColumn col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;

            DataTable dtStatus = readSQL.getStatus("writeOffStatus");
            col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;
            dtStatus.Columns.Add(col);
            dtStatus.Rows.Add(-1, "Все", 0);
            dtStatus.DefaultView.Sort = "main asc";
            cbStatus.DataSource = dtStatus;
            cbStatus.DisplayMember = "cName";
            cbStatus.ValueMember = "id";
        }

        private void cbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (dgvData.CurrentRow != null && e.RowIndex != -1
            //    && dtData != null && dtData.DefaultView.Count != 0)
            //{
            //    frmAddActWriteOff frm = new frmAddActWriteOff();
            //    frm.Text = "Просмотр акта списания";               
            //    frm.setRow(dtData.DefaultView[dgvData.CurrentRow.Index]);
            //    frm.isV();
            //    frm.ShowDialog();
            //}
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int status = -1;
                if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
                {
                    status = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["Status"].ToString());
                }

                if (status != -1)
                {
                    if ((status == 0 || status == 2) && config.statusCode.Equals("кнт"))
                        btNextStatus.Enabled = true;
                    else
                    if ((status == 1) && config.statusCode.Equals("оп"))
                        btNextStatus.Enabled = true;
                    else
                        btNextStatus.Enabled = false;

                    btDown.Enabled = ((status == 1 || status == 2) && config.statusCode.Equals("кнт"));

                    btEdit.Enabled = btDel.Enabled = status == 0;
                }
                else
                {
                    btDown.Enabled = btNextStatus.Enabled = false;
                    //btPrint.Enabled = false;
                    btEdit.Enabled = btDel.Enabled = false;
                }
            }
            catch {
                btDown.Enabled = btNextStatus.Enabled = false;
                //btPrint.Enabled = false;
                btEdit.Enabled = btDel.Enabled = false;
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

        private void btUpdate_Click(object sender, EventArgs e)
        {
            get_data();
        }

        private void dgvData_Paint(object sender, PaintEventArgs e)
        {
            tbNumber.Location = new Point(dgvData.Location.X, tbNumber.Location.Y);
            tbNumber.Size = new Size(cNumber.Width, tbNumber.Size.Height);
        }

        private void frmJournalActWriteOff_Load(object sender, EventArgs e)
        {
            btAdd.Visible = btDel.Visible = config.statusCode.ToLower().Equals("оп");
            //btEdit.Visible = config.statusCode.ToLower().Equals("кнт");

            dtpStart.Value = DateTime.Now.AddDays(-7);
            init_combobox();
            get_data();
        }

        private void btView_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
                && dtData != null && dtData.DefaultView.Count != 0)
            {
                frmViewActWriteOff frm = new frmViewActWriteOff();
                frm.Text = "Просмотр акта списания";               
                frm.setRow(dtData.DefaultView[dgvData.CurrentRow.Index]);                
                frm.ShowDialog();
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
               && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id_actWriteOff = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];

                DataTable dtTmp = readSQL.getActWriteOff(DateTime.Now, DateTime.Now, id_actWriteOff);
                Logging.StartFirstLevel(221);
                Logging.Comment("Выгрузка отчета по акту");
                if (dtTmp != null && dtTmp.Rows.Count > 0)
                {
                    Logging.Comment("Заголовок акта:");
                    Logging.Comment($"Id акта: {id_actWriteOff}");
                    Logging.Comment($"Номер акта: {dtTmp.Rows[0]["Number"]}");
                    Logging.Comment($"Дата создания акта: {dtTmp.Rows[0]["Date"]}");
                    Logging.Comment($"Причина списания: { dtTmp.Rows[0]["Reason"]}");
                    Logging.Comment($"Статуса акта Id:{dtTmp.Rows[0]["Status"]}; Наименование:{dtTmp.Rows[0]["nameStatus"]}");
                }

                DataTable dtDataBody = readSQL.getContentWriteOff(id_actWriteOff);
                if (dtDataBody != null && dtDataBody.Rows.Count > 0)
                {
                    Logging.Comment("Содержимое акта:");
                    foreach (DataRow row in dtDataBody.Rows)
                    {
                        Logging.Comment($"Id оборудования: {row["id_Hardware"]}");
                        Logging.Comment($"Инвентаризационный номер: {row["InventoryNumber"]}");
                        Logging.Comment($"EAN: {row["EAN"]}");
                        Logging.Comment($"Наименование: {row["cName"]}");
                        Logging.Comment($"Оборудование/комплектующие: {row["nameType"]}");
                        Logging.Comment($"Местоположение Id:{row["id_Location"]}; Наименование:{row["nameLocation"]}");
                        Logging.Comment($"Ответственный  Id:{row["id_Responsible"]}; ФИО:{row["FIO"]}");
                    }
                }
                Logging.StopFirstLevel();


                journalActWriteOff.printReport.printWriteOff(id_actWriteOff);
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
                dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor =  dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;


            }
        }

        private void cbStatus_DropDown(object sender, EventArgs e)
        {
            var senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;

            int vertScrollBarWidth = (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                    ? SystemInformation.VerticalScrollBarWidth : 0;

            //var itemsList = senderComboBox.Items.Cast<object>().Select(item => item.ToString());
            //foreach (string s in itemsList)
            //{
            //    int newWidth = (int)g.MeasureString(s, font).Width + vertScrollBarWidth;

            //    if (width < newWidth)
            //    {
            //        width = newWidth;
            //    }
            //}

            DataTable dtList = (DataTable)senderComboBox.DataSource;


            foreach (DataRow r in dtList.Rows)
            {
                string s = (string)r["cName"];

                int newWidth = (int)g.MeasureString(s, font).Width + vertScrollBarWidth;

                if (width < newWidth)
                {
                    width = newWidth;
                }
            }

            senderComboBox.DropDownWidth = width;
        }
    }
}
