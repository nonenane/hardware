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
    public partial class frmAddComponentInEstimates : Form
    {
        private bool isHardWare = true;
        private int idHardWare = -1;
        public decimal inComeSumma = -1;
        private int status = 0;
        public int type = -1;
        private bool chEnable = true;

        private decimal sPrice = 0;
        private int sCount = 0;
        public frmAddComponentInEstimates(int newStatus = 0)
        {
            status = newStatus;
            InitializeComponent();
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                e.KeyChar = ',';

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

        private void tbCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!Char.IsNumber(e.KeyChar) && (e.KeyChar != '\b'));
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            frmDirectoryHardWareAndComponents frm = new frmDirectoryHardWareAndComponents();
            if (type == 0)
                frm.setHardwaress();
            else if (type == 1)
                frm.setComponentes();

            if (DialogResult.OK == frm.ShowDialog())
            {
                isHardWare = frm.getIsHardWare();
                tbName.Text = frm.getSendName();
                idHardWare = frm.getSendId();                     
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (idHardWare == -1)
            {
                MessageBox.Show("Необходимо выбрать \"Оборудование/Комплектующие\"!","Информирование",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (decimal.Parse(tbCount.Text.ToString())==0)
            {
                MessageBox.Show("Необходимо указать кол-во!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (decimal.Parse(tbPrice.Text.ToString()) == 0)
            //{
            //    MessageBox.Show("Необходимо указать цену!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            
            if (tbPrice.Text.ToString() == "")
            {
                tbPrice.Text = "0";
            }

            if (tbDelivery.Text.ToString() == "")
            {
                tbDelivery.Text = "0";
            }

            if (row != null)
            {
                row["id_ComponentsHardware"] = idHardWare;
                row["TypeComponentsHardware"] = isHardWare ? 0 : 1;
                row["Price"] = tbPrice.Text.Trim();
                row["Count"] = tbCount.Text.Trim();
                row["Link"] = tbLink.Text.Trim();
                row["Comments"] = "";
                row["Description"] = tbDescription.Text.Trim();
                row["cName"] = tbName.Text.Trim();
                row["nameType"] = isHardWare ? "Оборудование" : "Комплектующие";
                row["nameTypeLinkView"] = isHardWare ? "Оборудование" : "Комплектующие";
                row["isLink"] = tbLink.Text.Trim().Length != 0;
                row["summa"] = decimal.Parse(tbPrice.Text.Trim()) * decimal.Parse(tbCount.Text.Trim());
                row["Status"] = 0;
                row["StatusConfirmation"] = 0;
                row["Purchase"] = status;
                row["namePurchase"] = (status == 0) ? "Добавлено в смету" : "Оборудования которым произведена замена";
                row["Delivery"] = tbDelivery.Text.Trim();
                row["StatusBuild"] = isHardWare ? cbBuildUp.Checked : true;
            }
            else if (viewRow != null)
            {
                //viewRow["id_ComponentsHardware"] = idHardWare;
                //viewRow["TypeComponentsHardware"] = isHardWare ? 0 : 1;
                viewRow["Price"] = tbPrice.Text.Trim();
                viewRow["Count"] = tbCount.Text.Trim();
                viewRow["Link"] = tbLink.Text.Trim();                
                viewRow["Description"] = tbDescription.Text.Trim();
                viewRow["cName"] = tbName.Text.Trim();
                //viewRow["nameType"] = isHardWare ? "Оборудование" : "Комплектующие";
                viewRow["isLink"] = tbLink.Text.Trim().Length != 0;
                viewRow["summa"] = decimal.Parse(tbPrice.Text.Trim()) * decimal.Parse(tbCount.Text.Trim());
                viewRow["Delivery"] = tbDelivery.Text.Trim();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private DataRow row;
        
        public void setCreateRow(DataRow _row)
        {
            this.row = _row;
        }

        public DataRow getRow()
        {
            return row;
        }

        private DataRowView viewRow;
        public void setEditRow(DataRowView _row)
        {
            this.viewRow = _row;

            btSelect.Enabled = false;
            tbPrice.Text = viewRow["Price"].ToString();
            tbCount.Text = viewRow["Count"].ToString();
            tbLink.Text = viewRow["Link"].ToString();
            tbDescription.Text = viewRow["Description"].ToString();
            tbName.Text = viewRow["cName"].ToString();
            tbDelivery.Text = viewRow["Delivery"].ToString();
            idHardWare = int.Parse(viewRow["id_ComponentsHardware"].ToString());
            try
            {
                cbBuildUp.Checked = bool.Parse(viewRow["StatusBuild"].ToString());
            }
            catch
            {
                cbBuildUp.Checked = false;
            }
        }

        public DataRowView getEditRow()
        {
            return viewRow;
        }

        /// <summary>
        /// Кнопка статуса сборное / не сборное оборудование
        /// </summary>
        private void cbBuildUp_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                sPrice = Convert.ToDecimal(tbPrice.Text);
                sCount = Convert.ToInt32(tbCount.Text);
                tbPrice.Text = "0";
                tbCount.Text = "1";
            }
            else
            {
                tbPrice.Text = sPrice.ToString();
                tbCount.Text = sCount.ToString();
            }

            tbPrice.Enabled = !((CheckBox)sender).Checked;
            tbCount.Enabled = !((CheckBox)sender).Checked;

            if (!chEnable)
            {
                tbCount.Enabled = true;
                tbPrice.Enabled = true;
            }
        }

        /// <summary>
        /// Функция Изменения доступности чекбокса сборное оборудование
        /// </summary>
        public void changeStatusBuildUp(bool enable)
        {
            chEnable = enable;
            cbBuildUp.Enabled = enable;
        }

        /// <summary>
        /// Включение отключение доступности полей
        /// </summary>
        /// <param name="name">Имя поля</param>
        /// <param name="enable">Статус</param>
        public void enableField(string name, bool enable)
        {
            this.Controls.Find(name, false)[0].Enabled = false;
        }
        
    }
}
