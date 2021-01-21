namespace hardWareViewer
{
    partial class frmJournalActInventory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btUpdate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btAddDoc = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.pNotAll = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btDelDate = new System.Windows.Forms.Button();
            this.btAddDate = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvDateInventory = new System.Windows.Forms.DataGridView();
            this.cDateInventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbResponsibles = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.btCloseAct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // btUpdate
            // 
            this.btUpdate.Image = global::hardWareViewer.Properties.Resources.reload_8055;
            this.btUpdate.Location = new System.Drawing.Point(332, 6);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(32, 32);
            this.btUpdate.TabIndex = 31;
            this.btUpdate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Статус:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "по";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Период с";
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(483, 12);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(188, 21);
            this.cbStatus.TabIndex = 27;
            this.cbStatus.SelectionChangeCommitted += new System.EventHandler(this.cbStatus_SelectionChangeCommitted);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(216, 12);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(93, 20);
            this.dtpEnd.TabIndex = 25;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(80, 12);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(93, 20);
            this.dtpStart.TabIndex = 26;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // btAddDoc
            // 
            this.btAddDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddDoc.Enabled = false;
            this.btAddDoc.Image = global::hardWareViewer.Properties.Resources.folder_add;
            this.btAddDoc.Location = new System.Drawing.Point(800, 426);
            this.btAddDoc.Name = "btAddDoc";
            this.btAddDoc.Size = new System.Drawing.Size(32, 32);
            this.btAddDoc.TabIndex = 37;
            this.btAddDoc.UseVisualStyleBackColor = true;
            this.btAddDoc.Click += new System.EventHandler(this.btAddDoc_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(958, 464);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 36;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Enabled = false;
            this.btAdd.Image = global::hardWareViewer.Properties.Resources.document_add;
            this.btAdd.Location = new System.Drawing.Point(882, 426);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(32, 32);
            this.btAdd.TabIndex = 32;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Enabled = false;
            this.btEdit.Image = global::hardWareViewer.Properties.Resources.edit;
            this.btEdit.Location = new System.Drawing.Point(920, 426);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(32, 32);
            this.btEdit.TabIndex = 33;
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.Enabled = false;
            this.btDel.Image = global::hardWareViewer.Properties.Resources.document_delete;
            this.btDel.Location = new System.Drawing.Point(958, 426);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(32, 32);
            this.btDel.TabIndex = 34;
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // pNotAll
            // 
            this.pNotAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pNotAll.BackColor = System.Drawing.Color.Coral;
            this.pNotAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pNotAll.Location = new System.Drawing.Point(188, 433);
            this.pNotAll.Name = "pNotAll";
            this.pNotAll.Size = new System.Drawing.Size(19, 19);
            this.pNotAll.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 436);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "- незакрытый акт";
            // 
            // btDelDate
            // 
            this.btDelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelDate.Image = global::hardWareViewer.Properties.Resources.document_delete;
            this.btDelDate.Location = new System.Drawing.Point(141, 426);
            this.btDelDate.Name = "btDelDate";
            this.btDelDate.Size = new System.Drawing.Size(32, 32);
            this.btDelDate.TabIndex = 34;
            this.btDelDate.UseVisualStyleBackColor = true;
            this.btDelDate.Click += new System.EventHandler(this.btDelDate_Click);
            // 
            // btAddDate
            // 
            this.btAddDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddDate.Image = global::hardWareViewer.Properties.Resources.document_add;
            this.btAddDate.Location = new System.Drawing.Point(103, 426);
            this.btAddDate.Name = "btAddDate";
            this.btAddDate.Size = new System.Drawing.Size(32, 32);
            this.btAddDate.TabIndex = 32;
            this.btAddDate.UseVisualStyleBackColor = true;
            this.btAddDate.Click += new System.EventHandler(this.btAddDate_Click);
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
            this.cDate,
            this.cComment,
            this.cStatus,
            this.cScan});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Location = new System.Drawing.Point(188, 93);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(802, 321);
            this.dgvData.TabIndex = 40;
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDoubleClick);
            this.dgvData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvData_RowPostPaint);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
            // 
            // cNumber
            // 
            this.cNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cNumber.DataPropertyName = "id";
            this.cNumber.HeaderText = "№";
            this.cNumber.MinimumWidth = 110;
            this.cNumber.Name = "cNumber";
            this.cNumber.ReadOnly = true;
            this.cNumber.Width = 110;
            // 
            // cDate
            // 
            this.cDate.DataPropertyName = "Date";
            this.cDate.HeaderText = "Дата акта";
            this.cDate.Name = "cDate";
            this.cDate.ReadOnly = true;
            // 
            // cComment
            // 
            this.cComment.DataPropertyName = "Comment";
            this.cComment.HeaderText = "Комментарий";
            this.cComment.Name = "cComment";
            this.cComment.ReadOnly = true;
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
            this.cScan.DataPropertyName = "isScan";
            this.cScan.HeaderText = "Скан";
            this.cScan.Name = "cScan";
            this.cScan.ReadOnly = true;
            this.cScan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cScan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvDateInventory
            // 
            this.dgvDateInventory.AllowUserToAddRows = false;
            this.dgvDateInventory.AllowUserToDeleteRows = false;
            this.dgvDateInventory.AllowUserToResizeRows = false;
            this.dgvDateInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDateInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDateInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDateInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDateInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDateInventory});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDateInventory.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDateInventory.Location = new System.Drawing.Point(17, 93);
            this.dgvDateInventory.MultiSelect = false;
            this.dgvDateInventory.Name = "dgvDateInventory";
            this.dgvDateInventory.ReadOnly = true;
            this.dgvDateInventory.RowHeadersVisible = false;
            this.dgvDateInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDateInventory.Size = new System.Drawing.Size(156, 321);
            this.dgvDateInventory.TabIndex = 40;
            this.dgvDateInventory.CurrentCellChanged += new System.EventHandler(this.dgvDateInventory_CurrentCellChanged);
            // 
            // cDateInventory
            // 
            this.cDateInventory.DataPropertyName = "Date";
            this.cDateInventory.HeaderText = "Дата инв.";
            this.cDateInventory.Name = "cDateInventory";
            this.cDateInventory.ReadOnly = true;
            // 
            // cbResponsibles
            // 
            this.cbResponsibles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbResponsibles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResponsibles.FormattingEnabled = true;
            this.cbResponsibles.Location = new System.Drawing.Point(802, 39);
            this.cbResponsibles.Name = "cbResponsibles";
            this.cbResponsibles.Size = new System.Drawing.Size(188, 21);
            this.cbResponsibles.TabIndex = 27;
            this.cbResponsibles.SelectionChangeCommitted += new System.EventHandler(this.cbStatus_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(712, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Ответственный:";
            // 
            // cbLocation
            // 
            this.cbLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(802, 12);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(188, 21);
            this.cbLocation.TabIndex = 27;
            this.cbLocation.SelectionChangeCommitted += new System.EventHandler(this.cbStatus_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(703, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Местоположение:";
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(188, 67);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(110, 20);
            this.tbNumber.TabIndex = 41;
            this.tbNumber.TextChanged += new System.EventHandler(this.tbNumber_TextChanged);
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(469, 67);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(176, 20);
            this.tbComment.TabIndex = 41;
            this.tbComment.TextChanged += new System.EventHandler(this.tbNumber_TextChanged);
            // 
            // btCloseAct
            // 
            this.btCloseAct.Location = new System.Drawing.Point(682, 420);
            this.btCloseAct.Name = "btCloseAct";
            this.btCloseAct.Size = new System.Drawing.Size(98, 32);
            this.btCloseAct.TabIndex = 42;
            this.btCloseAct.Text = "Закрыть акт";
            this.btCloseAct.UseVisualStyleBackColor = true;
            this.btCloseAct.Visible = false;
            this.btCloseAct.Click += new System.EventHandler(this.btCloseAct_Click);
            // 
            // frmJournalActInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 539);
            this.ControlBox = false;
            this.Controls.Add(this.btCloseAct);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.dgvDateInventory);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.pNotAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btAddDoc);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btAddDate);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btDelDate);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.cbResponsibles);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmJournalActInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал актов инвентаризации";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btAddDoc;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Panel pNotAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btDelDate;
        private System.Windows.Forms.Button btAddDate;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridView dgvDateInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDateInventory;
        private System.Windows.Forms.ComboBox cbResponsibles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Button btCloseAct;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cScan;
    }
}