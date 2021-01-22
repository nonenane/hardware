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
    public partial class frmFind : Form
    {
        public frmFind()
        {
            InitializeComponent();
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            DataTable dtTypeBasic = readSQL.GetTypeBasic(false);
            cmbTypeBasic.DataSource = dtTypeBasic;
            cmbTypeBasic.DisplayMember = "cName";
            cmbTypeBasic.ValueMember = "id";
        }

        private void tbNumberBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
        }

        private void btFind_Click(object sender, EventArgs e)
        {

            if (tbNumberBase.Text.Trim().Length == 0)
            {
                MessageBox.Show(config.centralText($"Необходимо заполнить\n \"{label5.Text}\"\n"), "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNumberBase.Focus();
                return;
            }

            DateTime YearBasis = DateTime.Parse($"{dtpYear.Value.Year}-01-01");
            int NumberBase = int.Parse(tbNumberBase.Text);
            int idBasis = (int)cmbTypeBasic.SelectedValue;

            DataTable dtData = readSQL.FindMovementMaterial(idBasis, NumberBase, YearBasis);

            if (dtData == null || dtData.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных!","Поиск данных",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            new frmFindResult() { dtData = dtData, Text = $"Поиск по {NumberBase} за {dtpYear.Value.Year} год" }.ShowDialog();

            this.DialogResult = DialogResult.OK;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
