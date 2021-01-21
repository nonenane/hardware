using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace hardWareViewer.listHardware
{
    public partial class frmMOLChange : Form
    {
        DataRow[] HardwareRows;
        List<int> Responsibles = new List<int>();
        public frmMOLChange(DataRow[] HR)
        {
            HardwareRows = HR;
            InitializeComponent();
            DataTable dtListResp = readSQL.getListResponsibles(1);
            foreach (DataRow r in HardwareRows)
            {
                DataRow[] tmp = dtListResp.Select("id = " + r["id_Responsible"].ToString());
                if (tmp != null && tmp.Length > 0)
                {
                    Responsibles.Add((int)tmp[0]["id"]);
                    dtListResp.Rows.Remove(tmp[0]);
                }
            }
            cbResponsible.DataSource = dtListResp;
            cbResponsible.ValueMember = "id";
            cbResponsible.DisplayMember = "FIO";
            cbResponsible.SelectedIndex = -1;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (cbResponsible.SelectedIndex == -1)
            {
                MessageBox.Show("Необходимо выбрать ответственного.", "Информирование",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach(DataRow r in HardwareRows)
            {
                readSQL.setNewPositionAdded((int)r["id"], (int)r["id_Location"],
                    (int)r["id_ComponentsHardware"], (int)cbResponsible.SelectedValue,
                    (int)r["TypeComponentsHardware"], (string)r["cName"],
                    (string)r["InventoryNumber"], false, r["DatePurchase"], r["WarrantyPeriod"],
                    r["id_ListServiceRecords"] != DBNull.Value ? (int?)r["id_ListServiceRecords"] : null);
                DataTable dtListResp = readSQL.getListResponsibles(1);
                string ffOld = (string)dtListResp.Select("id = " + r["id_Responsible"])[0]["FIO"];
                readSQL.setChangesHardware((int)r["id"], @"Ответственный:", ffOld,
                    cbResponsible.Text, false);
            }
            Report();
            this.DialogResult = DialogResult.OK;
        }

        private void cbResponsible_SelectedIndexChanged(object sender, EventArgs e)
        {
            btSave.Enabled = cbResponsible.SelectedIndex != -1;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Report()
        {
            foreach(int i in Responsibles)
            {
                Word.Application wapp = new Word.Application();
                object mis = Type.Missing;
                Word.Document wdoc = wapp.Documents.Add(ref mis, ref mis, ref mis, ref mis);

                Word.Paragraph p = wdoc.Paragraphs.Add(ref mis);
                p.Range.Text = "Акт приёма-передачи оборудования";
                p.Range.Font.Size = 14;
                p.Range.Font.Bold = 1;
                p.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                p.Range.InsertParagraphAfter();
                
                p.Range.Text = "от " + DateTime.Now.ToShortDateString();
                p.Range.Font.Size = 11;
                p.Range.Font.Bold = 0;
                p.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                p.Range.InsertParagraphAfter();

                DataTable dtOldR = readSQL.GetRespInfo(i);
                DataTable dtNewR = readSQL.GetRespInfo((int)cbResponsible.SelectedValue);
                
                p.Range.Text = "\nСотрудник " + dtOldR.Rows[0]["FIO"].ToString().Trim()
                     + " отдела " + dtOldR.Rows[0]["Dep"].ToString().Trim() +
                     " и сотрудник " + dtNewR.Rows[0]["FIO"].ToString().Trim()
                     + " отдела " + dtNewR.Rows[0]["Dep"].ToString().Trim() +
                     " составили настоящий акт о передаче следующего компьютерного оборудования/комплектующих:";
                p.Range.Font.Size = 12;
                p.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                p.Range.InsertParagraphAfter();

                DataTable tmp = HardwareRows.CopyToDataTable();
                DataRow[] tmp2 = tmp.Select("id_Responsible = " + i.ToString());
                Word.Table t = wdoc.Tables.Add(p.Range, tmp2.Length + 1, 4, ref mis, ref mis);
                t.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                t.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                t.Rows[1].Cells[1].Range.Text = "№ п/п";
                t.Rows[1].Cells[1].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                t.Rows[1].Cells[1].Range.Bold = 1;
                t.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                t.Rows[1].Cells[2].Range.Text = "Наименование оборудования/ комплектующих";
                t.Rows[1].Cells[2].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                t.Rows[1].Cells[2].Range.Bold = 1;
                t.Rows[1].Cells[2].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                t.Rows[1].Cells[3].Range.Text = "Инвентарный номер";
                t.Rows[1].Cells[3].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                t.Rows[1].Cells[3].Range.Bold = 1;
                t.Rows[1].Cells[3].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                t.Rows[1].Cells[4].Range.Text = "Местоположение";
                t.Rows[1].Cells[4].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                t.Rows[1].Cells[4].Range.Bold = 1;
                t.Rows[1].Cells[4].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                for (int j = 0; j < tmp2.Length; j++)
                {
                    t.Rows[j + 2].Cells[1].Range.Text = (j + 1).ToString();
                    t.Rows[j + 2].Cells[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    t.Rows[j + 2].Cells[2].Range.Text = tmp2[j]["cName"].ToString();
                    t.Rows[j + 2].Cells[3].Range.Text = tmp2[j]["InventoryNumber"].ToString();
                    t.Rows[j + 2].Cells[3].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    t.Rows[j + 2].Cells[4].Range.Text = tmp2[j]["nameLocation"].ToString();
                    t.Rows[j + 2].Cells[4].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                t.Columns.AutoFit();

                p.Range.InsertParagraphAfter();
                p.Range.Text = "Сдал:\t\t\t_______________/\t" + dtOldR.Rows[0]["FIO"].ToString().Trim();
                p.Range.Font.Size = 12;
                p.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                p.Range.InsertParagraphAfter();
                p.Range.Text = "Принял:\t\t_______________/\t" + dtNewR.Rows[0]["FIO"].ToString().Trim();
                p.Range.Font.Size = 12;
                p.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                p.Range.InsertParagraphAfter();

                wapp.Visible = true;
            }
        }
    }
}
