using Nwuram.Framework.Settings.Connection;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.Text = "\"" + Nwuram.Framework.Settings.Connection.ConnectionSettings.ProgramName + "\", \"" + Nwuram.Framework.Settings.User.UserSettings.User.Status + "\", " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername + "";
            tslMainConnect.Text = ConnectionSettings.GetServer() + " " + ConnectionSettings.GetDatabase();
            tslAddConnect.Text = ConnectionSettings.GetServer("2") + " " + ConnectionSettings.GetDatabase("2");
            tslAdd2Connect.Text = ConnectionSettings.GetServer("3") + " " + ConnectionSettings.GetDatabase("3");
        }

        private void tsmiDirectoryResponsible_Click(object sender, EventArgs e)
        {
            frmDirectoryResponsible frm = new frmDirectoryResponsible();
            frm.ShowDialog();
        }

        private void tsmiDirectoryPlaceHardWare_Click(object sender, EventArgs e)
        {
            frmDirectoryPlaceHardWare frm = new frmDirectoryPlaceHardWare();
            frm.ShowDialog();
        }

        private void tsmiDirectoryTypeHardWare_Click(object sender, EventArgs e)
        {
            frmDirectoryTypeHardWare frm = new frmDirectoryTypeHardWare();
            frm.ShowDialog();
        }

        private void tsmDirectoryTypeComponents_Click(object sender, EventArgs e)
        {
            frmDirectoryTypeComponents frm = new frmDirectoryTypeComponents();
            frm.ShowDialog();
        }

        private void tsmiDirectoryHardWareAndComponents_Click(object sender, EventArgs e)
        {
            frmDirectoryHardWareAndComponents frm = new frmDirectoryHardWareAndComponents();
            frm.setDirectory();
            frm.ShowDialog();
        }

        private void tsmiJournalEstimates_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Tag = "frmJournalEstimates";
            AddTab(sender, e);
            //frmJournalEstimates frm = new frmJournalEstimates();
            //frm.ShowDialog();
        }

        private void tsmiJournalActInventory_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Tag = "frmJournalActInventory";
            AddTab(sender, e);
            //frmJournalActInventory frm = new frmJournalActInventory();
            //frm.ShowDialog();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiJournalActWriteOff_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Tag = "frmJournalActWriteOff";
            AddTab(sender, e);
            //frmJournalActWriteOff frm = new frmJournalActWriteOff();
            //frm.Text = tsmiJournalActWriteOff.Text;
            //frm.ShowDialog();
        }

        private void tsmiListHardware_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Tag = "frmListHardware";
            AddTab(sender, e);
            //frmListHardware frm = new frmListHardware();            
            //frm.ShowDialog();
        }

        private void tsmiJournalActReceivingTransfer_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Tag = "frmJournalActReceivingTransfer";
            AddTab(sender, e);
            //frmJournalActReceivingTransfer frm = new frmJournalActReceivingTransfer();
            //frm.ShowDialog();

        }

        private void tsmiDirectoryObject_Click(object sender, EventArgs e)
        {
            frmDirectoryObject frm = new frmDirectoryObject();
            frm.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("Закрыть программу?","Выход",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            config.SetDoubleBuffered(tcMain);
            SetTab(tsmiListHardware.Text, "frmListHardware", null, null);
            //SetTab("Обоснование списания", "hardWareViewer.frmJournalActReceivingTransfer", null, null);

            //string type = "hardWareViewer.frmJournalActReceivingTransfer";
            //string AssemblyName = type.Substring(0, type.IndexOf("."));                                    
            //Type objType = Type.GetType(type);

            //object aas = Activator.CreateInstance(objType);

            //Console.WriteLine($"Assembly full name:\n   {objType.Assembly.FullName}.");
            //Console.WriteLine(aas.ToString());
            tsmiContolScaner.Visible = config.statusCode.Equals("оп") || config.statusCode.Equals("кнт");
        }

        private void tsmiContolScaner_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Tag = "hardWareViewer.scaners.frmContScaner";
            AddTab(sender, e);
            //new scaners.frmContScaner().ShowDialog();
        }


        #region ""

        Form currentForm;
         
        /// <summary>
        /// Добавление закладки(если закладка уже есть - выбор закладки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTab(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Tag != null)
            {
                SetTab(((ToolStripMenuItem)sender).Text, ((ToolStripMenuItem)sender).Tag.ToString(), null, null);
            }
        }

        public void SetTab(string tabText, string tag, object[] args, int? frmId)
        {
            string formName = tag; //Название формы
            if (frmId != null && !tag.Contains(frmId.ToString()))
                tag += frmId.ToString(); //Тэг формы для поиска

            //Выбор существующей формы
            foreach (TabPage tpag in tcMain.TabPages)
            {
                if (tpag.Tag.ToString() == tag)
                {
                    tcMain.SelectedTab = tpag;
                    SelectMdiChild(tag);
                    return;
                }
            }
            tcMain.TabPages.Add(tabText);
            tcMain.SelectedTab = tcMain.TabPages[tcMain.TabPages.Count - 1];

            //Добавление новой формы
            string BaseType = (formName.IndexOf('.') == -1 ? "hardWareViewer." : "") +
                formName;
            tcMain.SelectedTab.Tag = tag;
            Form frm;
            if (args == null)
            {
                frm = GetInstance<Form>(BaseType);
            }
            else
            {
                frm = GetInstance<Form>(BaseType, args);
                if (frmId != null)
                {
                    frm.Name = frm.Name + frmId.ToString();
                }
            }

            frm.Tag = tag;
            frm.MdiParent = this;
            //frm.ControlBox = false;
            //frm.ShowIcon = false;
            //frm.Text = string.Empty;

            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Normal;
            currentForm = frm;
            SetChildDimensions(frm);
            frm.Show();
            //currentForm = frm;
            //SetChildDimensions(frm);
            frm.FormClosed += new FormClosedEventHandler(mdiClosedByButton);

            //Устанавливаем двойную буфферизацию для гридов
            foreach (Control con in frm.Controls)
            {
                if (con is DataGridView)
                {
                    config.SetDoubleBuffered(con);
                }
            }
        }

        private void mdiClosedByButton(object sender, FormClosedEventArgs e)
        {
            CloseTab(((Form)sender).Tag.ToString());
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ///// <summary>
        ///// Добавление дочерней MDI формы
        ///// </summary>
        ///// <param name="frm">Форма для добавления</param>
        //private void AddChlid(Form frm)
        //{
        //    frm.MdiParent = this;
        //    frm.Show();
        //    frm.WindowState = FormWindowState.Maximized;
        //}

        /// <summary>
        /// Выбор текущей дочерней формы (переход по вкладкам)
        /// </summary>
        /// <param name="frmName">Название формы</param>
        private void SelectMdiChild(string frmName)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == frmName || (frm.Tag != null && frm.Tag.ToString() == frmName))
                {
                    frm.Show();
                    currentForm = frm;
                    SetChildDimensions(frm);
                    //if (frm.Name == "frmRequests")
                    //{
                    //    ((frmRequests)frm).GetGridRequests();
                    //}
                }
                else
                {
                    frm.Size =
                    frm.MaximumSize =
                    frm.MinimumSize = new Size(1, 1);
                    frm.Location = new Point(0, 0);
                }
            }
        }

        /// <summary>
        /// Получение типа по названию
        /// </summary>
        /// <typeparam name="T">Базовый тип</typeparam>
        /// <param name="type">Название типа</param>
        /// <returns></returns>
        private T GetInstance<T>(string type)
        {
            string AssemblyName = type.Substring(0, type.IndexOf("."));
            return (T)Activator.CreateInstance(Type.GetType(type + ", " + AssemblyName));
        }

        /// <summary>
        /// Получение типа по названию
        /// </summary>
        /// <typeparam name="T">Базовый тип</typeparam>
        /// <param name="type">Название типа</param>
        ///  <param name="type">Аргументы </param>
        /// <returns></returns>
        private T GetInstance<T>(string type, object[] args)
        {
            string AssemblyName = type.Substring(0, type.IndexOf("."));
            return (T)Activator.CreateInstance(Type.GetType(type + ", " + AssemblyName), args);
        }

        private void tcMain_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control.Tag != null)
            {
                if (e.Control.Tag.Equals("frmListHardware")) return;
                if (e.Control.Tag.Equals("hardWareViewer.frmListHardware")) return;


                if (!RemoveMdiChild(e.Control.Tag.ToString()))
                {
                    tcMain.TabPages.Insert(tcMain.TabPages.IndexOf((TabPage)e.Control), (TabPage)e.Control);
                }
            }
        }

        /// <summary>
        /// Закрытие формы по зарытию вкладки
        /// </summary>
        /// <param name="frmName">Название формы</param>
        private bool RemoveMdiChild(string frmName)
        {
            bool retValue = true;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == frmName || (frm.Tag != null && frm.Tag.ToString() == frmName))
                {
                    frm.Close();
                    if (frm.DialogResult == DialogResult.No)
                    {
                        retValue = false;
                    }
                    break;
                }

            }

            if (this.MdiChildren.Count() == 0)
            {
                currentForm = null;
            }

            return retValue;
        }

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcMain.SelectedTab != null && tcMain.SelectedTab.Tag != null)
            {
                SelectMdiChild(tcMain.SelectedTab.Tag.ToString());
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.MdiChildren.Count() != 0 && currentForm != null)
            {
                SetChildDimensions(currentForm);
            }
        }

        private void SetChildDimensions(Form frm)
        {
            frm.StartPosition = FormStartPosition.Manual;
            frm.Size =
            frm.MinimumSize =
            frm.MaximumSize = new Size((this.ClientSize.Width != 0 ? this.ClientSize.Width - 4 : 2)
                                        , (this.ClientSize.Height != 0 ? this.ClientSize.Height - 72 : 2));
            frm.Location = new Point(0, 0);

            foreach (Form child in this.MdiChildren)
            {
                if (child != frm)
                {
                    child.Hide();
                }
            }
        }

        public void CloseTab(string tag)
        {
            foreach (TabPage tpMain in tcMain.TabPages)
            {
                if (tpMain.Tag.ToString() == tag)
                {
                    tcMain.TabPages.Remove(tpMain);
                    break;
                }
            }
        }

        public bool isFormOpened(string tag)
        {
            string formName = tag; //Название формы

            //Выбор существующей формы
            foreach (TabPage tpag in tcMain.TabPages)
            {
                if (tpag.Tag.ToString() == tag)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
