using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hardWareViewer.listHardware
{
    public partial class frmReportHistory : Form
    {
        public frmReportHistory()
        {
            InitializeComponent();

            dtpStart.Value = DateTime.Now.AddDays(-7);

            DataTable dtTypeReport = new DataTable();
            dtTypeReport.Columns.Add("id",typeof(Int32));
            dtTypeReport.Columns.Add("cName", typeof(string));
            dtTypeReport.Rows.Add(1, "Вывести измененные");
            dtTypeReport.Rows.Add(2, "Вывести удалённые");
            dtTypeReport.Rows.Add(3, "Вывести изменённые и удалённые");

            cmbType.DataSource = dtTypeReport;
            cmbType.DisplayMember = "cName";
            cmbType.ValueMember = "id";
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtReport_Click(object sender, EventArgs e)
        {
            Logging.StartFirstLevel(79);
            Logging.Comment("Выгрузка отчета по изменению для всего оборудования");
            Logging.Comment($"Период с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()}");
            Logging.Comment($"Параметры формирования отчета:{cmbType.Text}");           
            Logging.StopFirstLevel();

            //reportHistory.createReport();
            reportHistory.createReport(0, dtpStart.Value, dtpEnd.Value, cmbType.Text, (int)cmbType.SelectedValue,null);
        }

        private void DtpStart_ValueChanged(object sender, EventArgs e)
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

        private void DtpEnd_ValueChanged(object sender, EventArgs e)
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
