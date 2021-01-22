﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hardWareViewer
{
    public partial class frmAddPlaceHardWare : Form
    {
        private int id = -1;
        private bool isEdit = false;

        private DataRowView row = null;

        public void setRow(DataRowView _row)
        {
            this.row = _row;
            id = int.Parse(row["id"].ToString());
            tbName.Text = row["cName"].ToString();
            cmbObject.SelectedValue = row["id_object"];
            isEdit = false;
        }
        
        public frmAddPlaceHardWare()
        {
            InitializeComponent();
            DataTable dtObject = readSQL.getObject(false);
            cmbObject.DataSource = dtObject;
            cmbObject.DisplayMember = "cName";
            cmbObject.ValueMember = "id";
            cmbObject.SelectedIndex = -1;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо ввести наименование!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbObject.SelectedIndex == -1)
            {
                MessageBox.Show("Необходимо выбрать объект!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id_object = (int)cmbObject.SelectedValue;

            DataTable dtResult = readSQL.setLocation(id, tbName.Text.Trim(), id_object, 1, true);
            if (dtResult == null && dtResult.Rows.Count == 0 && dtResult.Rows[0]["id"].ToString().Equals("-1"))
            {
                MessageBox.Show("Не удалось сохранить данные", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (dtResult.Rows[0]["id"].ToString().Equals("-2"))
            {
                MessageBox.Show("Такое наименование присутствует в Базе!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Данные сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isEdit = false;
            this.DialogResult = DialogResult.OK;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            isEdit = true;
        }

        private void frmAddPlaceHardWare_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (isEdit && MessageBox.Show("Закрыть форму без сохранения?", "Инфомирование", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No);
        }

        private void frmAddPlaceHardWare_Load(object sender, EventArgs e)
        {
           
        }
    }
}
