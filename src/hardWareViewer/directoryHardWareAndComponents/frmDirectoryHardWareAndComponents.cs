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
    public partial class frmDirectoryHardWareAndComponents : Form
    {
        public frmDirectoryHardWareAndComponents()
        {
            InitializeComponent();
            rbHrdWare_CheckedChanged(null, null);
            get_type_components();
            get_data_components();

            get_type_hardware();
            get_data_hardware();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbHrdWare_CheckedChanged(object sender, EventArgs e)
        {
            gbComponents.Enabled = !(gbHardWare.Enabled = rbHrdWare.Checked);
        }
      
        #region "Компоненты"
        private void btOpenDirectionComponents_Click(object sender, EventArgs e)
        {
            frmDirectoryTypeComponents frm = new frmDirectoryTypeComponents();
            frm.ShowDialog();
            get_type_components();
        }

        private DataTable dtTypeComponent,dtComponents;
        private void get_type_components()
        {
            dtTypeComponent = readSQL.getTypeComponents();

            DataColumn col = new DataColumn("main",typeof(int));
            col.DefaultValue = 1;
            dtTypeComponent.Columns.Add(col);
            dtTypeComponent.Rows.Add(-1, "Все",true,"", 0);
            dtTypeComponent.DefaultView.Sort = "main asc";

            cbTypeComponents.DataSource = dtTypeComponent;
            cbTypeComponents.DisplayMember = "cName";
            cbTypeComponents.ValueMember = "id";
        }

        private void get_data_components()
        {
            dgvComponents.AutoGenerateColumns = false;
            dtComponents = readSQL.getComponents();
            filter_components();
            dgvComponents.DataSource = dtComponents;
        }

        private void btAddComponents_Click(object sender, EventArgs e)
        {
            frmAddComponents frm = new frmAddComponents();
            frm.Text = "Добавить комплектующие";          
            if (DialogResult.OK == frm.ShowDialog())
            {
                get_data_components();
            }
        }

        private void btEditComponents_Click(object sender, EventArgs e)
        {
            if (dgvComponents.CurrentRow != null && dgvComponents.CurrentRow.Index != -1 && dtComponents != null && dtComponents.DefaultView.Count != 0)
            {
                frmAddComponents frm = new frmAddComponents();
                frm.Text = "Редактировать комплектующие";
                frm.setRow(dtComponents.DefaultView[dgvComponents.CurrentRow.Index]);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    get_data_components();
                }
            }
        }

        private void btDelComponents_Click(object sender, EventArgs e)
        {
            if (dgvComponents.CurrentRow != null && dgvComponents.CurrentRow.Index != -1 && dtComponents != null && dtComponents.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Удалить запись?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    int id = int.Parse(dtComponents.DefaultView[dgvComponents.CurrentRow.Index]["id"].ToString());
                    string cName = dtComponents.DefaultView[dgvComponents.CurrentRow.Index]["cName"].ToString();
                    string description = dtComponents.DefaultView[dgvComponents.CurrentRow.Index]["Description"].ToString();
                    readSQL.setComponents(id, cName, description, 0, 2, true);
                    dgvComponents.Rows.RemoveAt(dgvComponents.CurrentRow.Index);
                    get_data_components();
                }
            }
        }

        private void filter_components()
        {
            try
            {
                string str = "";

                str += string.Format("cName like '%{0}%'", tbNameComponents.Text.Trim());

                //if (!chbIsActiveComponents.Checked)
                //    str += " AND isActive = 1";

                if (cbTypeComponents.SelectedIndex != 0)
                    str += string.Format("AND id_TypeComponents = {0}", cbTypeComponents.SelectedValue.ToString());

                dtComponents.DefaultView.RowFilter = str;
                btSelectComponents.Enabled = btAddDocComponents.Enabled = btViewComponents.Enabled =
                btPrintComponents.Enabled = btDelComponents.Enabled = btEditComponents.Enabled = dtComponents.DefaultView.Count != 0;
            }
            catch
            {
                dtComponents.DefaultView.RowFilter = "id = -9999";
                btSelectComponents.Enabled=btAddDocComponents.Enabled=btViewComponents.Enabled=
                btPrintComponents.Enabled = btDelComponents.Enabled = btEditComponents.Enabled = dtComponents.DefaultView.Count != 0;
            }
        }

        private void tbNameComponents_TextChanged(object sender, EventArgs e)
        {
            filter_components();
        }

        private void chbIsActiveComponents_CheckedChanged(object sender, EventArgs e)
        {
            filter_components();
        }

        private void dgvComponents_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtComponents != null && dtComponents.DefaultView.Count != 0)
            {
                Color rColor = Color.White;

                //if (!(bool)dtComponents.DefaultView[e.RowIndex]["isActive"])
                //    rColor = pIsActive.BackColor;

                dgvComponents.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvComponents.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
            }
        }

        private void dgvComponents_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void cbTypeComponents_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter_components();
        }

        private void dgvComponents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvComponents.CurrentRow != null && dgvComponents.CurrentRow.Index != -1 && dtComponents != null && dtComponents.DefaultView.Count != 0)
            {
                tbDescriptionComponents.Text = dtComponents.DefaultView[dgvComponents.CurrentRow.Index]["Description"].ToString();
            }
            else
            {
                tbDescriptionComponents.Text = "";
            }
        }

        private void btViewComponents_Click(object sender, EventArgs e)
        {
            if (dgvComponents.CurrentRow != null && dgvComponents.CurrentRow.Index != -1 && dtComponents != null && dtComponents.DefaultView.Count != 0)
            {
                int id = int.Parse(dtComponents.DefaultView[dgvComponents.CurrentRow.Index]["id"].ToString());
                frmAddDoc frm = new frmAddDoc();
                frm.setView();
                frm.setId_journal(id);
                frm.setTypeScan(9);
                frm.ShowDialog();
            }
        }

        private void btAddDocComponents_Click(object sender, EventArgs e)
        {
            if (dgvComponents.CurrentRow != null && dgvComponents.CurrentRow.Index != -1 && dtComponents != null && dtComponents.DefaultView.Count != 0)
            {
                int id = int.Parse(dtComponents.DefaultView[dgvComponents.CurrentRow.Index]["id"].ToString());
                frmAddDoc frm = new frmAddDoc();               
                frm.setId_journal(id);
                frm.setTypeScan(9);
                if (DialogResult.OK == frm.ShowDialog())
                    get_data_components();
            }
        }

        private void btPrintComponents_Click(object sender, EventArgs e)
        {

        }

        private void btSelectComponents_Click(object sender, EventArgs e)
        {
            sendData();
        }
        #endregion

        #region "Железяки"

        private DataTable dtTypeHardWare, dtHardWare;
        private void get_type_hardware()
        {
            dtTypeHardWare = readSQL.getTypeHardWare();

            DataColumn col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;
            dtTypeHardWare.Columns.Add(col);
            dtTypeHardWare.Rows.Add(-1, "Все", true,true,"", 0);
            dtTypeHardWare.DefaultView.Sort = "main asc";
            
            cbTypeHardWare.DataSource = dtTypeHardWare;
            cbTypeHardWare.DisplayMember = "cName";
            cbTypeHardWare.ValueMember = "id";
        }

        private void get_data_hardware()
        {
            dgvHardWare.AutoGenerateColumns = false;
            dtHardWare = readSQL.getHardWare();
            filter_hardware();
            dgvHardWare.DataSource = dtHardWare;
        }

        private void filter_hardware()
        {
            try
            {
                string str = "";

                str += string.Format("cName like '%{0}%'", tbNameHardWare.Text.Trim());

                //if (!chbIsActiveComponents.Checked)
                //    str += " AND isActive = 1";

                if (cbTypeHardWare.SelectedIndex != 0)
                    str += string.Format("AND id_TypeHardWare = {0}", cbTypeHardWare.SelectedValue.ToString());

                dtHardWare.DefaultView.RowFilter = str;
                btSelectHardWare.Enabled = btAddDocHardWare.Enabled = btViewHardWare.Enabled =
                btPrintHardWare.Enabled = btDelHardWare.Enabled = btEditHardWare.Enabled = dtHardWare.DefaultView.Count != 0;
            }
            catch
            {
                dtHardWare.DefaultView.RowFilter = "id = -9999";
                btSelectHardWare.Enabled = btAddDocHardWare.Enabled = btViewHardWare.Enabled =
                btPrintHardWare.Enabled = btDelHardWare.Enabled = btEditHardWare.Enabled = dtHardWare.DefaultView.Count != 0;
            }
        }
                
        private void cbTypeHardWare_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter_hardware();
        }

        private void tbNameHardWare_TextChanged(object sender, EventArgs e)
        {
            filter_hardware();
        }

        private void chbIsActiveHardWare_CheckedChanged(object sender, EventArgs e)
        {
            filter_hardware();
        }

        private void btAddHardWare_Click(object sender, EventArgs e)
        {
            frmAddHardWare frm = new frmAddHardWare();
            frm.Text = "Добавить оборудование";
            if (DialogResult.OK == frm.ShowDialog())
            {
                get_data_hardware();
            }
        }

        private void btEditHardWare_Click(object sender, EventArgs e)
        {
            if (dgvHardWare.CurrentRow != null && dgvHardWare.CurrentRow.Index != -1
                && dtHardWare != null && dtHardWare.DefaultView.Count != 0)
            {
                frmAddHardWare frm = new frmAddHardWare();
                frm.Text = "Редактировать оборудование";
                frm.setRow(dtHardWare.DefaultView[dgvHardWare.CurrentRow.Index]);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    get_data_hardware();
                }
            }
        }

        private void btDelHardWare_Click(object sender, EventArgs e)
        {
            if (dgvHardWare.CurrentRow != null && dgvHardWare.CurrentRow.Index != -1
               && dtHardWare != null && dtHardWare.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Удалить запись?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    int id = int.Parse(dtHardWare.DefaultView[dgvHardWare.CurrentRow.Index]["id"].ToString());
                    string cName = dtHardWare.DefaultView[dgvHardWare.CurrentRow.Index]["cName"].ToString();
                    string description = dtHardWare.DefaultView[dgvHardWare.CurrentRow.Index]["Description"].ToString();
                    readSQL.setHardWare(id, cName, description, 0, 2, true);
                    dgvHardWare.Rows.RemoveAt(dgvHardWare.CurrentRow.Index);
                    get_data_hardware();
                }
            }
        }

        private void btViewHardWare_Click(object sender, EventArgs e)
        {
            if (dgvHardWare.CurrentRow != null && dgvHardWare.CurrentRow.Index != -1
                 && dtHardWare != null && dtHardWare.DefaultView.Count != 0)
            {
                int id = int.Parse(dtHardWare.DefaultView[dgvHardWare.CurrentRow.Index]["id"].ToString());
                frmAddDoc frm = new frmAddDoc();
                frm.setView();
                frm.setId_journal(id);
                frm.setTypeScan(7);
                frm.ShowDialog();
            }
        }

        private void btAddDocHardWare_Click(object sender, EventArgs e)
        {
            if (dgvHardWare.CurrentRow != null && dgvHardWare.CurrentRow.Index != -1
                    && dtHardWare != null && dtHardWare.DefaultView.Count != 0)
            {
                int id = int.Parse(dtHardWare.DefaultView[dgvHardWare.CurrentRow.Index]["id"].ToString());
                frmAddDoc frm = new frmAddDoc();
                frm.setId_journal(id);
                frm.setTypeScan(7);
               if(DialogResult.OK== frm.ShowDialog())
                   get_data_hardware();
            }
        }

        private void btSelectHardWare_Click(object sender, EventArgs e)
        {
            sendData();
        }

        private void dgvHardWare_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHardWare.CurrentRow != null && dgvHardWare.CurrentRow.Index != -1 
                && dtHardWare != null && dtHardWare.DefaultView.Count != 0)
            {
                tbDescriptionHardWare.Text = dtHardWare.DefaultView[dgvHardWare.CurrentRow.Index]["Description"].ToString();
            }
            else
            {
                tbDescriptionHardWare.Text = "";
            }
        }

        private void dgvHardWare_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtHardWare != null && dtHardWare.DefaultView.Count != 0)
            {
                Color rColor = Color.White;

                //if (!(bool)dtComponents.DefaultView[e.RowIndex]["isActive"])
                //    rColor = pIsActive.BackColor;

                dgvHardWare.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvHardWare.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
            }
        }

        private void dgvHardWare_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
        
        private void btOpenDirectionHardWare_Click(object sender, EventArgs e)
        {
            frmDirectoryTypeHardWare frm = new frmDirectoryTypeHardWare();
            frm.ShowDialog();
            get_type_hardware();
        }

        #endregion

        public void setComponentes()
        {
            rbComponents.Checked = true;
            rbHrdWare.Enabled = false;
        }

        public void setHardwaress()
        {
            rbHrdWare.Checked = true;
            rbComponents.Enabled = false;
        }

        public void setDirectory()
        {
            btSelectComponents.Visible = btSelectHardWare.Visible = false;
        }

        private int sendId;
        private string sendName;
        private bool sendIsHardWare;

        public int getSendId()
        {
            return sendId;
        }

        public string getSendName()
        {
            return sendName;
        }

        public bool getIsHardWare()
        {
            return sendIsHardWare;
        }

        private void sendData()
        {
            sendIsHardWare = rbHrdWare.Checked;

            if (rbHrdWare.Checked)
            {
                if (dgvHardWare.CurrentRow != null && dgvHardWare.CurrentRow.Index != -1
                    && dtHardWare != null && dtHardWare.DefaultView.Count != 0)
                {
                    sendId = int.Parse(dtHardWare.DefaultView[dgvHardWare.CurrentRow.Index]["id"].ToString());
                    sendName = dtHardWare.DefaultView[dgvHardWare.CurrentRow.Index]["cName"].ToString();
                }

            }
            else
            {
                if (dgvComponents.CurrentRow != null && dgvComponents.CurrentRow.Index != -1 && dtComponents != null && dtComponents.DefaultView.Count != 0)
                {
                    sendId = int.Parse(dtComponents.DefaultView[dgvComponents.CurrentRow.Index]["id"].ToString());
                    sendName = dtComponents.DefaultView[dgvComponents.CurrentRow.Index]["cName"].ToString();
                }
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
