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
    public partial class frmList : Form
    {
        private Nwuram.Framework.UI.Service.EnableControlsServiceInProg blockers = new Nwuram.Framework.UI.Service.EnableControlsServiceInProg();
        private Nwuram.Framework.ToExcelNew.ExcelUnLoad report = null;

        #region "Main"
        public frmList()
        {
            InitializeComponent();
            dgvOst.AutoGenerateColumns = false;
            dgvJour.AutoGenerateColumns = false;
        }

        private void frmList_Load(object sender, EventArgs e)
        {
            initTypeOperation();
            getJouData();
        }

        private void frmList_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void initTypeOperation()
        {
            DataTable dtTypeOperation = readSQL.GetTypeOperation(true);
            cmbTypeOperation.DataSource = dtTypeOperation;
            cmbTypeOperation.DisplayMember = "cName";
            cmbTypeOperation.ValueMember = "id";
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
                dtpEnd.Value = dtpStart.Value.Date;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
                dtpStart.Value = dtpEnd.Value.Date;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {           
            getJouData();
        }

        private void setWidthColumn(int indexRow, int indexCol, int width, Nwuram.Framework.ToExcelNew.ExcelUnLoad report)
        {
            report.SetColumnWidth(indexRow, indexCol, indexRow, indexCol, width);
        }

        #endregion

        #region "Расчёт остатков"
        private DataTable dtOst;
        private void getOstData()
        {
            dtOst = readSQL.GetMetrialOstOnDate(dtpOstDate.Value.Date);
            setFilterOst();
            dgvOst.DataSource = dtOst;
        }

        private void dgvOst_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;
            foreach (DataGridViewColumn col in dgvOst.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cMatName.Name))
                {
                    tbOstName.Location = new Point(dgvOst.Location.X + 1 + width, tbOstName.Location.Y);
                    tbOstName.Size = new Size(col.Width, tbOstName.Height);
                }

                if (col.Name.Equals(cMatMol.Name))
                {
                    tbOstMol.Location = new Point(dgvOst.Location.X + 1 + width, tbOstName.Location.Y);
                    tbOstMol.Size = new Size(col.Width, tbOstName.Height);
                }

                width += col.Width;

            }
        }

        private void chbNotActive_CheckedChanged(object sender, EventArgs e)
        {
            setFilterOst();
        }

        private void tbOstName_TextChanged(object sender, EventArgs e)
        {
            setFilterOst();
        }

        private void setFilterOst()
        {
            if (dtOst == null || dtOst.Rows.Count == 0)
            {
                btOstPrint.Enabled =  false;
                return;
            }

            try
            {
                string filter = "";

                if (tbOstName.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"cName like '%{tbOstName.Text.Trim()}%'";

                if (tbOstMol.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"cNameMol like '%{tbOstMol.Text.Trim()}%'";

                if (!chbNotActive.Checked)
                    filter += (filter.Length == 0 ? "" : " and ") + $"ostNow > 0";

                dtOst.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtOst.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                btOstPrint.Enabled = 
                dtOst.DefaultView.Count != 0;                
            }
        }

        private void dgvOst_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtOst != null && dtOst.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                if ((decimal)dtOst.DefaultView[e.RowIndex]["ostNow"]<0)
                    rColor = panel1.BackColor;
                dgvOst.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvOst.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvOst.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;

            }
        }

        private void dgvOst_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private async void btOstPrint_Click(object sender, EventArgs e)
        {
            if (dtOst == null || dtOst.Rows.Count == 0 || dtOst.DefaultView.Count == 0)
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

                foreach (DataGridViewColumn col in dgvOst.Columns)
                    if (col.Visible)
                    {
                        maxColumns++;
                        if (col.Name.Equals(cMatName.Name)) setWidthColumn(indexRow, maxColumns, 37, report);
                        if (col.Name.Equals(cMatMol.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
                        if (col.Name.Equals(cMatOstNow.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
                        if (col.Name.Equals(cMatOstDate.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
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
                    report.AddSingleValue($"Остатки на дату {dtpOstDate.Value.ToShortDateString()} ", indexRow, 1);
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
                foreach (DataGridViewColumn col in dgvOst.Columns)
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

                foreach (DataRowView row in dtOst.DefaultView)
                {
                    indexCol = 1;
                    report.SetWrapText(indexRow, indexCol, indexRow, maxColumns);
                    foreach (DataGridViewColumn col in dgvOst.Columns)
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

                    if ((decimal)row["ostNow"]<0)
                        report.SetCellColor(indexRow, 1, indexRow, maxColumns, panel1.BackColor);

                    report.SetBorders(indexRow, 1, indexRow, maxColumns);
                    report.SetCellAlignmentToCenter(indexRow, 1, indexRow, maxColumns);
                    report.SetCellAlignmentToJustify(indexRow, 1, indexRow, maxColumns);

                    indexRow++;
                }

                indexRow++;
                report.SetCellColor(indexRow, 1, indexRow, 1, panel1.BackColor);
                report.Merge(indexRow, 2, indexRow, maxColumns);
                report.AddSingleValue($"{chbNotActive.Text}", indexRow, 2);

                config.DoOnUIThread(() =>
                {
                    blockers.RestoreControlEnabledState(this);
                    //progressBar1.Visible = false;
                }, this);

                report.Show();
                return true;
            });
        }

        private void btOstView_Click(object sender, EventArgs e)
        {
            new frmFind().ShowDialog();
        }

        #endregion

        #region "Журнал движения"
        DataTable dtJour;
        private void getJouData()
        {
            dtJour = readSQL.GetTMovementMaterial(dtpStart.Value.Date, dtpEnd.Value.Date);            
            setFilterJour();
            dgvJour.DataSource = dtJour;
            if (dtJour != null && dtJour.Rows.Count != 0)
                getOstData();
            else
            {
                if (dtOst != null)
                    dtOst.Rows.Clear();
                dgvOst.DataSource = null;
                setFilterOst();                
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            new MovementMaterial.frmAddMovementMaterial() { Text = "Добавить движение расходного материала" }.ShowDialog();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            DataRowView row = dtJour.DefaultView[dgvJour.CurrentRow.Index];
            new MovementMaterial.frmAddMovementMaterial() { Text = "Редактировать движение расходного материала", row = row }.ShowDialog();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            int id = (int)dtJour.DefaultView[dgvJour.CurrentRow.Index]["id"];

            DataTable dtResult = readSQL.DelTMovementMaterial(id, 0);

            if (dtResult == null || dtResult.Rows.Count==0)
            {
                MessageBox.Show(config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int result = (int)dtResult.Rows[0]["id"];

            if (result == -1)
            {
                MessageBox.Show(config.centralText("Запись уже удалена другим пользователем\n"), "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getJouData();
                return;
            }

            if (DialogResult.Yes == MessageBox.Show(config.centralText("Удалить выбранную запись\nи связанные с ней записи по движению товара?\n"), "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                dtResult = readSQL.DelTMovementMaterial(id, 1);
                getJouData();
                return;
            }
        }

        private async void btPrint_Click(object sender, EventArgs e)
        {

            if (dtJour == null || dtJour.Rows.Count == 0 || dtJour.DefaultView.Count == 0)
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

                foreach (DataGridViewColumn col in dgvJour.Columns)
                    if (col.Visible)
                    {
                        maxColumns++;
                        if (col.Name.Equals(cJouDate.Name)) setWidthColumn(indexRow, maxColumns, 37, report);
                        if (col.Name.Equals(cJouNumber.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
                        if (col.Name.Equals(cJouMol.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
                        if (col.Name.Equals(cJouCount.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
                        if (col.Name.Equals(cJouComment.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
                        if (col.Name.Equals(cJouType.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
                    }


                #region "Head"
                report.Merge(indexRow, 1, indexRow, maxColumns);
                report.AddSingleValue($"Движение расходных материалов", indexRow, 1);
                report.SetFontBold(indexRow, 1, indexRow, 1);
                report.SetFontSize(indexRow, 1, indexRow, 1, 16);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
                indexRow++;
                indexRow++;

                config.DoOnUIThread(() =>
                {
                    report.Merge(indexRow, 1, indexRow, maxColumns);
                    report.AddSingleValue($"Период с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()}", indexRow, 1);
                    indexRow++;

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
                foreach (DataGridViewColumn col in dgvJour.Columns)
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

                foreach (DataRowView row in dtJour.DefaultView)
                {
                    indexCol = 1;
                    report.SetWrapText(indexRow, indexCol, indexRow, maxColumns);
                    foreach (DataGridViewColumn col in dgvJour.Columns)
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

        private void dgvJour_SelectionChanged(object sender, EventArgs e)
        {
            if (dtJour == null || dtJour.Rows.Count == 0 || dtJour.DefaultView.Count == 0 || dgvJour.CurrentRow == null || dgvJour.CurrentRow.Index == -1)
            {
                tbFIO.Text = tbDateEdit.Text = "";
                return;
            }

            try
            {
                DataRowView row = dtJour.DefaultView[dgvJour.CurrentRow.Index];
                tbFIO.Text = (string)row["FIO"];
                tbDateEdit.Text = ((DateTime)row["DateEdit"]).ToString();
            }
            catch
            {
                tbFIO.Text = tbDateEdit.Text = "";
            }
        }

        private void dgvJour_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;
            foreach (DataGridViewColumn col in dgvJour.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cJouNumber.Name))
                {
                    tbJourNum.Location = new Point(dgvJour.Location.X + 1 + width, tbJourNum.Location.Y);
                    tbJourNum.Size = new Size(col.Width, tbJourNum.Height);
                }

                if (col.Name.Equals(cJouMol.Name))
                {
                    tbJourMol.Location = new Point(dgvJour.Location.X + 1 + width, tbJourNum.Location.Y);
                    tbJourMol.Size = new Size(col.Width, tbJourNum.Height);
                }

                if (col.Name.Equals(cJouComment.Name))
                {
                    tbJourComment.Location = new Point(dgvJour.Location.X + 1 + width, tbJourNum.Location.Y);
                    tbJourComment.Size = new Size(col.Width, tbJourNum.Height);
                }

                width += col.Width;

            }
        }

        private void tbJourNum_TextChanged(object sender, EventArgs e)
        {
            setFilterJour();
        }

        private void cmbTypeOperation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setFilterJour();
        }

        private void setFilterJour()
        {
            if (dtJour == null || dtJour.Rows.Count == 0)
            {
                btEdit.Enabled = btDel.Enabled = btPrint.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if (tbJourNum.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"NumberBase like '%{tbJourNum.Text.Trim()}%'";

                if (tbJourMol.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"cNameMol like '%{tbJourMol.Text.Trim()}%'";

                if (tbJourComment.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"Comment like '%{tbJourComment.Text.Trim()}%'";

                if ((int)cmbTypeOperation.SelectedValue != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"id_TypeOperation = {cmbTypeOperation.SelectedValue}";

                dtJour.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtJour.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                btEdit.Enabled = btDel.Enabled = btPrint.Enabled =
                dtJour.DefaultView.Count != 0;
                dgvJour_SelectionChanged(null, null);
            }
        }

        #endregion

    }
}
