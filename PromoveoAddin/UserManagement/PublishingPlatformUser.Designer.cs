namespace PromoveoAddin.UserManagement
{
    partial class PublishingPlatformUser
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
            this.tbcUsers = new System.Windows.Forms.TabControl();
            this.tbpUser = new System.Windows.Forms.TabPage();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsUsers = new System.Windows.Forms.BindingSource(this.components);
            this.promoveoDataSet = new PromoveoAddin.Data.PromoveoDataSet();
            this.bsSelectRole = new System.Windows.Forms.BindingSource(this.components);
            this.publishingPlatformUserTableAdapter = new PromoveoAddin.Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter();
            this.publishingPlatformRoleTableAdapter = new PromoveoAddin.Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter();
            this.tbcUsers.SuspendLayout();
            this.tbpUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.promoveoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSelectRole)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcUsers
            // 
            this.tbcUsers.Controls.Add(this.tbpUser);
            this.tbcUsers.Location = new System.Drawing.Point(12, 12);
            this.tbcUsers.Name = "tbcUsers";
            this.tbcUsers.SelectedIndex = 0;
            this.tbcUsers.Size = new System.Drawing.Size(459, 346);
            this.tbcUsers.TabIndex = 0;

            // 
            // tbpUser
            // 
            this.tbpUser.Controls.Add(this.dgvUsers);
            this.tbpUser.Location = new System.Drawing.Point(4, 22);
            this.tbpUser.Name = "tbpUser";
            this.tbpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUser.Size = new System.Drawing.Size(451, 320);
            this.tbpUser.TabIndex = 0;
            this.tbpUser.Text = "User";
            this.tbpUser.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AutoGenerateColumns = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.shortnameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.dgvUsers.DataSource = this.bsUsers;
            this.dgvUsers.Location = new System.Drawing.Point(6, 7);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(438, 307);
            this.dgvUsers.TabIndex = 1;
            this.dgvUsers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellEndEdit);
            this.dgvUsers.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellLeave);
            this.dgvUsers.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_RowLeave);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // shortnameDataGridViewTextBoxColumn
            // 
            this.shortnameDataGridViewTextBoxColumn.DataPropertyName = "Shortname";
            this.shortnameDataGridViewTextBoxColumn.HeaderText = "Shortname";
            this.shortnameDataGridViewTextBoxColumn.Name = "shortnameDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // bsUsers
            // 
            this.bsUsers.DataMember = "PublishingPlatformUser";
            this.bsUsers.DataSource = this.promoveoDataSet;
            // 
            // promoveoDataSet
            // 
            this.promoveoDataSet.DataSetName = "PromoveoDataSet";
            this.promoveoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsSelectRole
            // 
            this.bsSelectRole.DataMember = "PublishingPlatformRole";
            this.bsSelectRole.DataSource = this.promoveoDataSet;
            // 
            // publishingPlatformUserTableAdapter
            // 
            this.publishingPlatformUserTableAdapter.ClearBeforeFill = true;
            // 
            // publishingPlatformRoleTableAdapter
            // 
            this.publishingPlatformRoleTableAdapter.ClearBeforeFill = true;
            // 
            // PublishingPlatformUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 370);
            this.Controls.Add(this.tbcUsers);
            this.Name = "PublishingPlatformUser";
            this.Text = "PublishingPlatformUser";
            this.Load += new System.EventHandler(this.PublishingPlatformUser_Load);
            this.tbcUsers.ResumeLayout(false);
            this.tbpUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.promoveoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSelectRole)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcUsers;
        private System.Windows.Forms.TabPage tbpUser;
        private System.Windows.Forms.BindingSource bsUsers;
        private Data.PromoveoDataSet promoveoDataSet;
        private Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter publishingPlatformUserTableAdapter;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsSelectRole;
        private Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter publishingPlatformRoleTableAdapter;
    }
}