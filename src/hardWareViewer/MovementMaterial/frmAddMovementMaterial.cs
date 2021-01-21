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
        public int id { set; private get; }

        private bool isEditData = false;
        private DataTable dtData = new DataTable();
        public frmAddMovementMaterial()
        {
            InitializeComponent();
            id = -1;
        }

        private void frmAddMovementMaterial_Load(object sender, EventArgs e)
        {
            DataTable dtTypeOperation = readSQL.GetTypeOperation(false);
            cmbTypeOperation.DataSource = dtTypeOperation;
            cmbTypeOperation.DisplayMember = "cName";
            cmbTypeOperation.ValueMember = "id";
            cmbTypeOperation.SelectedIndex = -1;

            DataTable dtTypeBasic = readSQL.GetTypeBasic(false);
            cmbTypeBasic.DataSource = dtTypeBasic;
            cmbTypeBasic.DisplayMember = "cName";
            cmbTypeBasic.ValueMember = "id";

            if (id != -1)
            { 
            

            }

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

            //if (dtData == null || dtData.Rows.Count == 0)
            //{
            //    MessageBox.Show(config.centralText("Отсутствуют записи\nо движении расходных материалов.\nСохранение невозможно.\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

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
                //MessageBox.Show("В справочнике уже присутствует запись с таким наименованием.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(config.centralText($"{dtResult.Rows[0]["msg"].ToString().Replace("\\n", "\n")}"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((int)dtResult.Rows[0]["id"] == -9999)
            {
                MessageBox.Show($"{dtResult.Rows[0]["msg"]}", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
    }
}
