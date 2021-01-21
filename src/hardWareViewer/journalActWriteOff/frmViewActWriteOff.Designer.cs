namespace hardWareViewer
{
    partial class frmViewActWriteOff
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
            this.btClose = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDateCreate = new System.Windows.Forms.TextBox();
            this.tbDateWriteOff = new System.Windows.Forms.TextBox();
            this.tbStatusName = new System.Windows.Forms.TextBox();
            this.btPrint = new System.Windows.Forms.Button();
            this.btAddDoc = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHardWare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cResponsible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(1099, 402);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 61;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
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
            this.cNum,
            this.cEAN,
            this.cName,
            this.cHardWare,
            this.cResponsible,
            this.cLocation});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Location = new System.Drawing.Point(11, 151);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1120, 233);
            this.dgvData.TabIndex = 59;
            // 
            // tbReason
            // 
            this.tbReason.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReason.Location = new System.Drawing.Point(11, 91);
            this.tbReason.Multiline = true;
            this.tbReason.Name = "tbReason";
            this.tbReason.ReadOnly = true;
            this.tbReason.Size = new System.Drawing.Size(1120, 54);
            this.tbReason.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Причина:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Дата создания:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Дата списания:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(706, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Статус :";
            // 
            // tbDateCreate
            // 
            this.tbDateCreate.Location = new System.Drawing.Point(101, 6);
            this.tbDateCreate.Name = "tbDateCreate";
            this.tbDateCreate.ReadOnly = true;
            this.tbDateCreate.Size = new System.Drawing.Size(188, 20);
            this.tbDateCreate.TabIndex = 62;
            // 
            // tbDateWriteOff
            // 
            this.tbDateWriteOff.Location = new System.Drawing.Point(101, 33);
            this.tbDateWriteOff.Name = "tbDateWriteOff";
            this.tbDateWriteOff.ReadOnly = true;
            this.tbDateWriteOff.Size = new System.Drawing.Size(188, 20);
            this.tbDateWriteOff.TabIndex = 62;
            // 
            // tbStatusName
            // 
            this.tbStatusName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStatusName.Location = new System.Drawing.Point(759, 7);
            this.tbStatusName.Name = "tbStatusName";
            this.tbStatusName.ReadOnly = true;
            this.tbStatusName.Size = new System.Drawing.Size(372, 20);
            this.tbStatusName.TabIndex = 62;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Image = global::hardWareViewer.Properties.Resources.print;
            this.btPrint.Location = new System.Drawing.Point(50, 402);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(32, 32);
            this.btPrint.TabIndex = 64;
            this.toolTip1.SetToolTip(this.btPrint, "Печать");
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btAddDoc
            // 
            this.btAddDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddDoc.Image = global::hardWareViewer.Properties.Resources.folder_add;
            this.btAddDoc.Location = new System.Drawing.Point(12, 402);
            this.btAddDoc.Name = "btAddDoc";
            this.btAddDoc.Size = new System.Drawing.Size(32, 32);
            this.btAddDoc.TabIndex = 63;
            this.toolTip1.SetToolTip(this.btAddDoc, "Добавление документа");
            this.btAddDoc.UseVisualStyleBackColor = true;
            this.btAddDoc.Click += new System.EventHandler(this.btAddDoc_Click);
            // 
            // cNum
            // 
            this.cNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cNum.DataPropertyName = "InventoryNumber";
            this.cNum.HeaderText = "Инв. №";
            this.cNum.MinimumWidth = 45;
            this.cNum.Name = "cNum";
            this.cNum.Width = 120;
            // 
            // cEAN
            // 
            this.cEAN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cEAN.DataPropertyName = "EAN";
            this.cEAN.HeaderText = "EAN";
            this.cEAN.MinimumWidth = 45;
            this.cEAN.Name = "cEAN";
            this.cEAN.ReadOnly = true;
            this.cEAN.Width = 120;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "cName";
            this.cName.HeaderText = "Наименование";
            this.cName.MinimumWidth = 100;
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cHardWare
            // 
            this.cHardWare.DataPropertyName = "nameType";
            this.cHardWare.HeaderText = "Оборудование/Комплектующие";
            this.cHardWare.MinimumWidth = 190;
            this.cHardWare.Name = "cHardWare";
            this.cHardWare.ReadOnly = true;
            // 
            // cResponsible
            // 
            this.cResponsible.DataPropertyName = "FIO";
            this.cResponsible.HeaderText = "Ответственный";
            this.cResponsible.MinimumWidth = 120;
            this.cResponsible.Name = "cResponsible";
            this.cResponsible.ReadOnly = true;
            this.cResponsible.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cResponsible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cLocation
            // 
            this.cLocation.DataPropertyName = "nameLocation";
            this.cLocation.HeaderText = "Местоположение";
            this.cLocation.MinimumWidth = 120;
            this.cLocation.Name = "cLocation";
            this.cLocation.ReadOnly = true;
            this.cLocation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cLocation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmViewActWriteOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 442);
            this.ControlBox = false;
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btAddDoc);
            this.Controls.Add(this.tbStatusName);
            this.Controls.Add(this.tbDateWriteOff);
            this.Controls.Add(this.tbDateCreate);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.tbReason);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewActWriteOff";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmViewActWriteOff";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox tbReason;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDateCreate;
        private System.Windows.Forms.TextBox tbDateWriteOff;
        private System.Windows.Forms.TextBox tbStatusName;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btAddDoc;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHardWare;
        private System.Windows.Forms.DataGridViewTextBoxColumn cResponsible;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLocation;
    }
}