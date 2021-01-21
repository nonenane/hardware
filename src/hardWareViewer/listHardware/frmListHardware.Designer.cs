namespace hardWareViewer
{
    partial class frmListHardware
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rbComponents = new System.Windows.Forms.RadioButton();
            this.rbHrdWare = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.cbResponsibles = new System.Windows.Forms.ComboBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHardWare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cResponsible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cDateCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDateEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNumCZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.tbEAN = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btAdded = new System.Windows.Forms.Button();
            this.btEdited = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btViewComponents = new System.Windows.Forms.Button();
            this.btSelect = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.btAddDoc = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.printToExcel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btReport = new System.Windows.Forms.Button();
            this.chbDays = new System.Windows.Forms.CheckBox();
            this.nudDays = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.отчетПоИзменениюВОборудованииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btMOLChange = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNumberSZ = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).BeginInit();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbComponents
            // 
            this.rbComponents.AutoSize = true;
            this.rbComponents.Location = new System.Drawing.Point(113, 19);
            this.rbComponents.Name = "rbComponents";
            this.rbComponents.Size = new System.Drawing.Size(109, 17);
            this.rbComponents.TabIndex = 3;
            this.rbComponents.Text = "Комплектующие";
            this.rbComponents.UseVisualStyleBackColor = true;
            // 
            // rbHrdWare
            // 
            this.rbHrdWare.AutoSize = true;
            this.rbHrdWare.Checked = true;
            this.rbHrdWare.Location = new System.Drawing.Point(9, 19);
            this.rbHrdWare.Name = "rbHrdWare";
            this.rbHrdWare.Size = new System.Drawing.Size(98, 17);
            this.rbHrdWare.TabIndex = 4;
            this.rbHrdWare.TabStop = true;
            this.rbHrdWare.Text = "Оборудование";
            this.rbHrdWare.UseVisualStyleBackColor = true;
            this.rbHrdWare.CheckedChanged += new System.EventHandler(this.rbHrdWare_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbComponents);
            this.groupBox1.Controls.Add(this.rbHrdWare);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 44);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Оборудование/Комплектующие";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(860, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Статус:";
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(910, 8);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(188, 21);
            this.cbStatus.TabIndex = 36;
            this.cbStatus.SelectionChangeCommitted += new System.EventHandler(this.cbLocation_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(567, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Местоположение:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(576, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Ответственный:";
            // 
            // cbLocation
            // 
            this.cbLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(666, 8);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(188, 21);
            this.cbLocation.TabIndex = 38;
            this.cbLocation.SelectionChangeCommitted += new System.EventHandler(this.cbLocation_SelectionChangeCommitted);
            // 
            // cbResponsibles
            // 
            this.cbResponsibles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbResponsibles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResponsibles.FormattingEnabled = true;
            this.cbResponsibles.Location = new System.Drawing.Point(666, 35);
            this.cbResponsibles.Name = "cbResponsibles";
            this.cbResponsibles.Size = new System.Drawing.Size(188, 21);
            this.cbResponsibles.TabIndex = 39;
            this.cbResponsibles.SelectionChangeCommitted += new System.EventHandler(this.cbLocation_SelectionChangeCommitted);
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
            this.cSelect,
            this.cNum,
            this.cEAN,
            this.cName,
            this.LocationComment,
            this.cHardWare,
            this.cLocation,
            this.cResponsible,
            this.cStatus,
            this.cScan,
            this.cDateCreate,
            this.cDateEdit,
            this.cNumCZ});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.Location = new System.Drawing.Point(12, 107);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1136, 270);
            this.dgvData.TabIndex = 52;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvData_CellMouseClick);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvData_CellMouseDoubleClick);
            this.dgvData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvData_RowPostPaint);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            // 
            // cSelect
            // 
            this.cSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cSelect.DataPropertyName = "isSelect";
            this.cSelect.FalseValue = "false";
            this.cSelect.HeaderText = "V";
            this.cSelect.MinimumWidth = 50;
            this.cSelect.Name = "cSelect";
            this.cSelect.ReadOnly = true;
            this.cSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cSelect.TrueValue = "true";
            this.cSelect.Visible = false;
            this.cSelect.Width = 50;
            // 
            // cNum
            // 
            this.cNum.DataPropertyName = "InventoryNumber";
            this.cNum.HeaderText = "Инв. №";
            this.cNum.Name = "cNum";
            this.cNum.ReadOnly = true;
            // 
            // cEAN
            // 
            this.cEAN.DataPropertyName = "ean";
            this.cEAN.HeaderText = "EAN";
            this.cEAN.Name = "cEAN";
            this.cEAN.ReadOnly = true;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "cName";
            this.cName.HeaderText = "Наименование";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // LocationComment
            // 
            this.LocationComment.DataPropertyName = "LocationComment";
            this.LocationComment.HeaderText = "Объект";
            this.LocationComment.Name = "LocationComment";
            this.LocationComment.ReadOnly = true;
            // 
            // cHardWare
            // 
            this.cHardWare.DataPropertyName = "nameHardware";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cHardWare.DefaultCellStyle = dataGridViewCellStyle2;
            this.cHardWare.HeaderText = "Оборудование/ Комплектующие";
            this.cHardWare.Name = "cHardWare";
            this.cHardWare.ReadOnly = true;
            // 
            // cLocation
            // 
            this.cLocation.DataPropertyName = "nameLocation";
            this.cLocation.HeaderText = "Местоположение";
            this.cLocation.Name = "cLocation";
            this.cLocation.ReadOnly = true;
            this.cLocation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cResponsible
            // 
            this.cResponsible.DataPropertyName = "FIO";
            this.cResponsible.HeaderText = "Ответственный";
            this.cResponsible.Name = "cResponsible";
            this.cResponsible.ReadOnly = true;
            this.cResponsible.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cStatus
            // 
            this.cStatus.DataPropertyName = "nameStatus";
            this.cStatus.HeaderText = "Статус";
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            // 
            // cScan
            // 
            this.cScan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cScan.DataPropertyName = "scaneCount";
            this.cScan.HeaderText = "Скан";
            this.cScan.MinimumWidth = 85;
            this.cScan.Name = "cScan";
            this.cScan.ReadOnly = true;
            this.cScan.Width = 85;
            // 
            // cDateCreate
            // 
            this.cDateCreate.DataPropertyName = "DateCreate";
            this.cDateCreate.HeaderText = "Дата создания";
            this.cDateCreate.Name = "cDateCreate";
            this.cDateCreate.ReadOnly = true;
            // 
            // cDateEdit
            // 
            this.cDateEdit.DataPropertyName = "DateEdit";
            this.cDateEdit.HeaderText = "Дата редактирования";
            this.cDateEdit.Name = "cDateEdit";
            this.cDateEdit.ReadOnly = true;
            // 
            // cNumCZ
            // 
            this.cNumCZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cNumCZ.DataPropertyName = "Number";
            this.cNumCZ.HeaderText = "№ СЗ на ДС";
            this.cNumCZ.MinimumWidth = 50;
            this.cNumCZ.Name = "cNumCZ";
            this.cNumCZ.ReadOnly = true;
            this.cNumCZ.Width = 65;
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(12, 81);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(122, 20);
            this.tbNumber.TabIndex = 53;
            this.tbNumber.TextChanged += new System.EventHandler(this.tbNumber_TextChanged);
            // 
            // tbEAN
            // 
            this.tbEAN.Location = new System.Drawing.Point(140, 81);
            this.tbEAN.Name = "tbEAN";
            this.tbEAN.Size = new System.Drawing.Size(117, 20);
            this.tbEAN.TabIndex = 53;
            this.tbEAN.TextChanged += new System.EventHandler(this.tbNumber_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(263, 81);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(125, 20);
            this.tbName.TabIndex = 53;
            this.tbName.TextChanged += new System.EventHandler(this.tbNumber_TextChanged);
            // 
            // btUpdate
            // 
            this.btUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpdate.Image = global::hardWareViewer.Properties.Resources.reload_8055;
            this.btUpdate.Location = new System.Drawing.Point(1115, 12);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(32, 32);
            this.btUpdate.TabIndex = 54;
            this.toolTip1.SetToolTip(this.btUpdate, "Обновить");
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btDropFilter_Click);
            // 
            // btAdded
            // 
            this.btAdded.Location = new System.Drawing.Point(377, 385);
            this.btAdded.Name = "btAdded";
            this.btAdded.Size = new System.Drawing.Size(98, 40);
            this.btAdded.TabIndex = 59;
            this.btAdded.Text = "Добавить";
            this.btAdded.UseVisualStyleBackColor = true;
            this.btAdded.Click += new System.EventHandler(this.button1_Click);
            // 
            // btEdited
            // 
            this.btEdited.Location = new System.Drawing.Point(481, 385);
            this.btEdited.Name = "btEdited";
            this.btEdited.Size = new System.Drawing.Size(98, 40);
            this.btEdited.TabIndex = 60;
            this.btEdited.Text = "Редактировать";
            this.btEdited.UseVisualStyleBackColor = true;
            this.btEdited.Click += new System.EventHandler(this.button2_Click);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(585, 385);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(98, 40);
            this.btDelete.TabIndex = 61;
            this.btDelete.Text = "Удалить";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.Button3_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(537, 431);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 67;
            this.textBox4.Visible = false;
            // 
            // btViewComponents
            // 
            this.btViewComponents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btViewComponents.Image = global::hardWareViewer.Properties.Resources.eye_quick_view;
            this.btViewComponents.Location = new System.Drawing.Point(1039, 432);
            this.btViewComponents.Name = "btViewComponents";
            this.btViewComponents.Size = new System.Drawing.Size(32, 32);
            this.btViewComponents.TabIndex = 63;
            this.toolTip1.SetToolTip(this.btViewComponents, "Просмотр комплектации оборудования");
            this.btViewComponents.UseVisualStyleBackColor = true;
            this.btViewComponents.Click += new System.EventHandler(this.btViewComponents_Click);
            // 
            // btSelect
            // 
            this.btSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSelect.Enabled = false;
            this.btSelect.Image = global::hardWareViewer.Properties.Resources.Select;
            this.btSelect.Location = new System.Drawing.Point(1077, 432);
            this.btSelect.Name = "btSelect";
            this.btSelect.Size = new System.Drawing.Size(32, 32);
            this.btSelect.TabIndex = 64;
            this.btSelect.UseVisualStyleBackColor = true;
            this.btSelect.Visible = false;
            this.btSelect.Click += new System.EventHandler(this.btSelect_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Location = new System.Drawing.Point(1077, 432);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(32, 32);
            this.btPrint.TabIndex = 65;
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Visible = false;
            this.btPrint.Click += new System.EventHandler(this.BtPrint_Click);
            // 
            // btAddDoc
            // 
            this.btAddDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddDoc.Image = global::hardWareViewer.Properties.Resources.folder_add;
            this.btAddDoc.Location = new System.Drawing.Point(1115, 393);
            this.btAddDoc.Name = "btAddDoc";
            this.btAddDoc.Size = new System.Drawing.Size(32, 32);
            this.btAddDoc.TabIndex = 66;
            this.toolTip1.SetToolTip(this.btAddDoc, "Работа с документами");
            this.btAddDoc.UseVisualStyleBackColor = true;
            this.btAddDoc.Click += new System.EventHandler(this.btAddDoc_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(1115, 432);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 62;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // printToExcel
            // 
            this.printToExcel.Location = new System.Drawing.Point(12, 385);
            this.printToExcel.Name = "printToExcel";
            this.printToExcel.Size = new System.Drawing.Size(75, 23);
            this.printToExcel.TabIndex = 68;
            this.printToExcel.Text = "Печать";
            this.printToExcel.UseVisualStyleBackColor = true;
            this.printToExcel.Click += new System.EventHandler(this.printToExcel_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "xls (*.xls) | *.xls";
            // 
            // btReport
            // 
            this.btReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btReport.Image = global::hardWareViewer.Properties.Resources.print;
            this.btReport.Location = new System.Drawing.Point(1001, 432);
            this.btReport.Name = "btReport";
            this.btReport.Size = new System.Drawing.Size(32, 32);
            this.btReport.TabIndex = 69;
            this.toolTip1.SetToolTip(this.btReport, "Отчет по изменению в оборудовании");
            this.btReport.UseVisualStyleBackColor = true;
            this.btReport.Click += new System.EventHandler(this.BtReport_Click);
            // 
            // chbDays
            // 
            this.chbDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbDays.AutoSize = true;
            this.chbDays.Location = new System.Drawing.Point(21, 423);
            this.chbDays.Name = "chbDays";
            this.chbDays.Size = new System.Drawing.Size(132, 17);
            this.chbDays.TabIndex = 70;
            this.chbDays.Text = "показать данные за ";
            this.chbDays.UseVisualStyleBackColor = true;
            this.chbDays.CheckedChanged += new System.EventHandler(this.ChbDays_CheckedChanged);
            // 
            // nudDays
            // 
            this.nudDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudDays.Location = new System.Drawing.Point(159, 422);
            this.nudDays.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudDays.Name = "nudDays";
            this.nudDays.Size = new System.Drawing.Size(44, 20);
            this.nudDays.TabIndex = 71;
            this.nudDays.ValueChanged += new System.EventHandler(this.NudDays_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "дней";
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчетПоИзменениюВОборудованииToolStripMenuItem});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(283, 26);
            // 
            // отчетПоИзменениюВОборудованииToolStripMenuItem
            // 
            this.отчетПоИзменениюВОборудованииToolStripMenuItem.Name = "отчетПоИзменениюВОборудованииToolStripMenuItem";
            this.отчетПоИзменениюВОборудованииToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.отчетПоИзменениюВОборудованииToolStripMenuItem.Text = "Отчет по изменению в оборудовании";
            this.отчетПоИзменениюВОборудованииToolStripMenuItem.Click += new System.EventHandler(this.ОтчетПоИзменениюВОборудованииToolStripMenuItem_Click);
            // 
            // btMOLChange
            // 
            this.btMOLChange.Enabled = false;
            this.btMOLChange.Location = new System.Drawing.Point(689, 385);
            this.btMOLChange.Name = "btMOLChange";
            this.btMOLChange.Size = new System.Drawing.Size(98, 40);
            this.btMOLChange.TabIndex = 73;
            this.btMOLChange.Text = "Изменить МОЛ для выбранных";
            this.btMOLChange.UseVisualStyleBackColor = true;
            this.btMOLChange.Click += new System.EventHandler(this.btMOLChange_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(21, 447);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(21, 21);
            this.panel1.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = " - гарантийный срок не закончился";
            // 
            // tbNumberSZ
            // 
            this.tbNumberSZ.Location = new System.Drawing.Point(1077, 81);
            this.tbNumberSZ.MaxLength = 50;
            this.tbNumberSZ.Name = "tbNumberSZ";
            this.tbNumberSZ.Size = new System.Drawing.Size(70, 20);
            this.tbNumberSZ.TabIndex = 76;
            this.tbNumberSZ.TextChanged += new System.EventHandler(this.tbNumber_TextChanged);
            this.tbNumberSZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumberSZ_KeyPress);
            // 
            // frmListHardware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 470);
            this.ControlBox = false;
            this.Controls.Add(this.tbNumberSZ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btMOLChange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudDays);
            this.Controls.Add(this.chbDays);
            this.Controls.Add(this.btReport);
            this.Controls.Add(this.printToExcel);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.btViewComponents);
            this.Controls.Add(this.btSelect);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btAddDoc);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btEdited);
            this.Controls.Add(this.btAdded);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbEAN);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.cbResponsibles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListHardware";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список оборудования";
            this.Load += new System.EventHandler(this.frmListHardware_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).EndInit();
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbComponents;
        private System.Windows.Forms.RadioButton rbHrdWare;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.ComboBox cbResponsibles;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.TextBox tbEAN;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btUpdate;
        private Code39Control code39Control1;
        private System.Windows.Forms.Button btAdded;
        private System.Windows.Forms.Button btEdited;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btViewComponents;
        private System.Windows.Forms.Button btSelect;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btAddDoc;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button printToExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btReport;
        private System.Windows.Forms.CheckBox chbDays;
        private System.Windows.Forms.NumericUpDown nudDays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem отчетПоИзменениюВОборудованииToolStripMenuItem;
        private System.Windows.Forms.Button btMOLChange;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHardWare;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn cResponsible;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cScan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDateCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDateEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNumCZ;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNumberSZ;
    }
}