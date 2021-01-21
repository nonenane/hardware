using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hardWareViewer
{
    public partial class frmListComponents : Form
    {
        public frmListComponents()
        {
            InitializeComponent();
        }

        public void setRow(DataRowView _row)
        {
            if (Convert.ToInt64(_row["TypeComponentsHardware"]) == 1)
                dgvData.Visible = false;

            tbInvNumber.Text = _row["InventoryNumber"].ToString();
            tbEAN.Text = _row["EAN"].ToString();
            tbName.Text = _row["cName"].ToString();
            tbLocation.Text = _row["nameLocation"].ToString();
            tbRespo.Text = _row["FIO"].ToString();
            tbStatus.Text = _row["nameStatus"].ToString();

            if (_row["DatePurchase"] == DBNull.Value)
            {
                dtpGarant.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                dtpGarant.CustomFormat = " ";
            }
            else
                dtpGarant.Value = (DateTime)_row["DatePurchase"];
            tbMonthG.Text = _row["WarrantyPeriod"].ToString();
            if (_row["DateConfirmationD"] != DBNull.Value && _row["DateConfirmationD"].ToString().Length > 0)
                tbNumerSz.Text = $"{_row["Number"]} от {DateTime.Parse(_row["DateConfirmationD"].ToString()).ToShortDateString()}";

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
