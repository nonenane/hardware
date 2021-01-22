using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hardWareViewer.Material
{
    public partial class frmAdd : Form
    {
        public DataRowView row { set; private get; }

        private bool isEditData = false;
        private string oldName, oldUnit;
        private int id = 0;

        public frmAdd()
        {
            InitializeComponent();
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btSave, "Сохранить");
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            Task<DataTable> task = readSQL.GetUnits(false);
            task.Wait();
            cmbUnit.DataSource = task.Result;
            cmbUnit.ValueMember = "id";
            cmbUnit.DisplayMember = "cName";
            cmbUnit.SelectedIndex = -1;

            if (row != null)
            {
                id = (int)row["id"];
                tbRegName.Text = (string)row["cName"];
                oldName = tbRegName.Text.Trim();

                cmbUnit.SelectedValue = (int)row["id_Units"];
                oldUnit = cmbUnit.Text;
            }

            isEditData = false;
        }

        private void frmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }



        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            if (tbRegName.Text.Trim().Length == 0)
            {
                MessageBox.Show(config.centralText($"Необходимо заполнить\n \"{lName.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbRegName.Focus();
                return;
            }

            if (cmbUnit.SelectedIndex == -1)
            {
                MessageBox.Show(config.centralText($"Необходимо выбрать\n \"{label1.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUnit.Focus();
                return;
            }

            int id_unit = (int)cmbUnit.SelectedValue;

            Task<DataTable> task = readSQL.SetMaterial(id, tbRegName.Text, id_unit, true, 0, false);
            task.Wait();

            DataTable dtResult = task.Result;

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

            if (id == 0)
            {
                id = (int)dtResult.Rows[0]["id"];
                Logging.StartFirstLevel(1564);
                //Logging.Comment("Добавить Тип документа");
                Logging.Comment($"ID: {id}");
                Logging.Comment($"Наименование: {tbRegName.Text.Trim()}");
                Logging.Comment($"{label1.Text}: ID:{cmbUnit.SelectedValue}; Наименование:{cmbUnit.Text}");
                Logging.StopFirstLevel();
            }
            else
            {
                Logging.StartFirstLevel(1565);
                //Logging.Comment("Редактировать Тип документа");
                Logging.Comment($"ID: {id}");
                Logging.VariableChange("Наименование", tbRegName.Text.Trim(), oldName);

                Logging.VariableChange($"{label1.Text} ID", id_unit, row["id_Units"],typeLog._int);
                Logging.VariableChange($"{label1.Text} Наименование", cmbUnit.Text.Trim(), oldUnit);

                Logging.StopFirstLevel();
            }

            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void cmbUnit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }
       
    }
}
