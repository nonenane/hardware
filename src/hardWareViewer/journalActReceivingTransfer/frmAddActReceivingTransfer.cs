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
    public partial class frmAddActReceivingTransfer : Form
    {
        private int id_actReceivingTransfer = -1;
        public frmAddActReceivingTransfer()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            gen_combobox();
            get_data();
        }

        public void setRow(DataRowView _row)
        {
            dtpStart.Enabled = false;
            tbComment.ReadOnly = true;
            id_actReceivingTransfer = int.Parse(_row["id"].ToString());
            dtpStart.Value = DateTime.Parse(_row["Date"].ToString());
            tbComment.Text = _row["Comment"].ToString();
            get_data();
        }

        private void gen_combobox()
        {
            DataTable dtLocation = readSQL.getLocation();
            //dtLocation.DefaultView.RowFilter = "isActive =1";
            cLocation.DataSource = dtLocation;
            cLocation.ValueMember = "id";
            cLocation.DisplayMember = "cName";

            DataTable dtResponsibole = readSQL.getListResponsibles(1);
            //dtResponsibole.DefaultView.RowFilter = "isActive =1";
            cResponsible.DataSource = dtResponsibole;
            cResponsible.ValueMember = "id";
            cResponsible.DisplayMember = "FIO";
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmListHardware frm = new frmListHardware();
            frm.setSelectStatus();
            //frm.ShowDialog();
            //frmDirectoryHardWareAndComponents frm = new frmDirectoryHardWareAndComponents();
            if (DialogResult.OK == frm.ShowDialog())
            {
                //DataRow addRow = dtData.Rows.Add();
                //addRow["id"] = -1;
                //addRow["cName"] = frm.getSendName();
                //addRow["id_Hardware"] = frm.getSendId();
                //addRow["TypeComponentsHardware"] = frm.getIsHardWare();
                //addRow["id_hardwareComponent"] = -1;
                //addRow["id_estimateContent"] = -1;                
                //dtData.AcceptChanges();
                //dgvData.Refresh();

                DataTable dtSend = frm.getDataTable().Copy();
                foreach (DataRow r in dtSend.Rows)
                {
                    DataRow addRow = dtData.Rows.Add();
                    addRow["id"] = -1;
                    addRow["cName"] = r["cName"].ToString();
                    addRow["id_Hardware"] = r["id"];
                    addRow["TypeComponentsHardware"] = r["TypeComponentsHardware"];
                    addRow["id_hardwareComponent"] = r["id_ComponentsHardware"];
                    addRow["id_estimateContent"] = r["id"];
                    dtData.AcceptChanges();
                }
                dgvData.Refresh();

            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1
              && dtData != null && dtData.DefaultView.Count != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Удалить запись?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    int id = int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                    //string cName = dtHardWare.DefaultView[dgvHardWare.CurrentRow.Index]["cName"].ToString();
                    //string description = dtHardWare.DefaultView[dgvHardWare.CurrentRow.Index]["Description"].ToString();
                    //readSQL.setHardWare(id, cName, description, 0, 2, true);
                    dgvData.Rows.RemoveAt(dgvData.CurrentRow.Index);
                    //get_data_hardware();
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            DataTable dtResult = readSQL.setActReceivingTransfer(id_actReceivingTransfer, "", dtpStart.Value, tbComment.Text.Trim(),0, 1);
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

            id_actReceivingTransfer = int.Parse(dtResult.Rows[0]["id"].ToString());

            foreach(DataRow r in dtData.Rows)
            {
                dtResult = readSQL.setContentReceivingTransfer(int.Parse(r["id"].ToString()),
                    id_actReceivingTransfer,
                    r["id_Hardware"],
                    r["TypeComponentsHardware"],
                    r["id_Location"],
                    r["id_Responsible"],
                    "",
                    null,
                    r["id_hardwareComponent"],
                    r["id_estimateContent"],
                    r["isZip"],
                    1);
            }
            MessageBox.Show("Данные сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;  
        }

        private void btCreateWithOutEstimate_Click(object sender, EventArgs e)
        {
            frmJournalEstimates frm = new frmJournalEstimates();
            frm.getEstimate();
            if (DialogResult.OK == frm.ShowDialog())
            {
                DataTable dtSend = frm.getDataTable().Copy();
                foreach (DataRow r in dtSend.Rows)
                {
                    DataRow addRow = dtData.Rows.Add();
                    addRow["id"] = -1;
                    addRow["cName"] = r["cName"].ToString();
                    addRow["id_Hardware"] = -1;// r["id_ComponentsHardware"];
                    addRow["TypeComponentsHardware"] = r["TypeComponentsHardware"];
                    addRow["id_hardwareComponent"] = r["id_ComponentsHardware"];
                    addRow["id_estimateContent"] = r["id"];
                    dtData.AcceptChanges();                  
                }
                dgvData.Refresh();
            }
        }

        private DataTable dtData;
        private void get_data()
        {
            dtData = readSQL.getContentReceivingTransfer(id_actReceivingTransfer);
            dgvData.DataSource = dtData;
        }

        private void btAddDoc_Click(object sender, EventArgs e)
        {

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex].Name.Equals("cZip"))
            {               
                    bool isSelect = false;
                    if (dtData.DefaultView[e.RowIndex]["isZip"] != DBNull.Value)
                        isSelect = bool.Parse(dtData.DefaultView[e.RowIndex]["isZip"].ToString());
                    dtData.DefaultView[e.RowIndex]["isZip"] = !isSelect;
                    dtData.AcceptChanges();
                    dgvData.Refresh();               
            }
        }

        public void setDataCreateEstimates(DataTable _dtData)
        {
            btCreateWithOutEstimate.Visible = false;
            DataTable dtSend = _dtData.Copy();
            foreach (DataRow r in dtSend.Rows)
            {
                DataRow addRow = dtData.Rows.Add();
                addRow["id"] = -1;
                addRow["cName"] = r["cName"].ToString();
                addRow["id_Hardware"] = -1;// r["id_ComponentsHardware"];
                addRow["TypeComponentsHardware"] = r["TypeComponentsHardware"];
                addRow["id_hardwareComponent"] = r["id_ComponentsHardware"];
                addRow["id_estimateContent"] = r["id"];
                dtData.AcceptChanges();
            }
            dgvData.Refresh();
        }
    }
}
