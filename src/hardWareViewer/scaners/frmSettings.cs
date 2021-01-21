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
    public partial class frmSettings : Form
    {
        private bool isEdit = false;
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (cmbTypeHadr.SelectedIndex == -1)
            {
                MessageBox.Show("Необходимо выбрать \"Тип оборудования\"!","Информирование",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            readSQL.SetSettings("cods", "C", "код типа сканера", cmbTypeHadr.SelectedValue.ToString(), "");
            isEdit = false;


            if (editData)
            {
                Logging.StartFirstLevel(1236);

                Logging.VariableChange("Тип оборудования Id: ", cmbTypeHadr.SelectedValue.ToString(), oldIdValue, typeLog._int);
                Logging.VariableChange("Тип оборудования Наименование: ", cmbTypeHadr.Text.ToString(), oldValueName, typeLog._string);

                Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();
            }
            else
            {
                Logging.StartFirstLevel(1236);

                Logging.Comment("Тип оборудования Id: " + cmbTypeHadr.SelectedValue.ToString());
                Logging.Comment("Тип оборудования Наименование: " + cmbTypeHadr.Text.ToString());

                Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();
            }

            MessageBox.Show("Данные сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
        }

        private int oldIdValue = -1;
        private bool editData = false;
        private string oldValueName = "";
        private void frmSettings_Load(object sender, EventArgs e)
        {
            DataTable dtTypeHard = readSQL.getTypeHardWare();
            cmbTypeHadr.DataSource = dtTypeHard;
            cmbTypeHadr.DisplayMember = "cName";
            cmbTypeHadr.ValueMember = "id";
            cmbTypeHadr.SelectedIndex = -1;

            DataTable dtSettings = readSQL.GetSettings("cods");
            if (dtSettings != null && dtSettings.Rows.Count > 0)
            {
                cmbTypeHadr.SelectedValue = dtSettings.Rows[0]["value"];
                oldIdValue = int.Parse(dtSettings.Rows[0]["value"].ToString());
                oldValueName = cmbTypeHadr.Text;
                editData = true;
            }
            isEdit = false;
        }

        private void cmbTypeHadr_SelectionChangeCommitted(object sender, EventArgs e)
        {
            isEdit = true;
        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEdit && MessageBox.Show(config.centralText("Данные поменял, но не сохранил!\nВыйти без сохранения?\n"), "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No;
        }
    }
}
