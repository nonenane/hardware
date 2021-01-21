namespace hardWareViewer
{
    partial class frmJournalEstimates
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournalEstimates));
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSumm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAcceptCont = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbControl = new System.Windows.Forms.TextBox();
            this.tbSecre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btPrintEstimate = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btDown = new System.Windows.Forms.Button();
            this.btAddDoc = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.btAccept = new System.Windows.Forms.Button();
            this.btNextStatus = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btPrintMemo = new System.Windows.Forms.Button();
            this.btBalance = new System.Windows.Forms.Button();
            this.pAdmCash = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pOpOk = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pKntNo = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.pKntOk = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.pAllBal = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btCreateAct = new System.Windows.Forms.Button();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.tbObject = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(78, 11);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(93, 20);
            this.dtpStart.TabIndex = 0;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(214, 11);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(93, 20);
            this.dtpEnd.TabIndex = 0;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(743, 11);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(188, 21);
            this.cbStatus.TabIndex = 1;
            this.cbStatus.SelectionChangeCommitted += new System.EventHandler(this.cbStatus_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Период с";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "по";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(693, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Статус:";
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(12, 48);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(33, 20);
            this.tbNumber.TabIndex = 3;
            this.tbNumber.TextChanged += new System.EventHandler(this.tbNumber_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(214, 48);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(167, 20);
            this.tbName.TabIndex = 3;
            this.tbName.TextChanged += new System.EventHandler(this.tbNumber_TextChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNumber,
            this.cObject,
            this.cDate,
            this.cName,
            this.cDep,
            this.cSumm,
            this.cStatus,
            this.cAcceptCont,
            this.cFin,
            this.cBall,
            this.cScan});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Location = new System.Drawing.Point(12, 80);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(919, 288);
            this.dgvData.TabIndex = 4;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDoubleClick);
            this.dgvData.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dgvData_CellToolTipTextNeeded);
            this.dgvData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvData_RowPostPaint);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            // 
            // cNumber
            // 
            this.cNumber.DataPropertyName = "id";
            this.cNumber.FillWeight = 40F;
            this.cNumber.HeaderText = "№";
            this.cNumber.Name = "cNumber";
            this.cNumber.ReadOnly = true;
            // 
            // cObject
            // 
            this.cObject.DataPropertyName = "objectName";
            this.cObject.HeaderText = "Объект";
            this.cObject.Name = "cObject";
            this.cObject.ReadOnly = true;
            // 
            // cDate
            // 
            this.cDate.DataPropertyName = "Date";
            this.cDate.HeaderText = "Дата";
            this.cDate.Name = "cDate";
            this.cDate.ReadOnly = true;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "EstimateName";
            this.cName.HeaderText = "Наименование сметы";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cDep
            // 
            this.cDep.DataPropertyName = "depName";
            this.cDep.HeaderText = "Отдел";
            this.cDep.Name = "cDep";
            this.cDep.ReadOnly = true;
            // 
            // cSumm
            // 
            this.cSumm.DataPropertyName = "sumEstimate";
            this.cSumm.HeaderText = "Сумма сметы";
            this.cSumm.Name = "cSumm";
            this.cSumm.ReadOnly = true;
            // 
            // cStatus
            // 
            this.cStatus.DataPropertyName = "nameStatus";
            this.cStatus.FillWeight = 220F;
            this.cStatus.HeaderText = "Статус";
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            // 
            // cAcceptCont
            // 
            this.cAcceptCont.DataPropertyName = "DateControl";
            this.cAcceptCont.HeaderText = "Подтв. контролером";
            this.cAcceptCont.Name = "cAcceptCont";
            this.cAcceptCont.ReadOnly = true;
            // 
            // cFin
            // 
            this.cFin.DataPropertyName = "DateFinance";
            this.cFin.HeaderText = "Финансирование выделено";
            this.cFin.Name = "cFin";
            this.cFin.ReadOnly = true;
            // 
            // cBall
            // 
            this.cBall.DataPropertyName = "DateBalance";
            this.cBall.HeaderText = "Поставленно на баланс";
            this.cBall.Name = "cBall";
            this.cBall.ReadOnly = true;
            // 
            // cScan
            // 
            this.cScan.DataPropertyName = "isScan";
            this.cScan.FillWeight = 40F;
            this.cScan.HeaderText = "Скан";
            this.cScan.Name = "cScan";
            this.cScan.ReadOnly = true;
            this.cScan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cScan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tbControl
            // 
            this.tbControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbControl.Location = new System.Drawing.Point(78, 433);
            this.tbControl.Name = "tbControl";
            this.tbControl.ReadOnly = true;
            this.tbControl.Size = new System.Drawing.Size(236, 20);
            this.tbControl.TabIndex = 3;
            // 
            // tbSecre
            // 
            this.tbSecre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSecre.Location = new System.Drawing.Point(78, 459);
            this.tbSecre.Name = "tbSecre";
            this.tbSecre.ReadOnly = true;
            this.tbSecre.Size = new System.Drawing.Size(236, 20);
            this.tbSecre.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 435);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Контролер";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Секретарь";
            // 
            // btPrintEstimate
            // 
            this.btPrintEstimate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrintEstimate.Image = global::hardWareViewer.Properties.Resources.print;
            this.btPrintEstimate.Location = new System.Drawing.Point(899, 42);
            this.btPrintEstimate.Name = "btPrintEstimate";
            this.btPrintEstimate.Size = new System.Drawing.Size(32, 32);
            this.btPrintEstimate.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btPrintEstimate, "Печать сметы");
            this.btPrintEstimate.UseVisualStyleBackColor = true;
            this.btPrintEstimate.Click += new System.EventHandler(this.btPrintEstimate_Click);
            // 
            // btDown
            // 
            this.btDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDown.Image = global::hardWareViewer.Properties.Resources.old_edit_undo;
            this.btDown.Location = new System.Drawing.Point(712, 450);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(32, 32);
            this.btDown.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btDown, "Отклонить");
            this.btDown.UseVisualStyleBackColor = true;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // btAddDoc
            // 
            this.btAddDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddDoc.Image = global::hardWareViewer.Properties.Resources.folder_add;
            this.btAddDoc.Location = new System.Drawing.Point(750, 412);
            this.btAddDoc.Name = "btAddDoc";
            this.btAddDoc.Size = new System.Drawing.Size(32, 32);
            this.btAddDoc.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btAddDoc, "Добавить документ");
            this.btAddDoc.UseVisualStyleBackColor = true;
            this.btAddDoc.Click += new System.EventHandler(this.btAddDoc_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Image = global::hardWareViewer.Properties.Resources.reload_8055;
            this.btUpdate.Location = new System.Drawing.Point(330, 5);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(32, 32);
            this.btUpdate.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btUpdate, "Обновить");
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = global::hardWareViewer.Properties.Resources.document_add;
            this.btAdd.Location = new System.Drawing.Point(823, 412);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(32, 32);
            this.btAdd.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btAdd, "Создать");
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Image = global::hardWareViewer.Properties.Resources.edit;
            this.btEdit.Location = new System.Drawing.Point(861, 412);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(32, 32);
            this.btEdit.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btEdit, "Редактировать");
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.Image = global::hardWareViewer.Properties.Resources.document_delete;
            this.btDel.Location = new System.Drawing.Point(899, 412);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(32, 32);
            this.btDel.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btDel, "Удалить");
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btAccept
            // 
            this.btAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAccept.Image = global::hardWareViewer.Properties.Resources.Select;
            this.btAccept.Location = new System.Drawing.Point(750, 450);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(32, 32);
            this.btAccept.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btAccept, "Подтвердить");
            this.btAccept.UseVisualStyleBackColor = true;
            this.btAccept.Visible = false;
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // btNextStatus
            // 
            this.btNextStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNextStatus.Image = global::hardWareViewer.Properties.Resources.old_edit_redo;
            this.btNextStatus.Location = new System.Drawing.Point(788, 450);
            this.btNextStatus.Name = "btNextStatus";
            this.btNextStatus.Size = new System.Drawing.Size(32, 32);
            this.btNextStatus.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btNextStatus, "Передать");
            this.btNextStatus.UseVisualStyleBackColor = true;
            this.btNextStatus.Click += new System.EventHandler(this.btNextStatus_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(899, 450);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btPrintMemo
            // 
            this.btPrintMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrintMemo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btPrintMemo.Enabled = false;
            this.btPrintMemo.Image = ((System.Drawing.Image)(resources.GetObject("btPrintMemo.Image")));
            this.btPrintMemo.Location = new System.Drawing.Point(823, 42);
            this.btPrintMemo.Name = "btPrintMemo";
            this.btPrintMemo.Size = new System.Drawing.Size(32, 32);
            this.btPrintMemo.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btPrintMemo, "Печать СЗ на деньги");
            this.btPrintMemo.UseVisualStyleBackColor = true;
            this.btPrintMemo.Click += new System.EventHandler(this.btPrintMemo_Click);
            // 
            // btBalance
            // 
            this.btBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBalance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btBalance.Image = global::hardWareViewer.Properties.Resources.file_excel_o;
            this.btBalance.Location = new System.Drawing.Point(861, 42);
            this.btBalance.Name = "btBalance";
            this.btBalance.Size = new System.Drawing.Size(32, 32);
            this.btBalance.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btBalance, "Печать отчета по оборудованию и комплектующим ожидающим постоновки на баланс");
            this.btBalance.UseVisualStyleBackColor = true;
            this.btBalance.Click += new System.EventHandler(this.btBalance_Click);
            // 
            // pAdmCash
            // 
            this.pAdmCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pAdmCash.BackColor = System.Drawing.Color.LawnGreen;
            this.pAdmCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAdmCash.Location = new System.Drawing.Point(696, 383);
            this.pAdmCash.Name = "pAdmCash";
            this.pAdmCash.Size = new System.Drawing.Size(19, 19);
            this.pAdmCash.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(721, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(204, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "- Средства выделены (Администратор)";
            // 
            // pOpOk
            // 
            this.pOpOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pOpOk.BackColor = System.Drawing.Color.Yellow;
            this.pOpOk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pOpOk.Location = new System.Drawing.Point(15, 383);
            this.pOpOk.Name = "pOpOk";
            this.pOpOk.Size = new System.Drawing.Size(19, 19);
            this.pOpOk.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(185, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "- Смета подтверждена оператором";
            // 
            // pKntNo
            // 
            this.pKntNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pKntNo.BackColor = System.Drawing.Color.Pink;
            this.pKntNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pKntNo.Location = new System.Drawing.Point(231, 383);
            this.pKntNo.Name = "pKntNo";
            this.pKntNo.Size = new System.Drawing.Size(19, 19);
            this.pKntNo.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(256, 386);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(206, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "- Смета не подтверждена контролером";
            // 
            // pKntOk
            // 
            this.pKntOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pKntOk.BackColor = System.Drawing.Color.Orange;
            this.pKntOk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pKntOk.Location = new System.Drawing.Point(468, 383);
            this.pKntOk.Name = "pKntOk";
            this.pKntOk.Size = new System.Drawing.Size(19, 19);
            this.pKntOk.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(493, 386);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "- Смета подтверждена контролером";
            // 
            // pAllBal
            // 
            this.pAllBal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pAllBal.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pAllBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pAllBal.Location = new System.Drawing.Point(15, 408);
            this.pAllBal.Name = "pAllBal";
            this.pAllBal.Size = new System.Drawing.Size(19, 19);
            this.pAllBal.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "- Все поставлено на баланс";
            // 
            // btCreateAct
            // 
            this.btCreateAct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreateAct.Image = global::hardWareViewer.Properties.Resources.x_office_spreadsheet;
            this.btCreateAct.Location = new System.Drawing.Point(861, 450);
            this.btCreateAct.Name = "btCreateAct";
            this.btCreateAct.Size = new System.Drawing.Size(32, 32);
            this.btCreateAct.TabIndex = 6;
            this.btCreateAct.UseVisualStyleBackColor = true;
            // 
            // tbComment
            // 
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComment.Location = new System.Drawing.Point(330, 433);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ReadOnly = true;
            this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbComment.Size = new System.Drawing.Size(376, 46);
            this.tbComment.TabIndex = 7;
            // 
            // tbObject
            // 
            this.tbObject.Location = new System.Drawing.Point(51, 48);
            this.tbObject.Name = "tbObject";
            this.tbObject.Size = new System.Drawing.Size(82, 20);
            this.tbObject.TabIndex = 3;
            this.tbObject.TextChanged += new System.EventHandler(this.tbObject_TextChanged);
            // 
            // frmJournalEstimates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 508);
            this.Controls.Add(this.pAllBal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pKntOk);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pKntNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pOpOk);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pAdmCash);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.btDown);
            this.Controls.Add(this.btAddDoc);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btBalance);
            this.Controls.Add(this.btPrintMemo);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btPrintEstimate);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.btCreateAct);
            this.Controls.Add(this.btNextStatus);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.tbSecre);
            this.Controls.Add(this.tbControl);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbObject);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Name = "frmJournalEstimates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал смет";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox tbControl;
        private System.Windows.Forms.TextBox tbSecre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btCreateAct;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btNextStatus;
        private System.Windows.Forms.Button btAccept;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btAddDoc;
        private System.Windows.Forms.Button btPrintEstimate;
        private System.Windows.Forms.Button btPrintMemo;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pAdmCash;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pOpOk;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pKntNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pKntOk;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pAllBal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Button btBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn cObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSumm;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAcceptCont;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBall;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cScan;
        private System.Windows.Forms.TextBox tbObject;
    }
}