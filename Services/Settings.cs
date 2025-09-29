namespace Services
{
    public partial class Settings : Form
    {
        private Configurations _settings;
        private Category _selectedCategory = null;
        private bool _areChangesMade;

        public Settings()
        {
            InitializeComponent();
            InitializeSettings();
            RefreshCategoryList();
            InitializeMicroserviceGrid();
        }


        #region Category Management
        private void RefreshCategoryList()
        {
            lstCategories.Items.Clear();
            lstCategories.DisplayMember = "Name";
            lstCategories.ValueMember = "Services";
            foreach (var cat in _settings.Categories)
            {
                lstCategories.Items.Add(cat);
            }
        }

        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem == null)
            {
                _selectedCategory = null;
                dgvMicroservices.DataSource = null;
                txtMicroserviceName.Clear();
                txtMicroservicePath.Clear();
                btnRemoveCategory.Enabled = false;
                btnAddMicroservice.Enabled = false;
                return;
            }

            btnRemoveCategory.Enabled = true;
            btnAddMicroservice.Enabled = true;

            _selectedCategory = lstCategories.SelectedItem as Category;

            if (_selectedCategory != null)
            {
                RefreshMicroserviceList();
                if (_selectedCategory.Services.Count == 0)
                {
                    txtMicroserviceName.Clear();
                    txtMicroservicePath.Clear();
                    btnRemoveMicroservice.Enabled = false;
                    btnEditMicroservice.Enabled = false;
                }
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var name = txtCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("The category name cannot be blank!");
                return;
            }

            if (_settings.Categories.Any(c => c.Name == name))
            {
                MessageBox.Show("There is already a category with the same name!");
                return;
            }

            _settings.Categories.Add(new Category { Name = name });
            RefreshCategoryList();
            txtCategoryName.Clear();
            _areChangesMade = true;
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedIndex == -1)
                return;

            var selectedName = lstCategories.SelectedItem.ToString();
            var cat = _settings.Categories.FirstOrDefault(c => c.Name == selectedName);
            if (cat != null)
            {
                _settings.Categories.Remove(cat);
                RefreshCategoryList();
                _areChangesMade = true;
            }
        }
        #endregion

        #region Microservice Management
        private void btnAddMicroservice_Click(object sender, EventArgs e)
        {
            if (_selectedCategory == null)
            {
                MessageBox.Show("First, you must select a category.");
                return;
            }

            var name = txtMicroserviceName.Text.Trim();
            var path = txtMicroservicePath.Text.Trim();
            var isFavorited = chcbxFavorites.Checked;

            if (string.IsNullOrEmpty(name))
            {
                toolTipError.Show("The name cannot be empty.", txtMicroserviceName);
                return;
            }
            if (string.IsNullOrEmpty(path))
            {
                toolTipError.Show("The path cannot be empty.", txtMicroservicePath);
                return;
            }

            if (_selectedCategory.Services.Any(s => s.Name == name))
            {
                MessageBox.Show("A microservice with the same name already exists.");
                return;
            }

            if (_selectedCategory.Services.Any(s => s.Path == path))
            {
                MessageBox.Show("A microservice with the same path already exists.");
                return;
            }

            _selectedCategory.Services.Add(new Microservice { Name = name, Category = _selectedCategory.Name, Path = path, IsFavorite = isFavorited });
            RefreshMicroserviceList();

            txtMicroserviceName.Clear();
            txtMicroservicePath.Clear();
            chcbxFavorites.Checked = false;

            _areChangesMade = true;
        }

        private void btnRemoveMicroservice_Click(object sender, EventArgs e)
        {
            if (_selectedCategory == null)
            {
                MessageBox.Show("No category selected.");
                return;
            }

            if (dgvMicroservices.SelectedRows.Count == 0)
            {
                MessageBox.Show("No microservice to delete has been selected.");
                return;
            }

            var selectedService = dgvMicroservices.SelectedRows[0].DataBoundItem as Microservice;

            if (selectedService != null)
            {
                _selectedCategory.Services.Remove(selectedService);
                RefreshMicroserviceList();
                txtMicroserviceName.Clear();
                txtMicroservicePath.Clear();
                btnRemoveMicroservice.Enabled = false;

                _areChangesMade = true;
            }
        }

        private void btnEditMicroservice_Click(object sender, EventArgs e)
        {
            if (_selectedCategory == null)
            {
                MessageBox.Show("No category selected.");
                return;
            }

            if (dgvMicroservices.SelectedRows.Count == 0)
            {
                MessageBox.Show("No microservice to edit has been selected.");
                return;
            }

            var selectedService = dgvMicroservices.SelectedRows[0].DataBoundItem as Microservice;

            if (selectedService != null)
            {
                var newName = txtMicroserviceName.Text.Trim();
                var newPath = txtMicroservicePath.Text.Trim();
                var isFavorited = chcbxFavorites.Checked;

                if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newPath))
                {
                    MessageBox.Show("The name and path cannot be empty.");
                    return;
                }

                selectedService.Name = newName;
                selectedService.Category = _selectedCategory.Name;
                selectedService.Path = newPath;
                selectedService.IsFavorite = isFavorited;

                _areChangesMade = true;

                RefreshMicroserviceList();
            }
        }

        private void dgvMicroservices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMicroservices.SelectedRows.Count == 0)
                return;

            var ms = dgvMicroservices.SelectedRows[0].DataBoundItem as Microservice;
            if (ms != null)
            {
                txtMicroserviceName.Text = ms.Name;
                txtMicroservicePath.Text = ms.Path;
                chcbxFavorites.Checked = ms.IsFavorite;

                btnRemoveMicroservice.Enabled = true;
                btnEditMicroservice.Enabled = true;
            }
            else
            {
                txtMicroserviceName.Clear();
                txtMicroservicePath.Clear();
                chcbxFavorites.Checked = false;
                btnRemoveMicroservice.Enabled = false;
                btnEditMicroservice.Enabled = false;
            }
        }

        private void RefreshMicroserviceList()
        {
            if (_selectedCategory == null)
            {
                dgvMicroservices.DataSource = null;
                return;
            }

            dgvMicroservices.DataSource = null;
            dgvMicroservices.DataSource = _selectedCategory.Services;
        }

        private void dgvMicroservices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvMicroservices_SelectionChanged(sender, e);
        }
        #endregion

        private void toolbtnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            MessageBox.Show("Settings saved.");
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_areChangesMade)
            {
                var result = MessageBox.Show("You have unsaved changes. Do you want to save them?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveSettings();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chcbxMemoryWarnings.Checked)
            {
                lblMonitoring1.Enabled = true;
                lblMonitoring2.Enabled = true;
                lblMonitoring3.Enabled = true;
                lblMonitoring4.Enabled = true;
                numericConsumption.Enabled = true;
                numericTotalConsumption.Enabled = true;
            }
            else
            {
                lblMonitoring1.Enabled = false;
                lblMonitoring2.Enabled = false;
                lblMonitoring3.Enabled = false;
                lblMonitoring4.Enabled = false;
                numericConsumption.Enabled = false;
                numericTotalConsumption.Enabled = false;
            }

            _areChangesMade = true;
        }

        private void SaveSettings()
        {
            _settings.IsMonitored = chcbxMemoryWarnings.Checked;
            if (chcbxMemoryWarnings.Checked)
            {
                _settings.MaximumMemoryUsage = (int)numericTotalConsumption.Value;
                _settings.MaximumMemoryUsagePerMicroservice = (int)numericConsumption.Value;
            }

            _settings.AudibleWarning = chcbxAudibleWarning.Checked;
            _settings.LogLineLimit = (int)numericLogLineLimit.Value;
            _settings.FlushSequnece = (int)numericFlushSequence.Value;
            _settings.RestartOnError = chcbxRestartService.Checked;
            _settings.StartupDelay = (int)numericStartupDelay.Value;
            _settings.RestartLimit = comboBoxNumberOfRepeats.SelectedIndex + 1;
            _settings.IsLimitedOperation = checkBox1.Checked;
            _settings.MaxConcurrentStarts = (int)numericMaxInitialCount.Value;

            ConfigManager.SaveConfig(_settings);
            _areChangesMade = false;
        }

        private void InitializeSettings()
        {
            _settings = ConfigManager.LoadConfig();
            _settings.Categories ??= [];

            chcbxMemoryWarnings.Checked = _settings.IsMonitored;
            numericTotalConsumption.Value = _settings.MaximumMemoryUsage;
            numericConsumption.Value = _settings.MaximumMemoryUsagePerMicroservice;
            chcbxAudibleWarning.Checked = _settings.AudibleWarning;
            numericLogLineLimit.Value = _settings.LogLineLimit;
            numericFlushSequence.Value = _settings.FlushSequnece;
            chcbxRestartService.Checked = _settings.RestartOnError;
            numericStartupDelay.Value = _settings.StartupDelay;
            comboBoxNumberOfRepeats.SelectedIndex = _settings.RestartLimit is 0 ? 0 : _settings.RestartLimit - 1;
            checkBox1.Checked = _settings.IsLimitedOperation;
            numericMaxInitialCount.Value = _settings.MaxConcurrentStarts;

            _areChangesMade = false;
        }

        private void InitializeMicroserviceGrid()
        {
            dgvMicroservices.Columns.Clear();
            dgvMicroservices.AutoGenerateColumns = false;

            var colName = new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                DataPropertyName = "Name",
                Width = 300
            };

            var colPath = new DataGridViewTextBoxColumn
            {
                HeaderText = "Path",
                DataPropertyName = "Path",
                Width = 1200
            };

            dgvMicroservices.Columns.Add(colName);
            dgvMicroservices.Columns.Add(colPath);
        }

        private void importSettingsFromFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ConfigManager.ImportConfigFromJson(openFileDialog.FileName);
                        MessageBox.Show("Settings imported successfully.");
                        InitializeSettings();
                        RefreshCategoryList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error importing settings: {ex.Message}");
                    }
                }
            }
        }

        private void exportSettings_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        SaveSettings();
                        ConfigManager.ExportConfigToJson(_settings, saveFileDialog.FileName);
                        MessageBox.Show("Settings exported successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting settings: {ex.Message}");
                    }
                }
            }
        }

        private void chcbxRestartService_CheckedChanged(object sender, EventArgs e)
        {
            if (chcbxRestartService.Checked)
            {
                lblErrorHandling1.Enabled = true;
                lblErrorHandling2.Enabled = true;
                comboBoxNumberOfRepeats.Enabled = true;
                numericStartupDelay.Enabled = true;
            }
            else
            {
                lblErrorHandling1.Enabled = false;
                lblErrorHandling2.Enabled = false;
                comboBoxNumberOfRepeats.Enabled = false;
                numericStartupDelay.Enabled = false;
            }

            _areChangesMade = true;
        }

        private void numericStartupDelay_ValueChanged(object sender, EventArgs e)
        {
            _areChangesMade = true;
        }

        private void comboBoxNumberOfRepeats_ValueMemberChanged(object sender, EventArgs e)
        {
            _areChangesMade = true;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            _areChangesMade = true;

            if (checkBox1.Checked)
            {
                lblLimitedOperation.Enabled = true;
                numericMaxInitialCount.Enabled = true;
            }
            else
            {
                lblLimitedOperation.Enabled = false;
                numericMaxInitialCount.Enabled = false;
            }
        }
    }
}
