namespace PromoveoAddin.UserManagement
{
    partial class PublishingPlatformRole
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkModels = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxRole = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgdRoles = new System.Windows.Forms.DataGridView();
            this.tbcSettings = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsvAssignedUsers = new System.Windows.Forms.ListView();
            this.lsvAvailableUsers = new System.Windows.Forms.ListView();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnAssignSelected = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSelectRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbConfiguration = new System.Windows.Forms.ComboBox();
            this.configurationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.roleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fKConfigurationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleCBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdRoles)).BeginInit();
            this.tbcSettings.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleCBBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.chkModels);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cbxRole);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(482, 490);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Model Assignments";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(402, 449);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkModels
            // 
            this.chkModels.FormattingEnabled = true;
            this.chkModels.Location = new System.Drawing.Point(12, 49);
            this.chkModels.Name = "chkModels";
            this.chkModels.Size = new System.Drawing.Size(465, 394);
            this.chkModels.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Assign Models to the Role";
            // 
            // cbxRole
            // 
            this.cbxRole.DataSource = this.RoleCBBindingSource;
            this.cbxRole.FormattingEnabled = true;
            this.cbxRole.Location = new System.Drawing.Point(106, 3);
            this.cbxRole.Name = "cbxRole";
            this.cbxRole.Size = new System.Drawing.Size(371, 21);
            this.cbxRole.TabIndex = 1;
            this.cbxRole.SelectedIndexChanged += new System.EventHandler(this.cbxRole_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Role";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgdRoles);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(482, 490);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Roles";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgdRoles
            // 
            this.dgdRoles.AutoGenerateColumns = false;
            this.dgdRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fKConfigurationDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn});
            this.dgdRoles.DataSource = this.roleBindingSource;
            this.dgdRoles.Location = new System.Drawing.Point(4, 4);
            this.dgdRoles.Margin = new System.Windows.Forms.Padding(2);
            this.dgdRoles.Name = "dgdRoles";
            this.dgdRoles.RowTemplate.Height = 24;
            this.dgdRoles.Size = new System.Drawing.Size(474, 503);
            this.dgdRoles.TabIndex = 0;
            this.dgdRoles.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgdRoles_DataError);
            this.dgdRoles.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdRoles_RowLeave);
            this.dgdRoles.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdRoles_RowValidated);
            // 
            // tbcSettings
            // 
            this.tbcSettings.Controls.Add(this.tabPage1);
            this.tbcSettings.Controls.Add(this.tabPage2);
            this.tbcSettings.Controls.Add(this.tabPage3);
            this.tbcSettings.Location = new System.Drawing.Point(9, 35);
            this.tbcSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tbcSettings.Name = "tbcSettings";
            this.tbcSettings.SelectedIndex = 0;
            this.tbcSettings.Size = new System.Drawing.Size(490, 516);
            this.tbcSettings.TabIndex = 0;
            this.tbcSettings.SelectedIndexChanged += new System.EventHandler(this.tbcSettings_SelectedIndexChanged);
            this.tbcSettings.TabIndexChanged += new System.EventHandler(this.tbcSettings_TabIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.cmbSelectRole);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(482, 490);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "User Assignments";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsvAssignedUsers);
            this.groupBox1.Controls.Add(this.lsvAvailableUsers);
            this.groupBox1.Controls.Add(this.btnDeleteSelected);
            this.groupBox1.Controls.Add(this.btnAssignSelected);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(9, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 434);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Assign Users";
            // 
            // lsvAssignedUsers
            // 
            this.lsvAssignedUsers.FullRowSelect = true;
            this.lsvAssignedUsers.HideSelection = false;
            this.lsvAssignedUsers.Location = new System.Drawing.Point(269, 42);
            this.lsvAssignedUsers.Name = "lsvAssignedUsers";
            this.lsvAssignedUsers.Size = new System.Drawing.Size(192, 386);
            this.lsvAssignedUsers.TabIndex = 9;
            this.lsvAssignedUsers.UseCompatibleStateImageBehavior = false;
            this.lsvAssignedUsers.View = System.Windows.Forms.View.Details;
            // 
            // lsvAvailableUsers
            // 
            this.lsvAvailableUsers.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvAvailableUsers.FullRowSelect = true;
            this.lsvAvailableUsers.HideSelection = false;
            this.lsvAvailableUsers.Location = new System.Drawing.Point(10, 42);
            this.lsvAvailableUsers.Name = "lsvAvailableUsers";
            this.lsvAvailableUsers.Size = new System.Drawing.Size(192, 386);
            this.lsvAvailableUsers.TabIndex = 8;
            this.lsvAvailableUsers.UseCompatibleStateImageBehavior = false;
            this.lsvAvailableUsers.View = System.Windows.Forms.View.Details;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(212, 71);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(47, 23);
            this.btnDeleteSelected.TabIndex = 6;
            this.btnDeleteSelected.Text = "<";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnAssignSelected
            // 
            this.btnAssignSelected.Location = new System.Drawing.Point(212, 42);
            this.btnAssignSelected.Name = "btnAssignSelected";
            this.btnAssignSelected.Size = new System.Drawing.Size(47, 23);
            this.btnAssignSelected.TabIndex = 5;
            this.btnAssignSelected.Text = ">";
            this.btnAssignSelected.UseVisualStyleBackColor = true;
            this.btnAssignSelected.Click += new System.EventHandler(this.btnAssignSelected_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Assigned Users";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Available Users";
            // 
            // cmbSelectRole
            // 
            this.cmbSelectRole.DataSource = this.RoleCBBindingSource;
            this.cmbSelectRole.FormattingEnabled = true;
            this.cmbSelectRole.Location = new System.Drawing.Point(75, 6);
            this.cmbSelectRole.Name = "cmbSelectRole";
            this.cmbSelectRole.Size = new System.Drawing.Size(401, 21);
            this.cmbSelectRole.TabIndex = 4;
            this.cmbSelectRole.SelectedIndexChanged += new System.EventHandler(this.cmbSelectRole_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Select Role";
            // 
            // cmbConfiguration
            // 
            this.cmbConfiguration.DataSource = this.configurationBindingSource;
            this.cmbConfiguration.DisplayMember = "Name";
            this.cmbConfiguration.FormattingEnabled = true;
            this.cmbConfiguration.Location = new System.Drawing.Point(131, 6);
            this.cmbConfiguration.Margin = new System.Windows.Forms.Padding(2);
            this.cmbConfiguration.Name = "cmbConfiguration";
            this.cmbConfiguration.Size = new System.Drawing.Size(368, 21);
            this.cmbConfiguration.TabIndex = 3;
            this.cmbConfiguration.ValueMember = "Id";
            this.cmbConfiguration.SelectedIndexChanged += new System.EventHandler(this.cmbConfiguration_SelectedIndexChanged);
            // 
            // configurationBindingSource
            // 
            this.configurationBindingSource.DataSource = typeof(PromoveoAddin.ConfigurationService.Configuration);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Select the configuration:";
            // 
            // roleBindingSource
            // 
            this.roleBindingSource.DataSource = typeof(PromoveoAddin.PublishingPlatformRoleService.Role);
            // 
            // fKConfigurationDataGridViewTextBoxColumn
            // 
            this.fKConfigurationDataGridViewTextBoxColumn.DataPropertyName = "FK_Configuration";
            this.fKConfigurationDataGridViewTextBoxColumn.HeaderText = "FK_Configuration";
            this.fKConfigurationDataGridViewTextBoxColumn.Name = "fKConfigurationDataGridViewTextBoxColumn";
            this.fKConfigurationDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 250;
            // 
            // PublishingPlatformRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 558);
            this.Controls.Add(this.cmbConfiguration);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbcSettings);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PublishingPlatformRole";
            this.Text = "PublishingPlatformRole";
            this.Load += new System.EventHandler(this.PublishingPlatformRole_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgdRoles)).EndInit();
            this.tbcSettings.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleCBBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckedListBox chkModels;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgdRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabControl tbcSettings;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lsvAssignedUsers;
        private System.Windows.Forms.ListView lsvAvailableUsers;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnAssignSelected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSelectRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbConfiguration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource configurationBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fKConfigurationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource roleBindingSource;
        private System.Windows.Forms.BindingSource RoleCBBindingSource;
    }
}