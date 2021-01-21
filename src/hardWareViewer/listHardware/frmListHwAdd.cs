using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hardWareViewer.listHardware
{
    public partial class frmListHwAdd : Form
    {
        public DataRowView row { set; private get; }
        private int id = 0;
        private int typeHardWare = 0;
        DataTable dtListResp, dtLocation;

        public frmListHwAdd()
        {
            InitializeComponent();
        }

        private void frmListHwAdd_Load(object sender, EventArgs e)
        {
            if (config.statusCode == "оп")
                tbInventory.ReadOnly = false;

            dtListResp = readSQL.getListResponsibles(1);
            cbResponsible.DataSource = dtListResp;
            cbResponsible.ValueMember = "id";
            cbResponsible.DisplayMember = "FIO";
            cbResponsible.SelectedIndex = -1;

            dtLocation = readSQL.getLocation();
            dtLocation.DefaultView.Sort = "cName";
            cbLocation.DataSource = dtLocation;
            cbLocation.ValueMember = "id";
            cbLocation.DisplayMember = "cName";
            cbLocation.SelectedIndex = -1;

            setTypeCom();
            dtpGarant.MaxDate = DateTime.Now.Date;
            enableGarant();
            initCmbYear();

            if (row == null)
            {
                this.Text = "Добавить оборудование";
                id = 0;
                label6.Visible = tbComment.Visible = false;
            }
            else
            {
                this.Text = "Редактировать оборудование";
                id = (int)row["id"];
                typeHardWare = (int)row["TypeComponentsHardware"];

                rbHardware.Checked = typeHardWare == 0;
                rbAdditional.Checked = !rbHardware.Checked;
                setTypeCom();

                cbEquipment.SelectedValue = row["id_ComponentsHardware"];
                cbLocation.SelectedValue = row["id_Location"];
                cbResponsible.SelectedValue = row["id_Responsible"];
                tbInventory.Text = (string)row["InventoryNumber"];
                tbName.Text = (string)row["cName"];
                chbIsGarant.Checked = row["DatePurchase"] != DBNull.Value;
                dtpGarant.Value = row["DatePurchase"] == DBNull.Value ? DateTime.Now.Date : (DateTime)row["DatePurchase"];
                tbMonthG.Text = row["WarrantyPeriod"].ToString();
                id_ListServiceRecords = row["id_ListServiceRecords"] == DBNull.Value ? null : (int?)row["id_ListServiceRecords"];
                tbNumerSz.Text = row["Number"].ToString();
                if (row["confYear"].ToString().Length > 0)
                    cmbYear.SelectedValue = row["confYear"];
            }

            ///* передача выбранного значения Radio */
            //if (frmListHardware.hardwareAddition)
            //{
            //    rbHardware.Checked = true;
            //    rbAdditional.Checked = false;
            //}
            //else if (!frmListHardware.hardwareAddition)
            //{
            //    rbAdditional.Checked = true;
            //    rbHardware.Checked = false;
            //}

            ////ReLoadbyChoise();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        
        private void rbHardware_CheckedChanged(object sender, EventArgs e)
        {
            setTypeCom();
        }

        private void setTypeCom()
        {
            //DataTable dtComp = rbHardware.Checked ? readSQL.getTypeHardWare() : readSQL.getTypeComponents();
            DataTable dtComp = readSQL.getEquipmentList(rbHardware.Checked ? 0 : 1);
            dtComp.DefaultView.Sort = "cName";
            cbEquipment.DataSource = dtComp;
            cbEquipment.DisplayMember = "cName";
            cbEquipment.ValueMember = "id";
            cbEquipment.SelectedIndex = -1;
            tbInventory.Text = "";
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            if (tbName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо указать наименование.","Информирование",MessageBoxButtons.OK,MessageBoxIcon.Information); return;
            }

            if (cbEquipment.SelectedIndex == -1)
            {
                MessageBox.Show("Необходимо выбрать комплектующие или уборудование.", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }

            if (cbResponsible.SelectedIndex == -1)
            {
                MessageBox.Show("Необходимо выбрать ответственного.", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }

            if (cbLocation.SelectedIndex ==-1)
            {
                MessageBox.Show("Необходимо выбрать место расположение.", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }

            if (chbIsGarant.Checked)
            {
                if (tbMonthG.Text.Trim().Length==0)
                {
                    MessageBox.Show("Необходимо указать срок гарантии.", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                }
            }

            DataTable dtResult = new DataTable();

            int id_typeComp = (int)cbEquipment.SelectedValue;
            int type = rbHardware.Checked ? 0 : 1;

            DataTable dtTmp = (cbEquipment.DataSource as DataTable).Copy();
            string sRow = dtTmp.Select("id = " + id_typeComp)[0]["Inventory"].ToString();
            if(!tbInventory.Text.StartsWith(sRow + "-"))
            {
                MessageBox.Show("Введённый Инв. номер не соответствует шаблону.\nСохранение невозможно.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dtResult = readSQL.checkInvNumber_v1(type, id_typeComp, tbInventory.Text.Trim(),id);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                MessageBox.Show("Введённый Инв. номер уже присутствует в списке оборудования.\nСохранение невозможно.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            int id_Kadr = (int)cbResponsible.SelectedValue;
            int id_Location = (int)cbLocation.SelectedValue;
            int id_Equip = (int)cbEquipment.SelectedValue;

            object DatePurchase = null;
            object WarrantyPeriod = null;
            if (chbIsGarant.Checked)
            {
                DatePurchase = dtpGarant.Value;
                WarrantyPeriod = int.Parse(tbMonthG.Text.Trim());
            }


            dtResult = readSQL.setNewPositionAdded(id, id_Location, id_Equip, id_Kadr, type, tbName.Text.Trim(), tbInventory.Text.Trim(), false, DatePurchase, WarrantyPeriod, id_ListServiceRecords);
            if (dtResult == null)
            {
                MessageBox.Show("Ошибка работы процедуры", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }

            if (dtResult.Rows.Count>0 && (int)dtResult.Rows[0]["id"]<=0)
            {
                MessageBox.Show((string)dtResult.Rows[0]["msg"], "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }

            //Тут запись в новую таблицу, только нафига?:)
            if (id == 0)
            {
                int tId = (int)dtResult.Rows[0]["id"];

                string ff = rbHardware.Checked ? rbHardware.Text : rbAdditional.Text;

                readSQL.setChangesHardware(tId, @"Тип оборудования:", null, ff, false);
                readSQL.setChangesHardware(tId, @"Оборудование\Комплектующее:", null, cbEquipment.Text, false);
                readSQL.setChangesHardware(tId, @"Наименование объекта:", null, tbName.Text, false);
                readSQL.setChangesHardware(tId, @"Инв. номер:", null, tbInventory.Text, false);
                readSQL.setChangesHardware(tId, @"Расположение:", null, cbLocation.Text, false);
                readSQL.setChangesHardware(tId, @"Ответственный:", null, cbResponsible.Text, false);

                readSQL.setChangesHardware(tId, @"Дата покупки оборудования:", null, dtpGarant.Text, false);
                readSQL.setChangesHardware(tId, @"Срок гарантии:", null, tbMonthG.Text, false);
                readSQL.setChangesHardware(tId, @"Номер СЗ:", null, (chbIsGarant.Checked ? tbMonthG.Text : ""), false);
                readSQL.setChangesHardware(tId, @"Год СЗ:", null, cmbYear.Text, false);

            }
            else
            {
                if (tbComment.Text.Trim().Length > 0)
                    readSQL.setChangesHardware(id, @"Комментарий:", null, tbComment.Text, false);

                string ffNew = rbHardware.Checked ? rbHardware.Text : rbAdditional.Text;
                string ffOld = (int)row["TypeComponentsHardware"] == 0 ? rbHardware.Text : rbAdditional.Text;
                if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Тип оборудования:", ffOld, ffNew, false);

                DataTable dtComp = readSQL.getEquipmentList((int)row["TypeComponentsHardware"]);
                ffOld = (string)dtComp.Select("id = " + row["id_ComponentsHardware"])[0]["cName"];
                ffNew = cbEquipment.Text;
                if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Оборудование\Комплектующее:", ffOld, ffNew, false);


                ffOld = (string)row["cName"];
                ffNew = tbName.Text;
                if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Наименование объекта:", ffOld, ffNew, false);


                ffOld = (string)row["InventoryNumber"];
                ffNew = tbInventory.Text;
                if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Инв. номер:", ffOld, ffNew, false);


                ffOld = (string)dtLocation.Select("id = " + row["id_Location"])[0]["cName"];
                ffNew = cbLocation.Text;
                if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Расположение:", ffOld, ffNew, false);

                ffOld = (string)dtListResp.Select("id = " + row["id_Responsible"])[0]["FIO"];
                ffNew = cbResponsible.Text;
                if (!ffNew.Equals(ffOld))                   
                    readSQL.setChangesHardware(id, @"Ответственный:", ffOld, ffNew, false);



                ffOld = row["DatePurchase"]==DBNull.Value?"":((DateTime)row["DatePurchase"]).ToShortDateString();
                ffNew = dtpGarant.Text.Trim();
                if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Дата покупки оборудования:", ffOld, ffNew, false);

                ffOld = row["WarrantyPeriod"] == DBNull.Value ? "" : row["WarrantyPeriod"].ToString();
                ffNew = chbIsGarant.Checked ? tbMonthG.Text : "";
                if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Срок гарантии:", ffOld, ffNew, false);

                ffOld = row["Number"] == DBNull.Value ? "" : row["Number"].ToString();
                ffNew = tbNumerSz.Text;
                if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Номер СЗ:", ffOld, ffNew, false);

                ffOld = row["confYear"] == DBNull.Value ? "" : row["confYear"].ToString();
                ffNew = cmbYear.Text;
                if (!ffNew.Equals(ffOld))
                    readSQL.setChangesHardware(id, @"Год СЗ:", ffOld, ffNew, false);

            }

            MessageBox.Show("Данные сохранены!","Информирование",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void chbIsGarant_CheckedChanged(object sender, EventArgs e)
        {
            enableGarant();
        }

        private void enableGarant()
        {
            if (chbIsGarant.Checked)
            {
                dtpGarant.Enabled = true;
                dtpGarant.Format = DateTimePickerFormat.Short;
                tbMonthG.Enabled = true;
            }
            else
            {
                dtpGarant.Enabled = false;
                tbMonthG.Enabled = false;
                dtpGarant.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                dtpGarant.CustomFormat = " ";
            }
        }

        private void initCmbYear()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Columns.Add("year",typeof(string));
            dtTmp.AcceptChanges();

            dtTmp.Rows.Add(DateTime.Now.Year);
            dtTmp.Rows.Add(DateTime.Now.AddYears(-1).Year);
            dtTmp.Rows.Add(DateTime.Now.AddYears(-2).Year);
            dtTmp.AcceptChanges();

            cmbYear.DataSource = dtTmp;
            cmbYear.DisplayMember = "year";
            cmbYear.ValueMember = "year";
        }

        private void tbMonthG_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
        }

        private void tbMonthG_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb.Text.Trim().Length == 0) return;

            int value;
            if (!int.TryParse(tb.Text.Trim(), out value)) { e.Cancel = true;return; }
            if (value == 0) { tb.Text = "1"; return; }
        }

        private int? id_ListServiceRecords = null;
        private void tbNumerSz_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb.Text.Trim().Length == 0)
            {
                id_ListServiceRecords = null; return;
            }

            int value;
            if (!int.TryParse(tb.Text.Trim(), out value)) { id_ListServiceRecords = null; e.Cancel = true; return; }

            DateTime _date = new DateTime(int.Parse(cmbYear.Text), 1, 1);

            DataTable dtResult = readSQL.getInfoServiceRecordNumber(_date, value);
            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Сз не найдена","Сохранение данных",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                tb.Text = "";
                id_ListServiceRecords = null;
                return;
            }
            id_ListServiceRecords = (int?)dtResult.Rows[0]["id"];
        }

        private void CbEquipment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id_typeComp = (int)cbEquipment.SelectedValue;
            int type = rbHardware.Checked ? 0 : 1;
            DataTable dtResult = readSQL.getInventory_v1(type, id_typeComp);

            DataTable dtTmp = (cbEquipment.DataSource as DataTable).Copy();
            string sRow = dtTmp.Select("id = " + id_typeComp)[0]["Inventory"].ToString();

            if (dtResult == null || dtResult.Rows.Count==0)
            {
                tbInventory.Text = sRow + "-1";
            }
            else
            {
                tbInventory.Text = sRow + "-" + dtResult.Rows[0]["num"].ToString();
            }
        }
    }
}
