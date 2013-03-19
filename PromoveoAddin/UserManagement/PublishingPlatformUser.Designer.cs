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
            this.tbpRoleAssignment = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsvAssignedUsers = new System.Windows.Forms.ListView();
            this.lsvAvailableUsers = new System.Windows.Forms.ListView();
            this.button4 = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnAssignSelected = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSelectRole = new System.Windows.Forms.ComboBox();
            this.bsSelectRole = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.publishingPlatformUserTableAdapter = new PromoveoAddin.Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter();
            this.publishingPlatformRoleTableAdapter = new PromoveoAddin.Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter();
            this.tbcUsers.SuspendLayout();
            this.tbpUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.promoveoDataSet)).BeginInit();
            this.tbpRoleAssignment.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSelectRole)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcUsers
            // 
            this.tbcUsers.Controls.Add(this.tbpUser);
            this.tbcUsers.Controls.Add(this.tbpRoleAssignment);
            this.tbcUsers.Location = new System.Drawing.Point(12, 12);
            this.tbcUsers.Name = "tbcUsers";
            this.tbcUsers.SelectedIndex = 0;
            this.tbcUsers.Size = new System.Drawing.Size(459, 346);
            this.tbcUsers.TabIndex = 0;
            this.tbcUsers.SelectedIndexChanged += new System.EventHandler(this.tbcUsers_SelectedIndexChanged);
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
            // tbpRoleAssignment
            // 
            this.tbpRoleAssignment.Controls.Add(this.groupBox1);
            this.tbpRoleAssignment.Controls.Add(this.cmbSelectRole);
            this.tbpRoleAssignment.Controls.Add(this.label1);
            this.tbpRoleAssignment.Location = new System.Drawing.Point(4, 22);
            this.tbpRoleAssignment.Name = "tbpRoleAssignment";
            this.tbpRoleAssignment.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRoleAssignment.Size = new System.Drawing.Size(451, 320);
            this.tbpRoleAssignment.TabIndex = 1;
            this.tbpRoleAssignment.Text = "Role Assignment";
            this.tbpRoleAssignment.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsvAssignedUsers);
            this.groupBox1.Controls.Add(this.lsvAvailableUsers);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.btnDeleteSelected);
            this.groupBox1.Controls.Add(this.btnAssignSelected);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 273);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Assign Users";
            // 
            // lsvAssignedUsers
            // 
            this.lsvAssignedUsers.FullRowSelect = true;
            this.lsvAssignedUsers.HideSelection = false;
            this.lsvAssignedUsers.Location = new System.Drawing.Point(248, 45);
            this.lsvAssignedUsers.Name = "lsvAssignedUsers";
            this.lsvAssignedUsers.Size = new System.Drawing.Size(179, 219);
            this.lsvAssignedUsers.TabIndex = 9;
            this.lsvAssignedUsers.UseCompatibleStateImageBehavior = false;
            this.lsvAssignedUsers.View = System.Windows.Forms.View.Details;
            // 
            // lsvAvailableUsers
            // 
            this.lsvAvailableUsers.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvAvailableUsers.FullRowSelect = true;
            this.lsvAvailableUsers.HideSelection = false;
            this.lsvAvailableUsers.Location = new System.Drawing.Point(10, 48);
            this.lsvAvailableUsers.Name = "lsvAvailableUsers";
            this.lsvAvailableUsers.Size = new System.Drawing.Size(179, 219);
            this.lsvAvailableUsers.TabIndex = 8;
            this.lsvAvailableUsers.UseCompatibleStateImageBehavior = false;
            this.lsvAvailableUsers.View = System.Windows.Forms.View.Details;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(195, 135);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "<<";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(195, 106);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(47, 23);
            this.btnDeleteSelected.TabIndex = 6;
            this.btnDeleteSelected.Text = "<";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnAssignSelected
            // 
            this.btnAssignSelected.Location = new System.Drawing.Point(195, 77);
            this.btnAssignSelected.Name = "btnAssignSelected";
            this.btnAssignSelected.Size = new System.Drawing.Size(47, 23);
            this.btnAssignSelected.TabIndex = 5;
            this.btnAssignSelected.Text = ">";
            this.btnAssignSelected.UseVisualStyleBackColor = true;
            this.btnAssignSelected.Click += new System.EventHandler(this.btnAssignSelected_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(195, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Assigned Users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Available Users";
            // 
            // cmbSelectRole
            // 
            this.cmbSelectRole.DataSource = this.bsSelectRole;
            this.cmbSelectRole.DisplayMember = "RoleName";
            this.cmbSelectRole.FormattingEnabled = true;
            this.cmbSelectRole.Location = new System.Drawing.Point(76, 7);
            this.cmbSelectRole.Name = "cmbSelectRole";
            this.cmbSelectRole.Size = new System.Drawing.Size(369, 21);
            this.cmbSelectRole.TabIndex = 1;
            this.cmbSelectRole.SelectedIndexChanged += new System.EventHandler(this.cmbSelectRole_SelectedIndexChanged);
            // 
            // bsSelectRole
            // 
            this.bsSelectRole.DataMember = "PublishingPlatformRole";
            this.bsSelectRole.DataSource = this.promoveoDataSet;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Role";
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
            this.tbpRoleAssignment.ResumeLayout(false);
            this.tbpRoleAssignment.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSelectRole)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcUsers;
        private System.Windows.Forms.TabPage tbpUser;
        private System.Windows.Forms.TabPage tbpRoleAssignment;
        private System.Windows.Forms.BindingSource bsUsers;
        private Data.PromoveoDataSet promoveoDataSet;
        private Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter publishingPlatformUserTableAdapter;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnAssignSelected;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSelectRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsSelectRole;
        private Data.PromoveoDataSetTableAdapters.PublishingPlatformRoleTableAdapter publishingPlatformRoleTableAdapter;
        private System.Windows.Forms.ListView lsvAssignedUsers;
        private System.Windows.Forms.ListView lsvAvailableUsers;
    }
}