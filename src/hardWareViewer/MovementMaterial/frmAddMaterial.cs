using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace hardWareViewer.MovementMaterial
{
    
    public partial class frmAddMaterial : Form
    {
        public int id { set; private get; }
        public int id_tMovementMaterial { set; private get; }
        private int id_Material;
        private bool isEditData;
        public frmAddMaterial()
        {
            InitializeComponent();
            id = -1;
            id_Material = -1;
            isEditData = false;
        }

        private void frmAddMaterial_Load(object sender, EventArgs e)
        {
            DataTable dtMol = readSQL.GetActiveMOL(false);
            cmbMOL.DataSource = dtMol;
            cmbMOL.DisplayMember = "cName";
            cmbMOL.ValueMember = "id";
            cmbMOL.SelectedIndex = -1;

            if (id != -1)
            { 
            
            }
            isEditData = false;
        }

        private void frmAddMaterial_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEditData && DialogResult.No == MessageBox.Show("На форме есть не сохранённые данные.\nЗакрыть форму без сохранения данных?\n", "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            //CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            ////dialog.InitialDirectory = "C:\\Users";
            //dialog.IsFolderPicker = true;
            //if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            //{
            //    MessageBox.Show("You selected: " + dialog.FileName);
            //}
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            tbUnit.Text = "Шт.";
            id_Material = 1;
            isEditData = true;
        }

        private void tbCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.ToString().Contains(e.KeyChar) || (sender as TextBox).Text.ToString().Length == 0))
            {
                e.Handled = true;
            }
            else
                if ((!Char.IsNumber(e.KeyChar) && (e.KeyChar != ',')))
            {
                if (e.KeyChar != '\b')
                { e.Handled = true; }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            decimal Count;
            if (cmbMOL.SelectedIndex == -1)
            {
                MessageBox.Show(config.centralText($"Необходимо выбрать\n \"{label2.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMOL.Focus();
                return;
            }

            if (tbCount.Text.Trim().Length == 0)
            {
                MessageBox.Show(config.centralText($"Необходимо заполнить\n \"{label3.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCount.Focus();
                return;
            }

            if (!decimal.TryParse(tbCount.Text, out Count))
            {
                MessageBox.Show(config.centralText($"Необходимо заполнить\n \"{label3.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCount.Focus();
                return;
            }


            //decimal Count = decimal.Parse(tbCount.Text);
            int id_Responsible = (int)cmbMOL.SelectedValue;
            string Comment = tbComment.Text;

            DataTable dtResult = readSQL.SetMovementMaterial(id, id_tMovementMaterial, id_Material, Count, id_Responsible, Comment);
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

            isEditData = false;
            MessageBox.Show("Данные сохранены.", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void tbCount_TextChanged(object sender, EventArgs e)
        {
            isEditData = true;
        }

        private void cmbMOL_SelectionChangeCommitted(object sender, EventArgs e)
        {
            isEditData = true;
        }
    }
}
