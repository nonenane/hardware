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
    public partial class frmViewActWriteOff : Form
    {
        private int id_actWriteOff = -1;
        private bool isView = false;
        
        public void setRow(DataRowView _row)
        {
            tbDateCreate.Text = DateTime.Parse(_row["Date"].ToString()).ToShortDateString();

            if (_row["DateWriteOff"] != DBNull.Value)
                tbDateWriteOff.Text = DateTime.Parse(_row["DateWriteOff"].ToString()).ToShortDateString();

            tbStatusName.Text = _row["nameStatus"].ToString();
            tbReason.Text = _row["Reason"].ToString();

            id_actWriteOff = int.Parse(_row["id"].ToString());
            get_data();
        }


        public frmViewActWriteOff()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            get_data();
        }

        private DataTable dtData;
        private void get_data()
        {
            dtData = readSQL.getContentWriteOff(id_actWriteOff);
            dgvData.DataSource = dtData;
            btPrint.Enabled = dtData != null && dtData.Rows.Count > 0;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btAddDoc_Click(object sender, EventArgs e)
        {
            frmAddDoc frm = new frmAddDoc();
            frm.setId_journal(id_actWriteOff);
            frm.setTypeScan(3);
            frm.ShowDialog();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
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
}
