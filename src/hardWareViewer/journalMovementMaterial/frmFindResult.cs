using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hardWareViewer.journalMovementMaterial
{
    public partial class frmFindResult : Form
    {
        private Nwuram.Framework.UI.Service.EnableControlsServiceInProg blockers = new Nwuram.Framework.UI.Service.EnableControlsServiceInProg();
        private Nwuram.Framework.ToExcelNew.ExcelUnLoad report = null;

        public DataTable dtData { set; private get; }
        public frmFindResult()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
        }

        private void frmFindResult_Load(object sender, EventArgs e)
        {
            DataTable dtTypeOperation = readSQL.GetTypeOperation(true);
            cmbTypeOperation.DataSource = dtTypeOperation;
            cmbTypeOperation.DisplayMember = "cName";
            cmbTypeOperation.ValueMember = "id";

            setFilterOst();
            dgvData.DataSource = dtData;
        }

        private void setFilterOst()
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                btPrint.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if (tbMat.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"nameMat like '%{tbMat.Text.Trim()}%'";

                if (tbMol.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"cNameMol like '%{tbMol.Text.Trim()}%'";

                if (tbComment.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"Comment like '%{tbComment.Text.Trim()}%'";

                if ((int)cmbTypeOperation.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_TypeOperation = {cmbTypeOperation.SelectedValue}";

                dtData.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                 btPrint.Enabled =
               dtData.DefaultView.Count != 0;
                dgvData_SelectionChanged(null, null);
            }
        }

        private void setWidthColumn(int indexRow, int indexCol, int width, Nwuram.Framework.ToExcelNew.ExcelUnLoad report)
        {
            report.SetColumnWidth(indexRow, indexCol, indexRow, indexCol, width);
        }


        private async void btOstView_Click(object sender, EventArgs e)
        {

            if (dtData == null || dtData.Rows.Count == 0 || dtData.DefaultView.Count == 0)
            {
                MessageBox.Show("Нет данных для формирования отчёта.", "Печать", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();

            int indexRow = 1;
            int maxColumns = 0;
            blockers.SaveControlsEnabledState(this);
            blockers.SetControlsEnabled(this, false);
            //progressBar1.Visible = true;
            var result = await Task<bool>.Factory.StartNew(() =>
            {

                foreach (DataGridViewColumn col in dgvData.Columns)
                    if (col.Visible)
                    {
                        maxColumns++;
                        if (col.Name.Equals(cJouDate.Name)) setWidthColumn(indexRow, maxColumns, 37, report);
                        if (col.Name.Equals(cJouMaterial.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
                        if (col.Name.Equals(cJouMol.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
                        if (col.Name.Equals(cJouCount.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
                        if (col.Name.Equals(cJouComment.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
                        if (col.Name.Equals(cJouType.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
                    }


                #region "Head"
                report.Merge(indexRow, 1, indexRow, maxColumns);
                report.AddSingleValue($"Остатки расходных материалов", indexRow, 1);
                report.SetFontBold(indexRow, 1, indexRow, 1);
                report.SetFontSize(indexRow, 1, indexRow, 1, 16);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
                indexRow++;
                indexRow++;

                config.DoOnUIThread(() =>
                {
                    report.Merge(indexRow, 1, indexRow, maxColumns);
                    report.AddSingleValue($"Тип операции {cmbTypeOperation.Text} ", indexRow, 1);
                    indexRow++;
                }, this);

                report.Merge(indexRow, 1, indexRow, maxColumns);
                report.AddSingleValue("Выгрузил: " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername, indexRow, 1);
                indexRow++;

                report.Merge(indexRow, 1, indexRow, maxColumns);
                report.AddSingleValue("Дата выгрузки: " + DateTime.Now.ToString(), indexRow, 1);
                indexRow++;
                indexRow++;
                #endregion

                int indexCol = 0;
                foreach (DataGridViewColumn col in dgvData.Columns)
                    if (col.Visible)
                    {
                        indexCol++;
                        report.AddSingleValue(col.HeaderText, indexRow, indexCol);
                    }
                report.SetFontBold(indexRow, 1, indexRow, maxColumns);
                report.SetBorders(indexRow, 1, indexRow, maxColumns);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);
                report.SetWrapText(indexRow, 1, indexRow, maxColumns);
                indexRow++;

                foreach (DataRowView row in dtData.DefaultView)
                {
                    indexCol = 1;
                    report.SetWrapText(indexRow, indexCol, indexRow, maxColumns);
                    foreach (DataGridViewColumn col in dgvData.Columns)
                    {
                        if (col.Visible)
                        {
                            if (row[col.DataPropertyName] is DateTime)
                                report.AddSingleValue(((DateTime)row[col.DataPropertyName]).ToShortDateString(), indexRow, indexCol);
                            else
                               if (row[col.DataPropertyName] is decimal || row[col.DataPropertyName] is double)
                            {
                                report.AddSingleValueObject(row[col.DataPropertyName], indexRow, indexCol);
                                report.SetFormat(indexRow, indexCol, indexRow, indexCol, "0.00");
                            }
                            else
                                report.AddSingleValue(row[col.DataPropertyName].ToString(), indexRow, indexCol);

                            indexCol++;
                        }
                    }

                    report.SetBorders(indexRow, 1, indexRow, maxColumns);
                    report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                    report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);

                    indexRow++;
                }

                config.DoOnUIThread(() =>
                {
                    blockers.RestoreControlEnabledState(this);
                    //progressBar1.Visible = false;
                }, this);

                report.Show();
                return true;
            });
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dgvData_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cJouMaterial.Name))
                {
                    tbMat.Location = new Point(dgvData.Location.X + 1 + width, tbMat.Location.Y);
                    tbMat.Size = new Size(col.Width, tbMat.Height);
                }

                if (col.Name.Equals(cJouMol.Name))
                {
                    tbMol.Location = new Point(dgvData.Location.X + 1 + width, tbMat.Location.Y);
                    tbMol.Size = new Size(col.Width, tbMat.Height);
                }

                if (col.Name.Equals(cJouComment.Name))
                {
                    tbComment.Location = new Point(dgvData.Location.X + 1 + width, tbMat.Location.Y);
                    tbComment.Size = new Size(col.Width, tbMat.Height);
                }

                width += col.Width;

            }
        }

        private void tbMat_TextChanged(object sender, EventArgs e)
        {
            setFilterOst();
        }

        private void cmbTypeOperation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilterOst();
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dtData == null || dtData.Rows.Count == 0 || dtData.DefaultView.Count == 0 || dgvData.CurrentRow==null || dgvData.CurrentRow.Index==-1)
            {
                tbFIO.Text = tbDateEdit.Text = "";
                return;
            }

            try
            {
                DataRowView row = dtData.DefaultView[dgvData.CurrentRow.Index];
                tbFIO.Text = (string)row["FIO"];
                tbDateEdit.Text = ((DateTime)row["DateEdit"]).ToString();
            }
            catch {
                tbFIO.Text = tbDateEdit.Text = "";
            }
        }
    }
}
