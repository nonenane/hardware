namespace hardWareViewer.journalMovementMaterial
{
    partial class frmFind
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
            this.cmbTypeBasic = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNumberBase = new System.Windows.Forms.TextBox();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.btFind = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // cmbTypeBasic
            // 
            this.cmbTypeBasic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeBasic.FormattingEnabled = true;
            this.cmbTypeBasic.Location = new System.Drawing.Point(122, 64);
            this.cmbTypeBasic.Name = "cmbTypeBasic";
            this.cmbTypeBasic.Size = new System.Drawing.Size(137, 21);
            this.cmbTypeBasic.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Источник поиска";
            // 
            // tbNumberBase
            // 
            this.tbNumberBase.Location = new System.Drawing.Point(122, 38);
            this.tbNumberBase.MaxLength = 250;
            this.tbNumberBase.Name = "tbNumberBase";
            this.tbNumberBase.Size = new System.Drawing.Size(134, 20);
            this.tbNumberBase.TabIndex = 24;
            this.tbNumberBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumberBase_KeyPress);
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(122, 12);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(80, 20);
            this.dtpYear.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Номер документа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Год документа";
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(229, 91);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 25;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btFind
            // 
            this.btFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btFind.Image = global::hardWareViewer.Properties.Resources.old_edit_find;
            this.btFind.Location = new System.Drawing.Point(191, 91);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(32, 32);
            this.btFind.TabIndex = 25;
            this.toolTip1.SetToolTip(this.btFind, "Поиск");
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // frmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 131);
            this.ControlBox = false;
            this.Controls.Add(this.btFind);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tbNumberBase);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTypeBasic);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFind";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите источник для поиска";
            this.Load += new System.EventHandler(this.frmFind_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTypeBasic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNumberBase;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}