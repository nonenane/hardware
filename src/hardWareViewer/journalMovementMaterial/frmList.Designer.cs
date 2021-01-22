namespace hardWareViewer.journalMovementMaterial
{
    partial class frmList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbNotActive = new System.Windows.Forms.CheckBox();
            this.btOstView = new System.Windows.Forms.Button();
            this.btOstPrint = new System.Windows.Forms.Button();
            this.dgvOst = new System.Windows.Forms.DataGridView();
            this.cMatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMatMol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMatOstNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMatOstDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbOstMol = new System.Windows.Forms.TextBox();
            this.tbOstName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btPrint = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.tbJourComment = new System.Windows.Forms.TextBox();
            this.tbJourMol = new System.Windows.Forms.TextBox();
            this.tbDateEdit = new System.Windows.Forms.TextBox();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.tbJourNum = new System.Windows.Forms.TextBox();
            this.dgvJour = new System.Windows.Forms.DataGridView();
            this.cJouDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJouNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJouMol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJouCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJouComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJouType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpOstDate = new System.Windows.Forms.DateTimePicker();
            this.cmbTypeOperation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btUpdate = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOst)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJour)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.chbNotActive);
            this.groupBox1.Controls.Add(this.btOstView);
            this.groupBox1.Controls.Add(this.btOstPrint);
            this.groupBox1.Controls.Add(this.dgvOst);
            this.groupBox1.Controls.Add(this.tbOstMol);
            this.groupBox1.Controls.Add(this.tbOstName);
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 385);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список расходных материалов";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(11, 354);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(21, 21);
            this.panel1.TabIndex = 24;
            // 
            // chbNotActive
            // 
            this.chbNotActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbNotActive.AutoSize = true;
            this.chbNotActive.Location = new System.Drawing.Point(38, 356);
            this.chbNotActive.Name = "chbNotActive";
            this.chbNotActive.Size = new System.Drawing.Size(196, 17);
            this.chbNotActive.TabIndex = 23;
            this.chbNotActive.Text = "-отрицательные текущие остатки";
            this.chbNotActive.UseVisualStyleBackColor = true;
            this.chbNotActive.CheckedChanged += new System.EventHandler(this.chbNotActive_CheckedChanged);
            // 
            // btOstView
            // 
            this.btOstView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOstView.Image = global::hardWareViewer.Properties.Resources.old_edit_find;
            this.btOstView.Location = new System.Drawing.Point(482, 348);
            this.btOstView.Name = "btOstView";
            this.btOstView.Size = new System.Drawing.Size(32, 32);
            this.btOstView.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btOstView, "Поиск по номеру документа");
            this.btOstView.UseVisualStyleBackColor = true;
            this.btOstView.Click += new System.EventHandler(this.btOstView_Click);
            // 
            // btOstPrint
            // 
            this.btOstPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOstPrint.Image = global::hardWareViewer.Properties.Resources.file_excel_o;
            this.btOstPrint.Location = new System.Drawing.Point(551, 348);
            this.btOstPrint.Name = "btOstPrint";
            this.btOstPrint.Size = new System.Drawing.Size(32, 32);
            this.btOstPrint.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btOstPrint, "Печать остатков");
            this.btOstPrint.UseVisualStyleBackColor = true;
            this.btOstPrint.Click += new System.EventHandler(this.btOstPrint_Click);
            // 
            // dgvOst
            // 
            this.dgvOst.AllowUserToAddRows = false;
            this.dgvOst.AllowUserToDeleteRows = false;
            this.dgvOst.AllowUserToResizeRows = false;
            this.dgvOst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOst.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOst.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cMatName,
            this.cMatMol,
            this.cMatOstNow,
            this.cMatOstDate});
            this.dgvOst.Location = new System.Drawing.Point(6, 45);
            this.dgvOst.MultiSelect = false;
            this.dgvOst.Name = "dgvOst";
            this.dgvOst.ReadOnly = true;
            this.dgvOst.RowHeadersVisible = false;
            this.dgvOst.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOst.Size = new System.Drawing.Size(577, 296);
            this.dgvOst.TabIndex = 17;
            this.dgvOst.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvOst_ColumnWidthChanged);
            this.dgvOst.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvOst_RowPostPaint);
            this.dgvOst.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvOst_RowPrePaint);
            // 
            // cMatName
            // 
            this.cMatName.DataPropertyName = "cName";
            this.cMatName.HeaderText = "Расходный материал";
            this.cMatName.Name = "cMatName";
            this.cMatName.ReadOnly = true;
            // 
            // cMatMol
            // 
            this.cMatMol.DataPropertyName = "cNameMol";
            this.cMatMol.HeaderText = "МОЛ";
            this.cMatMol.Name = "cMatMol";
            this.cMatMol.ReadOnly = true;
            // 
            // cMatOstNow
            // 
            this.cMatOstNow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cMatOstNow.DataPropertyName = "ostNow";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.cMatOstNow.DefaultCellStyle = dataGridViewCellStyle2;
            this.cMatOstNow.HeaderText = "Текущий остаток";
            this.cMatOstNow.MinimumWidth = 90;
            this.cMatOstNow.Name = "cMatOstNow";
            this.cMatOstNow.ReadOnly = true;
            this.cMatOstNow.Width = 90;
            // 
            // cMatOstDate
            // 
            this.cMatOstDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cMatOstDate.DataPropertyName = "ostDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.cMatOstDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.cMatOstDate.HeaderText = "Остаток на дату";
            this.cMatOstDate.MinimumWidth = 90;
            this.cMatOstDate.Name = "cMatOstDate";
            this.cMatOstDate.ReadOnly = true;
            this.cMatOstDate.Width = 90;
            // 
            // tbOstMol
            // 
            this.tbOstMol.Location = new System.Drawing.Point(125, 19);
            this.tbOstMol.Name = "tbOstMol";
            this.tbOstMol.Size = new System.Drawing.Size(100, 20);
            this.tbOstMol.TabIndex = 18;
            this.tbOstMol.TextChanged += new System.EventHandler(this.tbOstName_TextChanged);
            // 
            // tbOstName
            // 
            this.tbOstName.Location = new System.Drawing.Point(7, 19);
            this.tbOstName.Name = "tbOstName";
            this.tbOstName.Size = new System.Drawing.Size(100, 20);
            this.tbOstName.TabIndex = 18;
            this.tbOstName.TextChanged += new System.EventHandler(this.tbOstName_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btPrint);
            this.groupBox2.Controls.Add(this.btDel);
            this.groupBox2.Controls.Add(this.btEdit);
            this.groupBox2.Controls.Add(this.btAdd);
            this.groupBox2.Controls.Add(this.tbJourComment);
            this.groupBox2.Controls.Add(this.tbJourMol);
            this.groupBox2.Controls.Add(this.tbDateEdit);
            this.groupBox2.Controls.Add(this.tbFIO);
            this.groupBox2.Controls.Add(this.tbJourNum);
            this.groupBox2.Controls.Add(this.dgvJour);
            this.groupBox2.Location = new System.Drawing.Point(630, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(632, 385);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Журнал движения расходных материалов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Дата редактирования";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Редактировал";
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Image = global::hardWareViewer.Properties.Resources.file_excel_o;
            this.btPrint.Location = new System.Drawing.Point(465, 347);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(32, 32);
            this.btPrint.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btPrint, "Печать движения материал");
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.Image = global::hardWareViewer.Properties.Resources.document_delete;
            this.btDel.Location = new System.Drawing.Point(594, 347);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(32, 32);
            this.btDel.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btDel, "Удалить");
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Image = global::hardWareViewer.Properties.Resources.edit;
            this.btEdit.Location = new System.Drawing.Point(556, 347);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(32, 32);
            this.btEdit.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btEdit, "Редактировать");
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = global::hardWareViewer.Properties.Resources.document_add;
            this.btAdd.Location = new System.Drawing.Point(518, 347);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(32, 32);
            this.btAdd.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btAdd, "Добавить");
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // tbJourComment
            // 
            this.tbJourComment.Location = new System.Drawing.Point(246, 19);
            this.tbJourComment.Name = "tbJourComment";
            this.tbJourComment.Size = new System.Drawing.Size(100, 20);
            this.tbJourComment.TabIndex = 18;
            this.tbJourComment.TextChanged += new System.EventHandler(this.tbJourNum_TextChanged);
            // 
            // tbJourMol
            // 
            this.tbJourMol.Location = new System.Drawing.Point(140, 19);
            this.tbJourMol.Name = "tbJourMol";
            this.tbJourMol.Size = new System.Drawing.Size(100, 20);
            this.tbJourMol.TabIndex = 18;
            this.tbJourMol.TextChanged += new System.EventHandler(this.tbJourNum_TextChanged);
            // 
            // tbDateEdit
            // 
            this.tbDateEdit.Location = new System.Drawing.Point(136, 355);
            this.tbDateEdit.Name = "tbDateEdit";
            this.tbDateEdit.ReadOnly = true;
            this.tbDateEdit.Size = new System.Drawing.Size(181, 20);
            this.tbDateEdit.TabIndex = 18;
            // 
            // tbFIO
            // 
            this.tbFIO.Location = new System.Drawing.Point(136, 329);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.ReadOnly = true;
            this.tbFIO.Size = new System.Drawing.Size(181, 20);
            this.tbFIO.TabIndex = 18;
            // 
            // tbJourNum
            // 
            this.tbJourNum.Location = new System.Drawing.Point(22, 19);
            this.tbJourNum.Name = "tbJourNum";
            this.tbJourNum.Size = new System.Drawing.Size(100, 20);
            this.tbJourNum.TabIndex = 18;
            this.tbJourNum.TextChanged += new System.EventHandler(this.tbJourNum_TextChanged);
            // 
            // dgvJour
            // 
            this.dgvJour.AllowUserToAddRows = false;
            this.dgvJour.AllowUserToDeleteRows = false;
            this.dgvJour.AllowUserToResizeRows = false;
            this.dgvJour.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJour.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvJour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJour.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cJouDate,
            this.cJouNumber,
            this.cJouMol,
            this.cJouCount,
            this.cJouComment,
            this.cJouType});
            this.dgvJour.Location = new System.Drawing.Point(6, 45);
            this.dgvJour.MultiSelect = false;
            this.dgvJour.Name = "dgvJour";
            this.dgvJour.ReadOnly = true;
            this.dgvJour.RowHeadersVisible = false;
            this.dgvJour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJour.Size = new System.Drawing.Size(620, 278);
            this.dgvJour.TabIndex = 17;
            this.dgvJour.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvJour_ColumnWidthChanged);
            this.dgvJour.SelectionChanged += new System.EventHandler(this.dgvJour_SelectionChanged);
            // 
            // cJouDate
            // 
            this.cJouDate.DataPropertyName = "DateMovement";
            this.cJouDate.HeaderText = "Дата прихода/расхода";
            this.cJouDate.Name = "cJouDate";
            this.cJouDate.ReadOnly = true;
            // 
            // cJouNumber
            // 
            this.cJouNumber.DataPropertyName = "NumberBase";
            this.cJouNumber.HeaderText = "№ СЗ/ДО/ЗР";
            this.cJouNumber.Name = "cJouNumber";
            this.cJouNumber.ReadOnly = true;
            // 
            // cJouMol
            // 
            this.cJouMol.DataPropertyName = "cNameMol";
            this.cJouMol.HeaderText = "МОЛ";
            this.cJouMol.Name = "cJouMol";
            this.cJouMol.ReadOnly = true;
            // 
            // cJouCount
            // 
            this.cJouCount.DataPropertyName = "Count";
            this.cJouCount.HeaderText = "Количество";
            this.cJouCount.Name = "cJouCount";
            this.cJouCount.ReadOnly = true;
            // 
            // cJouComment
            // 
            this.cJouComment.DataPropertyName = "Comment";
            this.cJouComment.HeaderText = "Комментарий";
            this.cJouComment.Name = "cJouComment";
            this.cJouComment.ReadOnly = true;
            // 
            // cJouType
            // 
            this.cJouType.DataPropertyName = "nameType";
            this.cJouType.HeaderText = "Тип операции";
            this.cJouType.Name = "cJouType";
            this.cJouType.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Период с ";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(84, 12);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(102, 20);
            this.dtpStart.TabIndex = 2;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "по";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(214, 12);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(102, 20);
            this.dtpEnd.TabIndex = 2;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Остаток на дату";
            // 
            // dtpOstDate
            // 
            this.dtpOstDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOstDate.Location = new System.Drawing.Point(115, 38);
            this.dtpOstDate.Name = "dtpOstDate";
            this.dtpOstDate.Size = new System.Drawing.Size(102, 20);
            this.dtpOstDate.TabIndex = 2;
            // 
            // cmbTypeOperation
            // 
            this.cmbTypeOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeOperation.FormattingEnabled = true;
            this.cmbTypeOperation.Location = new System.Drawing.Point(1095, 19);
            this.cmbTypeOperation.Name = "cmbTypeOperation";
            this.cmbTypeOperation.Size = new System.Drawing.Size(121, 21);
            this.cmbTypeOperation.TabIndex = 16;
            this.cmbTypeOperation.SelectionChangeCommitted += new System.EventHandler(this.cmbTypeOperation_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1005, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Тип операции";
            // 
            // btUpdate
            // 
            this.btUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpdate.Image = global::hardWareViewer.Properties.Resources.reload_8055;
            this.btUpdate.Location = new System.Drawing.Point(1230, 12);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(32, 32);
            this.btUpdate.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btUpdate, "Обновить");
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // frmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 505);
            this.ControlBox = false;
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.cmbTypeOperation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpOstDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал движения расходных материалов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmList_FormClosing);
            this.Load += new System.EventHandler(this.frmList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOst)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvOst;
        private System.Windows.Forms.TextBox tbOstMol;
        private System.Windows.Forms.TextBox tbOstName;
        private System.Windows.Forms.TextBox tbJourComment;
        private System.Windows.Forms.TextBox tbJourMol;
        private System.Windows.Forms.TextBox tbJourNum;
        private System.Windows.Forms.DataGridView dgvJour;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btOstView;
        private System.Windows.Forms.Button btOstPrint;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chbNotActive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDateEdit;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpOstDate;
        private System.Windows.Forms.ComboBox cmbTypeOperation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMatMol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMatOstNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMatOstDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJouDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJouNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJouMol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJouCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJouComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJouType;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}