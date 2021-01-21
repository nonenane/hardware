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
    public partial class frmAddActInventory : Form
    {
        private int id_DateInventory = -1;
        public void setDateInventory(DateTime _inDate)
        {
            this.dtpDateInventory.Value = _inDate;
            dtpDateAct.MinDate = dtpDateInventory.Value.Date;
        }

        public void setIdDateInventory(int _id_DateInventory)
        {
            id_DateInventory = _id_DateInventory;
        }

        private bool isView = false;
        public void isV()
        {
            btDel.Visible = btSave.Visible = false;
            button1.Visible = button2.Visible = false;
            dtpDateInventory.Enabled = false;
            dtpDateAct.Enabled = false;
            tbComment.ReadOnly = true;
            cSelect.Visible = false;
            gbAdd.Visible = true;
            gbEdit.Visible = false;
            this.isView = true;
        }

        private int id_actInventory = -1;

        public void setRow(DataRowView _row)
        {
            cSelect.Visible = true;
            cStatus.Visible = true;
            tbComment.ReadOnly = true;
            dtpDateAct.Enabled = false;

            gbAdd.Visible = false;
            gbEdit.Visible = true;
            gbEdit_cb.Visible = true;
            btDel.Visible = false;
            cNum.ReadOnly = true;
            dtpDateAct.MinDate = DateTime.Parse(_row["Date"].ToString());
            dtpDateAct.Value = DateTime.Parse(_row["Date"].ToString());            
            id_actInventory = int.Parse(_row["id"].ToString());
            tbComment.Text = _row["Comment"].ToString();
            

            get_data();
        }

        public frmAddActInventory()
        {
            InitializeComponent();
            init_combobox();
            dgvData.AutoGenerateColumns = false;
            //gbEdit_cb.Visible = gbEdit.Visible = !(gbAdd.Visible = false);
            cSelect.Visible = false;
            //cNum.Visible = false;
            //cEAN.Visible = false;
            cStatus.Visible = false;
            get_data();
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert && !isView && id_actInventory == -1)
            {
                DataRow row = dtData.Rows.Add();
                //row["nameStatus"] = "На месте";
                //row["nameHardware"] = "Оборудование";
                btDel.Enabled = dgvData.Rows.Count != 0;
            }
        }

        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView grd = (DataGridView)sender;

            if (grd.CurrentCell.ColumnIndex == cNum.Index)
            {
                //TextBox tb = (TextBox)e.Control;
                //tb.KeyPress -= tbEan_KeyPress;
                //tb.KeyPress -= tbEan_KeyPress;
                //tb.KeyPress += new KeyPressEventHandler(tbEan_KeyPress);
            }
        }

        void tbEan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!Char.IsNumber(e.KeyChar) && (e.KeyChar != '\b'));
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
                //&& dtData != null && dtData.DefaultView.Count != 0
                )
            {
                dgvData.Rows.RemoveAt(dgvData.CurrentRow.Index);
                btDel.Enabled = dgvData.Rows.Count != 0;
            }
        }

        private DataTable dtData;
        private void get_data()
        {
            dtData = readSQL.getContentInventory(id_actInventory);
            filter();
            dgvData.DataSource = dtData;
            btDel.Enabled = dgvData.Rows.Count != 0;
        }

        private void filter()
        {
            try
            {
                string filter = "";

                // filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Convert(Number,System.String) like '%{0}%'", tbNumber.Text.Trim());
                // filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Comment like '%{0}%'", tbComment.Text.Trim());

                if (cbStatus.SelectedIndex != 0)
                    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Status = {0}", cbStatus.SelectedValue);


                //if (cbLocation.SelectedIndex != 0)
                //    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("Status = {0}", cbLocation.SelectedValue);

                if (cbResponsibles.SelectedIndex != 0)
                    filter += (filter.Trim().Length != 0 ? " AND " : "") + string.Format("id_Responsible = {0}", cbResponsibles.SelectedValue);

                dtData.DefaultView.RowFilter = filter;

            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -9999";
            }

            btDel.Enabled = dtData.DefaultView.Count != 0;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (cNum.Index == e.ColumnIndex)
            {
                if (dtData.DefaultView[e.RowIndex]["invNumber"].ToString().Length != 0)
                {
                    string invNumber = dtData.DefaultView[e.RowIndex]["invNumber"].ToString();
                    dtData.DefaultView[e.RowIndex]["id_Hardware"] = -1;
                    dtData.DefaultView[e.RowIndex]["ean"] = "";
                    dtData.DefaultView[e.RowIndex]["invNumber"] = "";
                    dtData.DefaultView[e.RowIndex]["nameHardware"] = "";
                    dtData.DefaultView[e.RowIndex]["nameLocation"] = "";
                    dtData.DefaultView[e.RowIndex]["FIO"] = "";
                    dtData.DefaultView[e.RowIndex]["id"] = -1;
                    dtData.DefaultView[e.RowIndex]["Status"] = 0;

                    DataTable dtTovar = readSQL.findJHardWare(invNumber);
                    if (dtTovar != null && dtTovar.Rows.Count > 0)
                    {
                        dtData.DefaultView[e.RowIndex]["id_Hardware"] = dtTovar.Rows[0]["id"];
                        dtData.DefaultView[e.RowIndex]["ean"] = dtTovar.Rows[0]["ean"];
                        dtData.DefaultView[e.RowIndex]["invNumber"] = invNumber;
                        dtData.DefaultView[e.RowIndex]["nameHardware"] = dtTovar.Rows[0]["nameHardware"];
                        dtData.DefaultView[e.RowIndex]["nameLocation"] = dtTovar.Rows[0]["nameLocation"];
                        dtData.DefaultView[e.RowIndex]["FIO"] = dtTovar.Rows[0]["FIO"];
                        dtData.DefaultView[e.RowIndex]["id"] = -1;
                        dtData.DefaultView[e.RowIndex]["Status"] = 0;
                        
                        dgvData.Refresh();
                    }
                }
                else
                {
                    dtData.DefaultView[e.RowIndex]["id_Hardware"] = -1;
                    dtData.DefaultView[e.RowIndex]["ean"] = "";
                    dtData.DefaultView[e.RowIndex]["invNumber"] = "";
                    dtData.DefaultView[e.RowIndex]["nameHardware"] = "";
                    dtData.DefaultView[e.RowIndex]["nameLocation"] = "";
                    dtData.DefaultView[e.RowIndex]["FIO"] = "";
                    dtData.DefaultView[e.RowIndex]["id"] = -1;
                    dtData.DefaultView[e.RowIndex]["Status"] = 0;
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            DataTable dtResult = readSQL.setActInventory(id_actInventory,
                id_DateInventory,
                0,
                dtpDateAct.Value,
                tbComment.Text.Trim(),
                0,
                1
                );

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

            id_actInventory = int.Parse(dtResult.Rows[0]["id"].ToString());

            foreach (DataRow r in dtData.Rows)
            {
                int id = int.Parse(r["id"].ToString());
                int id_hardware = int.Parse(r["id_Hardware"].ToString());
                int status = int.Parse(r["Status"].ToString());
                readSQL.setContentInventory(id, id_actInventory, id_hardware, status, 1);
            }

            MessageBox.Show("Данные сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex].Name.Equals("cSelect"))
            {                
                    bool isSelect = false;
                    if (dtData.DefaultView[e.RowIndex]["isSelect"] != DBNull.Value)
                        isSelect = bool.Parse(dtData.DefaultView[e.RowIndex]["isSelect"].ToString());

                    dtData.DefaultView[e.RowIndex]["isSelect"] = !isSelect;
                    dtData.AcceptChanges();
                    dgvData.Refresh();                
            }
        }

        private void btStatus_Click(object sender, EventArgs e)
        {
            Button _btn = (Button)sender;
            switch (_btn.Tag.ToString())
            {
                case "0": change_status(0); break;
                case "1": change_status(1); break;
                case "2": change_status(2); break;
                case "3": change_status(3); break;
                default: break;
            }
        }

        private void change_status(int _status)
        {
            DataRow[] row = dtData.Select("isSelect = 1");
            foreach (DataRow r in row)
            {
                r["Status"] = _status;
                r["nameStatus"] = "";
                DataRow[] rStatus = dtStatus.Select("id = " + _status);
                if (rStatus.Count() != 0)
                {
                    r["nameStatus"] = rStatus[0]["cName"].ToString();
                }
            }
            dtData.AcceptChanges();
        }

        private DataTable dtStatus;
        private void init_combobox()
        {
            DataColumn col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;

            dtStatus = readSQL.getStatus("contentInventoryStatus");
            dtStatus.Columns.Add(col);
            dtStatus.Rows.Add(-1, "Все", 0);
            dtStatus.DefaultView.Sort = "main asc";

            cbStatus.DataSource = dtStatus;
            cbStatus.DisplayMember = "cName";
            cbStatus.ValueMember = "id";

            //
            DataTable dtResponsibles = readSQL.getListResponsibles(1);
            col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;
            dtResponsibles.Columns.Add(col);
            dtResponsibles.Rows.Add(-1, -1, "Все", true, true, 0);
            dtResponsibles.DefaultView.RowFilter = "isActive = 1";
            dtResponsibles.DefaultView.Sort = "main asc";
            cbResponsibles.DataSource = dtResponsibles;
            cbResponsibles.DisplayMember = "FIO";
            cbResponsibles.ValueMember = "id";
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                Color rColor = Color.White;

                //if (!(bool)dtComponents.DefaultView[e.RowIndex]["isActive"])
                if (dtData.DefaultView[e.RowIndex]["Status"]!=DBNull.Value && int.Parse(dtData.DefaultView[e.RowIndex]["Status"].ToString())==1)
                    rColor = pNotAll.BackColor;

                dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
            }
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            //Рисуем рамку для выделеной строки
            if (dgv.Rows[e.RowIndex].Selected)
            {
                int width = dgv.Width;
                Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
                Rectangle rect = new Rectangle(r.X, r.Y, width - 1, r.Height - 1);

                ControlPaint.DrawBorder(e.Graphics, rect,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
            }
        }

        private void cbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
        }
    }
}
