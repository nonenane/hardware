using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.Connection;
using Nwuram.Framework.Settings.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hardWareViewer.Material
{
    public partial class frmList : Form
    {
        public bool isSelect { set; private get; }
        public bool isUpdate { private set; get; }
        private DataTable dtData;
        public frmList()
        {
            InitializeComponent();

            dgvData.AutoGenerateColumns = false;

            ToolTip tp = new ToolTip();
            tp.SetToolTip(btAdd, "Добавить");
            tp.SetToolTip(btEdit, "Редактировать");
            tp.SetToolTip(btDelete, "Удалить");
            tp.SetToolTip(btClose, "Выход");
            //btAdd.Visible = btEdit.Visible = btDelete.Visible = new List<string> { "ИНФ", "СОП" }.Contains(UserSettings.User.StatusCode);
        }

        private void frmList_Load(object sender, EventArgs e)
        {
            btSelect.Visible = isSelect;
            get_data();
        }

        private void frmList_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == new frmAdd() { Text = "Добавить тип расходного материала" }.ShowDialog())
            {
                get_data();
                isUpdate = true;
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                DataRowView row = dtData.DefaultView[dgvData.CurrentRow.Index];
                if (DialogResult.OK == new frmAdd() { Text = "Редактировать тип расходного материала", row = row }.ShowDialog())
                {
                    get_data();
                    isUpdate = true;
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                int id = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
                bool isActive = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"];
                string cName = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["cName"];
                int id_unit = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id_Units"];


                Task<DataTable> task = readSQL.SetMaterial(id, cName, id_unit, isActive, 0, true);
                task.Wait();

                if (task.Result == null)
                {
                    MessageBox.Show(config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int result = (int)task.Result.Rows[0]["id"];

                if (result == -1)
                {
                    MessageBox.Show(config.centralText("Запись уже удалена другим пользователем\n"), "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isUpdate = true;
                    get_data();
                    return;
                }

                if (result == -2 && isActive)
                {
                    if (DialogResult.Yes == MessageBox.Show(config.centralText("Выбранная для удаления запись\nиспользуется в программе.\nСделать запись недействующей?\n"), "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        //setLog(id, 1542);
                        task = readSQL.SetMaterial(id, cName, id_unit, !isActive, 0, false);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        isUpdate = true;
                        get_data();
                        return;
                    }
                }
                else
                if (result == 0 && isActive)
                {
                    if (DialogResult.Yes == MessageBox.Show("Удалить выбранную запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        //setLog(id, 1566);
                        task = readSQL.SetMaterial(id, cName, id_unit, isActive, 1, true);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        isUpdate = true;
                        get_data();
                        return;
                    }
                }
                else if (!isActive)
                {
                    if (DialogResult.Yes == MessageBox.Show("Сделать выбранную запись действующей?", "Восстановление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        //setLog(id, 1543);
                        task = readSQL.SetMaterial(id, cName, id_unit, !isActive, 0, false);
                        task.Wait();
                        if (task.Result == null)
                        {
                            MessageBox.Show(config.centralText("При сохранение данных возникли ошибки записи.\nОбратитесь в ОЭЭС\n"), "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        isUpdate = true;
                        get_data();
                        return;
                    }
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void chbNotActive_CheckedChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void setFilter()
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                btSelect.Enabled = btPrint.Enabled = btEdit.Enabled = btDelete.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if (tbName.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"cName like '%{tbName.Text.Trim()}%'";
                               
                if (!chbNotActive.Checked)
                    filter += (filter.Length == 0 ? "" : " and ") + $"isActive = 1";

                dtData.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                btSelect.Enabled = btPrint.Enabled = btEdit.Enabled = btDelete.Enabled =
                dtData.DefaultView.Count != 0;
                dgvData_SelectionChanged(null, null);
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null || dgvData.CurrentRow.Index == -1 || dtData == null || dtData.DefaultView.Count == 0 || dgvData.CurrentRow.Index >= dtData.DefaultView.Count)
            {
                btDelete.Enabled = false;
                btEdit.Enabled = false;
                return;
            }

            btDelete.Enabled = true;
            btEdit.Enabled = (bool)dtData.DefaultView[dgvData.CurrentRow.Index]["isActive"];
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
                if (!(bool)dtData.DefaultView[e.RowIndex]["isActive"])
                    rColor = panel1.BackColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;

            }
        }

        private void get_data()
        {
            Task.Run(() =>
            {
                config.DoOnUIThread(() => { this.Enabled = false; }, this);

                Task<DataTable> task = readSQL.GetMaterial();
                task.Wait();
                dtData = task.Result;

                config.DoOnUIThread(() =>
                {
                    DataGridViewColumn oldCol = dgvData.SortedColumn;
                    ListSortDirection direction = ListSortDirection.Ascending;
                    if (oldCol != null)
                    {
                        if (dgvData.SortOrder == SortOrder.Ascending)
                        {
                            direction = ListSortDirection.Ascending;
                        }
                        else
                        {
                            direction = ListSortDirection.Descending;
                        }
                    }
                    setFilter();
                    dgvData.DataSource = dtData;


                    if (oldCol != null)
                    {
                        dgvData.Sort(oldCol, direction);
                        oldCol.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;
                    }

                }, this);

                config.DoOnUIThread(() => { this.Enabled = true; }, this);
            });
        }

        private void setLog(int id, int id_log)
        {
            Logging.StartFirstLevel(id_log);
            switch (id_log)
            {
                case 2: Logging.Comment("Удаление Типа документа"); break;
                case 3: Logging.Comment("Тип документа переведён в недействующие "); break;
                case 4: Logging.Comment("Тип документа переведён  в действующие"); break;
                default: break;
            }

            string cName = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["cName"];

            Logging.Comment($"ID:{id}");
            Logging.Comment($"Наименование: {cName}");

            Logging.StopFirstLevel();
        }

        private void dgvData_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cName.Name))
                {
                    tbName.Location = new Point(dgvData.Location.X + 1 + width, tbName.Location.Y);
                    tbName.Size = new Size(cName.Width, tbName.Height);
                }
               
                width += col.Width;

            }
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            if (dtData == null) return;
            if (dtData.DefaultView.Count == 0) return;

            DataRowView row = dtData.DefaultView[dgvData.CurrentRow.Index];
            material.id = (int)row["id"];
            material.cName = (string)row["cName"];
            material.cNameUnit = (string)row["cNameUnit"];
            material.id_unit = (int)row["id_Units"];
            
            this.DialogResult = DialogResult.OK;
        }

        private Nwuram.Framework.UI.Service.EnableControlsServiceInProg blockers = new Nwuram.Framework.UI.Service.EnableControlsServiceInProg();
        private Nwuram.Framework.ToExcelNew.ExcelUnLoad report = null;

        private void setWidthColumn(int indexRow, int indexCol, int width, Nwuram.Framework.ToExcelNew.ExcelUnLoad report)
        {
            report.SetColumnWidth(indexRow, indexCol, indexRow, indexCol, width);
        }

        private async void btPrint_Click(object sender, EventArgs e)
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
                        if (col.Name.Equals(cName.Name)) setWidthColumn(indexRow, maxColumns, 37, report);
                        if (col.Name.Equals(cUnit.Name)) setWidthColumn(indexRow, maxColumns, 17, report);
                    }


                #region "Head"
                report.Merge(indexRow, 1, indexRow, maxColumns);
                report.SetWrapText(indexRow, 1, indexRow, 1);
                report.SetRowHeight(indexRow, 1, indexRow, 1, 45);
                report.AddSingleValue($"{this.Text}", indexRow, 1);
                report.SetFontBold(indexRow, 1, indexRow, 1);
                report.SetFontSize(indexRow, 1, indexRow, 1, 16);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
                indexRow++;
                indexRow++;

                config.DoOnUIThread(() =>
                {
                    //report.Merge(indexRow, 1, indexRow, maxColumns);
                    //report.AddSingleValue($"Период с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()} ", indexRow, 1);
                    //indexRow++;

                    //report.Merge(indexRow, 1, indexRow, maxColumns);
                    //report.AddSingleValue($"Объект: {cmbObject.Text}", indexRow, 1);
                    //indexRow++;

                    //report.Merge(indexRow, 1, indexRow, maxColumns);
                    //report.AddSingleValue($"Тип договора: {cmbTypeDoc.Text}", indexRow, 1);
                    //indexRow++;


                    if (tbName.Text.Trim().Length != 0 )
                    {
                        report.Merge(indexRow, 1, indexRow, maxColumns);
                        report.AddSingleValue($"Фильтр: {(tbName.Text.Trim().Length != 0 ? $"EAN:{tbName.Text.Trim()} " : "")}", indexRow, 1);
                        indexRow++;
                    }

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

                    if (!(bool)row["isActive"])
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
    }
}