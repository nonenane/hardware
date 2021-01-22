using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hardWareViewer.MovementMaterial
{
    public partial class frmAddMovementMaterial : Form
    {

        public DataRowView row { set; private get; }

        private int id;
        private bool isEditData = false;
        private DataTable dtData = new DataTable();
        private List<int> listToDel = new List<int>();
        public frmAddMovementMaterial()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            id = -1;
        }

        private void frmAddMovementMaterial_Load(object sender, EventArgs e)
        {
            listToDel = new List<int>();
            DataTable dtTypeOperation = readSQL.GetTypeOperation(false);
            cmbTypeOperation.DataSource = dtTypeOperation;
            cmbTypeOperation.DisplayMember = "cName";
            cmbTypeOperation.ValueMember = "id";
            cmbTypeOperation.SelectedIndex = -1;

            DataTable dtTypeBasic = readSQL.GetTypeBasic(false);
            cmbTypeBasic.DataSource = dtTypeBasic;
            cmbTypeBasic.DisplayMember = "cName";
            cmbTypeBasic.ValueMember = "id";

           

            if (row!=null)
            {
                id = (int)row["id"];
                cmbTypeOperation.SelectedValue = (int)row["id_TypeOperation"];
                cmbTypeBasic.SelectedValue = (int)row["idBasis"];
                dtpDate.Value = (DateTime)row["DateMovement"];
                dtpYear.Value = (DateTime)row["YearBasis"];
                tbNumberBase.Text = (string)row["NumberBase"];
                tbComment.Text = (string)row["Comment"];
            }
            dtData = readSQL.GetMovementMaterial(id);
            setFilter();
            dgvData.DataSource = dtData;

            isEditData = false;
        }

        private void frmAddMovementMaterial_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            if (cmbTypeOperation.SelectedIndex==-1)
            {
                MessageBox.Show(config.centralText($"Необходимо выбрать\n \"{label2.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTypeOperation.Focus();
                return;
            }

            if (tbNumberBase.Text.Trim().Length == 0)
            {
                MessageBox.Show(config.centralText($"Необходимо заполнить\n \"{label5.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNumberBase.Focus();
                return;
            }

            if (dtData == null || dtData.Rows.Count == 0)
            {
                MessageBox.Show(config.centralText("Отсутствуют записи\nо движении расходных материалов.\nСохранение невозможно.\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime DateMovement = dtpDate.Value.Date;
            int id_TypeOperation = (int)cmbTypeOperation.SelectedValue;
            DateTime YearBasis = DateTime.Parse($"{dtpYear.Value.Year}-01-01");
            string NumberBase = tbNumberBase.Text;
            int idBasis = (int)cmbTypeBasic.SelectedValue;
            string Comment = tbComment.Text;

            DataTable dtValidate = readSQL.ValidateLinkToNumberDoc(YearBasis, int.Parse(NumberBase), idBasis);
            if (dtValidate == null || dtValidate.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось получить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(bool)dtValidate.Rows[0]["rowIsExists"])
            {
                MessageBox.Show(config.centralText("Документ с введённым\nномером нет за указанный год.\nСохранение невозможно.\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DataTable dtResult = readSQL.SetTMovementMaterial(id, DateMovement, id_TypeOperation, YearBasis, NumberBase, idBasis, Comment);
            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if ((int)dtResult.Rows[0]["id"] == -1)
            {                
                MessageBox.Show(config.centralText($"{dtResult.Rows[0]["msg"].ToString().Replace("\\n", "\n")}"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)dtResult.Rows[0]["id"] == -9999)
            {
                MessageBox.Show($"{dtResult.Rows[0]["msg"]}", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = (int)dtResult.Rows[0]["id"];
            int id_tMovementMaterial = id;

            foreach (int delId in listToDel)
            {
                readSQL.DelMovementMaterial(delId).Wait();
            }

            foreach (DataRow row in dtData.Rows)
            {
                int id_MovementMaterial = (int)row["id"];
                
                int id_Material = (int)row["id_Material"];
                decimal Count = (decimal)row["Count"];
                int id_Responsible = (int)row["id_Responsible"];
                string _Comment = (string)row["Comment"];


                dtResult = readSQL.SetMovementMaterial(id_MovementMaterial, id_tMovementMaterial, id_Material, Count, id_Responsible, _Comment);
                if (dtResult == null || dtResult.Rows.Count == 0)
                {
                    MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }


                if ((int)dtResult.Rows[0]["id"] == -1)
                {
                    MessageBox.Show(config.centralText($"{dtResult.Rows[0]["msg"].ToString().Replace("\\n", "\n")}"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }

                if ((int)dtResult.Rows[0]["id"] == -9999)
                {
                    MessageBox.Show($"{dtResult.Rows[0]["msg"]}", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
            }



            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void tbNumberBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void cmbTypeOperation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void tbNumberBase_TextChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }

        public void InsertMovementMaterial(int id_Responsible,decimal Count,string cName,string nameMaterial,int id_Material,string Comment,string nameUnit)
        {
            if (dtData != null)
            {
                DataRow rowNew = dtData.NewRow();
                rowNew["id"] = -1;
                rowNew["id_Responsible"] = id_Responsible;
                rowNew["Count"] = Count;
                rowNew["cName"] = cName;
                rowNew["nameMaterial"] = nameMaterial;
                rowNew["id_Material"] = id_Material;
                rowNew["Comment"] = Comment;
                rowNew["nameUnit"] = nameUnit;

                dtData.Rows.Add(rowNew);
                dtData.AcceptChanges();
                setFilter();
            }
        }

        public void UpdateMovementMaterial(int id_Responsible, decimal Count, string cName, string nameMaterial, int id_Material, string Comment, string nameUnit)
        {
            if (dtData != null)
            {
                DataRowView rowNew = dtData.DefaultView[dgvData.CurrentRow.Index];                
                rowNew["id_Responsible"] = id_Responsible;
                rowNew["Count"] = Count;
                rowNew["cName"] = cName;
                rowNew["nameMaterial"] = nameMaterial;
                rowNew["id_Material"] = id_Material;
                rowNew["Comment"] = Comment;
                rowNew["nameUnit"] = nameUnit;
                
                dtData.AcceptChanges();
                setFilter();
            }
        }

        private void setFilter()
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                btEdit.Enabled = btDel.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if (tbFilterName.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"nameMaterial like '%{tbFilterName.Text.Trim()}%'";

                if (tbFilterMol.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"cName like '%{tbFilterMol.Text.Trim()}%'";

                if (tbFilterComment.Text.Trim().Length != 0)
                    filter += (filter.Length == 0 ? "" : " and ") + $"Comment like '%{tbFilterComment.Text.Trim()}%'";

                dtData.DefaultView.RowFilter = filter;
            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -1";
            }
            finally
            {
                btEdit.Enabled = btDel.Enabled =
                dtData.DefaultView.Count != 0;                
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            new MovementMaterial.frmAddMaterial() { id_tMovementMaterial = id, Owner = this, Text = "Добавить расходный материал" }.ShowDialog();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dtData == null) return;
            if (dtData.DefaultView.Count==0) return;

            DataRowView row = dtData.DefaultView[dgvData.CurrentRow.Index];
            new MovementMaterial.frmAddMaterial() { id_tMovementMaterial = id, Owner = this, row = row, Text = "Редактировать расходный материал" }.ShowDialog();

        }


        private void btDel_Click(object sender, EventArgs e)
        {
            if (dtData == null) return;
            if (dtData.DefaultView.Count == 0) return;
            
            if (MessageBox.Show("Удалить запись?","Запрос на удаление",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DataRowView row = dtData.DefaultView[dgvData.CurrentRow.Index];
                if ((int)row["id"] > 0)
                {
                    listToDel.Add((int)row["id"]);
                }
                row.Delete();
                dtData.AcceptChanges();
                setFilter();
            }
        }

        private void dgvData_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            int width = 0;
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (!col.Visible) continue;

                if (col.Name.Equals(cMol.Name))
                {
                    tbFilterMol.Location = new Point(dgvData.Location.X + 1 + width, tbFilterMol.Location.Y);
                    tbFilterMol.Size = new Size(col.Width, tbFilterMol.Height);
                }
                else
                if (col.Name.Equals(cName.Name))
                {
                    tbFilterName.Location = new Point(dgvData.Location.X + 1 + width, tbFilterMol.Location.Y);
                    tbFilterName.Size = new Size(col.Width, tbFilterMol.Height);
                }
                else
                if (col.Name.Equals(cComment.Name))
                {
                    tbFilterComment.Location = new Point(dgvData.Location.X + 1 + width, tbFilterMol.Location.Y);
                    tbFilterComment.Size = new Size(col.Width, tbFilterMol.Height);
                }

                width += col.Width;

            }
        }

        private void tbFilterMol_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }
    }
}
