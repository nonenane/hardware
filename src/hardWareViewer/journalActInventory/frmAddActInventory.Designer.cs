namespace hardWareViewer
{
    partial class frmAddActInventory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateInventory = new System.Windows.Forms.DateTimePicker();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHardWare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cResponsible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btDel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.pNotAll = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gbEdit = new System.Windows.Forms.GroupBox();
            this.btStatus_3 = new System.Windows.Forms.Button();
            this.btStatus_1 = new System.Windows.Forms.Button();
            this.btStatus_0 = new System.Windows.Forms.Button();
            this.btStatus_2 = new System.Windows.Forms.Button();
            this.gbAdd = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpDateAct = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbResponsibles = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.gbEdit_cb = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gbEdit.SuspendLayout();
            this.gbAdd.SuspendLayout();
            this.gbEdit_cb.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Дата инв.:";
            // 
            // dtpDateInventory
            // 
            this.dtpDateInventory.Enabled = false;
            this.dtpDateInventory.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateInventory.Location = new System.Drawing.Point(85, 12);
            this.dtpDateInventory.Name = "dtpDateInventory";
            this.dtpDateInventory.Size = new System.Drawing.Size(93, 20);
            this.dtpDateInventory.TabIndex = 47;
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(106, 72);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(657, 54);
            this.tbComment.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Комментарий:";
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
            this.cHardWare,
            this.cResponsible,
            this.cLocation,
            this.cStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Location = new System.Drawing.Point(12, 146);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(751, 246);
            this.dgvData.TabIndex = 51;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            this.dgvData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellEndEdit);
            this.dgvData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvData_EditingControlShowing);
            this.dgvData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvData_RowPostPaint);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
            this.dgvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvData_KeyDown);
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
            this.cSelect.Width = 50;
            // 
            // cNum
            // 
            this.cNum.DataPropertyName = "invNumber";
            this.cNum.HeaderText = "Инв. №";
            this.cNum.Name = "cNum";
            // 
            // cEAN
            // 
            this.cEAN.DataPropertyName = "ean";
            this.cEAN.HeaderText = "EAN";
            this.cEAN.Name = "cEAN";
            this.cEAN.ReadOnly = true;
            // 
            // cHardWare
            // 
            this.cHardWare.DataPropertyName = "nameHardware";
            this.cHardWare.HeaderText = "Оборудование/Комплектующие";
            this.cHardWare.Name = "cHardWare";
            this.cHardWare.ReadOnly = true;
            // 
            // cResponsible
            // 
            this.cResponsible.DataPropertyName = "FIO";
            this.cResponsible.HeaderText = "Ответственный";
            this.cResponsible.Name = "cResponsible";
            this.cResponsible.ReadOnly = true;
            this.cResponsible.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cResponsible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cLocation
            // 
            this.cLocation.DataPropertyName = "nameLocation";
            this.cLocation.HeaderText = "Местоположение";
            this.cLocation.Name = "cLocation";
            this.cLocation.ReadOnly = true;
            this.cLocation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cLocation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cStatus
            // 
            this.cStatus.DataPropertyName = "nameStatus";
            this.cStatus.HeaderText = "Статус";
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.Image = global::hardWareViewer.Properties.Resources.document_delete;
            this.btDel.Location = new System.Drawing.Point(617, 445);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(32, 32);
            this.btDel.TabIndex = 54;
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::hardWareViewer.Properties.Resources.save_edit;
            this.btSave.Location = new System.Drawing.Point(693, 445);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 52;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(731, 445);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 53;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // pNotAll
            // 
            this.pNotAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pNotAll.BackColor = System.Drawing.Color.Coral;
            this.pNotAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pNotAll.Location = new System.Drawing.Point(19, 13);
            this.pNotAll.Name = "pNotAll";
            this.pNotAll.Size = new System.Drawing.Size(19, 19);
            this.pNotAll.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "- оборудование отсутствует";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(655, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 52;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(579, 445);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 32);
            this.button2.TabIndex = 54;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // gbEdit
            // 
            this.gbEdit.Controls.Add(this.btStatus_3);
            this.gbEdit.Controls.Add(this.btStatus_1);
            this.gbEdit.Controls.Add(this.btStatus_0);
            this.gbEdit.Controls.Add(this.btStatus_2);
            this.gbEdit.Controls.Add(this.label4);
            this.gbEdit.Controls.Add(this.pNotAll);
            this.gbEdit.Location = new System.Drawing.Point(12, 407);
            this.gbEdit.Name = "gbEdit";
            this.gbEdit.Size = new System.Drawing.Size(424, 70);
            this.gbEdit.TabIndex = 57;
            this.gbEdit.TabStop = false;
            this.gbEdit.Visible = false;
            // 
            // btStatus_3
            // 
            this.btStatus_3.Location = new System.Drawing.Point(233, 41);
            this.btStatus_3.Name = "btStatus_3";
            this.btStatus_3.Size = new System.Drawing.Size(173, 23);
            this.btStatus_3.TabIndex = 57;
            this.btStatus_3.Tag = "3";
            this.btStatus_3.Text = "закупленое за счёт МОЛ";
            this.btStatus_3.UseVisualStyleBackColor = true;
            this.btStatus_3.Click += new System.EventHandler(this.btStatus_Click);
            // 
            // btStatus_1
            // 
            this.btStatus_1.Location = new System.Drawing.Point(126, 41);
            this.btStatus_1.Name = "btStatus_1";
            this.btStatus_1.Size = new System.Drawing.Size(101, 23);
            this.btStatus_1.TabIndex = 57;
            this.btStatus_1.Tag = "1";
            this.btStatus_1.Text = "отсутствует";
            this.btStatus_1.UseVisualStyleBackColor = true;
            this.btStatus_1.Click += new System.EventHandler(this.btStatus_Click);
            // 
            // btStatus_0
            // 
            this.btStatus_0.Location = new System.Drawing.Point(19, 41);
            this.btStatus_0.Name = "btStatus_0";
            this.btStatus_0.Size = new System.Drawing.Size(101, 23);
            this.btStatus_0.TabIndex = 57;
            this.btStatus_0.Tag = "0";
            this.btStatus_0.Text = "на месте";
            this.btStatus_0.UseVisualStyleBackColor = true;
            this.btStatus_0.Click += new System.EventHandler(this.btStatus_Click);
            // 
            // btStatus_2
            // 
            this.btStatus_2.Location = new System.Drawing.Point(233, 13);
            this.btStatus_2.Name = "btStatus_2";
            this.btStatus_2.Size = new System.Drawing.Size(173, 23);
            this.btStatus_2.TabIndex = 57;
            this.btStatus_2.Tag = "2";
            this.btStatus_2.Text = "Получено в денежн. экв.";
            this.btStatus_2.UseVisualStyleBackColor = true;
            this.btStatus_2.Click += new System.EventHandler(this.btStatus_Click);
            // 
            // gbAdd
            // 
            this.gbAdd.Controls.Add(this.label2);
            this.gbAdd.Controls.Add(this.panel1);
            this.gbAdd.Location = new System.Drawing.Point(12, 407);
            this.gbAdd.Name = "gbAdd";
            this.gbAdd.Size = new System.Drawing.Size(424, 70);
            this.gbAdd.TabIndex = 57;
            this.gbAdd.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "- оборудование отсутствует";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Coral;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(19, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(19, 19);
            this.panel1.TabIndex = 56;
            // 
            // dtpDateAct
            // 
            this.dtpDateAct.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateAct.Location = new System.Drawing.Point(86, 38);
            this.dtpDateAct.Name = "dtpDateAct";
            this.dtpDateAct.Size = new System.Drawing.Size(93, 20);
            this.dtpDateAct.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Дата акта:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Ответственный:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Статус:";
            // 
            // cbResponsibles
            // 
            this.cbResponsibles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbResponsibles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResponsibles.FormattingEnabled = true;
            this.cbResponsibles.Location = new System.Drawing.Point(114, 38);
            this.cbResponsibles.Name = "cbResponsibles";
            this.cbResponsibles.Size = new System.Drawing.Size(235, 21);
            this.cbResponsibles.TabIndex = 58;
            this.cbResponsibles.SelectionChangeCommitted += new System.EventHandler(this.cbStatus_SelectionChangeCommitted);
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(114, 11);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(235, 21);
            this.cbStatus.TabIndex = 59;
            this.cbStatus.SelectionChangeCommitted += new System.EventHandler(this.cbStatus_SelectionChangeCommitted);
            // 
            // gbEdit_cb
            // 
            this.gbEdit_cb.Controls.Add(this.cbResponsibles);
            this.gbEdit_cb.Controls.Add(this.label6);
            this.gbEdit_cb.Controls.Add(this.cbStatus);
            this.gbEdit_cb.Controls.Add(this.label7);
            this.gbEdit_cb.Location = new System.Drawing.Point(408, 1);
            this.gbEdit_cb.Name = "gbEdit_cb";
            this.gbEdit_cb.Size = new System.Drawing.Size(355, 65);
            this.gbEdit_cb.TabIndex = 62;
            this.gbEdit_cb.TabStop = false;
            this.gbEdit_cb.Visible = false;
            // 
            // frmAddActInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 518);
            this.ControlBox = false;
            this.Controls.Add(this.gbEdit_cb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDateAct);
            this.Controls.Add(this.dtpDateInventory);
            this.Controls.Add(this.gbEdit);
            this.Controls.Add(this.gbAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddActInventory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddActInventory";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gbEdit.ResumeLayout(false);
            this.gbEdit.PerformLayout();
            this.gbAdd.ResumeLayout(false);
            this.gbAdd.PerformLayout();
            this.gbEdit_cb.ResumeLayout(false);
            this.gbEdit_cb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateInventory;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel pNotAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gbEdit;
        private System.Windows.Forms.GroupBox gbAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btStatus_3;
        private System.Windows.Forms.Button btStatus_1;
        private System.Windows.Forms.Button btStatus_0;
        private System.Windows.Forms.Button btStatus_2;
        private System.Windows.Forms.DateTimePicker dtpDateAct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbResponsibles;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.GroupBox gbEdit_cb;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHardWare;
        private System.Windows.Forms.DataGridViewTextBoxColumn cResponsible;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
    }
}