using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace hardWareViewer
{
    public partial class frmAddDoc : Form
    {        
        private DataTable dtData,dtOld;
        private int ZoomValue = 10;
        private MemoryStream ms;
        private Bitmap b;
        private byte[] img;

        public frmAddDoc()
        {
            InitializeComponent();
            dgvDoc.AutoGenerateColumns = false;
            openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            //btAdd.Visible = btDel.Visible = btSave.Visible = config.statusCode.Equals("адм");
            btDel.Visible = config.statusCode.Equals("кнт");
        }

        private void frmAddDoc_Load(object sender, EventArgs e)
        {
            dtData = readSQL.getScan(id_journal,typeScan);
            dtOld = dtData.Copy();
            filter();
            dgvDoc.DataSource = dtData;
        }

        private void btZoomOut_Click(object sender, EventArgs e)
        {
            ZoomValue -= 1;
            if (ZoomValue == 0)
                ZoomValue = 1;
            imagePanel1.Zoom = ZoomValue * 0.02f;
        }

        private void btZoomIn_Click(object sender, EventArgs e)
        {
            ZoomValue += 1;
            imagePanel1.Zoom = ZoomValue * 0.02f;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            string[] listFile = Directory.GetFiles("tmp");
            foreach (string remFile in listFile)
            {
                try
                {
                    File.Delete(remFile);
                }
                catch { };
            }
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (typeScan == 3 || typeScan == 8)
            {

                DataTable dtTmp = readSQL.getActWriteOff(DateTime.Now, DateTime.Now, id_journal);

                if (dtTmp != null && dtTmp.Rows.Count > 0)
                {

                    EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable()
                        .Where(r => r.Field<int>("id") == -1);


                    if (rowCollect.Count() > 0)
                    {
                        Logging.StartFirstLevel(1270);
                        Logging.Comment("Редактирование списка документов акта");
                        if (dtTmp != null && dtTmp.Rows.Count > 0)
                        {
                            Logging.Comment("Заголовок акта:");
                            Logging.Comment($"Id акта: {id_journal}");
                            Logging.Comment($"Номер акта: {dtTmp.Rows[0]["Number"]}");
                            Logging.Comment($"Дата создания акта: {dtTmp.Rows[0]["Date"]}");
                            Logging.Comment($"Причина списания: { dtTmp.Rows[0]["Reason"]}");
                            Logging.Comment($"Статуса акта Id:{dtTmp.Rows[0]["Status"]}; Наименование:{dtTmp.Rows[0]["nameStatus"]}");
                        }

                        Logging.Comment("Добавленные документы");
                        foreach (DataRow row in rowCollect)
                        {
                            Logging.Comment($"Имя файла:{row["cName"]}");
                        }

                        Logging.StopFirstLevel();
                    }


                    if (lDelete.Count > 0)
                    {
                        Logging.StartFirstLevel(1271);
                        Logging.Comment("Редактирование списка документов акта");
                        if (dtTmp != null && dtTmp.Rows.Count > 0)
                        {
                            Logging.Comment("Заголовок акта:");
                            Logging.Comment($"Id акта: {id_journal}");
                            Logging.Comment($"Номер акта: {dtTmp.Rows[0]["Number"]}");
                            Logging.Comment($"Дата создания акта: {dtTmp.Rows[0]["Date"]}");
                            Logging.Comment($"Причина списания: { dtTmp.Rows[0]["Reason"]}");
                            Logging.Comment($"Статуса акта Id:{dtTmp.Rows[0]["Status"]}; Наименование:{dtTmp.Rows[0]["nameStatus"]}");
                        }
                        Logging.Comment("Удаленные документы");

                        foreach (int id in lDelete)
                        {
                            rowCollect = dtOld.AsEnumerable()
                                                    .Where(r => r.Field<int>("id") == id);

                            if (rowCollect.Count() > 0)
                            {
                                Logging.Comment($"Имя файла:{rowCollect.First()["cName"]}");
                            }
                        }

                        Logging.StopFirstLevel();
                    }
                }
            }
            

            foreach (DataRowView rAdd in dtData.DefaultView)
            {
                readSQL.setScan(id_journal,
                    rAdd["cName"].ToString(),
                    (byte[])rAdd["Scan"],
                    typeScan,
                    int.Parse(rAdd["id"].ToString()),
                    false
                    );
            }

            foreach (int idDel in lDelete)
            {
                readSQL.setScan(id_journal,
                    "",
                    null,
                    typeScan,
                    idDel,
                    true
                    );
            }
            MessageBox.Show("Данные сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Файлы Doc|*.docx;*.doc;*.xlsx;*.xls;*.pdf;*.vsd;*.rtf|" +
                "IMG img| *.png;*.jpg;*.jpeg;*.bmp|" +
                "Все файлы| *.*";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                string selectFile = openFileDialog1.FileName;
                string nameFile = openFileDialog1.SafeFileName;
                string nameFileWithOutExension = Path.GetFileNameWithoutExtension(nameFile);
                string extension = Path.GetExtension(selectFile);
                int typeFile = config.getExension(extension);
                img = File.ReadAllBytes(selectFile);
                //ms = new MemoryStream(img);
                //b = new Bitmap(ms);
                //imagePanel1.Image = (Bitmap)b;
                //ZoomValue = 10;
                //imagePanel1.Zoom = ZoomValue * 0.02f;                    
                dtData.Rows.Add(-1, nameFile, img, DateTime.Now, config.userName);
                filter();
            }
        }

        private void dgvDoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDoc.CurrentRow != null && dgvDoc.CurrentRow.Index != -1)
            {
                img = (byte[])dtData.DefaultView[dgvDoc.CurrentRow.Index]["Scan"];
                ms = new MemoryStream(img);
                try { b = new Bitmap(ms); btZoomIn.Enabled = btZoomOut.Enabled = true; }
                catch { b = null; btZoomIn.Enabled = btZoomOut.Enabled = false; }
                imagePanel1.Image = (Bitmap)b;
                ZoomValue = 10;
                imagePanel1.Zoom = ZoomValue * 0.02f;
                tbFio.Text = dtData.DefaultView[dgvDoc.CurrentRow.Index]["FIO"].ToString();
                tbDate.Text = dtData.DefaultView[dgvDoc.CurrentRow.Index]["DateCreate"].ToString();               
            }
            else
            {
                tbFio.Text = tbDate.Text = "";
                imagePanel1.Image = null;
                btZoomIn.Enabled = btZoomOut.Enabled = false;
            }
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("tmp"))
            {
                Directory.CreateDirectory("tmp");
            }
            string openFile = @"tmp\" + dtData.DefaultView[dgvDoc.CurrentRow.Index]["cName"].ToString();
            FileStream fs = new FileStream(openFile, FileMode.Create, System.IO.FileAccess.Write);
            fs.Write(img, 0, img.Length);
            fs.Close();
            System.Diagnostics.Process.Start(openFile);
        }

        List<int> lDelete = new List<int>();
        private void btDel_Click(object sender, EventArgs e)
        {
            if (dgvDoc.CurrentRow != null && dgvDoc.CurrentRow.Index != -1)
            {
                if (int.Parse(dtData.DefaultView[dgvDoc.CurrentRow.Index]["id"].ToString()) != -1)
                    lDelete.Add(int.Parse(dtData.DefaultView[dgvDoc.CurrentRow.Index]["id"].ToString()));
                dgvDoc.Rows.RemoveAt(dgvDoc.CurrentRow.Index);
                filter();
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void filter()
        {
            try
            {
                string filter = "";

                filter += string.Format("cName like '%{0}%'", tbName.Text.Trim());

                dtData.DefaultView.RowFilter = filter;
                btDel.Enabled = btOpen.Enabled = btZoomIn.Enabled = btZoomOut.Enabled = dtData.DefaultView.Count != 0;                
            }
            catch
            {
                btDel.Enabled = btOpen.Enabled = btZoomIn.Enabled = btZoomOut.Enabled = false;
                if (dtData != null)
                    dtData.DefaultView.RowFilter = "id = -9999";
            }
        }


        private int id_journal = 0;
        private int typeScan = 0;

        public void setId_journal(int _id_journal)
        {
            this.id_journal = _id_journal;
        }

        public void setTypeScan(int _typeScan)
        {
            this.typeScan = _typeScan;
        }

        public void setView()
        {
            btSave.Visible = btDel.Visible = btAdd.Visible = btDel.Visible = btScaner.Visible = false;
        }

        private void btScaner_Click(object sender, EventArgs e)
        {
            try
            {
                Nwuram.Framework.scan.scanImg fImg = new Nwuram.Framework.scan.scanImg();
                fImg.ShowDialog();
                this.TopMost = true;
                byte[] img_array = fImg.img_array;
                if (img_array != null)
                {
                    dtData.Rows.Add(-1, "scaner", img, DateTime.Now, config.userName);
                    filter();
                }
                this.TopMost = false;
            }
            catch
            {
                MessageBox.Show("Ошибка при работе со сканером!");
            }
        }
    }
}
