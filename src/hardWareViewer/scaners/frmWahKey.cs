using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hardWareViewer.scaners
{
    public partial class frmWahKey : Form
    {
        private bool isEdit = false;
        private bool isGet = false;
        private int idDepsUser = -1;
        public void setGet(bool isGet)
        {
            this.isGet = isGet;
        }

        public frmWahKey()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmWahKey_Load(object sender, EventArgs e)
        {
            btSave.Enabled = false;
            //isGet = true;
            if (isGet)
            {
                this.Text = "Принять сканер";
                btSave.Text = "Принять сканер";
            }
            else
            {
                this.Text = "Выдать сканер";
                btSave.Text = "Выдать сканер";
            }
            getRooms();
            isEdit = false;
        }

        private void frmWahKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isEdit && DialogResult.No == MessageBox.Show(config.centralText("На форме есть несохраненные данные.\nЗакрыть форму без сохранения?\n"), "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private DataTable dtScaner;
        private void getRooms()
        {
            dtScaner = readSQL.getListScaners();
            cmbNumberRoom.DataSource = dtScaner;
            cmbNumberRoom.SelectedIndex = -1;
            isEdit = true;
        }

        private void cmbNumberRoom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                tbKeyCode.Text = dtScaner.Select("id = " + cmbNumberRoom.SelectedValue)[0]["EAN"].ToString();
                isEdit = true;
            }
            catch { }
            button_enable();
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            int id_office = (int)cmbNumberRoom.SelectedValue;
            DateTime nowDate = Convert.ToDateTime(readSQL.getDateTime().Rows[0]["date"].ToString());
            DataTable dtResult = new DataTable();
            if (isGet)
            {
                dtResult = readSQL.setInOutScan(id_office, idKadr, null, nowDate, null, idKadr);

                Logging.StartFirstLevel(936);

                Logging.Comment("ID сотрудника: " + idKadr);
                Logging.Comment("Код сотрудника: " + tbCode.Text.ToString());
                Logging.Comment("ФИО сотрудника: " + tbFIO.Text.ToString());

                Logging.Comment("ID отдела сотрудника: " + idDepsUser);
                Logging.Comment("Наименование отдела сотрудника: " + tbDeps.Text.ToString());

                Logging.Comment("ID сканера: " + id_office);
                Logging.Comment("Код сканера: " + tbKeyCode.Text.ToString());
                Logging.Comment("Инв. номер сканера: " + cmbNumberRoom.Text);


                Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();
            }
            else
            {
                dtResult = readSQL.setInOutScan(id_office, null, idKadr, null, nowDate, idKadr);

                Logging.StartFirstLevel(941);

                Logging.Comment("ID сотрудника: " + idKadr);
                Logging.Comment("Код сотрудника: " + tbCode.Text.ToString());
                Logging.Comment("ФИО сотрудника: " + tbFIO.Text.ToString());

                Logging.Comment("ID отдела сотрудника: " + idDepsUser);
                Logging.Comment("Наименование отдела сотрудника: " + tbDeps.Text.ToString());

                Logging.Comment("ID сканера: " + id_office);
                Logging.Comment("Код сканера: " + tbKeyCode.Text.ToString());
                Logging.Comment("Инв. номер сканера: " + cmbNumberRoom.Text);


                Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();
            }

            if (dtResult == null || dtResult.Rows.Count == 0 || dtResult.Rows[0]["id"].ToString().Equals("-1"))
            {
                MessageBox.Show(config.centralText(dtResult.Rows[0]["msg"].ToString() + "\n"), "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //tbCode.Clear();
                //tbFIO.Clear();
                //tbNum.Clear();
                //tbDeps.Clear();
                //pbDoc.Image = null;
                cmbNumberRoom.SelectedIndex = -1;
                tbKeyCode.Clear();
                tbKeyCode.Focus();
                return;                
            }
           
            if (dtResult.Rows[0]["msg"].ToString().Trim().Length > 0)
            {
                MessageBox.Show(config.centralText(dtResult.Rows[0]["msg"].ToString() + "\n"), "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            isEdit = false;
            cmbNumberRoom.SelectedIndex = -1;
            tbKeyCode.Clear();
            tbKeyCode.Focus();
            //this.DialogResult = DialogResult.OK;
        }

        string tCode = "";
        string tKeyCode = "";
        int idKadr;
        private void tbCode_Validated(object sender, EventArgs e)
        {

            if (tbCode.Text.Length > 0)
            {
                isEdit = true;
                if (tCode != tbCode.Text)
                {
                    //if (Config.hCntMain.isEmpAddNotAllow(Int64.Parse(tbCode.Text), -1))
                    //{
                    //    ClearFields();
                    //    return;
                    //}

                    DateTime nowDate = Convert.ToDateTime(readSQL.getDateTime().Rows[0]["date"].ToString());
                    DataTable dtUser = readSQL.getDateUser(Convert.ToInt64(tbCode.Text.ToString()), 0);
                    if (dtUser != null && dtUser.Rows.Count > 0)
                    {
                        idKadr = int.Parse(dtUser.Rows[0]["id"].ToString());
                        DataTable dtUmplo = readSQL.getdateUnemploy(nowDate, idKadr);
                        if (dtUmplo != null && dtUmplo.Rows.Count > 0)
                        {
                            MessageBox.Show("Данный сотрудник уволен!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbCode.Clear();
                            tbFIO.Clear();
                            tbNum.Clear();
                            tbDeps.Clear();
                            pbDoc.Image = null;
                            tbCode.Focus();
                            return;
                        }
                        tbNum.Text = dtUser.Rows[0]["NumberBeycik"].ToString();
                        tbFIO.Text = dtUser.Rows[0]["fio"].ToString();
                        tbDeps.Text = dtUser.Rows[0]["dep"].ToString();
                        idDepsUser = int.Parse(dtUser.Rows[0]["idDep"].ToString());
                        if (dtUser.Rows[0]["pic"].ToString().Length > 0)
                        {
                            byte[] img = (byte[])dtUser.Rows[0]["pic"];
                            MemoryStream ms = new MemoryStream(img);
                            pbDoc.Image = Image.FromStream(ms); //выводим изображение
                        }
                        else
                        {
                            pbDoc.Image = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Информация по сотруднику не была найдена!");
                        tbNum.Text = "";
                        tbFIO.Text = "";
                        tbDeps.Text = "";
                        pbDoc.Image = null;
                        idKadr = 0;
                        //GetFindUser(nowDate, Convert.ToInt64(tbCode.Text.ToString()), 0);
                    }
                }
            }
            else
            {
                if (tbNum.Text.Length == 0)
                {
                    //changeButtonsEnabled(false);
                }
            }
            tCode = tbCode.Text;
            button_enable();
        }

        private void tbCode_TextChanged(object sender, EventArgs e)
        {

            if (tbCode.Text.ToString().Length == 13)
            {
                isEdit = true;
                long c = 0;
                if (!long.TryParse(tbCode.Text, out c))
                {
                    MessageBox.Show("Такого кода не существует!");
                    tbCode.Text = "";
                    tbCode.Focus();
                    return;
                }

                //if (Config.hCntMain.IsOut(long.Parse(tbCode.Text)))
                //{
                //    Config.hCntMain.SetLogOutputs(0, long.Parse(tbCode.Text), UserSettings.User.Id);
                //    ShowUserInfo();
                //    if (!bw.IsBusy)
                //    {
                //        this.Enabled = false;
                //        frmM = new frmMsg();
                //        frmM.Show();
                //        bw.RunWorkerAsync();
                //    }
                //    return;
                //}

                //if (Config.hCntMain.isEmpAddNotAllow(Int64.Parse(tbCode.Text), -1))
                //{
                //    ClearFields();
                //    return;
                //}

                DateTime nowDate = Convert.ToDateTime(readSQL.getDateTime().Rows[0]["date"].ToString());
                tCode = tbCode.Text;
                DataTable dtUser = readSQL.getDateUser(Convert.ToInt64(tbCode.Text.ToString()), 0);

                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    idKadr = int.Parse(dtUser.Rows[0]["id"].ToString());
                    DataTable dtUmplo = readSQL.getdateUnemploy(nowDate, idKadr);
                    if (dtUmplo != null && dtUmplo.Rows.Count > 0)
                    {
                        MessageBox.Show("Данный сотрудник уволен!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbCode.Clear();
                        tbFIO.Clear();
                        tbNum.Clear();
                        tbDeps.Clear();
                        pbDoc.Image = null;
                        tbCode.Focus();
                        return;
                    }


                    //DataTable dtTypeShop = Config.hCntMain.getTypeShop(Convert.ToInt64(tbCode.Text.ToString()), 0);
                    int typeVahta = 0;// Convert.ToInt32(Properties.Settings.Default.typeShop);
                    int typeShop = 0;// Convert.ToInt32(dtTypeShop.Rows[0]["id_typeShop"]);
                    //if (dtTypeShop != null)
                    //{
                    //    if (typeShop != 3 && typeShop != typeVahta)
                    //    {
                    //        MessageBox.Show("У данного сотрудника нет пропуска на объект: ", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        tbCode.Clear();
                    //        return;
                    //    }
                    //}


                    tbNum.Text = dtUser.Rows[0]["NumberBeycik"].ToString();
                    tbFIO.Text = dtUser.Rows[0]["fio"].ToString();
                    tbDeps.Text = dtUser.Rows[0]["dep"].ToString();
                    idDepsUser = int.Parse(dtUser.Rows[0]["idDep"].ToString());
                    if (dtUser.Rows[0]["pic"].ToString().Length > 0)
                    {
                        byte[] img = (byte[])dtUser.Rows[0]["pic"];
                        MemoryStream ms = new MemoryStream(img);
                        pbDoc.Image = Image.FromStream(ms); //выводим изображение

                        // ExitSmena = 1;
                    }
                    else
                    {
                        pbDoc.Image = null;
                    }

                    tbKeyCode.Focus();
                }
                else
                {
                    MessageBox.Show("Информация по сотруднику не была найдена!");
                    tbNum.Text = "";
                    tbFIO.Text = "";
                    tbDeps.Text = "";
                    pbDoc.Image = null;
                    idKadr = 0;
                }
            }
            button_enable();
        }

        frmMsg frmM = new frmMsg();

        private void tbKeyCode_Validated(object sender, EventArgs e)
        {
            if (dtScaner != null)
                if (tKeyCode != tbKeyCode.Text)
                {
                    if (tbKeyCode.Text.Trim().Length > 0)
                    {
                        if (dtScaner.Select("CONVERT(EAN,'System.String') = '" + tbKeyCode.Text + "'").Count() == 0)
                        {
                            MessageBox.Show("Данных по сканеру нет в БД.", "Выдать ключ");
                        }
                        else
                        {
                            cmbNumberRoom.SelectedValue = dtScaner.Select("CONVERT(EAN,'System.String') = '" + tbKeyCode.Text + "'")[0]["id"];
                            btSave.Focus();
                        }
                        isEdit = true;
                    }
                    tKeyCode = tbKeyCode.Text;
                    button_enable();
                }
        }

        private void button_enable()
        {
            btSave.Enabled = cmbNumberRoom.SelectedIndex != -1 && tbKeyCode.Text.Trim().Length != 0 && tbFIO.Text.Trim().Length != 0;
        }

        private void tbKeyCode_TextChanged(object sender, EventArgs e)
        {
            if (tbKeyCode.Text.ToString().Length == 13)
            {
                tKeyCode = tbKeyCode.Text;
                if (tbKeyCode.Text.Trim().Length > 0)
                {
                    if (dtScaner.Select("CONVERT(EAN,'System.String') = '" + tbKeyCode.Text + "'").Count() == 0)
                    {
                        MessageBox.Show("Данных по cканеру нет в БД.", "Выдать ключ");
                    }
                    else
                    {
                        cmbNumberRoom.SelectedValue = dtScaner.Select("CONVERT(EAN,'System.String') = '" + tbKeyCode.Text + "'")[0]["id"];
                        btSave.Focus();
                    }
                    isEdit = true;
                }
                button_enable();
            }
        }

        private void tbCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b');
        }

        private void tbKeyCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b');
        }

        private void tbKeyCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tbDeps.Focus();
                    tbKeyCode.Focus();
                    //btSave_Click(this, EventArgs.Empty);
                }
            }
            catch (Exception)
            { }
        }
    }
}
