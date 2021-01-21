namespace hardWareViewer.listHardware
{
    partial class frmListHwAdd
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
            this.rbHardware = new System.Windows.Forms.RadioButton();
            this.rbAdditional = new System.Windows.Forms.RadioButton();
            this.cbEquipment = new System.Windows.Forms.ComboBox();
            this.dsMemoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.memoReport = new hardWareViewer.reports.memoReport.memoReport();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbInventory = new System.Windows.Forms.TextBox();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.cbResponsible = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbMonthG = new System.Windows.Forms.TextBox();
            this.dtpGarant = new System.Windows.Forms.DateTimePicker();
            this.chbIsGarant = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbNumerSz = new System.Windows.Forms.TextBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsMemoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoReport)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbHardware
            // 
            this.rbHardware.AutoSize = true;
            this.rbHardware.Checked = true;
            this.rbHardware.Location = new System.Drawing.Point(12, 23);
            this.rbHardware.Name = "rbHardware";
            this.rbHardware.Size = new System.Drawing.Size(98, 17);
            this.rbHardware.TabIndex = 0;
            this.rbHardware.TabStop = true;
            this.rbHardware.Text = "Оборудование";
            this.rbHardware.UseVisualStyleBackColor = true;
            this.rbHardware.CheckedChanged += new System.EventHandler(this.rbHardware_CheckedChanged);
            // 
            // rbAdditional
            // 
            this.rbAdditional.AutoSize = true;
            this.rbAdditional.Location = new System.Drawing.Point(118, 23);
            this.rbAdditional.Name = "rbAdditional";
            this.rbAdditional.Size = new System.Drawing.Size(109, 17);
            this.rbAdditional.TabIndex = 1;
            this.rbAdditional.Text = "Комплектующие";
            this.rbAdditional.UseVisualStyleBackColor = true;
            // 
            // cbEquipment
            // 
            this.cbEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipment.FormattingEnabled = true;
            this.cbEquipment.Location = new System.Drawing.Point(190, 56);
            this.cbEquipment.Name = "cbEquipment";
            this.cbEquipment.Size = new System.Drawing.Size(314, 21);
            this.cbEquipment.TabIndex = 2;
            this.cbEquipment.SelectionChangeCommitted += new System.EventHandler(this.CbEquipment_SelectionChangeCommitted);
            // 
            // dsMemoBindingSource
            // 
            this.dsMemoBindingSource.DataMember = "dsMemo";
            this.dsMemoBindingSource.DataSource = this.memoReport;
            // 
            // memoReport
            // 
            this.memoReport.DataSetName = "memoReport";
            this.memoReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(190, 84);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(314, 20);
            this.tbName.TabIndex = 3;
            // 
            // tbInventory
            // 
            this.tbInventory.Location = new System.Drawing.Point(190, 110);
            this.tbInventory.Name = "tbInventory";
            this.tbInventory.ReadOnly = true;
            this.tbInventory.Size = new System.Drawing.Size(314, 20);
            this.tbInventory.TabIndex = 4;
            // 
            // cbLocation
            // 
            this.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(190, 136);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(314, 21);
            this.cbLocation.TabIndex = 5;
            // 
            // cbResponsible
            // 
            this.cbResponsible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResponsible.FormattingEnabled = true;
            this.cbResponsible.Location = new System.Drawing.Point(190, 163);
            this.cbResponsible.Name = "cbResponsible";
            this.cbResponsible.Size = new System.Drawing.Size(314, 21);
            this.cbResponsible.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Оборудование\\Комплектующее:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Наименование объекта:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Инв. номер:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Расположение:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ответственный:";
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(472, 327);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 56;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::hardWareViewer.Properties.Resources.save_edit;
            this.btSave.Location = new System.Drawing.Point(434, 327);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 57;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(190, 190);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(314, 39);
            this.tbComment.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Комментарий:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbMonthG);
            this.groupBox1.Controls.Add(this.dtpGarant);
            this.groupBox1.Controls.Add(this.chbIsGarant);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(95, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 71);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Гарантия";
            // 
            // tbMonthG
            // 
            this.tbMonthG.Location = new System.Drawing.Point(95, 41);
            this.tbMonthG.MaxLength = 3;
            this.tbMonthG.Name = "tbMonthG";
            this.tbMonthG.Size = new System.Drawing.Size(48, 20);
            this.tbMonthG.TabIndex = 61;
            this.tbMonthG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMonthG_KeyPress);
            this.tbMonthG.Validating += new System.ComponentModel.CancelEventHandler(this.tbMonthG_Validating);
            // 
            // dtpGarant
            // 
            this.dtpGarant.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGarant.Location = new System.Drawing.Point(89, 12);
            this.dtpGarant.Name = "dtpGarant";
            this.dtpGarant.Size = new System.Drawing.Size(84, 20);
            this.dtpGarant.TabIndex = 61;
            // 
            // chbIsGarant
            // 
            this.chbIsGarant.AutoSize = true;
            this.chbIsGarant.Location = new System.Drawing.Point(179, 15);
            this.chbIsGarant.Name = "chbIsGarant";
            this.chbIsGarant.Size = new System.Drawing.Size(15, 14);
            this.chbIsGarant.TabIndex = 61;
            this.chbIsGarant.UseVisualStyleBackColor = true;
            this.chbIsGarant.CheckedChanged += new System.EventHandler(this.chbIsGarant_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(143, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "месяцев";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Срок гарантии";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Дата покупки";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbNumerSz);
            this.groupBox2.Controls.Add(this.cmbYear);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(304, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 71);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            // 
            // tbNumerSz
            // 
            this.tbNumerSz.Location = new System.Drawing.Point(70, 42);
            this.tbNumerSz.MaxLength = 50;
            this.tbNumerSz.Name = "tbNumerSz";
            this.tbNumerSz.Size = new System.Drawing.Size(121, 20);
            this.tbNumerSz.TabIndex = 61;
            this.tbNumerSz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMonthG_KeyPress);
            this.tbNumerSz.Validating += new System.ComponentModel.CancelEventHandler(this.tbNumerSz_Validating);
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(70, 12);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 21);
            this.cmbYear.TabIndex = 62;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 61;
            this.label10.Text = "Год СЗ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 61;
            this.label9.Text = "Номер СЗ";
            // 
            // frmListHwAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 371);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbResponsible);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.tbInventory);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.cbEquipment);
            this.Controls.Add(this.rbAdditional);
            this.Controls.Add(this.rbHardware);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmListHwAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить оборудование";
            this.Load += new System.EventHandler(this.frmListHwAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsMemoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoReport)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbHardware;
        private System.Windows.Forms.RadioButton rbAdditional;
        private System.Windows.Forms.ComboBox cbEquipment;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbInventory;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.ComboBox cbResponsible;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.BindingSource dsMemoBindingSource;
        private reports.memoReport.memoReport memoReport;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpGarant;
        private System.Windows.Forms.CheckBox chbIsGarant;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbMonthG;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.TextBox tbNumerSz;
    }
}