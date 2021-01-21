namespace hardWareViewer
{
    partial class frmDirectoryResponsible
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
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.dgvPersonal = new System.Windows.Forms.DataGridView();
            this.cNamePersonal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNamePersonal = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbNameMOP = new System.Windows.Forms.TextBox();
            this.dgvMOP = new System.Windows.Forms.DataGridView();
            this.cNameMOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btIn = new System.Windows.Forms.Button();
            this.btUnder = new System.Windows.Forms.Button();
            this.chbIsActiveHardWare = new System.Windows.Forms.CheckBox();
            this.pIsActive = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMOP)).BeginInit();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::hardWareViewer.Properties.Resources.save_edit;
            this.btSave.Location = new System.Drawing.Point(631, 438);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btSave, "Сохранить");
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(669, 438);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.AllowUserToAddRows = false;
            this.dgvPersonal.AllowUserToDeleteRows = false;
            this.dgvPersonal.AllowUserToResizeRows = false;
            this.dgvPersonal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNamePersonal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPersonal.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPersonal.Location = new System.Drawing.Point(6, 54);
            this.dgvPersonal.MultiSelect = false;
            this.dgvPersonal.Name = "dgvPersonal";
            this.dgvPersonal.ReadOnly = true;
            this.dgvPersonal.RowHeadersVisible = false;
            this.dgvPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonal.Size = new System.Drawing.Size(263, 347);
            this.dgvPersonal.TabIndex = 8;
            // 
            // cNamePersonal
            // 
            this.cNamePersonal.DataPropertyName = "FIO";
            this.cNamePersonal.HeaderText = "ФИО сотрудника";
            this.cNamePersonal.Name = "cNamePersonal";
            this.cNamePersonal.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbNamePersonal);
            this.groupBox1.Controls.Add(this.dgvPersonal);
            this.groupBox1.Location = new System.Drawing.Point(426, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 407);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ПО \"Персонал\"";
            // 
            // tbNamePersonal
            // 
            this.tbNamePersonal.Location = new System.Drawing.Point(6, 28);
            this.tbNamePersonal.Name = "tbNamePersonal";
            this.tbNamePersonal.Size = new System.Drawing.Size(263, 20);
            this.tbNamePersonal.TabIndex = 9;
            this.tbNamePersonal.TextChanged += new System.EventHandler(this.tbNamePersonal_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbNameMOP);
            this.groupBox2.Controls.Add(this.dgvMOP);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 407);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Материально-ответственные лица";
            // 
            // tbNameMOP
            // 
            this.tbNameMOP.Location = new System.Drawing.Point(6, 28);
            this.tbNameMOP.Name = "tbNameMOP";
            this.tbNameMOP.Size = new System.Drawing.Size(263, 20);
            this.tbNameMOP.TabIndex = 9;
            this.tbNameMOP.TextChanged += new System.EventHandler(this.tbNameMOP_TextChanged);
            // 
            // dgvMOP
            // 
            this.dgvMOP.AllowUserToAddRows = false;
            this.dgvMOP.AllowUserToDeleteRows = false;
            this.dgvMOP.AllowUserToResizeRows = false;
            this.dgvMOP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMOP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMOP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNameMOP});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMOP.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMOP.Location = new System.Drawing.Point(6, 54);
            this.dgvMOP.MultiSelect = false;
            this.dgvMOP.Name = "dgvMOP";
            this.dgvMOP.ReadOnly = true;
            this.dgvMOP.RowHeadersVisible = false;
            this.dgvMOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMOP.Size = new System.Drawing.Size(263, 347);
            this.dgvMOP.TabIndex = 8;
            this.dgvMOP.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMOP_RowPostPaint);
            this.dgvMOP.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvMOP_RowPrePaint);
            // 
            // cNameMOP
            // 
            this.cNameMOP.DataPropertyName = "FIO";
            this.cNameMOP.HeaderText = "ФИО сотрудника";
            this.cNameMOP.Name = "cNameMOP";
            this.cNameMOP.ReadOnly = true;
            // 
            // btIn
            // 
            this.btIn.Location = new System.Drawing.Point(319, 319);
            this.btIn.Name = "btIn";
            this.btIn.Size = new System.Drawing.Size(75, 23);
            this.btIn.TabIndex = 10;
            this.btIn.Text = "<-";
            this.btIn.UseVisualStyleBackColor = true;
            this.btIn.Click += new System.EventHandler(this.btIn_Click);
            // 
            // btUnder
            // 
            this.btUnder.Location = new System.Drawing.Point(319, 149);
            this.btUnder.Name = "btUnder";
            this.btUnder.Size = new System.Drawing.Size(75, 23);
            this.btUnder.TabIndex = 10;
            this.btUnder.Text = "->";
            this.btUnder.UseVisualStyleBackColor = true;
            this.btUnder.Click += new System.EventHandler(this.btUnder_Click);
            // 
            // chbIsActiveHardWare
            // 
            this.chbIsActiveHardWare.AutoSize = true;
            this.chbIsActiveHardWare.Location = new System.Drawing.Point(45, 438);
            this.chbIsActiveHardWare.Name = "chbIsActiveHardWare";
            this.chbIsActiveHardWare.Size = new System.Drawing.Size(81, 17);
            this.chbIsActiveHardWare.TabIndex = 11;
            this.chbIsActiveHardWare.Text = "уволенные";
            this.chbIsActiveHardWare.UseVisualStyleBackColor = true;
            this.chbIsActiveHardWare.CheckedChanged += new System.EventHandler(this.chbIsActiveHardWare_CheckedChanged);
            // 
            // pIsActive
            // 
            this.pIsActive.BackColor = System.Drawing.Color.Moccasin;
            this.pIsActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pIsActive.Location = new System.Drawing.Point(18, 436);
            this.pIsActive.Name = "pIsActive";
            this.pIsActive.Size = new System.Drawing.Size(21, 21);
            this.pIsActive.TabIndex = 12;
            // 
            // frmDirectoryResponsible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 511);
            this.ControlBox = false;
            this.Controls.Add(this.chbIsActiveHardWare);
            this.Controls.Add(this.pIsActive);
            this.Controls.Add(this.btUnder);
            this.Controls.Add(this.btIn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDirectoryResponsible";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник материально ответственных лиц";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMOP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DataGridView dgvPersonal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbNamePersonal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbNameMOP;
        private System.Windows.Forms.DataGridView dgvMOP;
        private System.Windows.Forms.Button btIn;
        private System.Windows.Forms.Button btUnder;
        private System.Windows.Forms.CheckBox chbIsActiveHardWare;
        private System.Windows.Forms.Panel pIsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNamePersonal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameMOP;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}