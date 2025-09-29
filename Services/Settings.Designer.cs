namespace Services
{
    partial class Settings
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            lstCategories = new ListBox();
            txtCategoryName = new TextBox();
            btnAddCategory = new Button();
            btnRemoveCategory = new Button();
            btnRemoveMicroservice = new Button();
            btnEditMicroservice = new Button();
            btnAddMicroservice = new Button();
            txtMicroserviceName = new TextBox();
            txtMicroservicePath = new TextBox();
            dgvMicroservices = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tabControl1 = new TabControl();
            basic_settings = new TabPage();
            groupBox4 = new GroupBox();
            numericMaxInitialCount = new NumericUpDown();
            lblLimitedOperation = new Label();
            checkBox1 = new CheckBox();
            groupBox3 = new GroupBox();
            comboBoxNumberOfRepeats = new ComboBox();
            lblErrorHandling2 = new Label();
            lblErrorHandling1 = new Label();
            numericStartupDelay = new NumericUpDown();
            chcbxRestartService = new CheckBox();
            groupBox2 = new GroupBox();
            numericFlushSequence = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            numericLogLineLimit = new NumericUpDown();
            groupBox1 = new GroupBox();
            lblMonitoring4 = new Label();
            lblMonitoring3 = new Label();
            chcbxAudibleWarning = new CheckBox();
            lblMonitoring2 = new Label();
            lblMonitoring1 = new Label();
            numericTotalConsumption = new NumericUpDown();
            numericConsumption = new NumericUpDown();
            chcbxMemoryWarnings = new CheckBox();
            service_settings = new TabPage();
            chcbxFavorites = new CheckBox();
            json_editor = new TabPage();
            richtxtJsonSettings = new RichTextBox();
            toolbtnSave = new ToolStripButton();
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            importSettingsFromFile = new ToolStripMenuItem();
            exportSettings = new ToolStripMenuItem();
            toolTipInfo = new ToolTip(components);
            toolTipWarning = new ToolTip(components);
            toolTipError = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgvMicroservices).BeginInit();
            tabControl1.SuspendLayout();
            basic_settings.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericMaxInitialCount).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericStartupDelay).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericFlushSequence).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericLogLineLimit).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericTotalConsumption).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericConsumption).BeginInit();
            service_settings.SuspendLayout();
            json_editor.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lstCategories
            // 
            lstCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lstCategories.Font = new Font("Segoe UI", 10F);
            lstCategories.ItemHeight = 17;
            lstCategories.Location = new Point(10, 29);
            lstCategories.Name = "lstCategories";
            lstCategories.Size = new Size(248, 225);
            lstCategories.TabIndex = 12;
            lstCategories.SelectedIndexChanged += lstCategories_SelectedIndexChanged;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtCategoryName.Font = new Font("Segoe UI", 9.75F);
            txtCategoryName.Location = new Point(10, 264);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(248, 25);
            txtCategoryName.TabIndex = 1;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddCategory.Font = new Font("Segoe UI", 9.75F);
            btnAddCategory.Location = new Point(10, 297);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(120, 30);
            btnAddCategory.TabIndex = 2;
            btnAddCategory.Text = "Add Category";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // btnRemoveCategory
            // 
            btnRemoveCategory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemoveCategory.Enabled = false;
            btnRemoveCategory.Font = new Font("Segoe UI", 9.75F);
            btnRemoveCategory.Location = new Point(138, 297);
            btnRemoveCategory.Name = "btnRemoveCategory";
            btnRemoveCategory.Size = new Size(120, 30);
            btnRemoveCategory.TabIndex = 4;
            btnRemoveCategory.Text = "Delete";
            btnRemoveCategory.UseVisualStyleBackColor = true;
            btnRemoveCategory.Click += btnRemoveCategory_Click;
            // 
            // btnRemoveMicroservice
            // 
            btnRemoveMicroservice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemoveMicroservice.Enabled = false;
            btnRemoveMicroservice.Font = new Font("Segoe UI", 10F);
            btnRemoveMicroservice.Location = new Point(650, 357);
            btnRemoveMicroservice.Name = "btnRemoveMicroservice";
            btnRemoveMicroservice.Size = new Size(120, 30);
            btnRemoveMicroservice.TabIndex = 9;
            btnRemoveMicroservice.Text = "Delete";
            btnRemoveMicroservice.UseVisualStyleBackColor = true;
            btnRemoveMicroservice.Click += btnRemoveMicroservice_Click;
            // 
            // btnEditMicroservice
            // 
            btnEditMicroservice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditMicroservice.Enabled = false;
            btnEditMicroservice.Font = new Font("Segoe UI", 10F);
            btnEditMicroservice.Location = new Point(524, 357);
            btnEditMicroservice.Name = "btnEditMicroservice";
            btnEditMicroservice.Size = new Size(120, 30);
            btnEditMicroservice.TabIndex = 8;
            btnEditMicroservice.Text = "Update";
            btnEditMicroservice.UseVisualStyleBackColor = true;
            btnEditMicroservice.Click += btnEditMicroservice_Click;
            // 
            // btnAddMicroservice
            // 
            btnAddMicroservice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddMicroservice.Enabled = false;
            btnAddMicroservice.Font = new Font("Segoe UI", 10F);
            btnAddMicroservice.Location = new Point(398, 357);
            btnAddMicroservice.Name = "btnAddMicroservice";
            btnAddMicroservice.Size = new Size(120, 30);
            btnAddMicroservice.TabIndex = 7;
            btnAddMicroservice.Text = "Add";
            btnAddMicroservice.UseVisualStyleBackColor = true;
            btnAddMicroservice.Click += btnAddMicroservice_Click;
            // 
            // txtMicroserviceName
            // 
            txtMicroserviceName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMicroserviceName.Font = new Font("Segoe UI", 10F);
            txtMicroserviceName.Location = new Point(398, 264);
            txtMicroserviceName.Name = "txtMicroserviceName";
            txtMicroserviceName.Size = new Size(496, 25);
            txtMicroserviceName.TabIndex = 6;
            // 
            // txtMicroservicePath
            // 
            txtMicroservicePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMicroservicePath.Font = new Font("Segoe UI", 10F);
            txtMicroservicePath.Location = new Point(398, 297);
            txtMicroservicePath.Name = "txtMicroservicePath";
            txtMicroservicePath.Size = new Size(496, 25);
            txtMicroservicePath.TabIndex = 10;
            // 
            // dgvMicroservices
            // 
            dgvMicroservices.AllowUserToAddRows = false;
            dgvMicroservices.AllowUserToDeleteRows = false;
            dgvMicroservices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMicroservices.BackgroundColor = Color.DarkGray;
            dgvMicroservices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvMicroservices.DefaultCellStyle = dataGridViewCellStyle3;
            dgvMicroservices.Location = new Point(290, 29);
            dgvMicroservices.MultiSelect = false;
            dgvMicroservices.Name = "dgvMicroservices";
            dgvMicroservices.ReadOnly = true;
            dgvMicroservices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMicroservices.Size = new Size(604, 224);
            dgvMicroservices.TabIndex = 11;
            dgvMicroservices.CellDoubleClick += dgvMicroservices_CellDoubleClick;
            dgvMicroservices.SelectionChanged += dgvMicroservices_SelectionChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(290, 267);
            label1.Name = "label1";
            label1.Size = new Size(94, 19);
            label1.TabIndex = 13;
            label1.Text = "Service Name:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(290, 302);
            label2.Name = "label2";
            label2.Size = new Size(86, 19);
            label2.TabIndex = 14;
            label2.Text = "Service Path:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(10, 6);
            label3.Name = "label3";
            label3.Size = new Size(74, 19);
            label3.TabIndex = 15;
            label3.Text = "Categories";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(290, 6);
            label4.Name = "label4";
            label4.Size = new Size(57, 19);
            label4.TabIndex = 16;
            label4.Text = "Services";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(basic_settings);
            tabControl1.Controls.Add(service_settings);
            tabControl1.Controls.Add(json_editor);
            tabControl1.Font = new Font("Segoe UI", 10F);
            tabControl1.Location = new Point(12, 28);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(960, 521);
            tabControl1.TabIndex = 17;
            // 
            // basic_settings
            // 
            basic_settings.Controls.Add(groupBox4);
            basic_settings.Controls.Add(groupBox3);
            basic_settings.Controls.Add(groupBox2);
            basic_settings.Controls.Add(groupBox1);
            basic_settings.Location = new Point(4, 26);
            basic_settings.Name = "basic_settings";
            basic_settings.Padding = new Padding(3);
            basic_settings.Size = new Size(952, 491);
            basic_settings.TabIndex = 0;
            basic_settings.Text = "Basic Settings";
            basic_settings.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(numericMaxInitialCount);
            groupBox4.Controls.Add(lblLimitedOperation);
            groupBox4.Controls.Add(checkBox1);
            groupBox4.Location = new Point(481, 187);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(465, 129);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Initial Limitation";
            // 
            // numericMaxInitialCount
            // 
            numericMaxInitialCount.Location = new Point(144, 48);
            numericMaxInitialCount.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numericMaxInitialCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericMaxInitialCount.Name = "numericMaxInitialCount";
            numericMaxInitialCount.Size = new Size(93, 25);
            numericMaxInitialCount.TabIndex = 2;
            numericMaxInitialCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblLimitedOperation
            // 
            lblLimitedOperation.AutoSize = true;
            lblLimitedOperation.Location = new Point(6, 50);
            lblLimitedOperation.Name = "lblLimitedOperation";
            lblLimitedOperation.Size = new Size(101, 19);
            lblLimitedOperation.TabIndex = 1;
            lblLimitedOperation.Text = "Operating limit";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(6, 24);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(337, 23);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Run a limited number of services at the same time.";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(comboBoxNumberOfRepeats);
            groupBox3.Controls.Add(lblErrorHandling2);
            groupBox3.Controls.Add(lblErrorHandling1);
            groupBox3.Controls.Add(numericStartupDelay);
            groupBox3.Controls.Add(chcbxRestartService);
            groupBox3.Location = new Point(6, 187);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(465, 129);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Error Handling";
            // 
            // comboBoxNumberOfRepeats
            // 
            comboBoxNumberOfRepeats.Enabled = false;
            comboBoxNumberOfRepeats.FormattingEnabled = true;
            comboBoxNumberOfRepeats.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            comboBoxNumberOfRepeats.Location = new Point(156, 79);
            comboBoxNumberOfRepeats.Name = "comboBoxNumberOfRepeats";
            comboBoxNumberOfRepeats.Size = new Size(93, 25);
            comboBoxNumberOfRepeats.TabIndex = 13;
            comboBoxNumberOfRepeats.ValueMemberChanged += comboBoxNumberOfRepeats_ValueMemberChanged;
            // 
            // lblErrorHandling2
            // 
            lblErrorHandling2.AutoSize = true;
            lblErrorHandling2.Enabled = false;
            lblErrorHandling2.Location = new Point(6, 81);
            lblErrorHandling2.Name = "lblErrorHandling2";
            lblErrorHandling2.Size = new Size(144, 19);
            lblErrorHandling2.TabIndex = 12;
            lblErrorHandling2.Text = "Number of repetitions";
            // 
            // lblErrorHandling1
            // 
            lblErrorHandling1.AutoSize = true;
            lblErrorHandling1.Enabled = false;
            lblErrorHandling1.Location = new Point(6, 50);
            lblErrorHandling1.Name = "lblErrorHandling1";
            lblErrorHandling1.Size = new Size(120, 19);
            lblErrorHandling1.TabIndex = 11;
            lblErrorHandling1.Text = "Startup delay (ms)";
            // 
            // numericStartupDelay
            // 
            numericStartupDelay.Enabled = false;
            numericStartupDelay.Location = new Point(156, 48);
            numericStartupDelay.Maximum = new decimal(new int[] { 300000, 0, 0, 0 });
            numericStartupDelay.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numericStartupDelay.Name = "numericStartupDelay";
            numericStartupDelay.Size = new Size(93, 25);
            numericStartupDelay.TabIndex = 1;
            numericStartupDelay.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            numericStartupDelay.ValueChanged += numericStartupDelay_ValueChanged;
            // 
            // chcbxRestartService
            // 
            chcbxRestartService.AutoSize = true;
            chcbxRestartService.Location = new Point(6, 24);
            chcbxRestartService.Name = "chcbxRestartService";
            chcbxRestartService.Size = new Size(358, 23);
            chcbxRestartService.TabIndex = 0;
            chcbxRestartService.Text = "If the service stops due to an error, restart the service.";
            chcbxRestartService.UseVisualStyleBackColor = true;
            chcbxRestartService.CheckedChanged += chcbxRestartService_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numericFlushSequence);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(numericLogLineLimit);
            groupBox2.Location = new Point(481, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(465, 175);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Logging";
            // 
            // numericFlushSequence
            // 
            numericFlushSequence.Location = new Point(144, 55);
            numericFlushSequence.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericFlushSequence.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericFlushSequence.Name = "numericFlushSequence";
            numericFlushSequence.Size = new Size(93, 25);
            numericFlushSequence.TabIndex = 3;
            toolTipWarning.SetToolTip(numericFlushSequence, "A low sequence interval can negatively affect performance!");
            numericFlushSequence.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 57);
            label6.Name = "label6";
            label6.Size = new Size(132, 19);
            label6.TabIndex = 2;
            label6.Text = "Flush sequence (ms)";
            toolTipInfo.SetToolTip(label6, "How often the log queue will be transferred in milliseconds");
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 26);
            label5.Name = "label5";
            label5.Size = new Size(87, 19);
            label5.TabIndex = 1;
            label5.Text = "Log line limit";
            toolTipInfo.SetToolTip(label5, "Maximum number of rows to display on the log screen");
            // 
            // numericLogLineLimit
            // 
            numericLogLineLimit.Location = new Point(144, 24);
            numericLogLineLimit.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericLogLineLimit.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numericLogLineLimit.Name = "numericLogLineLimit";
            numericLogLineLimit.Size = new Size(93, 25);
            numericLogLineLimit.TabIndex = 0;
            numericLogLineLimit.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblMonitoring4);
            groupBox1.Controls.Add(lblMonitoring3);
            groupBox1.Controls.Add(chcbxAudibleWarning);
            groupBox1.Controls.Add(lblMonitoring2);
            groupBox1.Controls.Add(lblMonitoring1);
            groupBox1.Controls.Add(numericTotalConsumption);
            groupBox1.Controls.Add(numericConsumption);
            groupBox1.Controls.Add(chcbxMemoryWarnings);
            groupBox1.Font = new Font("Segoe UI", 10F);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(465, 175);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Monitoring";
            // 
            // lblMonitoring4
            // 
            lblMonitoring4.AutoSize = true;
            lblMonitoring4.Location = new Point(218, 90);
            lblMonitoring4.Name = "lblMonitoring4";
            lblMonitoring4.Size = new Size(38, 19);
            lblMonitoring4.TabIndex = 9;
            lblMonitoring4.Text = "(MB)";
            // 
            // lblMonitoring3
            // 
            lblMonitoring3.AutoSize = true;
            lblMonitoring3.Location = new Point(218, 61);
            lblMonitoring3.Name = "lblMonitoring3";
            lblMonitoring3.Size = new Size(38, 19);
            lblMonitoring3.TabIndex = 8;
            lblMonitoring3.Text = "(MB)";
            // 
            // chcbxAudibleWarning
            // 
            chcbxAudibleWarning.AutoSize = true;
            chcbxAudibleWarning.Location = new Point(6, 133);
            chcbxAudibleWarning.Name = "chcbxAudibleWarning";
            chcbxAudibleWarning.Size = new Size(273, 23);
            chcbxAudibleWarning.TabIndex = 7;
            chcbxAudibleWarning.Text = "Give an audible warning in case of error.";
            chcbxAudibleWarning.UseVisualStyleBackColor = true;
            // 
            // lblMonitoring2
            // 
            lblMonitoring2.AutoSize = true;
            lblMonitoring2.Enabled = false;
            lblMonitoring2.Location = new Point(6, 90);
            lblMonitoring2.Name = "lblMonitoring2";
            lblMonitoring2.Size = new Size(177, 19);
            lblMonitoring2.TabIndex = 4;
            lblMonitoring2.Text = "Total memory consumption";
            // 
            // lblMonitoring1
            // 
            lblMonitoring1.AutoSize = true;
            lblMonitoring1.Enabled = false;
            lblMonitoring1.Location = new Point(6, 61);
            lblMonitoring1.Name = "lblMonitoring1";
            lblMonitoring1.Size = new Size(214, 19);
            lblMonitoring1.TabIndex = 3;
            lblMonitoring1.Text = "Memory consumption per service";
            // 
            // numericTotalConsumption
            // 
            numericTotalConsumption.Enabled = false;
            numericTotalConsumption.Location = new Point(262, 88);
            numericTotalConsumption.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericTotalConsumption.Name = "numericTotalConsumption";
            numericTotalConsumption.Size = new Size(93, 25);
            numericTotalConsumption.TabIndex = 2;
            numericTotalConsumption.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // numericConsumption
            // 
            numericConsumption.Enabled = false;
            numericConsumption.Location = new Point(262, 59);
            numericConsumption.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericConsumption.Name = "numericConsumption";
            numericConsumption.Size = new Size(93, 25);
            numericConsumption.TabIndex = 1;
            numericConsumption.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // chcbxMemoryWarnings
            // 
            chcbxMemoryWarnings.AutoSize = true;
            chcbxMemoryWarnings.Location = new Point(6, 24);
            chcbxMemoryWarnings.Name = "chcbxMemoryWarnings";
            chcbxMemoryWarnings.Size = new Size(269, 23);
            chcbxMemoryWarnings.TabIndex = 0;
            chcbxMemoryWarnings.Text = "Enable memory consumption warnings.";
            chcbxMemoryWarnings.UseVisualStyleBackColor = true;
            chcbxMemoryWarnings.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // service_settings
            // 
            service_settings.Controls.Add(chcbxFavorites);
            service_settings.Controls.Add(dgvMicroservices);
            service_settings.Controls.Add(label4);
            service_settings.Controls.Add(lstCategories);
            service_settings.Controls.Add(label3);
            service_settings.Controls.Add(txtCategoryName);
            service_settings.Controls.Add(label2);
            service_settings.Controls.Add(btnAddCategory);
            service_settings.Controls.Add(label1);
            service_settings.Controls.Add(btnRemoveCategory);
            service_settings.Controls.Add(txtMicroserviceName);
            service_settings.Controls.Add(txtMicroservicePath);
            service_settings.Controls.Add(btnAddMicroservice);
            service_settings.Controls.Add(btnRemoveMicroservice);
            service_settings.Controls.Add(btnEditMicroservice);
            service_settings.Location = new Point(4, 26);
            service_settings.Name = "service_settings";
            service_settings.Padding = new Padding(3);
            service_settings.Size = new Size(952, 491);
            service_settings.TabIndex = 1;
            service_settings.Text = "Service Settings";
            service_settings.UseVisualStyleBackColor = true;
            // 
            // chcbxFavorites
            // 
            chcbxFavorites.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chcbxFavorites.AutoSize = true;
            chcbxFavorites.Location = new Point(398, 328);
            chcbxFavorites.Name = "chcbxFavorites";
            chcbxFavorites.Size = new Size(206, 23);
            chcbxFavorites.TabIndex = 17;
            chcbxFavorites.Text = "Add to frequently used items";
            toolTipInfo.SetToolTip(chcbxFavorites, "You can make it easier to get started by marking the services you use frequently.");
            chcbxFavorites.UseVisualStyleBackColor = true;
            // 
            // json_editor
            // 
            json_editor.Controls.Add(richtxtJsonSettings);
            json_editor.Location = new Point(4, 26);
            json_editor.Name = "json_editor";
            json_editor.Size = new Size(952, 491);
            json_editor.TabIndex = 2;
            json_editor.Text = "JSON Editor";
            json_editor.UseVisualStyleBackColor = true;
            // 
            // richtxtJsonSettings
            // 
            richtxtJsonSettings.Dock = DockStyle.Fill;
            richtxtJsonSettings.Enabled = false;
            richtxtJsonSettings.Location = new Point(0, 0);
            richtxtJsonSettings.Name = "richtxtJsonSettings";
            richtxtJsonSettings.Size = new Size(952, 491);
            richtxtJsonSettings.TabIndex = 0;
            richtxtJsonSettings.Text = "";
            // 
            // toolbtnSave
            // 
            toolbtnSave.Font = new Font("Segoe UI", 10F);
            toolbtnSave.Image = Properties.Resources.diskette__1_;
            toolbtnSave.ImageTransparentColor = Color.Magenta;
            toolbtnSave.Name = "toolbtnSave";
            toolbtnSave.Size = new Size(114, 23);
            toolbtnSave.Text = "Save Changes";
            toolbtnSave.Click += toolbtnSave_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolbtnSave, toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RightToLeft = RightToLeft.Yes;
            toolStrip1.Size = new Size(984, 26);
            toolStrip1.TabIndex = 18;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { importSettingsFromFile, exportSettings });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(139, 23);
            toolStripDropDownButton1.Text = "Import/Export Settings";
            // 
            // importSettingsFromFile
            // 
            importSettingsFromFile.Name = "importSettingsFromFile";
            importSettingsFromFile.Size = new Size(207, 22);
            importSettingsFromFile.Text = "Import Settings From File";
            importSettingsFromFile.Click += importSettingsFromFile_Click;
            // 
            // exportSettings
            // 
            exportSettings.Name = "exportSettings";
            exportSettings.Size = new Size(207, 22);
            exportSettings.Text = "Export Settings As File";
            exportSettings.Click += exportSettings_Click;
            // 
            // toolTipInfo
            // 
            toolTipInfo.AutoPopDelay = 5000;
            toolTipInfo.InitialDelay = 500;
            toolTipInfo.IsBalloon = true;
            toolTipInfo.ReshowDelay = 100;
            toolTipInfo.ToolTipIcon = ToolTipIcon.Info;
            toolTipInfo.ToolTipTitle = "Info";
            // 
            // toolTipWarning
            // 
            toolTipWarning.IsBalloon = true;
            toolTipWarning.ToolTipIcon = ToolTipIcon.Warning;
            toolTipWarning.ToolTipTitle = "Warning";
            // 
            // toolTipError
            // 
            toolTipError.IsBalloon = true;
            toolTipError.ToolTipTitle = "Error";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(toolStrip1);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            MinimumSize = new Size(1000, 600);
            Name = "Settings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            FormClosing += Settings_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvMicroservices).EndInit();
            tabControl1.ResumeLayout(false);
            basic_settings.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericMaxInitialCount).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericStartupDelay).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericFlushSequence).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericLogLineLimit).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericTotalConsumption).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericConsumption).EndInit();
            service_settings.ResumeLayout(false);
            service_settings.PerformLayout();
            json_editor.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstCategories;
        private TextBox txtCategoryName;
        private Button btnAddCategory;
        private Button btnSave;
        private Button btnRemoveCategory;
        private Button btnRemoveMicroservice;
        private Button btnEditMicroservice;
        private Button btnAddMicroservice;
        private TextBox txtMicroserviceName;
        private TextBox txtMicroservicePath;
        private DataGridView dgvMicroservices;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TabControl tabControl1;
        private TabPage basic_settings;
        private TabPage service_settings;
        private CheckBox chcbxMemoryWarnings;
        private GroupBox groupBox1;
        private Label lblMonitoring2;
        private Label lblMonitoring1;
        private NumericUpDown numericTotalConsumption;
        private NumericUpDown numericConsumption;
        private CheckBox chcbxFavorites;
        private TabPage json_editor;
        private RichTextBox richtxtJsonSettings;
        private CheckBox chcbxAudibleWarning;
        private GroupBox groupBox2;
        private Label label5;
        private NumericUpDown numericLogLineLimit;
        private NumericUpDown numericFlushSequence;
        private Label label6;
        private ToolStripButton toolbtnSave;
        private ToolStrip toolStrip1;
        private ToolTip toolTipInfo;
        private ToolTip toolTipWarning;
        private Label lblMonitoring4;
        private Label lblMonitoring3;
        private ToolTip toolTipError;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem exportSettings;
        private ToolStripMenuItem importSettingsFromFile;
        private GroupBox groupBox3;
        private CheckBox chcbxRestartService;
        private NumericUpDown numericStartupDelay;
        private Label lblErrorHandling1;
        private Label lblErrorHandling2;
        private ComboBox comboBoxNumberOfRepeats;
        private GroupBox groupBox4;
        private Label lblLimitedOperation;
        private CheckBox checkBox1;
        private NumericUpDown numericMaxInitialCount;
    }
}