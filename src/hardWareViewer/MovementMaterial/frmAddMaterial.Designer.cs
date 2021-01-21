namespace hardWareViewer.MovementMaterial
{
    partial class frmAddMaterial
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
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.cmbMOL = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMaterial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.tbUnit = new System.Windows.Forms.TextBox();
            this.btSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::hardWareViewer.Properties.Resources.save_edit;
            this.btSave.Location = new System.Drawing.Point(358, 250);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 12;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::hardWareViewer.Properties.Resources.door_out;
            this.btClose.Location = new System.Drawing.Point(398, 250);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 13;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // cmbMOL
            // 
            this.cmbMOL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMOL.FormattingEnabled = true;
            this.cmbMOL.Location = new System.Drawing.Point(133, 58);
            this.cmbMOL.Name = "cmbMOL";
            this.cmbMOL.Size = new System.Drawing.Size(286, 21);
            this.cmbMOL.TabIndex = 16;
            this.cmbMOL.SelectionChangeCommitted += new System.EventHandler(this.cmbMOL_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "МОЛ";
            // 
            // tbMaterial
            // 
            this.tbMaterial.Location = new System.Drawing.Point(133, 6);
            this.tbMaterial.Name = "tbMaterial";
            this.tbMaterial.ReadOnly = true;
            this.tbMaterial.Size = new System.Drawing.Size(242, 20);
            this.tbMaterial.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Расходный материал";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Количество";
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(133, 32);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(221, 20);
            this.tbCount.TabIndex = 17;
            this.tbCount.Text = "0,00";
            this.tbCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCount.TextChanged += new System.EventHandler(this.tbCount_TextChanged);
            this.tbCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCount_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Комментарий";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(133, 85);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(286, 149);
            this.tbComment.TabIndex = 17;
            this.tbComment.TextChanged += new System.EventHandler(this.tbCount_TextChanged);
            // 
            // tbUnit
            // 
            this.tbUnit.Location = new System.Drawing.Point(360, 32);
            this.tbUnit.Name = "tbUnit";
            this.tbUnit.ReadOnly = true;
            this.tbUnit.Size = new System.Drawing.Size(59, 20);
            this.tbUnit.TabIndex = 17;
            // 
            // btSelect
            // 
            this.btSelect.Location = new System.Drawing.Point(381, 4);
            this.btSelect.Name = "btSelect";
            this.btSelect.Size = new System.Drawing.Size(38, 23);
            this.btSelect.TabIndex = 18;
            this.btSelect.Text = "...";
            this.btSelect.UseVisualStyleBackColor = true;
            this.btSelect.Click += new System.EventHandler(this.btSelect_Click);
            // 
            // frmAddMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 294);
            this.ControlBox = false;
            this.Controls.Add(this.btSelect);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.tbUnit);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMaterial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMOL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.Name = "frmAddMaterial";
            this.Text = "frmAddMaterial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddMaterial_FormClosing);
            this.Load += new System.EventHandler(this.frmAddMaterial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ComboBox cmbMOL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.TextBox tbUnit;
        private System.Windows.Forms.Button btSelect;
    }
}