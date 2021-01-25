namespace hardWareViewer
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiJournalEstimates = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiJournalActReceivingTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiJournalActInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiJournalActWriteOff = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiListHardware = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContolScaner = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDirectoryResponsible = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDirectoryPlaceHardWare = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDirectoryTypeHardWare = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDirectoryTypeComponents = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDirectoryHardWareAndComponents = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDirectoryObject = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ssConnections = new System.Windows.Forms.StatusStrip();
            this.tslMainConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslAddConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslAdd2Connect = new System.Windows.Forms.ToolStripStatusLabel();
            this.tcMain = new hardWareViewer.TabControlEx();
            this.menuStrip1.SuspendLayout();
            this.ssConnections.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.справочникиToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.tsmiExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1224, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiJournalEstimates,
            this.tsmiJournalActReceivingTransfer,
            this.tsmiJournalActInventory,
            this.tsmiJournalActWriteOff,
            this.tsmiListHardware,
            this.tsmiContolScaner});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // tsmiJournalEstimates
            // 
            this.tsmiJournalEstimates.Name = "tsmiJournalEstimates";
            this.tsmiJournalEstimates.Size = new System.Drawing.Size(410, 22);
            this.tsmiJournalEstimates.Tag = "frmJournalEstimates";
            this.tsmiJournalEstimates.Text = "Журнал смет";
            this.tsmiJournalEstimates.Click += new System.EventHandler(this.tsmiJournalEstimates_Click);
            // 
            // tsmiJournalActReceivingTransfer
            // 
            this.tsmiJournalActReceivingTransfer.Name = "tsmiJournalActReceivingTransfer";
            this.tsmiJournalActReceivingTransfer.Size = new System.Drawing.Size(410, 22);
            this.tsmiJournalActReceivingTransfer.Tag = "frmJournalActReceivingTransfer";
            this.tsmiJournalActReceivingTransfer.Text = "Журнал актов приемки передачи материальной ответственности";
            this.tsmiJournalActReceivingTransfer.Click += new System.EventHandler(this.tsmiJournalActReceivingTransfer_Click);
            // 
            // tsmiJournalActInventory
            // 
            this.tsmiJournalActInventory.Name = "tsmiJournalActInventory";
            this.tsmiJournalActInventory.Size = new System.Drawing.Size(410, 22);
            this.tsmiJournalActInventory.Text = "Журнал актов инвентаризации";
            this.tsmiJournalActInventory.Click += new System.EventHandler(this.tsmiJournalActInventory_Click);
            // 
            // tsmiJournalActWriteOff
            // 
            this.tsmiJournalActWriteOff.Name = "tsmiJournalActWriteOff";
            this.tsmiJournalActWriteOff.Size = new System.Drawing.Size(410, 22);
            this.tsmiJournalActWriteOff.Text = "Журнал актов списания";
            this.tsmiJournalActWriteOff.Click += new System.EventHandler(this.tsmiJournalActWriteOff_Click);
            // 
            // tsmiListHardware
            // 
            this.tsmiListHardware.Name = "tsmiListHardware";
            this.tsmiListHardware.Size = new System.Drawing.Size(410, 22);
            this.tsmiListHardware.Tag = "frmListHardware";
            this.tsmiListHardware.Text = "Список оборудования";
            this.tsmiListHardware.Click += new System.EventHandler(this.tsmiListHardware_Click);
            // 
            // tsmiContolScaner
            // 
            this.tsmiContolScaner.Name = "tsmiContolScaner";
            this.tsmiContolScaner.Size = new System.Drawing.Size(410, 22);
            this.tsmiContolScaner.Text = "Учет сканеров";
            this.tsmiContolScaner.Click += new System.EventHandler(this.tsmiContolScaner_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDirectoryResponsible,
            this.tsmiDirectoryPlaceHardWare,
            this.tsmiDirectoryTypeHardWare,
            this.tsmDirectoryTypeComponents,
            this.tsmiDirectoryHardWareAndComponents,
            this.tsmiDirectoryObject});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // tsmiDirectoryResponsible
            // 
            this.tsmiDirectoryResponsible.Name = "tsmiDirectoryResponsible";
            this.tsmiDirectoryResponsible.Size = new System.Drawing.Size(307, 22);
            this.tsmiDirectoryResponsible.Text = "Справочник материально ответственных лиц";
            this.tsmiDirectoryResponsible.Click += new System.EventHandler(this.tsmiDirectoryResponsible_Click);
            // 
            // tsmiDirectoryPlaceHardWare
            // 
            this.tsmiDirectoryPlaceHardWare.Name = "tsmiDirectoryPlaceHardWare";
            this.tsmiDirectoryPlaceHardWare.Size = new System.Drawing.Size(307, 22);
            this.tsmiDirectoryPlaceHardWare.Text = "Справочник местоположения оборудования";
            this.tsmiDirectoryPlaceHardWare.Click += new System.EventHandler(this.tsmiDirectoryPlaceHardWare_Click);
            // 
            // tsmiDirectoryTypeHardWare
            // 
            this.tsmiDirectoryTypeHardWare.Name = "tsmiDirectoryTypeHardWare";
            this.tsmiDirectoryTypeHardWare.Size = new System.Drawing.Size(307, 22);
            this.tsmiDirectoryTypeHardWare.Text = "Справочник типов оборудования";
            this.tsmiDirectoryTypeHardWare.Click += new System.EventHandler(this.tsmiDirectoryTypeHardWare_Click);
            // 
            // tsmDirectoryTypeComponents
            // 
            this.tsmDirectoryTypeComponents.Name = "tsmDirectoryTypeComponents";
            this.tsmDirectoryTypeComponents.Size = new System.Drawing.Size(307, 22);
            this.tsmDirectoryTypeComponents.Text = "Справочник типов комплектующих";
            this.tsmDirectoryTypeComponents.Click += new System.EventHandler(this.tsmDirectoryTypeComponents_Click);
            // 
            // tsmiDirectoryHardWareAndComponents
            // 
            this.tsmiDirectoryHardWareAndComponents.Name = "tsmiDirectoryHardWareAndComponents";
            this.tsmiDirectoryHardWareAndComponents.Size = new System.Drawing.Size(307, 22);
            this.tsmiDirectoryHardWareAndComponents.Text = "Справочник оборудования и комплектующих";
            this.tsmiDirectoryHardWareAndComponents.Click += new System.EventHandler(this.tsmiDirectoryHardWareAndComponents_Click);
            // 
            // tsmiDirectoryObject
            // 
            this.tsmiDirectoryObject.Name = "tsmiDirectoryObject";
            this.tsmiDirectoryObject.Size = new System.Drawing.Size(307, 22);
            this.tsmiDirectoryObject.Text = "Справочник объектов";
            this.tsmiDirectoryObject.Click += new System.EventHandler(this.tsmiDirectoryObject_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Visible = false;
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(52, 20);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // ssConnections
            // 
            this.ssConnections.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslMainConnect,
            this.tslAddConnect,
            this.tslAdd2Connect});
            this.ssConnections.Location = new System.Drawing.Point(0, 601);
            this.ssConnections.Name = "ssConnections";
            this.ssConnections.Size = new System.Drawing.Size(1224, 22);
            this.ssConnections.TabIndex = 0;
            this.ssConnections.Text = "statusStrip1";
            // 
            // tslMainConnect
            // 
            this.tslMainConnect.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tslMainConnect.Name = "tslMainConnect";
            this.tslMainConnect.Size = new System.Drawing.Size(4, 17);
            // 
            // tslAddConnect
            // 
            this.tslAddConnect.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tslAddConnect.Name = "tslAddConnect";
            this.tslAddConnect.Size = new System.Drawing.Size(4, 17);
            // 
            // tslAdd2Connect
            // 
            this.tslAdd2Connect.Name = "tslAdd2Connect";
            this.tslAdd2Connect.Size = new System.Drawing.Size(0, 17);
            // 
            // tcMain
            // 
            this.tcMain.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tcMain.ItemSize = new System.Drawing.Size(0, 18);
            this.tcMain.Location = new System.Drawing.Point(0, 581);
            this.tcMain.Multiline = true;
            this.tcMain.Name = "tcMain";
            this.tcMain.Padding = new System.Drawing.Point(10, 0);
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1224, 20);
            this.tcMain.TabIndex = 3;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            this.tcMain.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tcMain_ControlRemoved);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 623);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.ssConnections);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(975, 650);
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ssConnections.ResumeLayout(false);
            this.ssConnections.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiJournalEstimates;
        private System.Windows.Forms.ToolStripMenuItem tsmiJournalActReceivingTransfer;
        private System.Windows.Forms.ToolStripMenuItem tsmiJournalActInventory;
        private System.Windows.Forms.ToolStripMenuItem tsmiJournalActWriteOff;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiDirectoryResponsible;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDirectoryPlaceHardWare;
        private System.Windows.Forms.ToolStripMenuItem tsmiDirectoryTypeHardWare;
        private System.Windows.Forms.ToolStripMenuItem tsmDirectoryTypeComponents;
        private System.Windows.Forms.ToolStripMenuItem tsmiDirectoryHardWareAndComponents;
        private System.Windows.Forms.ToolStripMenuItem tsmiListHardware;
        private System.Windows.Forms.ToolStripMenuItem tsmiDirectoryObject;
        private System.Windows.Forms.ToolStripMenuItem tsmiContolScaner;
        private System.Windows.Forms.StatusStrip ssConnections;
        private System.Windows.Forms.ToolStripStatusLabel tslMainConnect;
        private System.Windows.Forms.ToolStripStatusLabel tslAddConnect;
        private System.Windows.Forms.ToolStripStatusLabel tslAdd2Connect;
        private TabControlEx tcMain;
    }
}

