namespace hardWareViewer.MovementMaterial
{
    partial class frmAddMovementMaterial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbTypeOperation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTypeBasic = new System.Windows.Forms.ComboBox();
            this.tbNumberBase = new System.Windows.Forms.TextBox();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFilterComment = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cMol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.tbFilterName = new System.Windows.Forms.TextBox();
            this.tbFilterMol = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::hardWareViewer.Properties.Resources.save_edit;
            this.btSave.Location = new System.Drawing.Point(492, 367);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btSave, "Сохранить");
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(532, 367);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Дата операции";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(102, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(92, 20);
            this.dtpDate.TabIndex = 13;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // cmbTypeOperation
            // 
            this.cmbTypeOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeOperation.FormattingEnabled = true;
            this.cmbTypeOperation.Location = new System.Drawing.Point(102, 47);
            this.cmbTypeOperation.Name = "cmbTypeOperation";
            this.cmbTypeOperation.Size = new System.Drawing.Size(121, 21);
            this.cmbTypeOperation.TabIndex = 14;
            this.cmbTypeOperation.SelectionChangeCommitted += new System.EventHandler(this.cmbTypeOperation_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Тип операции";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTypeBasic);
            this.groupBox1.Controls.Add(this.tbNumberBase);
            this.groupBox1.Controls.Add(this.dtpYear);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(294, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 86);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "На основании";
            // 
            // cmbTypeBasic
            // 
            this.cmbTypeBasic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeBasic.FormattingEnabled = true;
            this.cmbTypeBasic.Location = new System.Drawing.Point(129, 59);
            this.cmbTypeBasic.Name = "cmbTypeBasic";
            this.cmbTypeBasic.Size = new System.Drawing.Size(137, 21);
            this.cmbTypeBasic.TabIndex = 18;
            this.cmbTypeBasic.SelectionChangeCommitted += new System.EventHandler(this.cmbTypeOperation_SelectionChangeCommitted);
            // 
            // tbNumberBase
            // 
            this.tbNumberBase.Location = new System.Drawing.Point(129, 35);
            this.tbNumberBase.MaxLength = 250;
            this.tbNumberBase.Name = "tbNumberBase";
            this.tbNumberBase.Size = new System.Drawing.Size(134, 20);
            this.tbNumberBase.TabIndex = 14;
            this.tbNumberBase.TextChanged += new System.EventHandler(this.tbNumberBase_TextChanged);
            this.tbNumberBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumberBase_KeyPress);
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(20, 35);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(80, 20);
            this.dtpYear.TabIndex = 13;
            this.dtpYear.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Признак";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Номер документа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Год документа";
            // 
            // tbFilterComment
            // 
            this.tbFilterComment.Location = new System.Drawing.Point(294, 104);
            this.tbFilterComment.Name = "tbFilterComment";
            this.tbFilterComment.Size = new System.Drawing.Size(100, 20);
            this.tbFilterComment.TabIndex = 14;
            this.tbFilterComment.TextChanged += new System.EventHandler(this.tbFilterMol_TextChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cMol,
            this.cName,
            this.cCount,
            this.cComment});
            this.dgvData.Location = new System.Drawing.Point(12, 130);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(554, 150);
            this.dgvData.TabIndex = 16;
            this.dgvData.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvData_ColumnWidthChanged);
            // 
            // cMol
            // 
            this.cMol.DataPropertyName = "cName";
            this.cMol.HeaderText = "МОЛ";
            this.cMol.Name = "cMol";
            this.cMol.ReadOnly = true;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "nameMaterial";
            this.cName.HeaderText = "Наименование";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cCount
            // 
            this.cCount.DataPropertyName = "Count";
            this.cCount.HeaderText = "Количество";
            this.cCount.Name = "cCount";
            this.cCount.ReadOnly = true;
            // 
            // cComment
            // 
            this.cComment.DataPropertyName = "Comment";
            this.cComment.HeaderText = "Комментарий";
            this.cComment.Name = "cComment";
            this.cComment.ReadOnly = true;
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(102, 293);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(343, 104);
            this.tbComment.TabIndex = 14;
            this.tbComment.TextChanged += new System.EventHandler(this.tbNumberBase_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Комментарий";
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = global::hardWareViewer.Properties.Resources.document_add;
            this.btAdd.Location = new System.Drawing.Point(458, 293);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(32, 32);
            this.btAdd.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btAdd, "Добавить");
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Image = global::hardWareViewer.Properties.Resources.edit;
            this.btEdit.Location = new System.Drawing.Point(496, 293);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(32, 32);
            this.btEdit.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btEdit, "Редактировать");
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.Image = global::hardWareViewer.Properties.Resources.document_delete;
            this.btDel.Location = new System.Drawing.Point(534, 293);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(32, 32);
            this.btDel.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btDel, "Удалить");
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // tbFilterName
            // 
            this.tbFilterName.Location = new System.Drawing.Point(188, 104);
            this.tbFilterName.Name = "tbFilterName";
            this.tbFilterName.Size = new System.Drawing.Size(100, 20);
            this.tbFilterName.TabIndex = 14;
            this.tbFilterName.TextChanged += new System.EventHandler(this.tbFilterMol_TextChanged);
            // 
            // tbFilterMol
            // 
            this.tbFilterMol.Location = new System.Drawing.Point(82, 104);
            this.tbFilterMol.Name = "tbFilterMol";
            this.tbFilterMol.Size = new System.Drawing.Size(100, 20);
            this.tbFilterMol.TabIndex = 14;
            this.tbFilterMol.TextChanged += new System.EventHandler(this.tbFilterMol_TextChanged);
            // 
            // frmAddMovementMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 411);
            this.ControlBox = false;
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbTypeOperation);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.tbFilterMol);
            this.Controls.Add(this.tbFilterName);
            this.Controls.Add(this.tbFilterComment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddMovementMaterial";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddMovementMaterial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddMovementMaterial_FormClosing);
            this.Load += new System.EventHandler(this.frmAddMovementMaterial_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbTypeOperation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbNumberBase;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFilterComment;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.TextBox tbFilterName;
        private System.Windows.Forms.TextBox tbFilterMol;
        private System.Windows.Forms.ComboBox cmbTypeBasic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cComment;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}