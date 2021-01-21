namespace hardWareViewer.scaners
{
    partial class frmListScaners
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
            this.tbNumRoom = new System.Windows.Forms.TextBox();
            this.dgvScaner = new System.Windows.Forms.DataGridView();
            this.cInv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFIODrop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDeps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTimeDrop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFIOTake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTimeTake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbCodeKey = new System.Windows.Forms.TextBox();
            this.tbNameScaner = new System.Windows.Forms.TextBox();
            this.tbFioTake = new System.Windows.Forms.TextBox();
            this.tbNameDeps = new System.Windows.Forms.TextBox();
            this.tbFioOut = new System.Windows.Forms.TextBox();
            this.tbController = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbNotGet = new System.Windows.Forms.CheckBox();
            this.btExit = new System.Windows.Forms.Button();
            this.btExcel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btUpdate = new System.Windows.Forms.Button();
            this.tbNameLocation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScaner)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNumRoom
            // 
            this.tbNumRoom.Location = new System.Drawing.Point(13, 12);
            this.tbNumRoom.MaxLength = 150;
            this.tbNumRoom.Name = "tbNumRoom";
            this.tbNumRoom.Size = new System.Drawing.Size(118, 20);
            this.tbNumRoom.TabIndex = 4;
            this.tbNumRoom.TextChanged += new System.EventHandler(this.tbNumRoom_TextChanged);
            // 
            // dgvScaner
            // 
            this.dgvScaner.AllowUserToAddRows = false;
            this.dgvScaner.AllowUserToDeleteRows = false;
            this.dgvScaner.AllowUserToResizeRows = false;
            this.dgvScaner.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScaner.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvScaner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScaner.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cInv,
            this.cEan,
            this.cName,
            this.cFIODrop,
            this.cDeps,
            this.Location,
            this.cTimeDrop,
            this.cFIOTake,
            this.cTimeTake});
            this.dgvScaner.Location = new System.Drawing.Point(12, 41);
            this.dgvScaner.Name = "dgvScaner";
            this.dgvScaner.RowHeadersVisible = false;
            this.dgvScaner.Size = new System.Drawing.Size(1154, 461);
            this.dgvScaner.TabIndex = 5;
            this.dgvScaner.SelectionChanged += new System.EventHandler(this.dgvScaner_SelectionChanged);
            // 
            // cInv
            // 
            this.cInv.DataPropertyName = "InventoryNumber";
            this.cInv.HeaderText = "Инв. номер";
            this.cInv.Name = "cInv";
            this.cInv.ReadOnly = true;
            // 
            // cEan
            // 
            this.cEan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cEan.DataPropertyName = "EAN";
            this.cEan.HeaderText = "EAN";
            this.cEan.MinimumWidth = 110;
            this.cEan.Name = "cEan";
            this.cEan.ReadOnly = true;
            this.cEan.Width = 110;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "cName";
            this.cName.HeaderText = "Наименование";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cFIODrop
            // 
            this.cFIODrop.DataPropertyName = "nameOut";
            this.cFIODrop.HeaderText = "ФИО получил";
            this.cFIODrop.Name = "cFIODrop";
            this.cFIODrop.ReadOnly = true;
            // 
            // cDeps
            // 
            this.cDeps.DataPropertyName = "nameDeps";
            this.cDeps.HeaderText = "Отдел";
            this.cDeps.Name = "cDeps";
            this.cDeps.ReadOnly = true;
            // 
            // Location
            // 
            this.Location.DataPropertyName = "nameLocation";
            this.Location.HeaderText = "Местоположение";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            // 
            // cTimeDrop
            // 
            this.cTimeDrop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cTimeDrop.DataPropertyName = "DateOut";
            this.cTimeDrop.HeaderText = "Время выдачи";
            this.cTimeDrop.MinimumWidth = 120;
            this.cTimeDrop.Name = "cTimeDrop";
            this.cTimeDrop.ReadOnly = true;
            this.cTimeDrop.Width = 120;
            // 
            // cFIOTake
            // 
            this.cFIOTake.DataPropertyName = "nameGet";
            this.cFIOTake.HeaderText = "ФИО вернул";
            this.cFIOTake.Name = "cFIOTake";
            this.cFIOTake.ReadOnly = true;
            // 
            // cTimeTake
            // 
            this.cTimeTake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cTimeTake.DataPropertyName = "DateGet";
            this.cTimeTake.HeaderText = "Время возврата";
            this.cTimeTake.MinimumWidth = 120;
            this.cTimeTake.Name = "cTimeTake";
            this.cTimeTake.ReadOnly = true;
            this.cTimeTake.Width = 120;
            // 
            // tbCodeKey
            // 
            this.tbCodeKey.Location = new System.Drawing.Point(152, 11);
            this.tbCodeKey.MaxLength = 150;
            this.tbCodeKey.Name = "tbCodeKey";
            this.tbCodeKey.Size = new System.Drawing.Size(100, 20);
            this.tbCodeKey.TabIndex = 4;
            this.tbCodeKey.TextChanged += new System.EventHandler(this.tbNumRoom_TextChanged);
            // 
            // tbNameScaner
            // 
            this.tbNameScaner.Location = new System.Drawing.Point(259, 11);
            this.tbNameScaner.MaxLength = 150;
            this.tbNameScaner.Name = "tbNameScaner";
            this.tbNameScaner.Size = new System.Drawing.Size(130, 20);
            this.tbNameScaner.TabIndex = 4;
            this.tbNameScaner.TextChanged += new System.EventHandler(this.tbNumRoom_TextChanged);
            // 
            // tbFioTake
            // 
            this.tbFioTake.Location = new System.Drawing.Point(394, 11);
            this.tbFioTake.MaxLength = 150;
            this.tbFioTake.Name = "tbFioTake";
            this.tbFioTake.Size = new System.Drawing.Size(130, 20);
            this.tbFioTake.TabIndex = 4;
            this.tbFioTake.TextChanged += new System.EventHandler(this.tbNumRoom_TextChanged);
            // 
            // tbNameDeps
            // 
            this.tbNameDeps.Location = new System.Drawing.Point(535, 12);
            this.tbNameDeps.MaxLength = 150;
            this.tbNameDeps.Name = "tbNameDeps";
            this.tbNameDeps.Size = new System.Drawing.Size(115, 20);
            this.tbNameDeps.TabIndex = 4;
            this.tbNameDeps.TextChanged += new System.EventHandler(this.tbNumRoom_TextChanged);
            // 
            // tbFioOut
            // 
            this.tbFioOut.Location = new System.Drawing.Point(886, 12);
            this.tbFioOut.MaxLength = 150;
            this.tbFioOut.Name = "tbFioOut";
            this.tbFioOut.Size = new System.Drawing.Size(149, 20);
            this.tbFioOut.TabIndex = 4;
            this.tbFioOut.TextChanged += new System.EventHandler(this.tbNumRoom_TextChanged);
            // 
            // tbController
            // 
            this.tbController.Location = new System.Drawing.Point(728, 514);
            this.tbController.Name = "tbController";
            this.tbController.ReadOnly = true;
            this.tbController.Size = new System.Drawing.Size(223, 20);
            this.tbController.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(643, 518);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Сканер выдал";
            // 
            // chbNotGet
            // 
            this.chbNotGet.AutoSize = true;
            this.chbNotGet.Location = new System.Drawing.Point(26, 516);
            this.chbNotGet.Name = "chbNotGet";
            this.chbNotGet.Size = new System.Drawing.Size(151, 17);
            this.chbNotGet.TabIndex = 6;
            this.chbNotGet.Text = "- оборудование не сдано";
            this.chbNotGet.UseVisualStyleBackColor = true;
            this.chbNotGet.CheckedChanged += new System.EventHandler(this.chbNotGet_CheckedChanged);
            // 
            // btExit
            // 
            this.btExit.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btExit.Location = new System.Drawing.Point(1134, 508);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(32, 32);
            this.btExit.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btExit, "Выход");
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btExcel
            // 
            this.btExcel.Image = global::hardWareViewer.Properties.Resources.print;
            this.btExcel.Location = new System.Drawing.Point(1096, 508);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(32, 32);
            this.btExcel.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btExcel, "Выгрузить в Excel");
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(1065, 5);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(96, 30);
            this.btUpdate.TabIndex = 7;
            this.btUpdate.Text = "Обновить";
            this.toolTip1.SetToolTip(this.btUpdate, "Обновить");
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // tbNameLocation
            // 
            this.tbNameLocation.Location = new System.Drawing.Point(660, 12);
            this.tbNameLocation.MaxLength = 150;
            this.tbNameLocation.Name = "tbNameLocation";
            this.tbNameLocation.Size = new System.Drawing.Size(130, 20);
            this.tbNameLocation.TabIndex = 8;
            this.tbNameLocation.TextChanged += new System.EventHandler(this.tbNameLocation_TextChanged);
            // 
            // frmListScaners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 608);
            this.ControlBox = false;
            this.Controls.Add(this.tbNameLocation);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.chbNotGet);
            this.Controls.Add(this.dgvScaner);
            this.Controls.Add(this.tbController);
            this.Controls.Add(this.tbFioOut);
            this.Controls.Add(this.tbNameDeps);
            this.Controls.Add(this.tbFioTake);
            this.Controls.Add(this.tbNameScaner);
            this.Controls.Add(this.tbCodeKey);
            this.Controls.Add(this.tbNumRoom);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListScaners";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список сканеров";
            this.Load += new System.EventHandler(this.frmContScaner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScaner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNumRoom;
        private System.Windows.Forms.DataGridView dgvScaner;
        private System.Windows.Forms.TextBox tbCodeKey;
        private System.Windows.Forms.TextBox tbNameScaner;
        private System.Windows.Forms.TextBox tbFioTake;
        private System.Windows.Forms.TextBox tbNameDeps;
        private System.Windows.Forms.TextBox tbFioOut;
        private System.Windows.Forms.TextBox tbController;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbNotGet;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cInv;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFIODrop;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDeps;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTimeDrop;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFIOTake;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTimeTake;
        private System.Windows.Forms.TextBox tbNameLocation;
    }
}