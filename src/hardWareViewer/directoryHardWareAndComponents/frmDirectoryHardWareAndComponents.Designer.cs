namespace hardWareViewer
{
    partial class frmDirectoryHardWareAndComponents
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rbHrdWare = new System.Windows.Forms.RadioButton();
            this.rbComponents = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTypeHardWare = new System.Windows.Forms.ComboBox();
            this.btOpenDirectionHardWare = new System.Windows.Forms.Button();
            this.tbDescriptionHardWare = new System.Windows.Forms.TextBox();
            this.dgvHardWare = new System.Windows.Forms.DataGridView();
            this.cNameHardWare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScanHardWare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pIsActive = new System.Windows.Forms.Panel();
            this.chbIsActiveHardWare = new System.Windows.Forms.CheckBox();
            this.tbNameHardWare = new System.Windows.Forms.TextBox();
            this.gbHardWare = new System.Windows.Forms.GroupBox();
            this.btDelHardWare = new System.Windows.Forms.Button();
            this.btSelectHardWare = new System.Windows.Forms.Button();
            this.btViewHardWare = new System.Windows.Forms.Button();
            this.btAddDocHardWare = new System.Windows.Forms.Button();
            this.btPrintHardWare = new System.Windows.Forms.Button();
            this.btAddHardWare = new System.Windows.Forms.Button();
            this.btEditHardWare = new System.Windows.Forms.Button();
            this.gbComponents = new System.Windows.Forms.GroupBox();
            this.btDelComponents = new System.Windows.Forms.Button();
            this.tbNameComponents = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btSelectComponents = new System.Windows.Forms.Button();
            this.cbTypeComponents = new System.Windows.Forms.ComboBox();
            this.btViewComponents = new System.Windows.Forms.Button();
            this.btOpenDirectionComponents = new System.Windows.Forms.Button();
            this.btAddDocComponents = new System.Windows.Forms.Button();
            this.tbDescriptionComponents = new System.Windows.Forms.TextBox();
            this.btPrintComponents = new System.Windows.Forms.Button();
            this.dgvComponents = new System.Windows.Forms.DataGridView();
            this.cNameComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScanComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btAddComponents = new System.Windows.Forms.Button();
            this.chbIsActiveComponents = new System.Windows.Forms.CheckBox();
            this.btEditComponents = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHardWare)).BeginInit();
            this.gbHardWare.SuspendLayout();
            this.gbComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // rbHrdWare
            // 
            this.rbHrdWare.AutoSize = true;
            this.rbHrdWare.Checked = true;
            this.rbHrdWare.Location = new System.Drawing.Point(12, 12);
            this.rbHrdWare.Name = "rbHrdWare";
            this.rbHrdWare.Size = new System.Drawing.Size(98, 17);
            this.rbHrdWare.TabIndex = 2;
            this.rbHrdWare.TabStop = true;
            this.rbHrdWare.Text = "Оборудование";
            this.rbHrdWare.UseVisualStyleBackColor = true;
            this.rbHrdWare.CheckedChanged += new System.EventHandler(this.rbHrdWare_CheckedChanged);
            // 
            // rbComponents
            // 
            this.rbComponents.AutoSize = true;
            this.rbComponents.Location = new System.Drawing.Point(386, 12);
            this.rbComponents.Name = "rbComponents";
            this.rbComponents.Size = new System.Drawing.Size(109, 17);
            this.rbComponents.TabIndex = 2;
            this.rbComponents.Text = "Комплектующие";
            this.rbComponents.UseVisualStyleBackColor = true;
            this.rbComponents.CheckedChanged += new System.EventHandler(this.rbHrdWare_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Тип оборудования:";
            // 
            // cbTypeHardWare
            // 
            this.cbTypeHardWare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeHardWare.FormattingEnabled = true;
            this.cbTypeHardWare.Location = new System.Drawing.Point(119, 13);
            this.cbTypeHardWare.Name = "cbTypeHardWare";
            this.cbTypeHardWare.Size = new System.Drawing.Size(171, 21);
            this.cbTypeHardWare.TabIndex = 4;
            this.cbTypeHardWare.SelectionChangeCommitted += new System.EventHandler(this.cbTypeHardWare_SelectionChangeCommitted);
            // 
            // btOpenDirectionHardWare
            // 
            this.btOpenDirectionHardWare.Location = new System.Drawing.Point(296, 12);
            this.btOpenDirectionHardWare.Name = "btOpenDirectionHardWare";
            this.btOpenDirectionHardWare.Size = new System.Drawing.Size(34, 23);
            this.btOpenDirectionHardWare.TabIndex = 5;
            this.btOpenDirectionHardWare.Text = "...";
            this.btOpenDirectionHardWare.UseVisualStyleBackColor = true;
            this.btOpenDirectionHardWare.Click += new System.EventHandler(this.btOpenDirectionHardWare_Click);
            // 
            // tbDescriptionHardWare
            // 
            this.tbDescriptionHardWare.Location = new System.Drawing.Point(13, 274);
            this.tbDescriptionHardWare.Multiline = true;
            this.tbDescriptionHardWare.Name = "tbDescriptionHardWare";
            this.tbDescriptionHardWare.ReadOnly = true;
            this.tbDescriptionHardWare.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDescriptionHardWare.Size = new System.Drawing.Size(317, 67);
            this.tbDescriptionHardWare.TabIndex = 6;
            // 
            // dgvHardWare
            // 
            this.dgvHardWare.AllowUserToAddRows = false;
            this.dgvHardWare.AllowUserToDeleteRows = false;
            this.dgvHardWare.AllowUserToResizeRows = false;
            this.dgvHardWare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHardWare.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHardWare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHardWare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNameHardWare,
            this.cScanHardWare});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHardWare.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHardWare.Location = new System.Drawing.Point(13, 65);
            this.dgvHardWare.MultiSelect = false;
            this.dgvHardWare.Name = "dgvHardWare";
            this.dgvHardWare.ReadOnly = true;
            this.dgvHardWare.RowHeadersVisible = false;
            this.dgvHardWare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHardWare.Size = new System.Drawing.Size(317, 176);
            this.dgvHardWare.TabIndex = 7;
            this.dgvHardWare.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHardWare_RowPostPaint);
            this.dgvHardWare.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvHardWare_RowPrePaint);
            this.dgvHardWare.SelectionChanged += new System.EventHandler(this.dgvHardWare_SelectionChanged);
            // 
            // cNameHardWare
            // 
            this.cNameHardWare.DataPropertyName = "cName";
            this.cNameHardWare.HeaderText = "Оборудование";
            this.cNameHardWare.Name = "cNameHardWare";
            this.cNameHardWare.ReadOnly = true;
            // 
            // cScanHardWare
            // 
            this.cScanHardWare.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cScanHardWare.DataPropertyName = "scaneCount";
            this.cScanHardWare.HeaderText = "Скан";
            this.cScanHardWare.MinimumWidth = 85;
            this.cScanHardWare.Name = "cScanHardWare";
            this.cScanHardWare.ReadOnly = true;
            this.cScanHardWare.Width = 85;
            // 
            // pIsActive
            // 
            this.pIsActive.BackColor = System.Drawing.Color.Moccasin;
            this.pIsActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pIsActive.Location = new System.Drawing.Point(13, 247);
            this.pIsActive.Name = "pIsActive";
            this.pIsActive.Size = new System.Drawing.Size(21, 21);
            this.pIsActive.TabIndex = 9;
            // 
            // chbIsActiveHardWare
            // 
            this.chbIsActiveHardWare.AutoSize = true;
            this.chbIsActiveHardWare.Location = new System.Drawing.Point(40, 249);
            this.chbIsActiveHardWare.Name = "chbIsActiveHardWare";
            this.chbIsActiveHardWare.Size = new System.Drawing.Size(107, 17);
            this.chbIsActiveHardWare.TabIndex = 8;
            this.chbIsActiveHardWare.Text = "недействующие";
            this.chbIsActiveHardWare.UseVisualStyleBackColor = true;
            this.chbIsActiveHardWare.CheckedChanged += new System.EventHandler(this.chbIsActiveHardWare_CheckedChanged);
            // 
            // tbNameHardWare
            // 
            this.tbNameHardWare.Location = new System.Drawing.Point(13, 39);
            this.tbNameHardWare.Name = "tbNameHardWare";
            this.tbNameHardWare.Size = new System.Drawing.Size(317, 20);
            this.tbNameHardWare.TabIndex = 14;
            this.tbNameHardWare.TextChanged += new System.EventHandler(this.tbNameHardWare_TextChanged);
            // 
            // gbHardWare
            // 
            this.gbHardWare.Controls.Add(this.btDelHardWare);
            this.gbHardWare.Controls.Add(this.tbNameHardWare);
            this.gbHardWare.Controls.Add(this.label1);
            this.gbHardWare.Controls.Add(this.btSelectHardWare);
            this.gbHardWare.Controls.Add(this.cbTypeHardWare);
            this.gbHardWare.Controls.Add(this.btViewHardWare);
            this.gbHardWare.Controls.Add(this.btOpenDirectionHardWare);
            this.gbHardWare.Controls.Add(this.btAddDocHardWare);
            this.gbHardWare.Controls.Add(this.tbDescriptionHardWare);
            this.gbHardWare.Controls.Add(this.btPrintHardWare);
            this.gbHardWare.Controls.Add(this.dgvHardWare);
            this.gbHardWare.Controls.Add(this.btAddHardWare);
            this.gbHardWare.Controls.Add(this.chbIsActiveHardWare);
            this.gbHardWare.Controls.Add(this.btEditHardWare);
            this.gbHardWare.Controls.Add(this.pIsActive);
            this.gbHardWare.Location = new System.Drawing.Point(12, 35);
            this.gbHardWare.Name = "gbHardWare";
            this.gbHardWare.Size = new System.Drawing.Size(349, 433);
            this.gbHardWare.TabIndex = 15;
            this.gbHardWare.TabStop = false;
            this.gbHardWare.Text = "Оборудование";
            // 
            // btDelHardWare
            // 
            this.btDelHardWare.Image = global::hardWareViewer.Properties.Resources.document_delete;
            this.btDelHardWare.Location = new System.Drawing.Point(298, 348);
            this.btDelHardWare.Name = "btDelHardWare";
            this.btDelHardWare.Size = new System.Drawing.Size(32, 32);
            this.btDelHardWare.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btDelHardWare, "Удалить");
            this.btDelHardWare.UseVisualStyleBackColor = true;
            this.btDelHardWare.Click += new System.EventHandler(this.btDelHardWare_Click);
            // 
            // btSelectHardWare
            // 
            this.btSelectHardWare.Image = global::hardWareViewer.Properties.Resources.Select;
            this.btSelectHardWare.Location = new System.Drawing.Point(13, 388);
            this.btSelectHardWare.Name = "btSelectHardWare";
            this.btSelectHardWare.Size = new System.Drawing.Size(32, 32);
            this.btSelectHardWare.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btSelectHardWare, "Выбрать");
            this.btSelectHardWare.UseVisualStyleBackColor = true;
            this.btSelectHardWare.Click += new System.EventHandler(this.btSelectHardWare_Click);
            // 
            // btViewHardWare
            // 
            this.btViewHardWare.Image = global::hardWareViewer.Properties.Resources.eye_quick_view;
            this.btViewHardWare.Location = new System.Drawing.Point(13, 347);
            this.btViewHardWare.Name = "btViewHardWare";
            this.btViewHardWare.Size = new System.Drawing.Size(32, 32);
            this.btViewHardWare.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btViewHardWare, "Просмотр");
            this.btViewHardWare.UseVisualStyleBackColor = true;
            this.btViewHardWare.Click += new System.EventHandler(this.btViewHardWare_Click);
            // 
            // btAddDocHardWare
            // 
            this.btAddDocHardWare.Image = global::hardWareViewer.Properties.Resources.folder_add;
            this.btAddDocHardWare.Location = new System.Drawing.Point(51, 347);
            this.btAddDocHardWare.Name = "btAddDocHardWare";
            this.btAddDocHardWare.Size = new System.Drawing.Size(32, 32);
            this.btAddDocHardWare.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btAddDocHardWare, "Добавить документ");
            this.btAddDocHardWare.UseVisualStyleBackColor = true;
            this.btAddDocHardWare.Click += new System.EventHandler(this.btAddDocHardWare_Click);
            // 
            // btPrintHardWare
            // 
            this.btPrintHardWare.Image = global::hardWareViewer.Properties.Resources.gtk_print_report;
            this.btPrintHardWare.Location = new System.Drawing.Point(184, 347);
            this.btPrintHardWare.Name = "btPrintHardWare";
            this.btPrintHardWare.Size = new System.Drawing.Size(32, 32);
            this.btPrintHardWare.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btPrintHardWare, "Печать");
            this.btPrintHardWare.UseVisualStyleBackColor = true;
            // 
            // btAddHardWare
            // 
            this.btAddHardWare.Image = global::hardWareViewer.Properties.Resources.document_add;
            this.btAddHardWare.Location = new System.Drawing.Point(222, 347);
            this.btAddHardWare.Name = "btAddHardWare";
            this.btAddHardWare.Size = new System.Drawing.Size(32, 32);
            this.btAddHardWare.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btAddHardWare, "Создать ");
            this.btAddHardWare.UseVisualStyleBackColor = true;
            this.btAddHardWare.Click += new System.EventHandler(this.btAddHardWare_Click);
            // 
            // btEditHardWare
            // 
            this.btEditHardWare.Image = global::hardWareViewer.Properties.Resources.edit;
            this.btEditHardWare.Location = new System.Drawing.Point(260, 347);
            this.btEditHardWare.Name = "btEditHardWare";
            this.btEditHardWare.Size = new System.Drawing.Size(32, 32);
            this.btEditHardWare.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btEditHardWare, "Редактировать");
            this.btEditHardWare.UseVisualStyleBackColor = true;
            this.btEditHardWare.Click += new System.EventHandler(this.btEditHardWare_Click);
            // 
            // gbComponents
            // 
            this.gbComponents.Controls.Add(this.btDelComponents);
            this.gbComponents.Controls.Add(this.tbNameComponents);
            this.gbComponents.Controls.Add(this.label2);
            this.gbComponents.Controls.Add(this.btSelectComponents);
            this.gbComponents.Controls.Add(this.cbTypeComponents);
            this.gbComponents.Controls.Add(this.btViewComponents);
            this.gbComponents.Controls.Add(this.btOpenDirectionComponents);
            this.gbComponents.Controls.Add(this.btAddDocComponents);
            this.gbComponents.Controls.Add(this.tbDescriptionComponents);
            this.gbComponents.Controls.Add(this.btPrintComponents);
            this.gbComponents.Controls.Add(this.dgvComponents);
            this.gbComponents.Controls.Add(this.btAddComponents);
            this.gbComponents.Controls.Add(this.chbIsActiveComponents);
            this.gbComponents.Controls.Add(this.btEditComponents);
            this.gbComponents.Controls.Add(this.panel1);
            this.gbComponents.Location = new System.Drawing.Point(386, 35);
            this.gbComponents.Name = "gbComponents";
            this.gbComponents.Size = new System.Drawing.Size(349, 433);
            this.gbComponents.TabIndex = 15;
            this.gbComponents.TabStop = false;
            this.gbComponents.Text = "Комплектующие";
            // 
            // btDelComponents
            // 
            this.btDelComponents.Image = global::hardWareViewer.Properties.Resources.document_delete;
            this.btDelComponents.Location = new System.Drawing.Point(298, 348);
            this.btDelComponents.Name = "btDelComponents";
            this.btDelComponents.Size = new System.Drawing.Size(32, 32);
            this.btDelComponents.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btDelComponents, "Удалить");
            this.btDelComponents.UseVisualStyleBackColor = true;
            this.btDelComponents.Click += new System.EventHandler(this.btDelComponents_Click);
            // 
            // tbNameComponents
            // 
            this.tbNameComponents.Location = new System.Drawing.Point(13, 39);
            this.tbNameComponents.Name = "tbNameComponents";
            this.tbNameComponents.Size = new System.Drawing.Size(317, 20);
            this.tbNameComponents.TabIndex = 14;
            this.tbNameComponents.TextChanged += new System.EventHandler(this.tbNameComponents_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тип комплектующих:";
            // 
            // btSelectComponents
            // 
            this.btSelectComponents.Image = global::hardWareViewer.Properties.Resources.Select;
            this.btSelectComponents.Location = new System.Drawing.Point(13, 388);
            this.btSelectComponents.Name = "btSelectComponents";
            this.btSelectComponents.Size = new System.Drawing.Size(32, 32);
            this.btSelectComponents.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btSelectComponents, "Выбрать");
            this.btSelectComponents.UseVisualStyleBackColor = true;
            this.btSelectComponents.Click += new System.EventHandler(this.btSelectComponents_Click);
            // 
            // cbTypeComponents
            // 
            this.cbTypeComponents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeComponents.FormattingEnabled = true;
            this.cbTypeComponents.Location = new System.Drawing.Point(127, 13);
            this.cbTypeComponents.Name = "cbTypeComponents";
            this.cbTypeComponents.Size = new System.Drawing.Size(163, 21);
            this.cbTypeComponents.TabIndex = 4;
            this.cbTypeComponents.SelectionChangeCommitted += new System.EventHandler(this.cbTypeComponents_SelectionChangeCommitted);
            // 
            // btViewComponents
            // 
            this.btViewComponents.Image = global::hardWareViewer.Properties.Resources.eye_quick_view;
            this.btViewComponents.Location = new System.Drawing.Point(13, 347);
            this.btViewComponents.Name = "btViewComponents";
            this.btViewComponents.Size = new System.Drawing.Size(32, 32);
            this.btViewComponents.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btViewComponents, "Просмотр");
            this.btViewComponents.UseVisualStyleBackColor = true;
            this.btViewComponents.Click += new System.EventHandler(this.btViewComponents_Click);
            // 
            // btOpenDirectionComponents
            // 
            this.btOpenDirectionComponents.Location = new System.Drawing.Point(296, 12);
            this.btOpenDirectionComponents.Name = "btOpenDirectionComponents";
            this.btOpenDirectionComponents.Size = new System.Drawing.Size(34, 23);
            this.btOpenDirectionComponents.TabIndex = 5;
            this.btOpenDirectionComponents.Text = "...";
            this.btOpenDirectionComponents.UseVisualStyleBackColor = true;
            this.btOpenDirectionComponents.Click += new System.EventHandler(this.btOpenDirectionComponents_Click);
            // 
            // btAddDocComponents
            // 
            this.btAddDocComponents.Image = global::hardWareViewer.Properties.Resources.folder_add;
            this.btAddDocComponents.Location = new System.Drawing.Point(51, 347);
            this.btAddDocComponents.Name = "btAddDocComponents";
            this.btAddDocComponents.Size = new System.Drawing.Size(32, 32);
            this.btAddDocComponents.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btAddDocComponents, "Добавить документ");
            this.btAddDocComponents.UseVisualStyleBackColor = true;
            this.btAddDocComponents.Click += new System.EventHandler(this.btAddDocComponents_Click);
            // 
            // tbDescriptionComponents
            // 
            this.tbDescriptionComponents.Location = new System.Drawing.Point(13, 274);
            this.tbDescriptionComponents.Multiline = true;
            this.tbDescriptionComponents.Name = "tbDescriptionComponents";
            this.tbDescriptionComponents.ReadOnly = true;
            this.tbDescriptionComponents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDescriptionComponents.Size = new System.Drawing.Size(317, 67);
            this.tbDescriptionComponents.TabIndex = 6;
            // 
            // btPrintComponents
            // 
            this.btPrintComponents.Image = global::hardWareViewer.Properties.Resources.gtk_print_report;
            this.btPrintComponents.Location = new System.Drawing.Point(184, 347);
            this.btPrintComponents.Name = "btPrintComponents";
            this.btPrintComponents.Size = new System.Drawing.Size(32, 32);
            this.btPrintComponents.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btPrintComponents, "Печать");
            this.btPrintComponents.UseVisualStyleBackColor = true;
            this.btPrintComponents.Click += new System.EventHandler(this.btPrintComponents_Click);
            // 
            // dgvComponents
            // 
            this.dgvComponents.AllowUserToAddRows = false;
            this.dgvComponents.AllowUserToDeleteRows = false;
            this.dgvComponents.AllowUserToResizeRows = false;
            this.dgvComponents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComponents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNameComp,
            this.cScanComp});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComponents.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvComponents.Location = new System.Drawing.Point(13, 65);
            this.dgvComponents.MultiSelect = false;
            this.dgvComponents.Name = "dgvComponents";
            this.dgvComponents.ReadOnly = true;
            this.dgvComponents.RowHeadersVisible = false;
            this.dgvComponents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComponents.Size = new System.Drawing.Size(317, 176);
            this.dgvComponents.TabIndex = 7;
            this.dgvComponents.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvComponents_RowPostPaint);
            this.dgvComponents.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvComponents_RowPrePaint);
            this.dgvComponents.SelectionChanged += new System.EventHandler(this.dgvComponents_SelectionChanged);
            // 
            // cNameComp
            // 
            this.cNameComp.DataPropertyName = "cName";
            this.cNameComp.HeaderText = "Комплектующие";
            this.cNameComp.Name = "cNameComp";
            this.cNameComp.ReadOnly = true;
            // 
            // cScanComp
            // 
            this.cScanComp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cScanComp.DataPropertyName = "scaneCount";
            this.cScanComp.HeaderText = "Скан";
            this.cScanComp.MinimumWidth = 85;
            this.cScanComp.Name = "cScanComp";
            this.cScanComp.ReadOnly = true;
            this.cScanComp.Width = 85;
            // 
            // btAddComponents
            // 
            this.btAddComponents.Image = global::hardWareViewer.Properties.Resources.document_add;
            this.btAddComponents.Location = new System.Drawing.Point(222, 347);
            this.btAddComponents.Name = "btAddComponents";
            this.btAddComponents.Size = new System.Drawing.Size(32, 32);
            this.btAddComponents.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btAddComponents, "Создать");
            this.btAddComponents.UseVisualStyleBackColor = true;
            this.btAddComponents.Click += new System.EventHandler(this.btAddComponents_Click);
            // 
            // chbIsActiveComponents
            // 
            this.chbIsActiveComponents.AutoSize = true;
            this.chbIsActiveComponents.Location = new System.Drawing.Point(40, 249);
            this.chbIsActiveComponents.Name = "chbIsActiveComponents";
            this.chbIsActiveComponents.Size = new System.Drawing.Size(107, 17);
            this.chbIsActiveComponents.TabIndex = 8;
            this.chbIsActiveComponents.Text = "недействующие";
            this.chbIsActiveComponents.UseVisualStyleBackColor = true;
            this.chbIsActiveComponents.CheckedChanged += new System.EventHandler(this.chbIsActiveComponents_CheckedChanged);
            // 
            // btEditComponents
            // 
            this.btEditComponents.Image = global::hardWareViewer.Properties.Resources.edit;
            this.btEditComponents.Location = new System.Drawing.Point(260, 347);
            this.btEditComponents.Name = "btEditComponents";
            this.btEditComponents.Size = new System.Drawing.Size(32, 32);
            this.btEditComponents.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btEditComponents, "Редактировать");
            this.btEditComponents.UseVisualStyleBackColor = true;
            this.btEditComponents.Click += new System.EventHandler(this.btEditComponents_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Moccasin;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(13, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(21, 21);
            this.panel1.TabIndex = 9;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(738, 435);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmDirectoryHardWareAndComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 479);
            this.ControlBox = false;
            this.Controls.Add(this.gbComponents);
            this.Controls.Add(this.gbHardWare);
            this.Controls.Add(this.rbComponents);
            this.Controls.Add(this.rbHrdWare);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDirectoryHardWareAndComponents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник оборудования и комплектующих";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHardWare)).EndInit();
            this.gbHardWare.ResumeLayout(false);
            this.gbHardWare.PerformLayout();
            this.gbComponents.ResumeLayout(false);
            this.gbComponents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.RadioButton rbHrdWare;
        private System.Windows.Forms.RadioButton rbComponents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTypeHardWare;
        private System.Windows.Forms.Button btOpenDirectionHardWare;
        private System.Windows.Forms.TextBox tbDescriptionHardWare;
        private System.Windows.Forms.DataGridView dgvHardWare;
        private System.Windows.Forms.Panel pIsActive;
        private System.Windows.Forms.CheckBox chbIsActiveHardWare;
        private System.Windows.Forms.Button btPrintHardWare;
        private System.Windows.Forms.Button btAddHardWare;
        private System.Windows.Forms.Button btEditHardWare;
        private System.Windows.Forms.Button btDelHardWare;
        private System.Windows.Forms.Button btAddDocHardWare;
        private System.Windows.Forms.Button btViewHardWare;
        private System.Windows.Forms.Button btSelectHardWare;
        private System.Windows.Forms.TextBox tbNameHardWare;
        private System.Windows.Forms.GroupBox gbHardWare;
        private System.Windows.Forms.GroupBox gbComponents;
        private System.Windows.Forms.Button btDelComponents;
        private System.Windows.Forms.TextBox tbNameComponents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSelectComponents;
        private System.Windows.Forms.ComboBox cbTypeComponents;
        private System.Windows.Forms.Button btOpenDirectionComponents;
        private System.Windows.Forms.TextBox tbDescriptionComponents;
        private System.Windows.Forms.DataGridView dgvComponents;
        private System.Windows.Forms.Button btAddComponents;
        private System.Windows.Forms.CheckBox chbIsActiveComponents;
        private System.Windows.Forms.Button btEditComponents;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btViewComponents;
        private System.Windows.Forms.Button btAddDocComponents;
        private System.Windows.Forms.Button btPrintComponents;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameHardWare;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScanHardWare;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameComp;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScanComp;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}