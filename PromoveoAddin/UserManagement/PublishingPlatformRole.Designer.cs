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
            this.bsPublishingRole = new System.Windows.Forms.BindingSource(this.components);
            this.promoveoDataSet = new PromoveoAddin.Data.PromoveoDataSet();
            this.publishingPlatformRoleTableAdapter = new PromoveoAddin.Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter();
            this.bsCbRoles = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxRole = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkModels = new System.Windows.Forms.CheckedListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgdRoles = new System.Windows.Forms.DataGridView();
            this.roleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbcSettings = new System.Windows.Forms.TabControl();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsPublishingRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.promoveoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCbRoles)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdRoles)).BeginInit();
            this.tbcSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsPublishingRole
            // 
            this.bsPublishingRole.DataMember = "PublishingPlatformRole";
            this.bsPublishingRole.DataSource = this.promoveoDataSet;
            // 
            // promoveoDataSet
            // 
            this.promoveoDataSet.DataSetName = "PromoveoDataSet";
            this.promoveoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // publishingPlatformRoleTableAdapter
            // 
            this.publishingPlatformRoleTableAdapter.ClearBeforeFill = true;
            // 
            // bsCbRoles
            // 
            this.bsCbRoles.DataMember = "PublishingPlatformRole";
            this.bsCbRoles.DataSource = this.promoveoDataSet;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.chkModels);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cbxRole);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(482, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Model Assignments";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // cbxRole
            // 
            this.cbxRole.DataSource = this.bsCbRoles;
            this.cbxRole.DisplayMember = "RoleName";
            this.cbxRole.FormattingEnabled = true;
            this.cbxRole.Location = new System.Drawing.Point(106, 3);
            this.cbxRole.Name = "cbxRole";
            this.cbxRole.Size = new System.Drawing.Size(371, 21);
            this.cbxRole.TabIndex = 1;
            this.cbxRole.SelectedIndexChanged += new System.EventHandler(this.cbxRole_SelectedIndexChanged);
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
            // chkModels
            // 
            this.chkModels.FormattingEnabled = true;
            this.chkModels.Location = new System.Drawing.Point(12, 49);
            this.chkModels.Name = "chkModels";
            this.chkModels.Size = new System.Drawing.Size(465, 184);
            this.chkModels.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(402, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgdRoles);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(482, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Roles";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgdRoles
            // 
            this.dgdRoles.AutoGenerateColumns = false;
            this.dgdRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.roleNameDataGridViewTextBoxColumn});
            this.dgdRoles.DataSource = this.bsPublishingRole;
            this.dgdRoles.Location = new System.Drawing.Point(4, 4);
            this.dgdRoles.Margin = new System.Windows.Forms.Padding(2);
            this.dgdRoles.Name = "dgdRoles";
            this.dgdRoles.RowTemplate.Height = 24;
            this.dgdRoles.Size = new System.Drawing.Size(474, 503);
            this.dgdRoles.TabIndex = 0;
            this.dgdRoles.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdRoles_RowLeave);
            // 
            // roleNameDataGridViewTextBoxColumn
            // 
            this.roleNameDataGridViewTextBoxColumn.DataPropertyName = "RoleName";
            this.roleNameDataGridViewTextBoxColumn.HeaderText = "RoleName";
            this.roleNameDataGridViewTextBoxColumn.Name = "roleNameDataGridViewTextBoxColumn";
            this.roleNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // tbcSettings
            // 
            this.tbcSettings.Controls.Add(this.tabPage1);
            this.tbcSettings.Controls.Add(this.tabPage2);
            this.tbcSettings.Location = new System.Drawing.Point(9, 10);
            this.tbcSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tbcSettings.Name = "tbcSettings";
            this.tbcSettings.SelectedIndex = 0;
            this.tbcSettings.Size = new System.Drawing.Size(490, 537);
            this.tbcSettings.TabIndex = 0;
            this.tbcSettings.SelectedIndexChanged += new System.EventHandler(this.tbcSettings_SelectedIndexChanged);
            this.tbcSettings.TabIndexChanged += new System.EventHandler(this.tbcSettings_TabIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Assign Users to the Role";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 265);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(465, 212);
            this.listBox1.TabIndex = 6;
            // 
            // PublishingPlatformRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 558);
            this.Controls.Add(this.tbcSettings);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PublishingPlatformRole";
            this.Text = "PublishingPlatformRole";
            this.Load += new System.EventHandler(this.PublishingPlatformRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsPublishingRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.promoveoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCbRoles)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgdRoles)).EndInit();
            this.tbcSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsPublishingRole;
        private Data.PromoveoDataSet promoveoDataSet;
        private Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter publishingPlatformRoleTableAdapter;
        private System.Windows.Forms.BindingSource bsCbRoles;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
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
    }
}