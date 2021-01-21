namespace hardWareViewer
{
    partial class frmAddEstimates
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cNameType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSumma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNamePurchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLink = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAccept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRepair = new System.Windows.Forms.DataGridViewButtonColumn();
            this.statusBuildUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNameEstimate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.tbItogo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbWithDost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btRedo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbOther = new System.Windows.Forms.GroupBox();
            this.btCancelBuy = new System.Windows.Forms.Button();
            this.btStopBuy = new System.Windows.Forms.Button();
            this.btCancelRepair = new System.Windows.Forms.Button();
            this.btCreateActReceving = new System.Windows.Forms.Button();
            this.gbPurchase = new System.Windows.Forms.GroupBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.gbOper = new System.Windows.Forms.GroupBox();
            this.btDown = new System.Windows.Forms.Button();
            this.btAccept = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbDep = new System.Windows.Forms.Label();
            this.cbDep = new System.Windows.Forms.ComboBox();
            this.tbDost = new System.Windows.Forms.TextBox();
            this.lbObject = new System.Windows.Forms.Label();
            this.cbObject = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gbOther.SuspendLayout();
            this.gbPurchase.SuspendLayout();
            this.gbOper.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = global::hardWareViewer.Properties.Resources.document_add;
            this.btAdd.Location = new System.Drawing.Point(9, 13);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(32, 32);
            this.btAdd.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btAdd, "Добавить наименование");
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Image = global::hardWareViewer.Properties.Resources.edit;
            this.btEdit.Location = new System.Drawing.Point(47, 13);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(32, 32);
            this.btEdit.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btEdit, "Редактировать наименование");
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.Image = global::hardWareViewer.Properties.Resources.document_delete;
            this.btDel.Location = new System.Drawing.Point(85, 13);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(32, 32);
            this.btDel.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btDel, "Удалить наименование");
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(918, 463);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::hardWareViewer.Properties.Resources.save_edit;
            this.btSave.Location = new System.Drawing.Point(123, 13);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btSave, "Сохранить смету");
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Дата:";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(51, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(93, 20);
            this.dtpDate.TabIndex = 12;
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
            this.cNameType,
            this.cName,
            this.cCount,
            this.cPrice,
            this.Delivery,
            this.cSumma,
            this.cComment,
            this.cNamePurchase,
            this.cLink,
            this.cStatus,
            this.cAccept,
            this.cRepair,
            this.statusBuildUp});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData.Location = new System.Drawing.Point(12, 117);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(943, 275);
            this.dgvData.TabIndex = 15;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDoubleClick);
            this.dgvData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvData_RowPostPaint);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            // 
            // cSelect
            // 
            this.cSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cSelect.DataPropertyName = "isSelect";
            this.cSelect.FalseValue = "false";
            this.cSelect.FillWeight = 1F;
            this.cSelect.HeaderText = "V";
            this.cSelect.MinimumWidth = 55;
            this.cSelect.Name = "cSelect";
            this.cSelect.ReadOnly = true;
            this.cSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cSelect.TrueValue = "true";
            this.cSelect.Width = 55;
            // 
            // cNameType
            // 
            this.cNameType.DataPropertyName = "nameTypeLinkView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cNameType.DefaultCellStyle = dataGridViewCellStyle2;
            this.cNameType.FillWeight = 84F;
            this.cNameType.HeaderText = "Тип оборудования/ комплектующих";
            this.cNameType.Name = "cNameType";
            this.cNameType.ReadOnly = true;
            this.cNameType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "cName";
            this.cName.FillWeight = 70F;
            this.cName.HeaderText = "Наименование";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cCount
            // 
            this.cCount.DataPropertyName = "Count";
            this.cCount.FillWeight = 30F;
            this.cCount.HeaderText = "Кол-во";
            this.cCount.Name = "cCount";
            this.cCount.ReadOnly = true;
            this.cCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cPrice
            // 
            this.cPrice.DataPropertyName = "Price";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.cPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.cPrice.FillWeight = 57.2248F;
            this.cPrice.HeaderText = "Цена";
            this.cPrice.Name = "cPrice";
            this.cPrice.ReadOnly = true;
            this.cPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Delivery
            // 
            this.Delivery.DataPropertyName = "Delivery";
            this.Delivery.FillWeight = 50F;
            this.Delivery.HeaderText = "Доставка";
            this.Delivery.Name = "Delivery";
            this.Delivery.ReadOnly = true;
            this.Delivery.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cSumma
            // 
            this.cSumma.DataPropertyName = "summa";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.cSumma.DefaultCellStyle = dataGridViewCellStyle4;
            this.cSumma.FillWeight = 57.2248F;
            this.cSumma.HeaderText = "Сумма";
            this.cSumma.Name = "cSumma";
            this.cSumma.ReadOnly = true;
            this.cSumma.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cComment
            // 
            this.cComment.DataPropertyName = "Comments";
            this.cComment.FillWeight = 59F;
            this.cComment.HeaderText = "Комментарий";
            this.cComment.Name = "cComment";
            this.cComment.ReadOnly = true;
            this.cComment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cNamePurchase
            // 
            this.cNamePurchase.DataPropertyName = "namePurchase";
            this.cNamePurchase.FillWeight = 70F;
            this.cNamePurchase.HeaderText = "Покупка";
            this.cNamePurchase.Name = "cNamePurchase";
            this.cNamePurchase.ReadOnly = true;
            this.cNamePurchase.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cLink
            // 
            this.cLink.DataPropertyName = "isLink";
            this.cLink.FillWeight = 57.2248F;
            this.cLink.HeaderText = "Ссылка";
            this.cLink.Name = "cLink";
            this.cLink.ReadOnly = true;
            this.cLink.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cStatus
            // 
            this.cStatus.DataPropertyName = "nameStatus";
            this.cStatus.FillWeight = 57.2248F;
            this.cStatus.HeaderText = "Статус оборудования";
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            this.cStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cAccept
            // 
            this.cAccept.DataPropertyName = "nameStatusConfirm";
            this.cAccept.FillWeight = 57.2248F;
            this.cAccept.HeaderText = "Статус подтверждения оборудования";
            this.cAccept.Name = "cAccept";
            this.cAccept.ReadOnly = true;
            this.cAccept.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cRepair
            // 
            this.cRepair.FillWeight = 57.2248F;
            this.cRepair.HeaderText = "Замена";
            this.cRepair.Name = "cRepair";
            this.cRepair.ReadOnly = true;
            this.cRepair.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cRepair.Text = "Замена";
            this.cRepair.UseColumnTextForButtonValue = true;
            // 
            // statusBuildUp
            // 
            this.statusBuildUp.HeaderText = "Статус оборудования";
            this.statusBuildUp.Name = "statusBuildUp";
            this.statusBuildUp.ReadOnly = true;
            this.statusBuildUp.Visible = false;
            // 
            // tbNum
            // 
            this.tbNum.Location = new System.Drawing.Point(206, 38);
            this.tbNum.Name = "tbNum";
            this.tbNum.Size = new System.Drawing.Size(749, 20);
            this.tbNum.TabIndex = 14;
            this.tbNum.TextChanged += new System.EventHandler(this.tbNameEstimate_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Проект/№ приказа, распоряжения:";
            // 
            // tbNameEstimate
            // 
            this.tbNameEstimate.Location = new System.Drawing.Point(290, 12);
            this.tbNameEstimate.Name = "tbNameEstimate";
            this.tbNameEstimate.Size = new System.Drawing.Size(665, 20);
            this.tbNameEstimate.TabIndex = 14;
            this.tbNameEstimate.TextChanged += new System.EventHandler(this.tbNameEstimate_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Наименование сметы:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(142, 90);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(190, 20);
            this.tbName.TabIndex = 14;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(12, 90);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(124, 21);
            this.cbType.TabIndex = 17;
            // 
            // tbItogo
            // 
            this.tbItogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbItogo.Location = new System.Drawing.Point(528, 417);
            this.tbItogo.Name = "tbItogo";
            this.tbItogo.ReadOnly = true;
            this.tbItogo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbItogo.Size = new System.Drawing.Size(100, 20);
            this.tbItogo.TabIndex = 14;
            this.tbItogo.Text = "0,00";
            this.tbItogo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(482, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Итого:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(462, 448);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Доставка:";
            // 
            // tbWithDost
            // 
            this.tbWithDost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbWithDost.Location = new System.Drawing.Point(528, 470);
            this.tbWithDost.Name = "tbWithDost";
            this.tbWithDost.ReadOnly = true;
            this.tbWithDost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbWithDost.Size = new System.Drawing.Size(100, 20);
            this.tbWithDost.TabIndex = 14;
            this.tbWithDost.Text = "0,00";
            this.tbWithDost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(417, 474);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Итого с доставкой:";
            // 
            // btRedo
            // 
            this.btRedo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRedo.Enabled = false;
            this.btRedo.Image = global::hardWareViewer.Properties.Resources.old_edit_redo;
            this.btRedo.Location = new System.Drawing.Point(880, 463);
            this.btRedo.Name = "btRedo";
            this.btRedo.Size = new System.Drawing.Size(32, 32);
            this.btRedo.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btRedo, "Передать смету");
            this.btRedo.UseVisualStyleBackColor = true;
            this.btRedo.Click += new System.EventHandler(this.btRedo_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(634, 421);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "руб.";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(634, 448);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "руб.";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(634, 474);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "руб.";
            // 
            // gbOther
            // 
            this.gbOther.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbOther.Controls.Add(this.btCancelBuy);
            this.gbOther.Controls.Add(this.btStopBuy);
            this.gbOther.Controls.Add(this.btCancelRepair);
            this.gbOther.Controls.Add(this.btCreateActReceving);
            this.gbOther.Location = new System.Drawing.Point(13, 404);
            this.gbOther.Name = "gbOther";
            this.gbOther.Size = new System.Drawing.Size(366, 93);
            this.gbOther.TabIndex = 18;
            this.gbOther.TabStop = false;
            this.gbOther.Visible = false;
            // 
            // btCancelBuy
            // 
            this.btCancelBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelBuy.Location = new System.Drawing.Point(184, 62);
            this.btCancelBuy.Name = "btCancelBuy";
            this.btCancelBuy.Size = new System.Drawing.Size(163, 24);
            this.btCancelBuy.TabIndex = 11;
            this.btCancelBuy.Text = "Отмена отказа от покупки";
            this.btCancelBuy.UseVisualStyleBackColor = true;
            this.btCancelBuy.Click += new System.EventHandler(this.btCancelBuy_Click);
            // 
            // btStopBuy
            // 
            this.btStopBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStopBuy.Location = new System.Drawing.Point(15, 62);
            this.btStopBuy.Name = "btStopBuy";
            this.btStopBuy.Size = new System.Drawing.Size(163, 24);
            this.btStopBuy.TabIndex = 11;
            this.btStopBuy.Text = "Отказ от покупки";
            this.btStopBuy.UseVisualStyleBackColor = true;
            this.btStopBuy.Click += new System.EventHandler(this.btStopBuy_Click);
            // 
            // btCancelRepair
            // 
            this.btCancelRepair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelRepair.Location = new System.Drawing.Point(136, 36);
            this.btCancelRepair.Name = "btCancelRepair";
            this.btCancelRepair.Size = new System.Drawing.Size(211, 24);
            this.btCancelRepair.TabIndex = 11;
            this.btCancelRepair.Text = "Отменить замену оборудования";
            this.btCancelRepair.UseVisualStyleBackColor = true;
            this.btCancelRepair.Click += new System.EventHandler(this.btCancelRepair_Click);
            // 
            // btCreateActReceving
            // 
            this.btCreateActReceving.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreateActReceving.Location = new System.Drawing.Point(15, 12);
            this.btCreateActReceving.Name = "btCreateActReceving";
            this.btCreateActReceving.Size = new System.Drawing.Size(332, 24);
            this.btCreateActReceving.TabIndex = 11;
            this.btCreateActReceving.Text = "Создать акт приема-передачи";
            this.btCreateActReceving.UseVisualStyleBackColor = true;
            this.btCreateActReceving.Click += new System.EventHandler(this.btCreateActReceving_Click);
            // 
            // gbPurchase
            // 
            this.gbPurchase.Controls.Add(this.btnReplace);
            this.gbPurchase.Controls.Add(this.btnBuy);
            this.gbPurchase.Location = new System.Drawing.Point(7, 404);
            this.gbPurchase.Name = "gbPurchase";
            this.gbPurchase.Size = new System.Drawing.Size(366, 93);
            this.gbPurchase.TabIndex = 24;
            this.gbPurchase.TabStop = false;
            this.gbPurchase.Text = "Оборудование";
            // 
            // btnReplace
            // 
            this.btnReplace.Enabled = false;
            this.btnReplace.Location = new System.Drawing.Point(6, 44);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(113, 23);
            this.btnReplace.TabIndex = 1;
            this.btnReplace.Text = "Замена";
            this.toolTip1.SetToolTip(this.btnReplace, "Заменить наименование");
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Enabled = false;
            this.btnBuy.Location = new System.Drawing.Point(6, 15);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(113, 23);
            this.btnBuy.TabIndex = 0;
            this.btnBuy.Text = "Отказ от покупки";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // gbOper
            // 
            this.gbOper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOper.Controls.Add(this.btDel);
            this.gbOper.Controls.Add(this.btEdit);
            this.gbOper.Controls.Add(this.btAdd);
            this.gbOper.Controls.Add(this.btSave);
            this.gbOper.Location = new System.Drawing.Point(795, 404);
            this.gbOper.Name = "gbOper";
            this.gbOper.Size = new System.Drawing.Size(161, 52);
            this.gbOper.TabIndex = 19;
            this.gbOper.TabStop = false;
            // 
            // btDown
            // 
            this.btDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDown.Image = global::hardWareViewer.Properties.Resources.old_edit_undo;
            this.btDown.Location = new System.Drawing.Point(804, 463);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(32, 32);
            this.btDown.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btDown, "Отклонить");
            this.btDown.UseVisualStyleBackColor = true;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // btAccept
            // 
            this.btAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAccept.Image = global::hardWareViewer.Properties.Resources.Select;
            this.btAccept.Location = new System.Drawing.Point(842, 463);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(32, 32);
            this.btAccept.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btAccept, "Подтвердить");
            this.btAccept.UseVisualStyleBackColor = true;
            this.btAccept.Visible = false;
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // lbDep
            // 
            this.lbDep.AutoSize = true;
            this.lbDep.Location = new System.Drawing.Point(9, 67);
            this.lbDep.Name = "lbDep";
            this.lbDep.Size = new System.Drawing.Size(38, 13);
            this.lbDep.TabIndex = 22;
            this.lbDep.Text = "Отдел";
            // 
            // cbDep
            // 
            this.cbDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDep.FormattingEnabled = true;
            this.cbDep.Location = new System.Drawing.Point(53, 64);
            this.cbDep.Name = "cbDep";
            this.cbDep.Size = new System.Drawing.Size(231, 21);
            this.cbDep.TabIndex = 23;
            // 
            // tbDost
            // 
            this.tbDost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbDost.Location = new System.Drawing.Point(528, 445);
            this.tbDost.Name = "tbDost";
            this.tbDost.ReadOnly = true;
            this.tbDost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbDost.Size = new System.Drawing.Size(100, 20);
            this.tbDost.TabIndex = 14;
            this.tbDost.Text = "0,00";
            this.tbDost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbObject
            // 
            this.lbObject.AutoSize = true;
            this.lbObject.Location = new System.Drawing.Point(513, 67);
            this.lbObject.Name = "lbObject";
            this.lbObject.Size = new System.Drawing.Size(45, 13);
            this.lbObject.TabIndex = 22;
            this.lbObject.Text = "Объект";
            // 
            // cbObject
            // 
            this.cbObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbObject.FormattingEnabled = true;
            this.cbObject.Location = new System.Drawing.Point(564, 64);
            this.cbObject.Name = "cbObject";
            this.cbObject.Size = new System.Drawing.Size(391, 21);
            this.cbObject.TabIndex = 23;
            // 
            // frmAddEstimates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 531);
            this.Controls.Add(this.cbObject);
            this.Controls.Add(this.lbObject);
            this.Controls.Add(this.cbDep);
            this.Controls.Add(this.lbDep);
            this.Controls.Add(this.btDown);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.gbOper);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.tbWithDost);
            this.Controls.Add(this.tbDost);
            this.Controls.Add(this.tbItogo);
            this.Controls.Add(this.tbNameEstimate);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btRedo);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.gbPurchase);
            this.Controls.Add(this.gbOther);
            this.MinimizeBox = false;
            this.Name = "frmAddEstimates";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "v";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddEstimates_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddEstimates_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gbOther.ResumeLayout(false);
            this.gbPurchase.ResumeLayout(false);
            this.gbOper.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox tbNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNameEstimate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.TextBox tbItogo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbWithDost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btRedo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbOther;
        private System.Windows.Forms.Button btStopBuy;
        private System.Windows.Forms.Button btCancelRepair;
        private System.Windows.Forms.Button btCreateActReceving;
        private System.Windows.Forms.Button btCancelBuy;
        private System.Windows.Forms.GroupBox gbOper;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Button btAccept;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbDep;
        private System.Windows.Forms.ComboBox cbDep;
        private System.Windows.Forms.GroupBox gbPurchase;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.TextBox tbDost;
        private System.Windows.Forms.Label lbObject;
        private System.Windows.Forms.ComboBox cbObject;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSumma;
        private System.Windows.Forms.DataGridViewTextBoxColumn cComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNamePurchase;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAccept;
        private System.Windows.Forms.DataGridViewButtonColumn cRepair;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusBuildUp;
    }
}