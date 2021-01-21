namespace hardWareViewer
{
    partial class frmAddHardWare
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbIsActive = new System.Windows.Forms.CheckBox();
            this.cbNotComponents = new System.Windows.Forms.CheckBox();
            this.gbComponents = new System.Windows.Forms.GroupBox();
            this.btDelComponents = new System.Windows.Forms.Button();
            this.btAddComponents = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.btEditComponents = new System.Windows.Forms.Button();
            this.btAddDoc = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEditDate = new System.Windows.Forms.TextBox();
            this.tbAddDate = new System.Windows.Forms.TextBox();
            this.tbEditFIO = new System.Windows.Forms.TextBox();
            this.tbAddFIO = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Наименование:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(105, 39);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(445, 20);
            this.tbName.TabIndex = 12;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Описание:";
            // 
            // chbIsActive
            // 
            this.chbIsActive.AutoSize = true;
            this.chbIsActive.Checked = true;
            this.chbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIsActive.Enabled = false;
            this.chbIsActive.Location = new System.Drawing.Point(105, 156);
            this.chbIsActive.Name = "chbIsActive";
            this.chbIsActive.Size = new System.Drawing.Size(104, 17);
            this.chbIsActive.TabIndex = 15;
            this.chbIsActive.Text = " - действующие";
            this.chbIsActive.UseVisualStyleBackColor = true;
            // 
            // cbNotComponents
            // 
            this.cbNotComponents.AutoSize = true;
            this.cbNotComponents.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbNotComponents.Checked = true;
            this.cbNotComponents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNotComponents.Location = new System.Drawing.Point(16, 181);
            this.cbNotComponents.Name = "cbNotComponents";
            this.cbNotComponents.Size = new System.Drawing.Size(130, 17);
            this.cbNotComponents.TabIndex = 15;
            this.cbNotComponents.Text = "Без комплектующих";
            this.cbNotComponents.UseVisualStyleBackColor = true;
            this.cbNotComponents.CheckedChanged += new System.EventHandler(this.cbNotComponents_CheckedChanged);
            // 
            // gbComponents
            // 
            this.gbComponents.Controls.Add(this.btDelComponents);
            this.gbComponents.Controls.Add(this.btAddComponents);
            this.gbComponents.Controls.Add(this.dgvData);
            this.gbComponents.Controls.Add(this.checkBox2);
            this.gbComponents.Controls.Add(this.btEditComponents);
            this.gbComponents.Location = new System.Drawing.Point(16, 204);
            this.gbComponents.Name = "gbComponents";
            this.gbComponents.Size = new System.Drawing.Size(534, 238);
            this.gbComponents.TabIndex = 17;
            this.gbComponents.TabStop = false;
            this.gbComponents.Text = "Комплектующие оборудования";
            // 
            // btDelComponents
            // 
            this.btDelComponents.Image = global::hardWareViewer.Properties.Resources.document_delete;
            this.btDelComponents.Location = new System.Drawing.Point(492, 200);
            this.btDelComponents.Name = "btDelComponents";
            this.btDelComponents.Size = new System.Drawing.Size(32, 32);
            this.btDelComponents.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btDelComponents, "Удалить");
            this.btDelComponents.UseVisualStyleBackColor = true;
            this.btDelComponents.Click += new System.EventHandler(this.btDelComponents_Click);
            // 
            // btAddComponents
            // 
            this.btAddComponents.Image = global::hardWareViewer.Properties.Resources.document_add;
            this.btAddComponents.Location = new System.Drawing.Point(416, 200);
            this.btAddComponents.Name = "btAddComponents";
            this.btAddComponents.Size = new System.Drawing.Size(32, 32);
            this.btAddComponents.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btAddComponents, "Добавить");
            this.btAddComponents.UseVisualStyleBackColor = true;
            this.btAddComponents.Click += new System.EventHandler(this.btAddComponents_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
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
            this.cName,
            this.cScan});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Location = new System.Drawing.Point(6, 23);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(518, 170);
            this.dgvData.TabIndex = 0;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "cName";
            this.cName.HeaderText = "Комплектующие";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cScan
            // 
            this.cScan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cScan.HeaderText = "Скан";
            this.cScan.MinimumWidth = 85;
            this.cScan.Name = "cScan";
            this.cScan.ReadOnly = true;
            this.cScan.Visible = false;
            this.cScan.Width = 85;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(6, 208);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 17);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = " - действующие";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // btEditComponents
            // 
            this.btEditComponents.Image = global::hardWareViewer.Properties.Resources.edit;
            this.btEditComponents.Location = new System.Drawing.Point(454, 200);
            this.btEditComponents.Name = "btEditComponents";
            this.btEditComponents.Size = new System.Drawing.Size(32, 32);
            this.btEditComponents.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btEditComponents, "Редактировать");
            this.btEditComponents.UseVisualStyleBackColor = true;
            this.btEditComponents.Visible = false;
            this.btEditComponents.Click += new System.EventHandler(this.btEditComponents_Click);
            // 
            // btAddDoc
            // 
            this.btAddDoc.Image = global::hardWareViewer.Properties.Resources.folder_add;
            this.btAddDoc.Location = new System.Drawing.Point(518, 147);
            this.btAddDoc.Name = "btAddDoc";
            this.btAddDoc.Size = new System.Drawing.Size(32, 32);
            this.btAddDoc.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btAddDoc, "Добавить документ");
            this.btAddDoc.UseVisualStyleBackColor = true;
            this.btAddDoc.Visible = false;
            this.btAddDoc.Click += new System.EventHandler(this.btAddDoc_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::hardWareViewer.Properties.Resources.save_edit;
            this.btSave.Location = new System.Drawing.Point(483, 474);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btSave, "Сохранить");
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(521, 474);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 493);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Дата ред.:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 467);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Редакт.:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 493);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Дата доб.:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 467);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Добавил:";
            // 
            // tbEditDate
            // 
            this.tbEditDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbEditDate.Location = new System.Drawing.Point(296, 489);
            this.tbEditDate.Name = "tbEditDate";
            this.tbEditDate.ReadOnly = true;
            this.tbEditDate.Size = new System.Drawing.Size(165, 20);
            this.tbEditDate.TabIndex = 31;
            // 
            // tbAddDate
            // 
            this.tbAddDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbAddDate.Location = new System.Drawing.Point(69, 489);
            this.tbAddDate.Name = "tbAddDate";
            this.tbAddDate.ReadOnly = true;
            this.tbAddDate.Size = new System.Drawing.Size(152, 20);
            this.tbAddDate.TabIndex = 32;
            // 
            // tbEditFIO
            // 
            this.tbEditFIO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbEditFIO.Location = new System.Drawing.Point(296, 463);
            this.tbEditFIO.Name = "tbEditFIO";
            this.tbEditFIO.ReadOnly = true;
            this.tbEditFIO.Size = new System.Drawing.Size(165, 20);
            this.tbEditFIO.TabIndex = 33;
            // 
            // tbAddFIO
            // 
            this.tbAddFIO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbAddFIO.Location = new System.Drawing.Point(69, 463);
            this.tbAddFIO.Name = "tbAddFIO";
            this.tbAddFIO.ReadOnly = true;
            this.tbAddFIO.Size = new System.Drawing.Size(152, 20);
            this.tbAddFIO.TabIndex = 34;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(105, 68);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDescription.Size = new System.Drawing.Size(445, 73);
            this.tbDescription.TabIndex = 39;
            this.tbDescription.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(105, 12);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(444, 21);
            this.cbType.TabIndex = 41;
            this.cbType.SelectionChangeCommitted += new System.EventHandler(this.cbType_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Тип оборуд.:";
            // 
            // frmAddHardWare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 514);
            this.ControlBox = false;
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gbComponents);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btAddDoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbNotComponents);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chbIsActive);
            this.Controls.Add(this.tbEditDate);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tbAddDate);
            this.Controls.Add(this.tbEditFIO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAddFIO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddHardWare";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddHardWare_FormClosing);
            this.gbComponents.ResumeLayout(false);
            this.gbComponents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbIsActive;
        private System.Windows.Forms.Button btAddDoc;
        private System.Windows.Forms.CheckBox cbNotComponents;
        private System.Windows.Forms.GroupBox gbComponents;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btDelComponents;
        private System.Windows.Forms.Button btAddComponents;
        private System.Windows.Forms.Button btEditComponents;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEditDate;
        private System.Windows.Forms.TextBox tbAddDate;
        private System.Windows.Forms.TextBox tbEditFIO;
        private System.Windows.Forms.TextBox tbAddFIO;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cScan;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}