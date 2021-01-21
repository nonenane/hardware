using hardWareViewer.listHardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Nwuram.Framework.ToExcelNew;
using System.Drawing;
using Nwuram.Framework.Logging;

namespace hardWareViewer
{
    public partial class frmListHardware : Form
    {
        private List<indexs> tempIndex = new List<indexs> { };       ///< Список для отработки условий добавления / замены для не существующих связей 
        private List<indexs> delIndex = new List<indexs> { };        ///< Список для отработки условий удаления существущих связей
        private List<indexs> contentEst = new List<indexs> { };      ///< Список для отработки условий добавления / замены для не существующих связей обороудования и комплектующих
        private List<indexs> delContentEst = new List<indexs> { };   ///< Список для отработки условий удаления существущих связей обороудования и комплектующих


        public static string strposcelling;
        public static bool hardwareAddition;
        public bool isStatusFirst { set; private get; }        
        private int id_actWriteOff;

        public void setSelectStatus(int id = 0)
        {
            cSelect.Visible = true;
            btSelect.Visible = true;

            //btAddDoc.Visible = false;
                //btPrint.Visible = btViewComponents.Visible = false;

            btAdded.Visible = btEdited.Visible = btDelete.Visible = !isStatusFirst;
            if (isStatusFirst)
            {
                id_actWriteOff = id;
                cbStatus.SelectedValue = 1;
                cbStatus.Enabled = false;
                toolTip1.SetToolTip(btSelect, "Подтвердить акт списания оборудования");

                if (id != 0)
                {
                    DataTable dtDataBody = readSQL.getContentWriteOff(id);
                    if (dtDataBody != null && dtDataBody.Rows.Count > 0)
                        foreach (DataRow row in dtDataBody.Rows)
                        {
                            EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable()
                                    .Where(r => r.Field<int>("id") == (int)row["id_Hardware"]);
                            if (rowCollect.Count() > 0)
                                rowCollect.First()["isSelect"] = true;

                        }

                    dgvData.DataSource = null;
                    dtData.DefaultView.RowFilter = "";
                    dtData.DefaultView.Sort = "isSelect desc";
                    dtData = dtData.DefaultView.ToTable().Copy();
                    filter();
                    dgvData.DataSource = dtData;
                }
                else
                { filter(); }
            }
            else
                toolTip1.SetToolTip(btSelect, "Подтвердить акт приема-передачи оборудования");
        }

        public frmListHardware()
        {
            InitializeComponent();
            dgvData.AllowUserToAddRows = false;
            init_combobox();
            get_data();
        }

        private void init_combobox()
        {
            DataColumn col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;

            DataTable dtLocation = readSQL.getLocation();
            dtLocation.Columns.Add(col);
            dtLocation.Rows.Add(-1, "Все", true, 0);
            dtLocation.DefaultView.RowFilter = "isActive = 1";
            dtLocation.DefaultView.Sort = "main asc";
            cbLocation.DataSource = dtLocation;
            cbLocation.DisplayMember = "cName";
            cbLocation.ValueMember = "id";


            DataTable dtResponsibles = readSQL.getListResponsibles(1);
            col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;
            dtResponsibles.Columns.Add(col);
            dtResponsibles.Rows.Add(-1, -1, "Все", true, true, 0);
            dtResponsibles.DefaultView.RowFilter = "isActive = 1";
            dtResponsibles.DefaultView.Sort = "main asc";
            cbResponsibles.DataSource = dtResponsibles;
            cbResponsibles.DisplayMember = "FIO";
            cbResponsibles.ValueMember = "id";

            DataTable dtStatus = readSQL.getStatus("hardwareStatus");
            col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;
            dtStatus.Columns.Add(col);
            dtStatus.Rows.Add(-1, "Все", 0);
            dtStatus.DefaultView.Sort = "main asc";
            cbStatus.DataSource = dtStatus;
            cbStatus.DisplayMember = "cName";
            cbStatus.ValueMember = "id";
        }

        private DataTable dtData;
        private void get_data()
        {
            btMOLChange.Enabled = false;
            int indexRow = 0;
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1)
                indexRow = dgvData.CurrentRow.Index;

            DataGridViewColumn oldCol = dgvData.SortedColumn;
            ListSortDirection direction = ListSortDirection.Ascending;
            if (oldCol != null)
            {
                if (dgvData.SortOrder == System.Windows.Forms.SortOrder.Ascending)
                {
                    direction = ListSortDirection.Ascending;                    
                }
                else
                {
                    direction = ListSortDirection.Descending;
                }
            }

            if (dtData != null && isStatusFirst)
            {
                EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable()
                    .Where(r => r.Field<bool>("isSelect"));
                if (rowCollect.Count() > 0)
                    dtSelected = rowCollect.CopyToDataTable();
            }

            dgvData.AutoGenerateColumns = false;
            dtData = readSQL.getListHardWare();

            if (isStatusFirst && dtSelected != null && dtData!=null && dtData.Rows.Count>0 && dtSelected.Rows.Count > 0)
            {
                foreach (DataRow row in dtSelected.Rows)
                {
                    EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable()
                            .Where(r => r.Field<int>("id") == (int)row["id"]);
                    if (rowCollect.Count() > 0)
                        rowCollect.First()["isSelect"] = true;
                }

                dtData.DefaultView.RowFilter = "";
                dtData.DefaultView.Sort = "isSelect desc";
                dtData = dtData.DefaultView.ToTable().Copy();
                dtSelected = null;
            }

            filter();
            dgvData.DataSource = dtData;
            dgvData_SelectionChanged(null, null);

            if (oldCol != null)
            {
                dgvData.Sort(oldCol, direction);
                oldCol.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
            }

            try
            {
                if (dgvData.Rows.Count > 0)
                {
                    dgvData.Rows[indexRow].Selected = true;
                    dgvData.CurrentCell = dgvData.Rows[indexRow].Cells[cName.Index];
                }
            }
            catch(Exception ex)
            { }

        }

        private void filter()
        {
            try
            {
                string filter = "";

                //filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Convert(Number,System.String) like '%{0}%'", tbNumber.Text.Trim());
                //filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Comment like '%{0}%'", tbComment.Text.Trim());

                filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Convert(InventoryNumber,System.String) like '%{0}%'", tbNumber.Text.Trim());
                filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Convert(EAN,System.String) like '%{0}%'", tbEAN.Text.Trim());
                filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Convert(cName,System.String) like '%{0}%'", tbName.Text.Trim());
                filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Convert(Number,System.String) like '%{0}%'", tbNumberSZ.Text.Trim());

                if (rbComponents.Checked)
                    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("TypeComponentsHardware = {0}", 1);
                else
                    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("TypeComponentsHardware = {0}", 0);

                if (cbStatus.SelectedIndex != 0)
                    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Status = {0}", cbStatus.SelectedValue);

                if (cbLocation.SelectedIndex != 0)
                    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("id_Location = {0}", cbLocation.SelectedValue);

                if (cbResponsibles.SelectedIndex != 0)
                    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("id_Responsible = {0}", cbResponsibles.SelectedValue);

                if (chbDays.Checked)
                    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("cntDay <= {0}", nudDays.Value);

                //if (isStatusFirst)
                //    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("status = 1", "");

                dtData.DefaultView.RowFilter = filter;

            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -9999";
            }

            btViewComponents.Enabled = btAddDoc.Enabled = dtData.DefaultView.Count != 0;
        }

        private void btAddDoc_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
              && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                frmAddDoc frm = new frmAddDoc();
                frm.setId_journal(id);
                frm.setTypeScan(8);
                if (DialogResult.OK == frm.ShowDialog())
                    get_data();
            }
        }

        private void btDropFilter_Click(object sender, EventArgs e)
        {
            //cbLocation.SelectedIndex = 0;
            //cbResponsibles.SelectedIndex = 0;
            //cbStatus.SelectedIndex = 0;
            //tbEAN.Clear();
            //tbName.Clear();
            //tbNumber.Clear();
            //filter();
            get_data();
        }

        private void cbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
            if(!btSelect.Visible)
                cSelect.Visible = cbLocation.SelectedIndex > 0;
        }

        private void rbHrdWare_CheckedChanged(object sender, EventArgs e)
        {
            filter();
            btViewComponents.Visible = rbHrdWare.Checked;
        }

        private void btViewComponents_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
            && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                frmListComponents frm = new frmListComponents();
                frm.setRow(dtData.DefaultView[dgvData.CurrentRow.Index]);
                frm.ShowDialog();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex == -1) return;

            if (senderGrid.Columns[e.ColumnIndex].Name.Equals("cSelect"))
            {
                bool isSelect = false;
                if (dtData.DefaultView[e.RowIndex]["isSelect"] != DBNull.Value)
                    isSelect = bool.Parse(dtData.DefaultView[e.RowIndex]["isSelect"].ToString());

                dtData.DefaultView[e.RowIndex]["isSelect"] = !isSelect;
                dtData.AcceptChanges();
                dgvData.Refresh();

                EnumerableRowCollection<DataRow> rowCollection = dtData.AsEnumerable().Where(r => r.Field<bool>("isSelect"));

                btSelect.Enabled = rowCollection.Count() > 0;
                btMOLChange.Enabled = rowCollection.Count() > 0 && cbLocation.SelectedIndex > 0;
            }            
        }

        private int sendId;
        private string sendName;
        private bool sendIsHardWare;

        public int getSendId()
        {
            return sendId;
        }

        public string getSendName()
        {
            return sendName;
        }

        public bool getIsHardWare()
        {
            return sendIsHardWare;
        }

        private void sendData()
        {
            sendId = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
            sendName = dtData.DefaultView[dgvData.CurrentRow.Index]["cName"].ToString();
            sendIsHardWare = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["TypeComponentsHardware"].ToString()) == 0;

            dtSend = dtData.Clone();
            foreach (DataRow r in dtData.Select("isSelect = 1"))
                dtSend.ImportRow(r);

            this.DialogResult = DialogResult.OK;
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            if (isStatusFirst)
                createActWriteOff();
            else
                sendData();
        }

        private void createActWriteOff()
        {
            EnumerableRowCollection<DataRow> rowCollection = dtData.AsEnumerable()
                .Where(r => r.Field<bool>("isSelect"));

            string replace = id_actWriteOff==0 ? "создать" : "редактировать";
            string replaceTitle = id_actWriteOff == 0 ? "Cоздание" : "Редактирование";
            string msg = config.centralText($"Вы действительно хотите {replace} акт\n списания оборудования для\n выделенных записей?\n");
            string title = $"{replaceTitle} акта списания оборудования";

            if (DialogResult.No == MessageBox.Show(msg, title, MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2))
            {
                //foreach (DataRow row in rowCollection)
                //    row["isSelect"] = false;

                //dtData.AcceptChanges();
                return;
            }

            journalActWriteOff.frmReasonActWriteOff frmAddReasone = new journalActWriteOff.frmReasonActWriteOff();
            frmAddReasone.rowCollection = rowCollection;
            frmAddReasone.id = id_actWriteOff;
            if (DialogResult.Cancel == frmAddReasone.ShowDialog())
            {
                //foreach (DataRow row in rowCollection)
                //    row["isSelect"] = false;

                //dtData.AcceptChanges();
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            code39Control1.Text = textBox4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //hardwareAddition = rbHrdWare.Checked;
            frmListHwAdd ifrm = new frmListHwAdd();
            if(DialogResult.OK== ifrm.ShowDialog()) get_data();

            /* обновление содержимого таблицы в Grid */
            //int intCurrentRow = 0;
            //if (dgvData.CurrentRow != null)
            //{
            //    intCurrentRow = dgvData.CurrentRow.Index;
            //}

            //filter();
            //if (dgvData.CurrentRow != null)
            //{
            //    dgvData.Rows[intCurrentRow].Selected = true;
            //}
        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private DataTable dtSend;
        public DataTable getDataTable()
        {
            return dtSend;
        }

         private void button2_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1)
            {
                frmListHwAdd ifrm = new frmListHwAdd();
                ifrm.row = dtData.DefaultView[dgvData.CurrentRow.Index];
                if (DialogResult.OK == ifrm.ShowDialog()) get_data();

                //strposcelling = dgvData.CurrentRow.Cells[2].Value.ToString();
                //hardwareAddition = rbHrdWare.Checked;
                //Form ifrm = new listHardware.frmListEd();
                //ifrm.ShowDialog();

                ///* обновление содержимого таблицы в Grid */
                //int intCurrentRow = dgvData.CurrentRow.Index;
                //get_data();
                //filter();
                //if (dgvData.CurrentRow != null)
                //{
                //    dgvData.Rows[intCurrentRow].Selected = true;
                //}

            }
            //else
            //{
            //    MessageBox.Show("У Вас не выбрана ни одна записись для редактирования", "Сообщение");
            //}
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Удалить запись?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    frmDeleteComment frm = new frmDeleteComment();
                    string Com = "";
                    if (frm.ShowDialog() == DialogResult.OK)
                        Com = frm.Comment;

                    int id = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];

                    DataTable dtResult = readSQL.setNewPositionAdded(id, 0, 0, 0, 0, "", "", true, null, null, null);
                    if (dtResult == null)
                    {
                        MessageBox.Show("Ошибка работы процедуры", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                    }

                    if (dtResult.Rows.Count > 0 && (int)dtResult.Rows[0]["id"] <= 0)
                    {
                        MessageBox.Show((string)dtResult.Rows[0]["msg"], "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                    }

                    if (Com.Trim().Length > 0)
                        readSQL.setChangesHardware(id, @"Комментарий:", null, Com, true);

                    object ffNew = null;
                    DataRowView row = dtData.DefaultView[dgvData.CurrentRow.Index];

                    object ffOld = (int)row["TypeComponentsHardware"] == 0 ? "Оборудование" : "Комплектующие";

                    //if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Тип оборудования:", ffOld, ffNew, true);

                    DataTable dtComp = readSQL.getEquipmentList((int)row["TypeComponentsHardware"]);
                    ffOld = (string)dtComp.Select("id = " + row["id_ComponentsHardware"])[0]["cName"];


                    //if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Оборудование\Комплектующее:", ffOld, ffNew, true);


                    ffOld = (string)row["cName"];
                    //if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Наименование объекта:", ffOld, ffNew, true);


                    ffOld = (string)row["InventoryNumber"];
                    //if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Инв. номер:", ffOld, ffNew, true);

                    DataTable dtLocation = readSQL.getLocation();
                    ffOld = (string)dtLocation.Select("id = " + row["id_Location"])[0]["cName"];

                    //if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Расположение:", ffOld, ffNew, true);

                    DataTable dtListResp = readSQL.getListResponsibles(1);
                    ffOld = (string)dtListResp.Select("id = " + row["id_Responsible"])[0]["FIO"];

                    //if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Ответственный:", ffOld, ffNew, true);


                    ffOld = row["DatePurchase"] == DBNull.Value ? "" : ((DateTime)row["DatePurchase"]).ToShortDateString();
                    readSQL.setChangesHardware(id, @"Дата покупки оборудования:", ffOld, ffNew, true);

                    ffOld = row["WarrantyPeriod"] == DBNull.Value ? "" : row["WarrantyPeriod"].ToString();
                    readSQL.setChangesHardware(id, @"Срок гарантии:", ffOld, ffNew, true);

                    ffOld = row["Number"] == DBNull.Value ? "" : row["Number"].ToString();
                    readSQL.setChangesHardware(id, @"Номер СЗ:", ffOld, ffNew, true);

                    ffOld = row["confYear"] == DBNull.Value ? "" : row["confYear"].ToString();
                    readSQL.setChangesHardware(id, @"Год СЗ:", ffOld, ffNew, true);


                    get_data();
                }
            }
            //else
            //{
            //    MessageBox.Show("У Вас не выбрана ни одна записись для удаления", "Сообщение");
            //}
        }

        private object GetReader(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        private void printToExcel_Click(object sender, EventArgs e)
        {

            Logging.StartFirstLevel(79);
            Logging.Comment("Выгрузка отчета по оборудованию");
            Logging.Comment($"Местоположение:{cbLocation.Text}");
            Logging.Comment($"Ответственный:{cbResponsibles.Text}");
            Logging.Comment($"Статус:{cbStatus.Text}");
            Logging.Comment($"Комплектующие или Оборудование:{(rbHrdWare.Checked? rbHrdWare.Text:rbComponents.Text)}");
            Logging.Comment($"Показать данные за N дней:{(chbDays.Checked ? nudDays.Value.ToString() : "Показать данные за все время")}");

            Logging.Comment($"Поиск по Инв.№:{tbNumber.Text}");
            Logging.Comment($"поиск по EAN:{tbEAN.Text}");
            Logging.Comment($"поиск по наименованию:{tbName.Text}");
            Logging.Comment($"поиск по Номеру СЗ:{tbNumberSZ.Text}");
            Logging.StopFirstLevel();


            var report = new ExcelUnLoad();

            report.AddSingleValue("Инв. №", 1, 1);
            report.AddSingleValue("EAN", 1, 2);
            report.AddSingleValue("Наименование", 1, 3);
            report.AddSingleValue("Объект", 1, 4);
            report.AddSingleValue("Оборудование/Комплектующие", 1, 5);
            report.AddSingleValue("Местоположение", 1, 6);
            report.AddSingleValue("Ответственный", 1, 7);
            report.AddSingleValue("Статус", 1, 8);
            report.SetBorders(1, 1, 1, 8);
            report.SetFontBold(1, 1, 1, 8);

            var rowCount = 2;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                var rowCountStart = rowCount;
                report.AddSingleValue(row.Cells["cNum"].Value.ToString(), rowCount, 1);
                report.AddSingleValue(row.Cells["cEAN"].Value.ToString(), rowCount, 2);
                report.AddSingleValue(row.Cells["cName"].Value.ToString(), rowCount, 3);
                report.AddSingleValue(row.Cells["LocationComment"].Value.ToString(), rowCount, 4);
                report.AddSingleValue(row.Cells["cHardWare"].Value.ToString(), rowCount, 5);
                report.AddSingleValue(row.Cells["cLocation"].Value.ToString(), rowCount, 6);
                report.AddSingleValue(row.Cells["cResponsible"].Value.ToString(), rowCount, 7);
                report.AddSingleValue(row.Cells["cStatus"].Value.ToString(), rowCount, 8);

                rowCount++;
                for (var i = 1; i < 8; i++)
                {
                    report.Merge(rowCountStart, i, rowCount - 1, i);
                    report.SetBorders(rowCountStart, 1, rowCount - 1, 8);
                }
            }
            report.SetColumnAutoSize(1, 1, rowCount, 8);
            report.SetColumnWidth(1, 1, rowCount, 1, 8);
            report.SetWrapText(1, 1, rowCount, 8);
            report.Show();
        }

        private void ChbDays_CheckedChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void NudDays_ValueChanged(object sender, EventArgs e)
        {
            if(chbDays.Checked) filter();
        }
              
        private void DgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1)// && !chbUsedGrp.Checked)
            {
                dgvData.CurrentCell = dgvData[e.ColumnIndex, e.RowIndex];
                cmsMenu.Show(MousePosition);
            }
        }

        private void ОтчетПоИзменениюВОборудованииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
            DataRowView row = dtData.DefaultView[dgvData.CurrentRow.Index];

            Logging.StartFirstLevel(79);
            Logging.Comment("Выгрузка отчета по изменению для конкретного оборудования");

            Logging.Comment($"Id оборудования: {row["id"]}");
            Logging.Comment($"Инвентаризационный номер: {row["InventoryNumber"]}");
            Logging.Comment($"EAN: {row["EAN"]}");
            Logging.Comment($"Наименование: {row["cName"]}");
            Logging.Comment($"Оборудование/комплектующие: {row["nameHardware"]}");
            Logging.Comment($"Местоположение Id:{row["id_Location"]}; Наименование:{row["nameLocation"]}");
            Logging.Comment($"Ответственный  Id:{row["id_Responsible"]}; ФИО:{row["FIO"]}");
            Logging.Comment($"Статус  Id:{row["Status"]}; Наименование:{row["nameStatus"]}");
            Logging.Comment($"Скан: {((int)row["scaneCount"]>0?"Да":"Нет")}");
            
            Logging.Comment($"Дата создания: {row["DateCreate"]}");
            Logging.Comment($"Дата редактирования: {row["DateEdit"]}");

            Logging.StopFirstLevel();



            reportHistory.createReport(id, DateTime.Now, DateTime.Now, "", 0);
        }

        private void BtReport_Click(object sender, EventArgs e)
        {
            new frmReportHistory() { }.ShowDialog();
        }

        private void BtPrint_Click(object sender, EventArgs e)
        {

        }

        private void DgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && !isStatusFirst && (int)dtData.DefaultView[dgvData.CurrentRow.Index]["status"] != 2)
                button2_Click(null, null);
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null || dgvData.CurrentRow.Index == -1 || dgvData.CurrentRow.Index>= dtData.DefaultView.Count)
            {
                btDelete.Enabled = btEdited.Enabled = false;
                return;
            }

            int _status = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["status"];
            btDelete.Enabled = btEdited.Enabled = _status != 2;


        }

        private void frmListHardware_Load(object sender, EventArgs e)
        {
            //setSelectStatus();
        }

        private DataTable dtSelected;

        private void btMOLChange_Click(object sender, EventArgs e)
        {
            DataRow[] tmp = dtData.Select("isSelect = 1 AND id_Location = "
                + cbLocation.SelectedValue.ToString() + " AND status <> 2");
            if(tmp == null || tmp.Length == 0)
            {
                MessageBox.Show("Выбрано только списанное оборудование.\nИзменение МОЛ невозможно.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmMOLChange frm = new frmMOLChange(tmp);
            if (frm.ShowDialog() == DialogResult.OK)
                get_data();
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
                {
                    Color rColor = Color.White;
                    if ((bool)dtData.DefaultView[e.RowIndex]["isGarant"])
                        rColor = panel1.BackColor;

                    dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                    dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                    dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
                }
            }
            catch { }
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

        private void tbNumberSZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
        }
    }
}
