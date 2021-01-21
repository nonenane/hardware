namespace hardWareViewer.scaners
{
    partial class frmWahKey
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDeps = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.tbNum = new System.Windows.Forms.TextBox();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbNumberRoom = new System.Windows.Forms.ComboBox();
            this.tbKeyCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbDoc = new System.Windows.Forms.PictureBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDeps);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbFIO);
            this.groupBox1.Controls.Add(this.tbNum);
            this.groupBox1.Controls.Add(this.tbCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Шаг 1 - оформление сотрудника получающего сканер";
            // 
            // tbDeps
            // 
            this.tbDeps.BackColor = System.Drawing.Color.White;
            this.tbDeps.Location = new System.Drawing.Point(109, 101);
            this.tbDeps.Name = "tbDeps";
            this.tbDeps.ReadOnly = true;
            this.tbDeps.Size = new System.Drawing.Size(349, 20);
            this.tbDeps.TabIndex = 10;
            this.tbDeps.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Отдел";
            // 
            // tbFIO
            // 
            this.tbFIO.BackColor = System.Drawing.Color.White;
            this.tbFIO.Location = new System.Drawing.Point(109, 75);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.ReadOnly = true;
            this.tbFIO.Size = new System.Drawing.Size(349, 20);
            this.tbFIO.TabIndex = 2;
            this.tbFIO.TabStop = false;
            // 
            // tbNum
            // 
            this.tbNum.BackColor = System.Drawing.Color.White;
            this.tbNum.Location = new System.Drawing.Point(109, 49);
            this.tbNum.MaxLength = 5;
            this.tbNum.Name = "tbNum";
            this.tbNum.ReadOnly = true;
            this.tbNum.Size = new System.Drawing.Size(262, 20);
            this.tbNum.TabIndex = 1;
            // 
            // tbCode
            // 
            this.tbCode.BackColor = System.Drawing.Color.White;
            this.tbCode.Location = new System.Drawing.Point(109, 23);
            this.tbCode.MaxLength = 13;
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(262, 20);
            this.tbCode.TabIndex = 0;
            this.tbCode.TextChanged += new System.EventHandler(this.tbCode_TextChanged);
            this.tbCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCode_KeyPress);
            this.tbCode.Validated += new System.EventHandler(this.tbCode_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "ФИО сотрудника";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "№ бейджика";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Код сотрудника";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbNumberRoom);
            this.groupBox2.Controls.Add(this.tbKeyCode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 88);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Шаг 2 - оформление выдачи сканера";
            // 
            // cmbNumberRoom
            // 
            this.cmbNumberRoom.DisplayMember = "InventoryNumber";
            this.cmbNumberRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumberRoom.FormattingEnabled = true;
            this.cmbNumberRoom.Location = new System.Drawing.Point(109, 25);
            this.cmbNumberRoom.Name = "cmbNumberRoom";
            this.cmbNumberRoom.Size = new System.Drawing.Size(349, 21);
            this.cmbNumberRoom.TabIndex = 0;
            this.cmbNumberRoom.ValueMember = "id";
            this.cmbNumberRoom.SelectionChangeCommitted += new System.EventHandler(this.cmbNumberRoom_SelectionChangeCommitted);
            // 
            // tbKeyCode
            // 
            this.tbKeyCode.BackColor = System.Drawing.Color.White;
            this.tbKeyCode.Location = new System.Drawing.Point(109, 51);
            this.tbKeyCode.MaxLength = 13;
            this.tbKeyCode.Name = "tbKeyCode";
            this.tbKeyCode.Size = new System.Drawing.Size(349, 20);
            this.tbKeyCode.TabIndex = 0;
            this.tbKeyCode.TextChanged += new System.EventHandler(this.tbKeyCode_TextChanged);
            this.tbKeyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbKeyCode_KeyDown);
            this.tbKeyCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKeyCode_KeyPress);
            this.tbKeyCode.Validated += new System.EventHandler(this.tbKeyCode_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Код сканера:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Инв. номер:";
            // 
            // pbDoc
            // 
            this.pbDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDoc.Location = new System.Drawing.Point(507, 12);
            this.pbDoc.Name = "pbDoc";
            this.pbDoc.Size = new System.Drawing.Size(130, 132);
            this.pbDoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDoc.TabIndex = 1;
            this.pbDoc.TabStop = false;
            // 
            // btSave
            // 
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSave.Location = new System.Drawing.Point(507, 150);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(130, 88);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "Выдать ключ";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btExit
            // 
            this.btExit.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btExit.Location = new System.Drawing.Point(605, 244);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(32, 32);
            this.btExit.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btExit, "Выход");
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // frmWahKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 305);
            this.ControlBox = false;
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.pbDoc);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWahKey";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmWahKey";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWahKey_FormClosing);
            this.Load += new System.EventHandler(this.frmWahKey_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbDoc;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.TextBox tbKeyCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.TextBox tbNum;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbNumberRoom;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbDeps;
        private System.Windows.Forms.Label label6;
    }
}