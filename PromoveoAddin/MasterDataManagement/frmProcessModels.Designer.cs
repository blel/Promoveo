namespace PromoveoAddin.MasterDataManagement
{
    partial class frmProcessModels
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbConfiguration = new System.Windows.Forms.ComboBox();
            this.configurationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.promoveoDataSet = new PromoveoAddin.Data.PromoveoDataSet();
            this.btnCreateModels = new System.Windows.Forms.Button();
            this.dgvModels = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processModelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publishingVersionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKPublishingPlatformUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.publishingPlatformUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fKConfigurationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.processModelTableAdapter = new PromoveoAddin.Data.PromoveoDataSetTableAdapters.ProcessModelTableAdapter();
            this.publishingPlatformUserTableAdapter = new PromoveoAddin.Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter();
            this.configurationTableAdapter = new PromoveoAddin.Data.PromoveoDataSetTableAdapters.ConfigurationTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.promoveoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.publishingPlatformUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuration";
            // 
            // cmbConfiguration
            // 
            this.cmbConfiguration.DataSource = this.configurationBindingSource;
            this.cmbConfiguration.DisplayMember = "Name";
            this.cmbConfiguration.FormattingEnabled = true;
            this.cmbConfiguration.Location = new System.Drawing.Point(88, 10);
            this.cmbConfiguration.Name = "cmbConfiguration";
            this.cmbConfiguration.Size = new System.Drawing.Size(316, 21);
            this.cmbConfiguration.TabIndex = 1;
            this.cmbConfiguration.ValueMember = "Id";
            this.cmbConfiguration.SelectedIndexChanged += new System.EventHandler(this.cmbConfiguration_SelectedIndexChanged);
            // 
            // configurationBindingSource
            // 
            this.configurationBindingSource.DataMember = "Configuration";
            this.configurationBindingSource.DataSource = this.promoveoDataSet;
            // 
            // promoveoDataSet
            // 
            this.promoveoDataSet.DataSetName = "PromoveoDataSet";
            this.promoveoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnCreateModels
            // 
            this.btnCreateModels.Location = new System.Drawing.Point(314, 37);
            this.btnCreateModels.Name = "btnCreateModels";
            this.btnCreateModels.Size = new System.Drawing.Size(90, 23);
            this.btnCreateModels.TabIndex = 2;
            this.btnCreateModels.Text = "Create Models";
            this.btnCreateModels.UseVisualStyleBackColor = true;
            this.btnCreateModels.Click += new System.EventHandler(this.btnCreateModels_Click);
            // 
            // dgvModels
            // 
            this.dgvModels.AllowUserToAddRows = false;
            this.dgvModels.AllowUserToDeleteRows = false;
            this.dgvModels.AutoGenerateColumns = false;
            this.dgvModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.processModelDataGridViewTextBoxColumn,
            this.publishingVersionDataGridViewTextBoxColumn,
            this.fKPublishingPlatformUserDataGridViewTextBoxColumn,
            this.fKConfigurationDataGridViewTextBoxColumn});
            this.dgvModels.DataSource = this.processModelBindingSource;
            this.dgvModels.Location = new System.Drawing.Point(16, 75);
            this.dgvModels.Name = "dgvModels";
            this.dgvModels.Size = new System.Drawing.Size(388, 278);
            this.dgvModels.TabIndex = 3;
            this.dgvModels.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModels_RowValidated);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // processModelDataGridViewTextBoxColumn
            // 
            this.processModelDataGridViewTextBoxColumn.DataPropertyName = "ProcessModel";
            this.processModelDataGridViewTextBoxColumn.HeaderText = "ProcessModel";
            this.processModelDataGridViewTextBoxColumn.Name = "processModelDataGridViewTextBoxColumn";
            // 
            // publishingVersionDataGridViewTextBoxColumn
            // 
            this.publishingVersionDataGridViewTextBoxColumn.DataPropertyName = "PublishingVersion";
            this.publishingVersionDataGridViewTextBoxColumn.HeaderText = "PublishingVersion";
            this.publishingVersionDataGridViewTextBoxColumn.Name = "publishingVersionDataGridViewTextBoxColumn";
            this.publishingVersionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fKPublishingPlatformUserDataGridViewTextBoxColumn
            // 
            this.fKPublishingPlatformUserDataGridViewTextBoxColumn.DataPropertyName = "FK_PublishingPlatformUser";
            this.fKPublishingPlatformUserDataGridViewTextBoxColumn.DataSource = this.publishingPlatformUserBindingSource;
            this.fKPublishingPlatformUserDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.fKPublishingPlatformUserDataGridViewTextBoxColumn.HeaderText = "Owner";
            this.fKPublishingPlatformUserDataGridViewTextBoxColumn.Name = "fKPublishingPlatformUserDataGridViewTextBoxColumn";
            this.fKPublishingPlatformUserDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fKPublishingPlatformUserDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fKPublishingPlatformUserDataGridViewTextBoxColumn.ValueMember = "Id";
            // 
            // publishingPlatformUserBindingSource
            // 
            this.publishingPlatformUserBindingSource.DataMember = "PublishingPlatformUser";
            this.publishingPlatformUserBindingSource.DataSource = this.promoveoDataSet;
            // 
            // fKConfigurationDataGridViewTextBoxColumn
            // 
            this.fKConfigurationDataGridViewTextBoxColumn.DataPropertyName = "FK_Configuration";
            this.fKConfigurationDataGridViewTextBoxColumn.HeaderText = "FK_Configuration";
            this.fKConfigurationDataGridViewTextBoxColumn.Name = "fKConfigurationDataGridViewTextBoxColumn";
            this.fKConfigurationDataGridViewTextBoxColumn.Visible = false;
            // 
            // processModelBindingSource
            // 
            this.processModelBindingSource.DataMember = "ProcessModel";
            this.processModelBindingSource.DataSource = this.promoveoDataSet;
            // 
            // processModelTableAdapter
            // 
            this.processModelTableAdapter.ClearBeforeFill = true;
            // 
            // publishingPlatformUserTableAdapter
            // 
            this.publishingPlatformUserTableAdapter.ClearBeforeFill = true;
            // 
            // configurationTableAdapter
            // 
            this.configurationTableAdapter.ClearBeforeFill = true;
            // 
            // frmProcessModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 365);
            this.Controls.Add(this.dgvModels);
            this.Controls.Add(this.btnCreateModels);
            this.Controls.Add(this.cmbConfiguration);
            this.Controls.Add(this.label1);
            this.Name = "frmProcessModels";
            this.Text = "frmProcessModels";
            this.Load += new System.EventHandler(this.frmProcessModels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.promoveoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.publishingPlatformUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbConfiguration;
        private System.Windows.Forms.Button btnCreateModels;
        private System.Windows.Forms.DataGridView dgvModels;
        private Data.PromoveoDataSet promoveoDataSet;
        private System.Windows.Forms.BindingSource processModelBindingSource;
        private Data.PromoveoDataSetTableAdapters.ProcessModelTableAdapter processModelTableAdapter;
        private System.Windows.Forms.BindingSource publishingPlatformUserBindingSource;
        private Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter publishingPlatformUserTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn processModelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn publishingVersionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn fKPublishingPlatformUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fKConfigurationDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource configurationBindingSource;
        private Data.PromoveoDataSetTableAdapters.ConfigurationTableAdapter configurationTableAdapter;
    }
}