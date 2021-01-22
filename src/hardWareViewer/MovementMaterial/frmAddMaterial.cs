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

        public DataRowView row { set; private get; }

        frmAddMovementMaterial frmOwer;
        public frmAddMaterial()
        {
            InitializeComponent();
            id = -1;
            id_Material = -1;
            isEditData = false;
        }

        private void frmAddMaterial_Load(object sender, EventArgs e)
        {
            frmOwer = (frmAddMovementMaterial)Owner;
            DataTable dtMol = readSQL.GetActiveMOL(false);
            cmbMOL.DataSource = dtMol;
            cmbMOL.DisplayMember = "cName";
            cmbMOL.ValueMember = "id";
            cmbMOL.SelectedIndex = -1;

            if (row != null)
            {
                id = (int)row["id"];
                id_Material = (int)row["id_Material"];
                tbMaterial.Text = (string)row["nameMaterial"];
                tbUnit.Text = (string)row["nameUnit"];
                tbCount.Text = ((decimal)row["Count"]).ToString("0.000");
                cmbMOL.SelectedValue = (int)row["id_Responsible"];
                tbComment.Text = (string)row["Comment"];
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
            if (new Material.frmList() { isSelect=true,Text = "Справочник типов расходных материалов -  выбор материала" }.ShowDialog() == DialogResult.OK)
            {

                tbUnit.Text = material.cNameUnit;
                id_Material = material.id;
                tbMaterial.Text = material.cName;
                isEditData = true;
            }
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

            if(Count==0)
            {
                MessageBox.Show(config.centralText($"Необходимо заполнить\n \"{label3.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCount.Focus();
                return;
            }

            if (id_Material == -1)
            {
                MessageBox.Show(config.centralText($"Необходимо выбрать\n \"{label1.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btSelect.Focus();
                return;
            }

            //decimal Count = decimal.Parse(tbCount.Text);
            int id_Responsible = (int)cmbMOL.SelectedValue;
            string Comment = tbComment.Text;
            if (row == null)
                frmOwer.InsertMovementMaterial(id_Responsible, Count, cmbMOL.Text, tbMaterial.Text, id_Material, tbComment.Text, tbUnit.Text);
            else
            {
                frmOwer.UpdateMovementMaterial(id_Responsible, Count, cmbMOL.Text, tbMaterial.Text, id_Material, tbComment.Text, tbUnit.Text);

                //row["id_Material"] = id_Material;
                //row["nameMaterial"] = tbMaterial.Text;
                //row["nameUnit"] = tbUnit.Text ;
                //row["Count"] = Count;
                //row["id_Responsible"] = (int)cmbMOL.SelectedValue;
                //row["Comment"] = tbComment.Text;
                //row["cName"] = cmbMOL.Text;
            }

            //DataTable dtResult = readSQL.SetMovementMaterial(id, id_tMovementMaterial, id_Material, Count, id_Responsible, Comment);
            //if (dtResult == null || dtResult.Rows.Count == 0)
            //{
            //    MessageBox.Show("Не удалось сохранить данные", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            //if ((int)dtResult.Rows[0]["id"] == -1)
            //{
            //    MessageBox.Show(config.centralText($"{dtResult.Rows[0]["msg"].ToString().Replace("\\n", "\n")}"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if ((int)dtResult.Rows[0]["id"] == -9999)
            //{
            //    MessageBox.Show($"{dtResult.Rows[0]["msg"]}", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

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
