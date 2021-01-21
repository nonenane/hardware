using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hardWareViewer.scaners
{
    public partial class frmContScaner : Form
    {
        public frmContScaner()
        {
            InitializeComponent();
            dgvScaner.AutoGenerateColumns = false;
            btDrop.Visible = btTake.Visible = btSettings.Visible = config.statusCode.Equals("оп");
        }

        private void frmContScaner_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            scaners.frmSettings frmS = new scaners.frmSettings();
            frmS.ShowDialog();
        }

        private void btDrop_Click(object sender, EventArgs e)
        {
            frmWahKey frmScaner = new frmWahKey();
            frmScaner.setGet(false);
            //if (DialogResult.OK == frmScaner.ShowDialog())
            if (DialogResult.Cancel == frmScaner.ShowDialog())
                getData();
        }

        private void btTake_Click(object sender, EventArgs e)
        {
            frmWahKey frmScaner = new frmWahKey();
            frmScaner.setGet(true);
            //if (DialogResult.OK == frmScaner.ShowDialog())
            if (DialogResult.Cancel == frmScaner.ShowDialog())
                getData();            
        }

        DataTable dtJournalScaner;
        private void getData()
        {
            dtJournalScaner = readSQL.getInOutScan(dtpStart.Value, dtpEnd.Value);
            setFilter();
            dgvScaner.DataSource = dtJournalScaner;
        }

        private void setFilter()
        {
            if (dtJournalScaner != null)
            {
                string _filter = "";
                try
                {
                    if (tbNumRoom.Text.Trim().Length != 0)
                        _filter += (_filter.Trim().Length == 0 ? "" : " AND ") + string.Format("CONVERT(InventoryNumber,'System.String') like '%{0}%'", tbNumRoom.Text);

                    if (tbCodeKey.Text.Trim().Length != 0)
                        _filter += (_filter.Trim().Length == 0 ? "" : " AND ") + string.Format("CONVERT(EAN,'System.String') like '%{0}%'", tbCodeKey.Text);

                    if (tbFioTake.Text.Trim().Length != 0)
                        _filter += (_filter.Trim().Length == 0 ? "" : " AND ") + string.Format("CONVERT(nameOut,'System.String') like '%{0}%'", tbFioTake.Text);

                    if (tbNameScaner.Text.Trim().Length != 0)
                        _filter += (_filter.Trim().Length == 0 ? "" : " AND ") + string.Format("CONVERT(cName,'System.String') like '%{0}%'", tbNameScaner.Text);

                    if (tbFioOut.Text.Trim().Length != 0)
                        _filter += (_filter.Trim().Length == 0 ? "" : " AND ") + string.Format("CONVERT(nameGet,'System.String') like '%{0}%'", tbFioOut.Text);

                    if (tbNameDeps.Text.Trim().Length != 0)
                        _filter += (_filter.Trim().Length == 0 ? "" : " AND ") + string.Format("CONVERT(nameDeps,'System.String') like '%{0}%'", tbNameDeps.Text);

                    if (tbNameLocation.Text.Trim().Length != 0)
                        _filter += (_filter.Trim().Length == 0 ? "" : " AND ") + string.Format("CONVERT(nameLocation,'System.String') like '%{0}%'", tbNameLocation.Text);

                    if (chbNotGet.Checked)
                        _filter += (_filter.Trim().Length == 0 ? "" : " AND ") + "DateGet is null and DateOut is not null";

                    dtJournalScaner.DefaultView.RowFilter = _filter;
                }
                catch
                {
                    _filter = "id  = -1";
                    dtJournalScaner.DefaultView.RowFilter = _filter;
                }


                //dtKeys.DefaultView.Sort = "namePost ASC,FIO ASC";
                //btDelete.Enabled = dtKeys.DefaultView.Count != 0;
                dgvScaner_SelectionChanged(null, null);
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void dgvScaner_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvScaner.CurrentRow != null && dgvScaner.CurrentRow.Index != -1 && dtJournalScaner.DefaultView.Count != 0)
            {
                tbController.Text = dtJournalScaner.DefaultView[dgvScaner.CurrentRow.Index]["FIO"].ToString();
                btExcel.Enabled = true;
            }
            else
            {
                tbController.Text = "";
                btExcel.Enabled = false;
            }
        }

        private void chbNotGet_CheckedChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void tbNumRoom_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void dtpStart_Leave(object sender, EventArgs e)
        {
            getData();
        }

        private void dtpEnd_Leave(object sender, EventArgs e)
        {
            getData();
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            Logging.StartFirstLevel(79);

            Logging.Comment("Произведена выгрузка в Excel отчета «Отчет по сканерам»");

            Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                        + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
            Logging.StopFirstLevel();

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad("Лист - 1");
            report.SetPageOrientationToLandscape();

            int indexRow = 1;

            report.Merge(indexRow, 1, indexRow, 9);
            report.AddSingleValue("Отчёт по сканерам", indexRow, 1);
            report.SetCellAlignmentToJustify(indexRow, 1, indexRow, 3);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 3);
            report.SetFontSize(indexRow, 1, indexRow, 1, 16);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 9);
            report.AddSingleValue("Период с : " + dtpStart.Value.ToShortDateString() + " по: " + dtpEnd.Value.ToShortDateString(), indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 9);
            report.AddSingleValue("Выгрузил: " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername, indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 9);
            report.AddSingleValue("Дата выгрузки: " + DateTime.Now.ToString(), indexRow, 1);
            indexRow++;
            indexRow++;
            indexRow++;

            int indexColum = 1;
            foreach(DataGridViewColumn col in dgvScaner.Columns)
            {
                report.AddSingleValue(col.HeaderText, indexRow, indexColum);                
                indexColum++;
                if (col.Name.Equals("cTimeDrop"))
                {
                    report.AddSingleValue("Сканер Выдал", indexRow, indexColum);
                    indexColum++;
                }
            }

            //report.AddSingleValue("№ кабинета", indexRow, 1);
            //report.AddSingleValue("Код ключа", indexRow, 2);
            //report.AddSingleValue("ОТдел", indexRow, 3);
            //report.AddSingleValue("ФИО взял ключ", indexRow, 4);
            //report.AddSingleValue("Время выдачи ключа", indexRow, 5);
            //report.AddSingleValue("ФИО ключ вернул", indexRow, 6);
            //report.AddSingleValue("Время возврата ключа", indexRow, 7);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, indexColum-1);
            report.SetBorders(indexRow, 1, indexRow, indexColum-1);
            indexRow++;

            foreach (DataRowView r in dtJournalScaner.DefaultView)
            {
                report.AddSingleValue(r["InventoryNumber"].ToString(), indexRow, 1);
                report.AddSingleValue(r["EAN"].ToString(), indexRow, 2);
                report.AddSingleValue(r["cName"].ToString(), indexRow, 3);
                report.AddSingleValue(r["nameOut"].ToString(), indexRow, 4);
                report.AddSingleValue(r["nameDeps"].ToString(), indexRow, 5);
                report.AddSingleValue(r["DateOut"].ToString(), indexRow, 6);
                report.AddSingleValue(r["FIO"].ToString(), indexRow, 7);
                report.AddSingleValue(r["nameGet"].ToString(), indexRow, 8);
                report.AddSingleValue(r["DateGet"].ToString(), indexRow, 9);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 9);
                report.SetBorders(indexRow, 1, indexRow, 9);
                indexRow++;
            }


            report.SetColumnAutoSize(1, 1, indexRow - 1, 9);
            report.Show();
        }

        private void btListScaner_Click(object sender, EventArgs e)
        {
            new frmListScaners().ShowDialog();
        }

        private void tbNameLocation_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }
    }
}
