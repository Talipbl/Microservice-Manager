namespace Services
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabMicroservices = new TabControl();
            statusStrip1 = new StatusStrip();
            toollblServices = new ToolStripStatusLabel();
            toollblMemory = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            notifyIcon = new NotifyIcon(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            toolStrip2 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            cmbCategories = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            toolbtnStartAll = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton1 = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            btnRunFavorites = new ToolStripButton();
            toolStrip3 = new ToolStrip();
            toolbtnExit = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolbtnSettings = new ToolStripButton();
            lblAppStatus = new Label();
            statusStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            toolStrip2.SuspendLayout();
            toolStrip3.SuspendLayout();
            SuspendLayout();
            // 
            // tabMicroservices
            // 
            tabMicroservices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabMicroservices.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            tabMicroservices.Location = new Point(12, 63);
            tabMicroservices.Name = "tabMicroservices";
            tabMicroservices.SelectedIndex = 0;
            tabMicroservices.Size = new Size(1160, 686);
            tabMicroservices.TabIndex = 10;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toollblServices, toollblMemory, toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 739);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1184, 22);
            statusStrip1.TabIndex = 13;
            statusStrip1.Text = "statusStrip1";
            // 
            // toollblServices
            // 
            toollblServices.Name = "toollblServices";
            toollblServices.Size = new Size(120, 17);
            toollblServices.Text = "Working Services: 0/0";
            // 
            // toollblMemory
            // 
            toollblMemory.Name = "toollblMemory";
            toollblMemory.Size = new Size(135, 17);
            toollblMemory.Text = "Memory Usage: 0,00 MB";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(159, 17);
            toolStripStatusLabel1.Text = "© 2025 - All Rights Reserved ";
            toolStripStatusLabel1.ToolTipText = "Developed By Talip";
            toolStripStatusLabel1.Click += toolStripStatusLabel1_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Microservice Manager";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(toolStrip2, 0, 0);
            tableLayoutPanel1.Controls.Add(toolStrip3, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1184, 42);
            tableLayoutPanel1.TabIndex = 15;
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = Color.Transparent;
            toolStrip2.CanOverflow = false;
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel1, cmbCategories, toolStripSeparator2, toolbtnStartAll, toolStripSeparator1, toolStripButton1, toolStripSeparator4, btnRunFavorites });
            toolStrip2.Location = new Point(4, 7);
            toolStrip2.Margin = new Padding(4, 7, 0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(621, 28);
            toolStrip2.TabIndex = 0;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Segoe UI", 10.25F);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(57, 25);
            toolStripLabel1.Text = "Services";
            // 
            // cmbCategories
            // 
            cmbCategories.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(150, 28);
            cmbCategories.SelectedIndexChanged += cmbCategories_SelectedIndexChanged;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Margin = new Padding(10, 0, 10, 0);
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 28);
            // 
            // toolbtnStartAll
            // 
            toolbtnStartAll.BackColor = Color.GreenYellow;
            toolbtnStartAll.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolbtnStartAll.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            toolbtnStartAll.Image = (Image)resources.GetObject("toolbtnStartAll.Image");
            toolbtnStartAll.ImageTransparentColor = Color.Magenta;
            toolbtnStartAll.Name = "toolbtnStartAll";
            toolbtnStartAll.Size = new Size(108, 25);
            toolbtnStartAll.Text = "Run All Services";
            toolbtnStartAll.Click += toolbtnStartAll_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 28);
            // 
            // toolStripButton1
            // 
            toolStripButton1.BackColor = Color.OrangeRed;
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            toolStripButton1.ForeColor = SystemColors.ButtonHighlight;
            toolStripButton1.ImageTransparentColor = Color.Transparent;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(112, 25);
            toolStripButton1.Text = "Stop All Services";
            toolStripButton1.Click += toolbtnStopAll_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 28);
            // 
            // btnRunFavorites
            // 
            btnRunFavorites.BackColor = Color.Silver;
            btnRunFavorites.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnRunFavorites.Image = (Image)resources.GetObject("btnRunFavorites.Image");
            btnRunFavorites.ImageTransparentColor = Color.Magenta;
            btnRunFavorites.Name = "btnRunFavorites";
            btnRunFavorites.Size = new Size(122, 25);
            btnRunFavorites.Text = "Run Favorite Services";
            btnRunFavorites.Click += btnRunFavorites_Click;
            // 
            // toolStrip3
            // 
            toolStrip3.BackColor = Color.Transparent;
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolbtnExit, toolStripSeparator3, toolbtnSettings });
            toolStrip3.Location = new Point(625, 7);
            toolStrip3.Margin = new Padding(0, 7, 10, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.RightToLeft = RightToLeft.Yes;
            toolStrip3.Size = new Size(549, 26);
            toolStrip3.TabIndex = 1;
            toolStrip3.Text = "toolStrip3";
            // 
            // toolbtnExit
            // 
            toolbtnExit.Font = new Font("Segoe UI", 10.25F);
            toolbtnExit.Image = (Image)resources.GetObject("toolbtnExit.Image");
            toolbtnExit.ImageTransparentColor = Color.Magenta;
            toolbtnExit.Name = "toolbtnExit";
            toolbtnExit.Size = new Size(50, 23);
            toolbtnExit.Text = "Exit";
            toolbtnExit.Click += toolbtnExit_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Margin = new Padding(10, 0, 10, 0);
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 26);
            // 
            // toolbtnSettings
            // 
            toolbtnSettings.Font = new Font("Segoe UI", 10.25F);
            toolbtnSettings.Image = (Image)resources.GetObject("toolbtnSettings.Image");
            toolbtnSettings.ImageTransparentColor = Color.Linen;
            toolbtnSettings.Name = "toolbtnSettings";
            toolbtnSettings.Size = new Size(78, 23);
            toolbtnSettings.Text = "Settings";
            toolbtnSettings.ToolTipText = "Application Settings";
            toolbtnSettings.Click += toolbtnSettings_Click;
            // 
            // lblAppStatus
            // 
            lblAppStatus.AutoSize = true;
            lblAppStatus.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblAppStatus.ForeColor = Color.Red;
            lblAppStatus.Location = new Point(12, 45);
            lblAppStatus.Name = "lblAppStatus";
            lblAppStatus.Size = new Size(0, 17);
            lblAppStatus.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(lblAppStatus);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(statusStrip1);
            Controls.Add(tabMicroservices);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Microservice Manager";
            FormClosing += Form1_FormClosing;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabMicroservices;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toollblServices;
        private ToolStripStatusLabel toollblMemory;
        private NotifyIcon notifyIcon;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStrip toolStrip2;
        private ToolStrip toolStrip3;
        private ToolStripButton toolbtnSettings;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cmbCategories;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripButton toolbtnExit;
        private Label lblAppStatus;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolbtnStartAll;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton btnRunFavorites;
    }
}
