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
    /// <summary>Код формы просмотра и редактирования сметы.</summary>
    /// Данная форма содержит основную информацию о смете и позволяет управлять в ней оборудованием и комплектующим.
    public partial class frmAddEstimates : Form
    {
        private bool isCreate = true;
        private int id = -1, statusEstimate = 0;
        private bool isEdit = false;
        private List<indexs> tempIndex = new List<indexs> {};       ///< Список для отработки условий добавления / замены для не существующих связей 
        private List<indexs> delIndex = new List<indexs> {};        ///< Список для отработки условий удаления существущих связей
        private List<indexs> contentEst = new List<indexs> {};      ///< Список для отработки условий добавления / замены для не существующих связей обороудования и комплектующих
        private List<indexs> delContentEst = new List<indexs> {};   ///< Список для отработки условий удаления существущих связей обороудования и комплектующих

        public frmAddEstimates()
        {
            InitializeComponent();
            get_status_type();
            get_departments();
            get_object();
            changeButtonStatusEnable();
        }

        private DataTable dtTableStatus;
        private void tableStatus()
        {
            dtTableStatus = readSQL.getTableStatusEstimat(statusEstimate,1);
        }

        private DataTable dtData;
        #region "Создание сметы"

        public void setCreate()
        {
            isCreate = true;
            get_create_smeta();
        }

        /// <summary>
        /// Кнопка добавления оборудования и комплектующих в смету
        /// </summary>
        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAddComponentInEstimates frm = new frmAddComponentInEstimates();
            DataRow sendRow = dtData.Clone().Rows.Add();
            frm.Text = "Добавить оборудование/комплектующие в смету";
            frm.setCreateRow(sendRow);
            if (DialogResult.OK == frm.ShowDialog())
            {
                //dtData.LoadDataRow(frm.getRow().ItemArray, true);
                dtData.ImportRow(frm.getRow());

                // Индекс Оборудования
                int compIndex = dtData.Rows.Count-1;

                if (!bool.Parse(frm.getRow()["TypeComponentsHardware"].ToString()))
                {
                    DataTable dtTempData = readSQL.getHardwareVsComponents(int.Parse(frm.getRow()["id_ComponentsHardware"].ToString()));
                    foreach (DataRow r in dtTempData.Rows)
                    {
                        DataRow rowTempData = dtData.Clone().Rows.Add();
                        rowTempData["id_ComponentsHardware"] = int.Parse(r["id_component"].ToString());
                        rowTempData["TypeComponentsHardware"] = 1;
                        rowTempData["Price"] = 0;
                        rowTempData["Count"] = int.Parse(frm.getRow()["Count"].ToString());
                        rowTempData["Link"] = "";
                        rowTempData["Comments"] = "";
                        rowTempData["Description"] = "";
                        rowTempData["cName"] = r["cName"].ToString();
                        rowTempData["nameType"] = "Комплектующие";
                        rowTempData["nameTypeLinkView"] = "-- Комплектующие";
                        rowTempData["isLink"] = false;
                        rowTempData["summa"] = 0;
                        rowTempData["Status"] = 0;
                        rowTempData["StatusConfirmation"] = 0;
                        rowTempData["Purchase"] = 0;
                        rowTempData["namePurchase"] = "Добавлено в смету";
                        rowTempData["StatusBuild"] = frm.getRow()["StatusBuild"];
                        dtData.ImportRow(rowTempData);

                        //Добавляем индексы для будущей связки ContentEst
                        contentEst.Add(new indexs(compIndex, dtData.Rows.Count - 1));
                    }
                }
                isEdit = true;
                //dtData = readSQL.getHardwareVsComponents(id);
            }
            dtData.AcceptChanges();
            dgvData.Refresh();
            global_sum();
            //dtReqGoods.LoadDataRow(frmGood.goodParameters.ItemArray, true);        
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                DataRowView curRow = dtData.DefaultView[dgvData.CurrentRow.Index];
                int purchase = Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"].ToString());
                frmAddComponentInEstimates frm = new frmAddComponentInEstimates(purchase);
                frm.Text = "Добавить оборудование/комплектующие в смету";
                frm.changeStatusBuildUp(false);
                if (Convert.ToBoolean(curRow["TypeComponentsHardware"].ToString()) == true && Convert.ToBoolean(curRow["StatusBuild"].ToString()) == false)
                {
                    frm.enableField("tbCount", false);
                    frm.enableField("tbPrice", false);
                }
                else if (Convert.ToBoolean(curRow["TypeComponentsHardware"].ToString()) == true && Convert.ToBoolean(curRow["StatusBuild"].ToString()) == true)
                {
                    frm.enableField("tbCount", true);
                    frm.enableField("tbPrice", true);
                }
                frm.setEditRow(curRow);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    if (Convert.ToBoolean(curRow["TypeComponentsHardware"].ToString()) == false && Convert.ToBoolean(curRow["StatusBuild"].ToString()) == false)
                    {
                        if (curRow["id"] != DBNull.Value)
                        {
                            int tempType = 0;
                            reCulcCount(tempType, Convert.ToInt32(curRow["id"]), Convert.ToInt32(curRow["Count"]));
                        }
                        else
                        {
                            int tempType = 1;
                            reCulcCount(tempType, dgvData.CurrentRow.Index, Convert.ToInt32(curRow["Count"]));
                        }
                    }
                    curRow = frm.getEditRow();
                }
                dtData.AcceptChanges();
                dgvData.Refresh();
                global_sum();
                isEdit = true;
                //frmEditGoods frmGood = new frmEditGoods(1, 0, (int)curRow["id_tovar"], (int)cbDep.SelectedValue, GetNewEans(), Mode, (Mode == 1 && !isCopy ? -1 : (int)reqSettings["id_unit"]), GetAddedEans(), checkSertificate);
                //frmGood.goodParameters = curRow;
                //DialogResult result = frmGood.ShowDialog();
                //curRow = frmGood.goodParameters;
                //dtReqGoods.AcceptChanges();
                //grdRequestGoods.Refresh();
            }
        }

        private void get_create_smeta()
        {
            //cSelect.Visible = false;
            //cStatus.Visible = false;
            //cAccept.Visible = false;
            //cRepair.Visible = false;
            elementsVisibleStatus();         
            dtData = readSQL.getContentEstimate(id);
            selectDep();
            selectObject();
            global_sum();
            dgvData.DataSource = dtData;
            tableStatus();
            statusSelected = -1;
            StatusConfirmationSelected = -1;
            changeButtonStatusEnable();
            
        }

        private void global_sum()
        {
            object _sum =0;
            if (dtData != null && dtData.Rows.Count != 0)
            _sum = dtData.Compute("sum(summa)", "(Status IN (0,1,4,5) or Status is null) and (Purchase IN (0,1) or Purchase is Null)");
            if (_sum == DBNull.Value)
                _sum = 0;
            tbItogo.Text = decimal.Parse(_sum.ToString()).ToString("### ##0.00");
            global_delivery();
        }

        private void global_delivery()
        {
            object _delivery = 0;
            if (dtData != null && dtData.Rows.Count != 0)
                _delivery = dtData.Compute("sum(Delivery)", "(Status IN (0,1,4,5) or Status is null) and (Purchase IN (0,1) or Purchase is Null)");
            if (_delivery == DBNull.Value)
                _delivery = 0;
            tbDost.Text = decimal.Parse(_delivery.ToString()).ToString("### ##0.00");
            global_dost();
        }

        private void global_dost()
        {
            decimal summa = decimal.Parse(tbItogo.Text) + decimal.Parse(tbDost.Text);
            tbWithDost.Text = summa.ToString("### ##0.00");
        }

        /// <summary>
        /// Показ в comboBox текущего отдела
        /// </summary>
        private void selectDep()
        {
            if (id != -1)
            {
                DataTable dtDep = readSQL.getIdDep(id);
                cbDep.SelectedValue = dtDep.Rows[0]["id_dep"];
            }
        }

        /// <summary>
        /// Показ в comboBox текущего объекта
        /// </summary>
        private void selectObject()
        {
            if (id != -1)
            {
                int currentObject = readSQL.getObject(id);
                cbObject.SelectedValue = currentObject;
            }
        }

        private void tbDost_Enter(object sender, EventArgs e)
        {
            if (tbDost.Text.Equals("0,00") || decimal.Parse(tbDost.Text)==0)
                tbDost.Text = "";
        }

        private void tbDost_Leave(object sender, EventArgs e)
        {
            if (tbDost.Text.Trim().Length == 0) tbDost.Text = "0,00";
            else tbDost.Text = decimal.Parse(tbDost.Text).ToString("### ##0.00");
            global_dost();
        }

        /// <summary>
        /// Сохранение сметы
        /// </summary>
        /// <returns>True - Сохранил, False - Какая либо ошибка</returns>
        private bool createSave()
        {
            if (tbNameEstimate.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо ввести наименование сметы!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (tbNum.Text.Trim().Length == 0)
            {
                MessageBox.Show("Необходимо ввести номер приказа/распоряжения!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(dtData==null || dtData.Rows.Count==0)
            {
                MessageBox.Show("Необходимо добавить комплектующие/оборудование!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (tbWithDost.Text.Trim() == "" || Convert.ToDecimal(tbWithDost.Text.Trim()) == Convert.ToDecimal("0"))
            {
                if (DialogResult.No == MessageBox.Show("Вы уверены в сохранении нулевой\n сметы?", "Запрос потверждения действий", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    return false;
            }

            //Заголовок
            int id_dep = Convert.ToInt32(cbDep.SelectedValue.ToString());
            int id_object;
            if (cbObject.SelectedValue == null)
                id_object = 0;
            else
                id_object = Convert.ToInt32(cbObject.SelectedValue.ToString());
            DataTable dtResult =
               readSQL.setEstimate(id, tbNameEstimate.Text.Trim(), tbNum.Text.Trim(), dtpDate.Value, tbItogo.Text, tbDost.Text, 1, id_dep, id_object);
            if (dtResult == null && dtResult.Rows.Count == 0 && dtResult.Rows[0]["id"].ToString().Equals("-1"))
            {
                MessageBox.Show("Не удалось сохранить данные", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            else if (dtResult.Rows[0]["id"].ToString().Equals("-2"))
            {
                MessageBox.Show("Такое наименование присутствует в Базе!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            int id_estimates = int.Parse(dtResult.Rows[0]["id"].ToString());
            //Тело
            dtData.AcceptChanges();
            int j  = 0;
            foreach (DataRow r in dtData.Rows)
            {
                int idCon =-1;
                if (r["id"]!=DBNull.Value)
                idCon = int.Parse(r["id"].ToString());
                DataTable tId = readSQL.setContentEstimate(idCon,
                    id_estimates,
                    r["id_ComponentsHardware"],
                    r["TypeComponentsHardware"],
                    r["Price"],
                    r["Count"],
                    r["Link"],
                    r["Description"],
                    1,
                    r["Status"],
                    r["StatusConfirmation"],
                    r["Purchase"],
                    r["Delivery"],
                    r["StatusBuild"],
                    r["Comments"].ToString()
                    );

                // Заполнение таблицы временными значениями
                int cId = Convert.ToInt32(tId.Rows[0]["id"].ToString());
                for (int i = 0; i < tempIndex.Count; i++)
                {
                    if (tempIndex[i].old_index == j)
                        tempIndex[i].old_id = cId;

                    if (tempIndex[i].new_index == j)
                        tempIndex[i].new_id = cId;
                }

                for (int i = 0; i < contentEst.Count; i++)
                {
                    if (contentEst[i].old_index == j)
                        contentEst[i].old_id = cId;

                    if (contentEst[i].new_index == j)
                        contentEst[i].new_id = cId;
                }
                j++;
            }

            // Записываем в LinkEstimate новые связи
            foreach (indexs item in tempIndex)
            {
                if (!readSQL.compareIdLinkEstimate(item.old_id, item.new_id))
                {
                    readSQL.setLinkEstimates(-1, item.old_id, item.new_id, 1);
                }
            }

            // Записываем в contentEst новые связи
            foreach (indexs item in contentEst)
            {
                if (!readSQL.compareContentEstCvsH(item.old_id, item.new_id))
                {
                    readSQL.setContentEstCvsH(item.old_id, item.new_id);
                }
            }
            
            // Удаляем устаревшие связи в LinkEstimate
            foreach (indexs item in delIndex)
            {
                readSQL.deleteLinkEstimate(item.old_id, item.new_id);
            }

            // Удаляем устаревшие связи в contentEst_Components_vs_Hardware
            foreach (indexs item in delContentEst)
            {
                if (item.old_index > 0)
                    readSQL.deleteContentEstCvsH(item.old_id, 0);
                else if (item.new_index > 0)
                    readSQL.deleteContentEstCvsH(item.new_id, 1);
            }

            foreach (int delId in delList)
            {
                readSQL.setContentEstimate(delId,
                       id_estimates,
                       0,
                       0,
                       0,
                       0,
                       "",
                       "",
                       2,
                       0,
                       0,
                       0,
                       0,
                       0,
                       ""
                       );
            }
            return true;
        }
        #endregion

        private void btSave_Click(object sender, EventArgs e)
        {
            if (isCreate) if (!createSave()) return;

            MessageBox.Show("Данные сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isEdit = false;
            this.DialogResult = DialogResult.OK;
        }

        List<int> delList = new List<int>();
        private void btDel_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Удалить запись?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    if (dtData.DefaultView[dgvData.CurrentRow.Index]["id"] != DBNull.Value && int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString()) != -1)
                        delList.Add(int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString()));
                    //DataRowView curRow = dtData.DefaultView[dgvData.CurrentRow.Index];
                    

                    bool statusBuild = getStatusBuild(dtData.Rows[dgvData.CurrentRow.Index]);

                    

                    //Сдвигаем строки временного списка
                    for (int i = 0; i < tempIndex.Count; i++)
                    {
                        if (tempIndex[i].old_index == dgvData.CurrentRow.Index || tempIndex[i].new_index == dgvData.CurrentRow.Index)
                        {
                            deleteReplaceChange(tempIndex[i].old_index, -1);
                            if (!statusBuild)
                                сhangeNoSB(2);
                            tempIndex.RemoveAt(i);
                        }
                        else
                        {
                            if (tempIndex[i].old_index > dgvData.CurrentRow.Index)
                                tempIndex[i].old_index = tempIndex[i].old_index - 1;
                            if (tempIndex[i].new_index > dgvData.CurrentRow.Index)
                                tempIndex[i].new_index = tempIndex[i].new_index - 1;
                        }
                    }

                    
                    if (statusBuild)
                        autoRemoveSB();

                    // Добавляем в список на удаление или удаляем из списка на добавление связей
                    if (dtData != null && dtData.Rows[dgvData.CurrentRow.Index]["id_component_link"].ToString() != "")
                    {
                        indexs tempDel = new indexs(0, 0);
                        if (Convert.ToBoolean(dtData.Rows[dgvData.CurrentRow.Index]["TypeComponentsHardware"]) == false)
                        {
                            tempDel.old_index = dgvData.CurrentRow.Index;
                            tempDel.old_id = Convert.ToInt32(dtData.Rows[dgvData.CurrentRow.Index]["id"].ToString());
                            tempDel.new_index = -1;
                            delContentEst.Add(tempDel);
                        }
                        else
                        {
                            tempDel.old_index = -1;
                            tempDel.new_index = dgvData.CurrentRow.Index;
                            tempDel.new_id = Convert.ToInt32(dtData.Rows[dgvData.CurrentRow.Index]["id"].ToString());
                            delContentEst.Add(tempDel);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < contentEst.Count; i++)
                        {
                            if (contentEst[i].old_index == dgvData.CurrentRow.Index || contentEst[i].new_index == dgvData.CurrentRow.Index)
                                contentEst.RemoveAt(i);
                        }
                    }

                    // Замена статуса при удалении
                    int status = Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"].ToString());
                    
                    if (dtData.DefaultView[dgvData.CurrentRow.Index]["id"] != DBNull.Value && status == 1)
                    {
                        int tId = Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                        DataTable dtLink = readSQL.getLinkEstimate(tId);
                        if (dtLink != null && dtLink.Rows.Count > 0)
                        {
                            indexs tempDel = new indexs(0, 0);
                            tempDel.old_id = Convert.ToInt32(dtLink.Rows[0]["id_ContentEstimatesOld"].ToString());
                            tempDel.new_id = Convert.ToInt32(dtLink.Rows[0]["id_ContentEstimatesNew"].ToString());
                            delIndex.Add(tempDel);

                            deleteReplaceChange(-1, tempDel.old_id);
                        }
                    }

                    contentEst = changeListIndex(contentEst, dgvData.CurrentRow.Index);

                    if (dtData.DefaultView[dgvData.CurrentRow.Index]["id"] != DBNull.Value && int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString()) != -1)
                    {
                        if (!statusBuild)
                            сhangeNoSB(2);
                    }

                    dtData.Rows.RemoveAt(dgvData.CurrentRow.Index);
                    isEdit = true;
                }
            }
        }

        /// <summary>
        /// Функция смещения списка индексов при удалении строки
        /// </summary>
        /// <param name="listIndex">Список который сдвигаем</param>
        /// <param name="pos">Позиция по которой определяем нужно ли двигать. Если индекс больше его то двигаем, иначе нет</param>
        /// <returns>Возращаем список с нужным сдвигом</returns>
        List<indexs> changeListIndex(List<indexs> listIndex, int pos)
        {
            for (int i = 0; i < listIndex.Count; i++)
            {
                if (listIndex[i].old_index > pos)
                    listIndex[i].old_index--;
                if (listIndex[i].new_index > pos)
                    listIndex[i].new_index--;
            }

            return listIndex;
        }

        private void deleteReplaceChange(int i , int j)
        {
            if (i != -1) 
            {
                if (dtData.Rows[i]["id"] != DBNull.Value)
                {
                    // int tId = Convert.ToInt32(dtData.Rows[tempIndex[i].old_index]["id"]);
                    int tId = Convert.ToInt32(dtData.Rows[i]["id"]);
                    DataTable dtLink = readSQL.getLinkEstimate(tId);

                    dtData.Rows[i]["Purchase"] = 0;
                    dtData.Rows[i]["namePurchase"] = "Добавленно в смету";

                    if (dtLink != null && dtLink.Rows.Count > 0)
                    {
                        tId = Convert.ToInt32(dtLink.Rows[0]["id_ContentEstimatesOld"].ToString());
                        DataRow[] dtRow = dtData.Select("id = " + tId);
                        dtRow[0]["Purchase"] = 1;
                        dtRow[0]["namePurchase"] = "Оборудование, которым произведена замена";
                    }
                }
                else
                {
                    dtData.Rows[i]["Purchase"] = 0;
                    dtData.Rows[i]["namePurchase"] = "Добавленно в смету";
                }
            }

            if (j != -1)
            {
                DataRow[] dtRow = dtData.Select("id = " + j);
                dtRow[0]["Purchase"] = 0;
                dtRow[0]["namePurchase"] = "Добавленно в смету";

                DataTable dtLink = readSQL.getLinkEstimate(j);

                if (dtLink != null && dtLink.Rows.Count > 0)
                {
                    j = Convert.ToInt32(dtLink.Rows[0]["id_ContentEstimatesOld"].ToString());
                    dtRow[0]["Purchase"] = 1;
                    dtRow[0]["namePurchase"] = "Оборудование, которым произведена замена";
                }
            }

            dtData.AcceptChanges();
            dgvData.Refresh();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void get_status_type()
        {
            DataTable dtStatus = readSQL.getStatus("typeHardWare");

            DataColumn col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;
            dtStatus.Columns.Add(col);
            dtStatus.Rows.Add(-1, "Все", 0);
            dtStatus.DefaultView.Sort = "main asc";

            cbType.DataSource = dtStatus;
            cbType.DisplayMember = "cName";
            cbType.ValueMember = "id";
        }

        /// <summary>
        /// Получить весь список отделов
        /// </summary>
        private void get_departments()
        {
            DataTable dtDep = readSQL.getListDepartmens();

            DataColumn col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;
            dtDep.Columns.Add(col);
            dtDep.DefaultView.Sort = "main asc";

            cbDep.DataSource = dtDep;
            cbDep.DisplayMember = "cName";
            cbDep.ValueMember = "id";
        }

        /// <summary>
        /// Получить весь список объектов.
        /// </summary>
        /// Учитываются только объекты активные в данный момент
        private void get_object()
        {
            DataTable dtObject = readSQL.getObject();

            DataColumn col = new DataColumn("main", typeof(int));
            col.DefaultValue = 1;
            dtObject.Columns.Add(col);
            dtObject.DefaultView.Sort = "main asc";

            cbObject.DataSource = dtObject;
            cbObject.DisplayMember = "cName";
            cbObject.ValueMember = "id";
        }

        #region "Редактирование сметы"        
        private DataRowView row = null;

        public void setRow(DataRowView _row)
        {
            this.row = _row;
            id = int.Parse(row["id"].ToString());
            tbNameEstimate.Text = row["EstimateName"].ToString();
            tbNum.Text = row["EstimateDetail"].ToString();
            tbItogo.Text = row["Shipping"].ToString();
            tbDost.Text = row["Delivery"].ToString();
            statusEstimate = int.Parse(row["Status"].ToString());
            dtpDate.Value = DateTime.Parse(row["Date"].ToString());
            btRedo.Enabled = true;
            tbNameEstimate.ReadOnly = true;
            dtpDate.Enabled = false;
            tbNum.ReadOnly = true;
            cbDep.Enabled = false;
            cbObject.Enabled = false;
                       
            dtTableStatus = readSQL.getTableStatusEstimat(statusEstimate,1);
            if (dtTableStatus != null && dtTableStatus.Rows.Count > 0)
            {
                btDown.Enabled = dtTableStatus.Rows[0]["undoStatus"] != DBNull.Value;
                btRedo.Enabled = dtTableStatus.Rows[0]["nextStatus"] != DBNull.Value;
            }
            else
            {
                btDown.Enabled = btRedo.Enabled = false;
            }

            get_create_smeta();
            isEdit = false;

            //tbNum.Text = row["EstimateDetail"].ToString();
        }

        private void elementsVisibleStatus()
        {
            dgvData.AutoGenerateColumns = false;
            switch (statusEstimate)
            {
                case 0:
                case 5:
                    cSelect.Visible = false;
                    cStatus.Visible = false;
                    cAccept.Visible = false;
                    cRepair.Visible = false;
                    gbOper.Visible = true;
                    gbPurchase.Visible = true;
                    btDown.Visible = false;
                    btAccept.Visible = false;
                    break;
                case 1:
                    cSelect.Visible = true;
                    cStatus.Visible = true;
                    cAccept.Visible = true;
                    cRepair.Visible = false;
                    gbOper.Visible = false;
                    gbPurchase.Visible = false;
                    btDown.Visible = true;
                    btAccept.Visible = true;
                    break;
                case 3:
                    gbOther.Visible = config.statusCode.Equals("оп");
                    gbOper.Visible = false;
                    gbPurchase.Visible = false;
                    tbDost.ReadOnly = true;
                    cRepair.Visible = config.statusCode.Equals("оп");
                    //btDown.Visible = false;
                    //btAccept.Visible = false;
                    //btRedo.Visible = false;
                    break;
                default: break;
            }
        }
        #endregion

        private void btRedo_Click(object sender, EventArgs e)
        {
            if (statusEstimate != 3)
            {
                createSave();
                readSQL.changeStatusEstimate(id, 1, "");
                MessageBox.Show("Смета передана контролёру!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isEdit = false;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                dtTableStatus = readSQL.getTableStatusEstimat(StatusConfirmationSelected, (statusSelected == 4) ? 2 : ((statusSelected == 3) ? 3 : -1));
                if (dtTableStatus == null || dtTableStatus.Rows.Count == 0) return;
                foreach(DataRow r in  dtData.Select("isSelect = 1"))
                {
                    int idSC = int.Parse(r["id"].ToString());
                    readSQL.changeStatusConfirmation(idSC, int.Parse(dtTableStatus.Rows[0]["nextStatus"].ToString()));
                }
                //readSQL.changeStatusConfirmation();
                //int.Parse(dtTableStatus.Rows[0]["nextStatus"].ToString());
                //int.Parse(dtTableStatus.Rows[0]["undoStatus"].ToString());
                get_create_smeta();
            }
        }

        private void btAccept_Click(object sender, EventArgs e)
        {
            dtData.AcceptChanges();
            DataTable dtBuffer = dtData.Copy();
            dtBuffer.DefaultView.RowFilter ="isSelect = 1";
            foreach (DataRowView r in dtBuffer.DefaultView)
            {
                Console.WriteLine(r["cName"].ToString());
            }
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            dtTableStatus = readSQL.getTableStatusEstimat(StatusConfirmationSelected, (statusSelected == 4) ? 2 : ((statusSelected == 3) ? 3 : -1));
            if (dtTableStatus == null || dtTableStatus.Rows.Count == 0) return;
            foreach (DataRow r in dtData.Select("isSelect = 1"))
            {
                int idSC = int.Parse(r["id"].ToString());
                readSQL.changeStatusConfirmation(idSC, int.Parse(dtTableStatus.Rows[0]["undoStatus"].ToString()));
            }
            //readSQL.changeStatusConfirmation();
            //int.Parse(dtTableStatus.Rows[0]["nextStatus"].ToString());
            //int.Parse(dtTableStatus.Rows[0]["undoStatus"].ToString());
            get_create_smeta();
        }

        private int statusSelected = -1;
        private int StatusConfirmationSelected = -1;
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name.Equals("cRepair"))
            {
                btRepeir_Click(sender, e);
            }
            else if (senderGrid.Columns[e.ColumnIndex].Name.Equals("cSelect"))
            {
                bool isSelect = false;
               
                int _status = int.Parse(dtData.DefaultView[e.RowIndex]["Status"].ToString());
                int _StatusConfirmation = int.Parse(dtData.DefaultView[e.RowIndex]["StatusConfirmation"].ToString());
                int countSelect = dtData.Select("isSelect = 1").Count();

                if (dtData.DefaultView[e.RowIndex]["isSelect"] != DBNull.Value)
                    isSelect = bool.Parse(dtData.DefaultView[e.RowIndex]["isSelect"].ToString());

                if (statusSelected != -1 && _status != statusSelected) return;
                dtTableStatus = readSQL.getTableStatusEstimat(_StatusConfirmation, (_status == 4) ? 2 : ((_status == 3) ? 3 : -1));

                if (countSelect == 0 && !isSelect)
                {
                    statusSelected = _status;
                    StatusConfirmationSelected = _StatusConfirmation;
                }
                else
                    if (countSelect == 1 && isSelect)
                    {
                        statusSelected = -1;
                        StatusConfirmationSelected = -1;
                    }


                if (
                    (
                            (_status == 2 && (_StatusConfirmation == 4 || _StatusConfirmation == 6))
                        || 
                            (_status == 3 && (_StatusConfirmation == 9 || _StatusConfirmation == 7))
                        || 
                            _status == 1
                        ||
                            (_status == 4 && (_StatusConfirmation == 5 ))
                    ) && config.statusCode.Equals("оп"))
                {
                    dtData.DefaultView[e.RowIndex]["isSelect"] = !isSelect;
                    if (dtTableStatus != null && dtTableStatus.Rows.Count > 0)
                    {
                        btDown.Enabled = dtTableStatus.Rows[0]["undoStatus"] != DBNull.Value;
                        btRedo.Enabled = dtTableStatus.Rows[0]["nextStatus"] != DBNull.Value;
                    }
                    else
                    {
                        btDown.Enabled = btRedo.Enabled = false;
                    }
                }
                else
                    if (_status == 4)
                    {
                        if (dtTableStatus != null && dtTableStatus.Rows.Count > 0)
                        {
                            btDown.Enabled = dtTableStatus.Rows[0]["undoStatus"] != DBNull.Value;
                            btRedo.Enabled = dtTableStatus.Rows[0]["nextStatus"] != DBNull.Value;
                            dtData.DefaultView[e.RowIndex]["isSelect"] = !isSelect;
                            if (countSelect == 1 && isSelect) btDown.Enabled = btRedo.Enabled = false;
                        }
                        else
                        {
                            btDown.Enabled = btRedo.Enabled = false;
                        }
                    }else
                        if (_status == 3)
                        {
                            if (dtTableStatus != null && dtTableStatus.Rows.Count > 0)
                            {
                                btDown.Enabled = dtTableStatus.Rows[0]["undoStatus"] != DBNull.Value;
                                btRedo.Enabled = dtTableStatus.Rows[0]["nextStatus"] != DBNull.Value;
                                dtData.DefaultView[e.RowIndex]["isSelect"] = !isSelect;
                                if (countSelect == 1 && isSelect) btDown.Enabled = btRedo.Enabled = false;
                            }
                            else
                            {
                                btDown.Enabled = btRedo.Enabled = false;
                            }
                        }

                if (countSelect == 0 && bool.Parse(dtData.DefaultView[e.RowIndex]["isSelect"].ToString()) == isSelect)
                {
                    statusSelected = -1;
                    StatusConfirmationSelected = -1;
                }

                dtData.AcceptChanges();
                dgvData.Refresh();
                changeButtonStatusEnable();
            }
        }

        private void changeButtonStatusEnable()
        {
            //if (!config.statusCode.Equals("оп"))
            if (config.statusCode.Equals("оп"))
            {
                if (statusSelected == -1) btDown.Enabled = btRedo.Enabled = false;
                return;
            }
            switch (statusSelected)
            {
                case -1: 
                    btCreateActReceving.Enabled = btCancelRepair.Enabled = btStopBuy.Enabled = btCancelBuy.Enabled = false;
                    btDown.Enabled = btRedo.Enabled = false;
                    break;
                case 2:
                    btCancelRepair.Enabled = true;
                    btCreateActReceving.Enabled = btStopBuy.Enabled = btCancelBuy.Enabled = false;
                    break;
                case 3:
                    btCancelBuy.Enabled = true;
                    btCreateActReceving.Enabled = btCancelRepair.Enabled = btStopBuy.Enabled =  false;
                    break;
                case 1:
                    btCreateActReceving.Enabled = btStopBuy.Enabled = true;
                    btCancelRepair.Enabled =  btCancelBuy.Enabled = false;
                    break;
                case 4:
                    btCreateActReceving.Enabled  = true;
                    btCancelRepair.Enabled = btStopBuy.Enabled = btCancelBuy.Enabled = false;
                    break;
               // case -1:
                //    btCreateActReceving.Enabled = btCancelRepair.Enabled = btStopBuy.Enabled = btCancelBuy.Enabled = true;
                //    break;
                default: break;
                
            }
        
        }

        private void btRepeir_Click(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //MessageBox.Show(dtData.DefaultView[e.RowIndex]["id"].ToString());
            if (int.Parse(dtData.DefaultView[e.RowIndex]["Status"].ToString()) == 1)
            {
                
                frmAddComponentInEstimates frm = new frmAddComponentInEstimates();
                DataRow sendRow = dtData.Clone().Rows.Add();
                frm.Text = "Добавить оборудование/комплектующие в смету";
                frm.setCreateRow(sendRow);
                frm.inComeSumma = decimal.Parse(dtData.DefaultView[e.RowIndex]["summa"].ToString());
                if (DialogResult.OK == frm.ShowDialog())
                {
                    frmAddComment frmComment = new frmAddComment();
                    if (frmComment.ShowDialog() == DialogResult.OK)
                    {
                        DataRow inRow = frm.getRow();
                        inRow["Status"] = 4;
                        inRow["Comments"] = frmComment.comment;
                        inRow["isSelect"] = false;
                        dtData.DefaultView[e.RowIndex]["Status"] = 2;
                        dtData.DefaultView[e.RowIndex]["isSelect"] = false;

                        int id_old = -1, id_new = -1;
                        int idCon = -1;
                        if (dtData.DefaultView[e.RowIndex]["id"] != DBNull.Value)
                            idCon = int.Parse(dtData.DefaultView[e.RowIndex]["id"].ToString());
                        
                        readSQL.setContentEstimate(idCon,
                            id,
                            dtData.DefaultView[e.RowIndex]["id_ComponentsHardware"],
                            dtData.DefaultView[e.RowIndex]["TypeComponentsHardware"],
                            dtData.DefaultView[e.RowIndex]["Price"],
                            dtData.DefaultView[e.RowIndex]["Count"],
                            dtData.DefaultView[e.RowIndex]["Link"],
                            dtData.DefaultView[e.RowIndex]["Description"],
                            1,
                            2,
                            4,
                            dtData.DefaultView[e.RowIndex]["Purchase"],
                            dtData.DefaultView[e.RowIndex]["Delivery"],
                            dtData.DefaultView[e.RowIndex]["StatusBuild"],
                            frmComment.comment
                            );
                        id_old = idCon;

                        idCon = -1;
                        DataTable dtResult = readSQL.setContentEstimate(idCon,
                            id,
                            inRow["id_ComponentsHardware"],
                            inRow["TypeComponentsHardware"],
                            inRow["Price"],
                            inRow["Count"],
                            inRow["Link"],
                            inRow["Description"],
                            1,
                            4,
                            4,
                            0,
                            0,
                            inRow["StatusBuild"],
                            frmComment.comment
                            );
                        id_new = int.Parse(dtResult.Rows[0]["id"].ToString());

                        readSQL.setLinkEstimates(-1, id_old, id_new, 1);

                        get_create_smeta();

                        /*
                        dtData.DefaultView[e.RowIndex]["Status"] = 2;
                        dtData.DefaultView[e.RowIndex]["isSelect"] = false;
                        DataRow inRow = frm.getRow();
                        inRow["Status"] = 4;
                        inRow["Comments"] = frmComment.comment;
                        inRow["isSelect"] = false;
                        dtData.LoadDataRow(inRow.ItemArray, true);
                         */
                    }
                }
                dtData.AcceptChanges();
                dgvData.Refresh();
                global_sum();
                dtData.AcceptChanges();
            }          
            
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Font _fonr = new Font(this.Font,FontStyle.Regular);    
            if (e.RowIndex != -1 && dtData.DefaultView.Count != 0)
            {
                if (dtData.DefaultView[e.RowIndex]["Status"] != DBNull.Value 
                    && int.Parse(dtData.DefaultView[e.RowIndex]["Status"].ToString()) == 2)
                {
                    _fonr = new Font(this.Font, FontStyle.Strikeout);
                    //dgvData.Rows[e.RowIndex].ReadOnly = true;
                }



                int status = Convert.ToInt32(dtData.DefaultView[e.RowIndex]["Purchase"].ToString());
                if (status == 2 || status == 3)
                {
                    _fonr = new Font(this.Font, FontStyle.Strikeout);
                }

                dgvData.Rows[e.RowIndex].DefaultCellStyle.Font = _fonr;
            }
        }

        private bool isGetData = false;
        public void getEstimate()
        {
            isGetData = true;
            tbDost.ReadOnly = true;
            cRepair.Visible = false;
            gbOther.Visible = config.statusCode.Equals("оп");
            cSelect.Visible = true;

            foreach (Control cnt in this.Controls)
                if (cnt is Button)
                {
                    cnt.Visible = cnt.Name.Equals(btClose.Name);
                }               


            foreach (Control cnt in gbOther.Controls)
                if (cnt is Button)
                {
                    cnt.Visible = cnt.Name.Equals(btCreateActReceving.Name);
                    cnt.Text = cnt.Name.Equals(btCreateActReceving.Name) ? "Добавить в акт приема-передачи" : "Создать акт приема-передачи";
                }

            dtData.DefaultView.RowFilter = "(Status = 1 AND StatusConfirmation = 3) OR (Status = 4 AND StatusConfirmation = 5)";
            dtData = dtData.DefaultView.ToTable().Copy();
            dtData.AcceptChanges();
            dgvData.DataSource = dtData;
        }

        private DataTable dtSend;
        public DataTable getDataTable()
        {
            return dtSend;
        }
       
        private void btCreateActReceving_Click(object sender, EventArgs e)
        {
            if (isGetData)
            {
                dtSend = dtData.Clone();
                foreach (DataRow r in dtData.Select("isSelect = 1"))
                    dtSend.ImportRow(r);
                if (dtSend.Rows.Count == 0)
                {
                    MessageBox.Show("Необходимо выбрать записи!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                dtSend = dtData.Clone();
                foreach (DataRow r in dtData.Select("isSelect = 1"))
                    dtSend.ImportRow(r);
                if (dtSend.Rows.Count == 0)
                {
                    MessageBox.Show("Необходимо выбрать записи!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmAddActReceivingTransfer frm = new frmAddActReceivingTransfer();
                frm.Text = "Создать акт приемки передачи материальной ответственности";
                frm.setDataCreateEstimates(dtSend);
                if (DialogResult.OK == frm.ShowDialog())
                    get_create_smeta();
            }
        }

        public void setView()
        {
            gbOther.Visible = false;
            gbPurchase.Visible = false;
            gbOper.Visible = false;
            cSelect.Visible = false;
            cStatus.Visible = true;
            cAccept.Visible = true;
            cRepair.Visible = false;        
            btDown.Visible = false;
            btAccept.Visible = false;
            btRedo.Visible = false;
            tbDost.ReadOnly = true;
        }

        private void btCancelRepair_Click(object sender, EventArgs e)
        {
            if (dtData.Select("isSelect = 1 AND Status=2 AND (StatusConfirmation=4 OR StatusConfirmation=6)").Count() > 0 && DialogResult.Yes == MessageBox.Show("Подтвердить \"Отменить замену оборудования\"?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                foreach (DataRow r in dtData.Select("isSelect = 1 AND Status=2 AND (StatusConfirmation=4 OR StatusConfirmation=6)"))
                {
                    readSQL.setContentEstimate(int.Parse(r["id"].ToString()),
                                    id,
                                    r["id_ComponentsHardware"],
                                    r["TypeComponentsHardware"],
                                    r["Price"],
                                    r["Count"],
                                    r["Link"],
                                    r["Description"],
                                    1,
                                    1,
                                    3,
                                    r["Purchase"],
                                    r["Delivery"],
                                    r["StatusBuild"],
                                    ""
                                    );

                    readSQL.setLinkEstimates(0, int.Parse(r["id"].ToString()), 0, 2);
                }
                get_create_smeta();
            }
        }

        private void btStopBuy_Click(object sender, EventArgs e)
        {
            if (dtData.Select("isSelect = 1 AND Status=1 AND StatusConfirmation=3").Count()>0 
                && DialogResult.Yes == MessageBox.Show("Подтвердить \"Отказ от покупки\"?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                frmAddComment frmComment = new frmAddComment();
                if (frmComment.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataRow r in dtData.Select("isSelect = 1 AND Status=1 AND StatusConfirmation=3"))
                    {
                        readSQL.setContentEstimate(int.Parse(r["id"].ToString()),
                                        id,
                                        r["id_ComponentsHardware"],
                                        r["TypeComponentsHardware"],
                                        r["Price"],
                                        r["Count"],
                                        r["Link"],
                                        frmComment.comment,
                                        1,
                                        3,
                                        7,
                                        0,
                                        0,
                                        r["StatusBuild"],
                                       frmComment.comment
                                        );                       
                    }
                    get_create_smeta();
                }             
            }
        }

        private void btCancelBuy_Click(object sender, EventArgs e)
        {
            if (dtData.Select("isSelect = 1 AND Status=3 AND StatusConfirmation=7").Count() > 0 
                && DialogResult.Yes == MessageBox.Show("Подтвердить \"Отмена отказа от покупки\"?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                //frmAddComment frmComment = new frmAddComment();
                //if (frmComment.ShowDialog() == DialogResult.OK)
                //{
                    foreach (DataRow r in dtData.Select("isSelect = 1 AND Status=3 AND StatusConfirmation=7"))
                    {
                        readSQL.setContentEstimate(int.Parse(r["id"].ToString()),
                                        id,
                                        r["id_ComponentsHardware"],
                                        r["TypeComponentsHardware"],
                                        r["Price"],
                                        r["Count"],
                                        r["Link"],
                                        "",//frmComment.comment,
                                        1,
                                        1,
                                        3,
                                        0,
                                        0,
                                        r["StatusBuild"],
                                        ""
                                        );                      
                    }
                    get_create_smeta();
                //}
            }
        }

        private void frmAddEstimates_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (isEdit && MessageBox.Show("Закрыть форму без сохранения?", "Инфомирование", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No);
        }

        private void tbNameEstimate_TextChanged(object sender, EventArgs e)
        {
            isEdit = true;
        }

        private void frmAddEstimates_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (id != -1)
            {
                readSQL.updateSummaEstimate(id, decimal.Parse(tbItogo.Text));
             //   Console.WriteLine(tbItogo.Text);

            }
        }

        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvData.CurrentRow != null && e.RowIndex != -1
            && dtData != null && dtData.DefaultView.Count != 0)
            {
                DataTable dtHardware = readSQL.getSingleHardWare(dtData.DefaultView[e.RowIndex]["id_ComponentsHardware"], dtData.DefaultView[e.RowIndex]["TypeComponentsHardware"]);
                if (dtHardware != null && dtHardware.DefaultView.Count != 0)
                {
                    frmListComponents frm = new frmListComponents();
                    frm.setRow(dtHardware.DefaultView[0]);
                    frm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Отказ от покупки <--> Вернуть в заказ.
        /// </summary>
        /// Кнопка отвечающая за смену статусов оборудования и комплектующих в смете.
        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                int purchase = Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"].ToString());
                
                int id = -1;
                int.TryParse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString(), out id);

                if (purchase == 3)
                {
                    dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"] = 0;
                    dtData.DefaultView[dgvData.CurrentRow.Index]["namePurchase"] = "Добавлено в смету";
                }
                else if (purchase == 0)
                {
                    // Добавление комментария к причине отказа
                    frmAddComment frmCom = new frmAddComment();
                    frmCom.Text = "Ввод причины отказа";
                    if (frmCom.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        dtData.DefaultView[dgvData.CurrentRow.Index]["Comments"] = frmCom.comment;
                    }
                    dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"] = 3;
                    dtData.DefaultView[dgvData.CurrentRow.Index]["namePurchase"] = "Отказ от покупки товара";
                }

                сhangeNoSB(1);

                changeBtnTextPurchase();
                dtData.AcceptChanges();
                dgvData.Refresh();
                global_sum();
            }
        }

        /// <summary>
        /// Доступность кнопок группы gbPurchase и их текст
        /// </summary>
        private void changeBtnTextPurchase()
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                int status = Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"].ToString());
                bool type = Convert.ToBoolean(dtData.DefaultView[dgvData.CurrentRow.Index]["TypeComponentsHardware"].ToString());

                bool build = getStatusBuild(dtData.DefaultView[dgvData.CurrentRow.Index].Row);

                switch (status) {
                    case 0:
                        btnBuy.Text = "Отказ от покупки";
                        btnBuy.Enabled = true;
                        toolTip1.SetToolTip(btnBuy, "Отказаться от покупки наименования");
                        btnReplace.Enabled = true;
                        btDel.Enabled = true;
                        btEdit.Enabled = true;

                        changeBtnSb(type, build);
                        break;
                    case 1:
                        btnReplace.Enabled = true;
                        btDel.Enabled = true;
                        btEdit.Enabled = true;

                        changeBtnSb(type, build);

                        btnBuy.Enabled = false;
                        break;
                    case 2:
                        btnBuy.Enabled = false;
                        btnReplace.Enabled = false;
                        btDel.Enabled = false;
                        btEdit.Enabled = false;
                        break;
                    case 3: 
                        btnBuy.Text = "Вернуть в заказ";
                        btnBuy.Enabled = true;
                        toolTip1.SetToolTip(btnBuy, "Вернуть в заказ");
                        btDel.Enabled = true;

                        changeBtnSb(type, build);

                        btnReplace.Enabled = false;
                        btEdit.Enabled = false;
                        break;
                }

                
            }
        }

        /// <summary>
        /// Работа кнопок в зависимости от типа позиции
        /// </summary>
        /// type - 0 Оборудование 1 Комплектующие
        /// build - 0 Не сборное 1 Сборное
        /// По умолчанию все кнопки будут доступны
        void changeBtnSb(bool type = false, bool build = false)
        {
            if (!type && !build)
            {
                // Замена, отказ, удаление
                btnBuy.Enabled = true;
                btnReplace.Enabled = true;
                btDel.Enabled = true;
            }
            else if (!type && build)
            {
                btnBuy.Enabled = false;
                btnReplace.Enabled = false;
                btDel.Enabled = false;
            }
            else if (type && !build)
            {
                // Удаление
                btnBuy.Enabled = false;
                btnReplace.Enabled = false;
                btDel.Enabled = true;
            }
            else if (type && build)
            {
                // Замена, отказ, удаление
                btnBuy.Enabled = true;
                btnReplace.Enabled = true;
                btDel.Enabled = true;
            }
        }

        /// <summary>
        /// Смена строки таблицы
        /// </summary>
        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            changeBtnTextPurchase();
        }

        /// <summary>
        /// Рисуем рамку для выделеной строки
        /// </summary>
        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
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

        /// <summary>
        /// Замена оборудования / комплектующих
        /// </summary>
        private void btnReplace_Click(object sender, EventArgs e)
        {
            frmAddComponentInEstimates frm = new frmAddComponentInEstimates(1); // Передаем статус будущего оборудования как замена
            DataRow sendRow = dtData.Clone().Rows.Add();
            frm.Text = "Заменить оборудование/комплектующие в смете";
            frm.type = Convert.ToInt32(Convert.ToBoolean(dtData.Rows[dgvData.CurrentRow.Index]["TypeComponentsHardware"].ToString()));
            frm.setCreateRow(sendRow);
            if (DialogResult.OK == frm.ShowDialog())
            {
                // Добавление комментария к причине замены
                frmAddComment frmCom = new frmAddComment();
                frmCom.Text = "Ввод причины замены";
                if (frmCom.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    dtData.DefaultView[dgvData.CurrentRow.Index]["Comments"] = frmCom.comment;
                }
                //dtData.LoadDataRow(frm.getRow().ItemArray, true);

                if (dgvData.CurrentRow.Index != -1 && dtData != null && dtData.DefaultView.Count != 0)
                {
                    dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"] = 2;
                    dtData.DefaultView[dgvData.CurrentRow.Index]["namePurchase"] = "Замененное оборудование";

                    if (dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString() != "")
                    {
                        DataRow[] tempDT = dtData.Select("id_component_link = " + int.Parse(dtData.Rows[dgvData.CurrentRow.Index]["id"].ToString()));
                        foreach (DataRow item in tempDT)
                        {
                            item["Purchase"] = dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"];
                            item["namePurchase"] = dtData.DefaultView[dgvData.CurrentRow.Index]["namePurchase"];
                        }
                    }
                    else
                    {
                        List<indexs> tempList = contentEst.FindAll(x => x.old_index == dgvData.CurrentRow.Index);
                        foreach (indexs item in tempList)
                        {
                            dtData.Rows[item.new_index]["Purchase"] = dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"];
                            dtData.Rows[item.new_index]["namePurchase"] = dtData.DefaultView[dgvData.CurrentRow.Index]["namePurchase"];
                        }
                    }
                }

                dtData.ImportRow(frm.getRow());
                dtData.Rows[dtData.Rows.Count - 1]["nameTypeLinkView"] = dtData.Rows[dgvData.CurrentRow.Index]["nameTypeLinkView"];

                // Индекс Оборудования
                int compIndex = dgvData.CurrentRow.Index + 1;

                if (!bool.Parse(dtData.Rows[dgvData.CurrentRow.Index]["TypeComponentsHardware"].ToString()) && dtData.Rows[dgvData.CurrentRow.Index]["id"].ToString() != "")
                {
                    
                    //int.Parse(frm.getRow()["id_ComponentsHardware"].ToString()));
                    compIndex += dtData.Select("id_component_link = " + int.Parse(dtData.Rows[dgvData.CurrentRow.Index]["id"].ToString())).Count();
                }
                else if (!bool.Parse(frm.getRow()["TypeComponentsHardware"].ToString()))
                {
                    foreach (indexs item in contentEst)
                        if (item.old_index == dgvData.CurrentRow.Index)
                            compIndex++;
                }
                
                if (dtData != null)
                {
                    DataRow temp = dtData.Rows[dtData.Rows.Count - 1];
                    DataRow newRow = dtData.NewRow();

                    newRow.ItemArray = temp.ItemArray;

                    dtData.Rows.Remove(temp);
                    dtData.Rows.InsertAt(newRow, compIndex);
                }

                // Запись временных позиций до момента записи в таблицу
                //tempIndex.Add(new indexs(dgvData.CurrentRow.Index, dtData.Rows.Count - 1));
                //tempIndex.Add(new indexs(dgvData.CurrentRow.Index, dgvData.CurrentRow.Index + compIndex));
                tempIndex.Add(new indexs(dgvData.CurrentRow.Index, compIndex));
                
                // Проверяем если комплектующие существует и имеет позоцию то добавляем в список
                // если нет то проверяем список еще несозданных
                if (bool.Parse(frm.getRow()["TypeComponentsHardware"].ToString()))
                {
                    if (dtData != null && dgvData.CurrentRow.Index != -1 && dtData.Rows[dgvData.CurrentRow.Index]["id_component_link"].ToString() != "" && int.Parse(dtData.Rows[dgvData.CurrentRow.Index]["id_component_link"].ToString()) != -1)
                    {   
                        //contentEst.Add(new indexs(dgvData.CurrentRow.Index, dtData.Rows.Count - 1));
                        contentEst.Add(new indexs(dgvData.CurrentRow.Index, dgvData.CurrentRow.Index + compIndex));
                    }
                    else
                    {
                        foreach (indexs item in contentEst.ToArray())
                        {
                            if (item.new_index == dgvData.CurrentRow.Index)
                                //contentEst.Add(new indexs(item.old_index, dtData.Rows.Count - 1));
                                contentEst.Add(new indexs(item.old_index, dgvData.CurrentRow.Index + compIndex));
                        }
                    }
                }

                if (!bool.Parse(frm.getRow()["TypeComponentsHardware"].ToString()))
                {
                    DataTable dtTempData = readSQL.getHardwareVsComponents(int.Parse(frm.getRow()["id_ComponentsHardware"].ToString()));
                    int i = 1;
                    foreach (DataRow r in dtTempData.Rows)
                    {
                        DataRow rowTempData = dtData.Clone().Rows.Add();
                        rowTempData["id_ComponentsHardware"] = int.Parse(r["id_component"].ToString());
                        rowTempData["TypeComponentsHardware"] = 1;
                        rowTempData["Price"] = 0;
                        rowTempData["Count"] = int.Parse(frm.getRow()["Count"].ToString());
                        rowTempData["Link"] = "";
                        rowTempData["Comments"] = "";
                        rowTempData["Description"] = "";
                        rowTempData["cName"] = r["cName"].ToString();
                        rowTempData["nameType"] = "Комплектующие";
                        rowTempData["nameTypeLinkView"] = "-- Комплектующие";
                        rowTempData["isLink"] = false;
                        rowTempData["summa"] = 0;
                        rowTempData["Status"] = 0;
                        rowTempData["StatusConfirmation"] = 0;
                        rowTempData["Purchase"] = 1;
                        rowTempData["namePurchase"] = "Оборудование, которым произведена замена";
                        rowTempData["StatusBuild"] = frm.getRow()["StatusBuild"];
                        dtData.ImportRow(rowTempData);

                        DataRow temp = dtData.Rows[dtData.Rows.Count - 1];
                        DataRow newRow = dtData.NewRow();

                        newRow.ItemArray = temp.ItemArray;

                        dtData.Rows.Remove(temp);
                        dtData.Rows.InsertAt(newRow, compIndex + i);

                        contentEst.Add(new indexs(compIndex, compIndex + i));

                        i++;
                    }
                }
                isEdit = true;
                //dtData = readSQL.getHardwareVsComponents(id);
            }

            сhangeNoSB(0);

            dtData.AcceptChanges();
            dgvData.Refresh();
            global_sum();
            //dtReqGoods.LoadDataRow(frmGood.goodParameters.ItemArray, true);
        }

        /// <summary>
        /// Проверка сборного оборудования на существование связей
        /// </summary>
        /// Если комплектующих не осталось будет происходить удаление строки
        void autoRemoveSB()
        {
            bool type = Convert.ToBoolean(dtData.DefaultView[dgvData.CurrentRow.Index]["TypeComponentsHardware"].ToString()); // Тип оборудования

            int purchase; // Статус покупки
            try 
            {
                purchase = Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"].ToString());
            }
            catch 
            {
                purchase = 0;
            }

            if (!type)
                return;

            if (purchase == 1)
                return;

            // Если статус не сборное то выходим
            if (!getStatusBuild(dtData.DefaultView[dgvData.CurrentRow.Index].Row))
                return;

            int id;
            try
            {
                id = Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
            }
            catch
            {
                id = -1;
            }
            
            if (id != -1)
            {
                // Удаление из сохраненных комплектующих
                int idH;
                try
                {
                    idH = Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["id_component_link"].ToString());
                }
                catch
                {
                    return;
                }
                DataTable tempDT = dtData;
                tempDT = tempDT.Select("id_component_link = " + idH).CopyToDataTable();
                if (tempDT.Rows.Count == 1)
                {
                    // Нужно удалить само оборудование
                    indexs tempDel = new indexs(0, 0);
                    tempDel.old_index = dgvData.CurrentRow.Index;
                    tempDel.old_id = idH;
                    tempDel.new_index = -1;
                    delContentEst.Add(tempDel);

                    delList.Add(idH);

                    DataRow[] tempDR = dtData.Select("id = " + idH);
                    dtData.Rows.Remove(tempDR[0]);
                }

                tempDT.Dispose();
            }
            else
            {
                // Если удаляется из еще не сохраненных комплектующих
                int index = dgvData.CurrentRow.Index;
                List<indexs> filteredList = contentEst.Where(x => x.new_index == index).ToList();

                int tempIndex = -1;
                if (filteredList.Count > 0)
                    tempIndex = filteredList[0].old_index;

                if (tempIndex != -1)
                {
                    List<indexs> tempList = contentEst.Where(x => x.old_index == tempIndex).ToList();
                    if (tempList.Count == 1)
                    {
                        // Нужно удалить и само оборудование
                        contentEst.RemoveAll(x => x.old_index == tempIndex);
                        dtData.Rows.RemoveAt(tempIndex);
                    }
                }
            }
        }

        /// <summary>
        /// Работа с комплектующими относящимися к не сборному оборудованию
        /// </summary>
        /// <param name="typeS">
        /// Тип операции
        ///     0 - Замена
        ///     1 - Отказ
        ///     2 - Удаление
        /// </param>
        void сhangeNoSB(int typeS)
        {
            bool type = Convert.ToBoolean(dtData.DefaultView[dgvData.CurrentRow.Index]["TypeComponentsHardware"].ToString()); // Тип оборудования

            if (type)
                return;

            // Если статус сборное то выходим
            if (getStatusBuild(dtData.DefaultView[dgvData.CurrentRow.Index].Row))
                return;

            int id;
            try
            {
                id = Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
            }
            catch
            {
                id = -1;
            }

            if (id != -1)
            {
                // Работа с сохраненным оборудованием
                DataRow[] tempDR = dtData.Select("id_component_link = " + id);

                if (typeS == 0)
                {
                    // Нужно заменить оборудование полностью
                    // Да да пустое условие т.к. при замене слишком большая связь с кнопкой и происходящими процессами
                    // Место обозначенное для этого действия оставленно на случай упращения логики и возможности выделения
                    // этого процесса в отдельное условие
                }
                else if (typeS == 1)
                {
                    // Нужно отказаться от всех комплектующих
                    foreach (DataRow item in tempDR)
                    {
                        item["Purchase"] = dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"];
                        item["namePurchase"] = dtData.DefaultView[dgvData.CurrentRow.Index]["namePurchase"];
                    }
                }
                else if (typeS == 2)
                {
                    // Нужно удалить все комплектующие
                    foreach (DataRow item in tempDR)
                    {
                        int tempId = Convert.ToInt32(item["id"].ToString());
                        indexs tempDel = new indexs(0, 0);
                        tempDel.new_index = 0;
                        tempDel.new_id = tempId;
                        tempDel.old_index = -1;
                        delContentEst.Add(tempDel);

                        delList.Add(tempId);

                        dtData.Rows.Remove(item);
                    }

                    if (dtData.DefaultView[dgvData.CurrentRow.Index]["id"] != DBNull.Value && int.Parse(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString()) != -1)
                    {
                        int index0 = dgvData.CurrentRow.Index;
                        int tId = -1;
                        int.TryParse(readSQL.getLinkEstimate(int.Parse(dtData.DefaultView[index0]["id"].ToString())).Rows[0]["id_ContentEstimatesOld"].ToString(), out tId);

                        foreach (DataRow item in dtData.Select("id_component_link = " + tId))
                        {
                            DataTable tempDT = dtData.Select("id = " + tId).CopyToDataTable();
                            item["Purchase"] = tempDT.Rows[0]["Purchase"];
                            item["namePurchase"] = tempDT.Rows[0]["namePurchase"];
                        }
                    }
                }
            }
            else
            {
               // Работа с не сохраненным оборудованием
                if (typeS == 0)
                {
                    // Нужно заменить оборудование полностью
                    foreach (indexs item in contentEst)
                    {
                        if (item.old_index == dgvData.CurrentRow.Index)
                        {
                            dtData.Rows[item.new_index]["Purchase"] = dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"];
                            dtData.Rows[item.new_index]["namePurchase"] = dtData.DefaultView[dgvData.CurrentRow.Index]["namePurchase"];
                        }
                    }
                }
                else if (typeS == 1)
                {
                    // Нужно отказаться от всех комплектующих
                    foreach (indexs item in contentEst)
                    {
                        if (item.old_index == dgvData.CurrentRow.Index)
                        {
                            dtData.Rows[item.new_index]["Purchase"] = dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"];
                            dtData.Rows[item.new_index]["namePurchase"] = dtData.DefaultView[dgvData.CurrentRow.Index]["namePurchase"];
                        }
                    }
                }
                else if (typeS == 2)
                {
                    // Нужно удалить все комплектующие
                    int index0 = tempIndex.ToList().Where(x => x.new_index == dgvData.CurrentRow.Index).ToList()[0].old_index;

                    List<indexs> tempContest = contentEst.ToList();
                    foreach (indexs item in contentEst)
                    {
                        if (item.old_index == dgvData.CurrentRow.Index)
                        {
                            tempContest.Remove(item);
                            dtData.Rows.RemoveAt(item.new_index);

                            changeListIndex(contentEst, item.new_index);
                        }
                    }

                    contentEst = tempContest.ToList();
                    if (dtData.DefaultView[index0]["id"] == DBNull.Value)
                    {
                        tempContest = contentEst.Where(x => x.new_index == index0).ToList();
                        foreach (indexs item in contentEst)
                        {
                            if (item.old_index == index0)
                            {
                                dtData.Rows[item.new_index]["Purchase"] = dtData.DefaultView[index0]["Purchase"];
                                dtData.Rows[item.new_index]["namePurchase"] = dtData.DefaultView[index0]["namePurchase"];
                            }
                        }

                        contentEst = tempContest.ToList();
                    }
                    else
                    {
                        int tId = Convert.ToInt32(dtData.DefaultView[index0]["id"].ToString());
                        foreach (DataRow item in dtData.Select("id_component_link = " + tId))
                        {
                            item["Purchase"] = dtData.DefaultView[index0]["Purchase"];
                            item["namePurchase"] = dtData.DefaultView[index0]["namePurchase"];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Востоновление старого статуса при удалении на не сборном оборудовании которое было заменено
        /// </summary>
        void restoreOldPurchase()
        {

            int id;
            try
            {
                id = Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
            }
            catch
            {
                id = -1;
            }

            if (id != -1)
            {
                // То существуют в базе
                int tId = Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                DataTable dtLink = readSQL.getLinkEstimate(tId);
                
                if (dtLink != null && dtLink.Rows.Count > 0)
                {
                    indexs tempDel = new indexs(0, 0);
                    tempDel.old_id = Convert.ToInt32(dtLink.Rows[0]["id_ContentEstimatesOld"].ToString());
                    tempDel.new_id = Convert.ToInt32(dtLink.Rows[0]["id_ContentEstimatesNew"].ToString());
                    delIndex.Add(tempDel);

                    deleteReplaceChange(-1, tempDel.old_id);
                }
            }
            else
            {
                // Существуют во временной таблице
            }

            // Замена статуса при удалении
            int status = Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["Purchase"].ToString());

            if (dtData.DefaultView[dgvData.CurrentRow.Index]["id"] != DBNull.Value && status == 1)
            {
                int tId = Convert.ToInt32(dtData.DefaultView[dgvData.CurrentRow.Index]["id"].ToString());
                DataTable dtLink = readSQL.getLinkEstimate(tId);
                if (dtLink != null && dtLink.Rows.Count > 0)
                {
                    indexs tempDel = new indexs(0, 0);
                    tempDel.old_id = Convert.ToInt32(dtLink.Rows[0]["id_ContentEstimatesOld"].ToString());
                    tempDel.new_id = Convert.ToInt32(dtLink.Rows[0]["id_ContentEstimatesNew"].ToString());
                    delIndex.Add(tempDel);

                    deleteReplaceChange(-1, tempDel.old_id);
                }
            }

            contentEst = changeListIndex(contentEst, dgvData.CurrentRow.Index); 

        }

        /// <summary>
        /// Получение StatusBuild
        /// </summary>
        /// <param name="row">Строка для которой требуется получить данный статус</param>
        /// <returns>Возращает StatusBuild</returns>
        bool getStatusBuild(DataRow row)
        {
            bool build;
            try
            {
                build = Convert.ToBoolean(row["StatusBuild"].ToString());
            }
            catch
            {
                build = true;
            }

            return build;
        }

        /// <summary>
        /// Пересчет количества товара для не сборного оборудования
        /// </summary>
        /// <param name="id">id оборудования</param>
        /// <param name="count">количество</param>
        void reCulcCount(int type, int id, int count)
        {
            switch (type)
            { 
                case 0:
                    DataRow[] tempDR = dtData.Select("id_component_link = " + id);
                    foreach (DataRow item in tempDR)
                    item["Count"] = count;
                    break;
                case 1:
                    foreach (indexs item in contentEst.Where(x => x.old_index == id))
                    {
                        dtData.Rows[item.new_index]["Count"] = count;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Класс для хранения временных id.
    /// </summary>
    /// Создает связь между полями в таблице и id элементов таблицы. Это требуется для обеспечения корректоной работы с временными данными в смете
    public class indexs
    {
        
        public int old_index;
        public int new_index;

        public int old_id = -1;
        public int new_id = -1;
        public indexs(int _old, int _new)
        {
            old_index = _old;
            new_index = _new;
        }
    }
}
