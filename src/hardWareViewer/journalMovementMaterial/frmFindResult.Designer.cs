namespace hardWareViewer.journalMovementMaterial
{
    partial class frmFindResult
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cJouDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJouMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJouMol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJouCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJouComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cJouType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTypeOperation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.tbMol = new System.Windows.Forms.TextBox();
            this.tbMat = new System.Windows.Forms.TextBox();
            this.btPrint = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDateEdit = new System.Windows.Forms.TextBox();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
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
            this.cJouDate,
            this.cJouMaterial,
            this.cJouMol,
            this.cJouCount,
            this.cJouComment,
            this.cJouType});
            this.dgvData.Location = new System.Drawing.Point(12, 70);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(776, 316);
            this.dgvData.TabIndex = 18;
            this.dgvData.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvData_ColumnWidthChanged);
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            // 
            // cJouDate
            // 
            this.cJouDate.DataPropertyName = "DateMovement";
            this.cJouDate.HeaderText = "Дата прихода/расхода";
            this.cJouDate.Name = "cJouDate";
            this.cJouDate.ReadOnly = true;
            // 
            // cJouMaterial
            // 
            this.cJouMaterial.DataPropertyName = "nameMat";
            this.cJouMaterial.HeaderText = "Материал";
            this.cJouMaterial.Name = "cJouMaterial";
            this.cJouMaterial.ReadOnly = true;
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
            // cmbTypeOperation
            // 
            this.cmbTypeOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeOperation.FormattingEnabled = true;
            this.cmbTypeOperation.Location = new System.Drawing.Point(667, 12);
            this.cmbTypeOperation.Name = "cmbTypeOperation";
            this.cmbTypeOperation.Size = new System.Drawing.Size(121, 21);
            this.cmbTypeOperation.TabIndex = 20;
            this.cmbTypeOperation.SelectionChangeCommitted += new System.EventHandler(this.cmbTypeOperation_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(577, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Тип операции";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(236, 44);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(100, 20);
            this.tbComment.TabIndex = 21;
            this.tbComment.TextChanged += new System.EventHandler(this.tbMat_TextChanged);
            // 
            // tbMol
            // 
            this.tbMol.Location = new System.Drawing.Point(130, 44);
            this.tbMol.Name = "tbMol";
            this.tbMol.Size = new System.Drawing.Size(100, 20);
            this.tbMol.TabIndex = 22;
            this.tbMol.TextChanged += new System.EventHandler(this.tbMat_TextChanged);
            // 
            // tbMat
            // 
            this.tbMat.Location = new System.Drawing.Point(12, 44);
            this.tbMat.Name = "tbMat";
            this.tbMat.Size = new System.Drawing.Size(100, 20);
            this.tbMat.TabIndex = 23;
            this.tbMat.TextChanged += new System.EventHandler(this.tbMat_TextChanged);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Image = global::hardWareViewer.Properties.Resources.printer;
            this.btPrint.Location = new System.Drawing.Point(718, 406);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(32, 32);
            this.btPrint.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btPrint, "Печать");
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btOstView_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(756, 406);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 25;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Дата редактирования";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Редактировал";
            // 
            // tbDateEdit
            // 
            this.tbDateEdit.Location = new System.Drawing.Point(139, 418);
            this.tbDateEdit.Name = "tbDateEdit";
            this.tbDateEdit.ReadOnly = true;
            this.tbDateEdit.Size = new System.Drawing.Size(181, 20);
            this.tbDateEdit.TabIndex = 26;
            // 
            // tbFIO
            // 
            this.tbFIO.Location = new System.Drawing.Point(139, 392);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.ReadOnly = true;
            this.tbFIO.Size = new System.Drawing.Size(181, 20);
            this.tbFIO.TabIndex = 27;
            // 
            // frmFindResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 446);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDateEdit);
            this.Controls.Add(this.tbFIO);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.tbMol);
            this.Controls.Add(this.tbMat);
            this.Controls.Add(this.cmbTypeOperation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindResult";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFindResult";
            this.Load += new System.EventHandler(this.frmFindResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ComboBox cmbTypeOperation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.TextBox tbMol;
        private System.Windows.Forms.TextBox tbMat;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDateEdit;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJouDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJouMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJouMol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJouCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJouComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cJouType;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}