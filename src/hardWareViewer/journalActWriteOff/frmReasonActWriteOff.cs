using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hardWareViewer.journalActWriteOff
{
    public partial class frmReasonActWriteOff : Form
    {

        public int id { set; private get; }
        public string Reason { set; private get; }
        public EnumerableRowCollection<DataRow> rowCollection { set; private get; }        

        public frmReasonActWriteOff()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btCreate_Click(object sender, EventArgs e)       
        {
            DataTable dtResult = null;
            DataTable dtRowCollection = rowCollection.CopyToDataTable().Copy();
            bool isEdit = false;
            if (id != 0)
            {
                isEdit = true;
                DataTable dtTmp = readSQL.getActWriteOff(DateTime.Now, DateTime.Now, id);


                Logging.StartFirstLevel(930);
                Logging.Comment("Редактирование акта списания");
                if (dtTmp != null && dtTmp.Rows.Count > 0)
                {
                    Logging.Comment("Заголовок акта:");
                    Logging.Comment($"Id акта: {id}");
                    Logging.Comment($"Номер акта: {dtTmp.Rows[0]["Number"]}");
                    Logging.Comment($"Дата создания акта: {dtTmp.Rows[0]["Date"]}");
                    Logging.VariableChange($"Причина списания:", tbReasone.Text, dtTmp.Rows[0]["Reason"].ToString());
                    Logging.Comment($"Статуса акта Id:{dtTmp.Rows[0]["Status"]}; Наименование:{dtTmp.Rows[0]["nameStatus"]}");
                }


                DataTable dtDataBody = readSQL.getContentWriteOff(id);
                if (dtDataBody != null && dtDataBody.Rows.Count > 0)
                {
                    Logging.Comment("Удаленные записи");

                    foreach (DataRow row in dtDataBody.Rows)
                    {
                        EnumerableRowCollection<DataRow> rowCollect = dtRowCollection.AsEnumerable()
                               .Where(r => r.Field<int>("id") == (int)row["id_Hardware"]);
                        if (rowCollect.Count() == 0)
                        {

                            Logging.Comment($"Id оборудования: {row["id_Hardware"]}");
                            Logging.Comment($"Инвентаризационный номер: {row["InventoryNumber"]}");
                            Logging.Comment($"EAN: {row["EAN"]}");
                            Logging.Comment($"Наименование: {row["cName"]}");
                            Logging.Comment($"Оборудование/комплектующие: {row["nameType"]}");
                            Logging.Comment($"Местоположение Id:{row["id_Location"]}; Наименование:{row["nameLocation"]}");
                            Logging.Comment($"Ответственный  Id:{row["id_Responsible"]}; ФИО:{row["FIO"]}");


                            dtResult = readSQL.setContentWriteOff((int)row["id_Hardware"], id, (int)row["id_Hardware"]);
                            if (dtResult == null || dtResult.Rows.Count == 0 || dtResult.Rows[0]["id"].ToString().Equals("-1"))
                            {
                                MessageBox.Show("Ошибка в работе процедуры!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Logging.StopFirstLevel();
                                return;
                            }
                        }
                        else
                        {
                            rowCollect.First().Delete();
                            dtRowCollection.AcceptChanges();
                        }
                    }

                    //foreach (DataRow row in rowCollection)
                    //{
                    //    EnumerableRowCollection<DataRow> rowCollect = dtDataBody.AsEnumerable()
                    //            .Where(r => r.Field<int>("id_Hardware") == (int)row["id"]);
                    //    if (rowCollect.Count() > 0)
                    //        rowCollect.First().Delete();
                    //}
                }

                readSQL.setActWriteOff(id, tbReasone.Text, false);
            }
            else
            {
                dtResult = readSQL.setActWriteOff(id, tbReasone.Text, false);

                if (dtResult == null || dtResult.Rows.Count == 0 || dtResult.Rows[0]["id"].ToString().Equals("-1"))
                {
                    MessageBox.Show("Ошибка в работе процедуры!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                id = (int)dtResult.Rows[0]["id"];

                DataTable dtTmp = readSQL.getActWriteOff(DateTime.Now, DateTime.Now, id);


                Logging.StartFirstLevel(17);
                Logging.Comment("Добавление акта списания");
                if (dtTmp != null && dtTmp.Rows.Count > 0)
                {
                    Logging.Comment("Заголовок акта:");
                    Logging.Comment($"Id акта: {id}");
                    Logging.Comment($"Номер акта: {dtTmp.Rows[0]["Number"]}");
                    Logging.Comment($"Дата создания акта: {dtTmp.Rows[0]["Date"]}");
                    Logging.Comment($"Причина списания: {dtTmp.Rows[0]["Reason"]}");
                    Logging.Comment($"Статуса акта Id:{dtTmp.Rows[0]["Status"]}; Наименование:{dtTmp.Rows[0]["nameStatus"]}");
                }
            }

            Logging.Comment(!isEdit ? "Содержимое акта:" : "Добавленные записи");

            foreach (DataRow row in dtRowCollection.Rows)
            {
                Logging.Comment($"Id оборудования: {row["id"]}");
                Logging.Comment($"Инвентаризационный номер: {row["InventoryNumber"]}");
                Logging.Comment($"EAN: {row["EAN"]}");
                Logging.Comment($"Наименование: {row["cName"]}");
                Logging.Comment($"Оборудование/комплектующие: {row["nameHardware"]}");
                Logging.Comment($"Местоположение Id:{row["id_Location"]}; Наименование:{row["nameLocation"]}");
                Logging.Comment($"Ответственный  Id:{row["id_Responsible"]}; ФИО:{row["FIO"]}");


                dtResult = readSQL.setContentWriteOff(0, id, (int)row["id"]);

                if (dtResult == null || dtResult.Rows.Count == 0 || dtResult.Rows[0]["id"].ToString().Equals("-1"))
                {
                    MessageBox.Show("Ошибка в работе процедуры!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logging.StopFirstLevel();
                    return;
                }
            }

            Logging.StopFirstLevel();

            if (DialogResult.Yes == MessageBox.Show(config.centralText("Вывести в Excel созданный акт\nсписания оборудования?\n"),"Печать акта списания оборудования",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2))
            {
                journalActWriteOff.printReport.printWriteOff(id);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void frmReasonActWriteOff_Load(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(btClose, "Выход");
            //tbReasone.Text = Reason;
            tbReasone.Text = config.Reason;
        }
    }
}
