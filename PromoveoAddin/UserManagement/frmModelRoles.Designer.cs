namespace PromoveoAddin.UserManagement
{
    partial class frmModelRoles
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbConfiguration = new System.Windows.Forms.ComboBox();
            this.tbcModelUsers = new System.Windows.Forms.TabControl();
            this.tbpModelRoles = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbpUserAssignment = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbModelUserRole = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsvAssignedUsers = new System.Windows.Forms.ListView();
            this.lsvAvailableUsers = new System.Windows.Forms.ListView();
            this.button4 = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnAssignSelected = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbcModelUsers.SuspendLayout();
            this.tbpModelRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tbpUserAssignment.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the configuration:";
            // 
            // cmbConfiguration
            // 
            this.cmbConfiguration.FormattingEnabled = true;
            this.cmbConfiguration.Location = new System.Drawing.Point(180, 10);
            this.cmbConfiguration.Name = "cmbConfiguration";
            this.cmbConfiguration.Size = new System.Drawing.Size(427, 24);
            this.cmbConfiguration.TabIndex = 1;
            // 
            // tbcModelUsers
            // 
            this.tbcModelUsers.Controls.Add(this.tbpModelRoles);
            this.tbcModelUsers.Controls.Add(this.tbpUserAssignment);
            this.tbcModelUsers.Location = new System.Drawing.Point(16, 40);
            this.tbcModelUsers.Name = "tbcModelUsers";
            this.tbcModelUsers.SelectedIndex = 0;
            this.tbcModelUsers.Size = new System.Drawing.Size(591, 458);
            this.tbcModelUsers.TabIndex = 2;
            // 
            // tbpModelRoles
            // 
            this.tbpModelRoles.Controls.Add(this.dataGridView1);
            this.tbpModelRoles.Location = new System.Drawing.Point(4, 25);
            this.tbpModelRoles.Name = "tbpModelRoles";
            this.tbpModelRoles.Padding = new System.Windows.Forms.Padding(3);
            this.tbpModelRoles.Size = new System.Drawing.Size(583, 429);
            this.tbpModelRoles.TabIndex = 0;
            this.tbpModelRoles.Text = "Model User Roles";
            this.tbpModelRoles.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(571, 417);
            this.dataGridView1.TabIndex = 0;
            // 
            // tbpUserAssignment
            // 
            this.tbpUserAssignment.Controls.Add(this.groupBox1);
            this.tbpUserAssignment.Controls.Add(this.cmbModelUserRole);
            this.tbpUserAssignment.Controls.Add(this.label2);
            this.tbpUserAssignment.Location = new System.Drawing.Point(4, 25);
            this.tbpUserAssignment.Name = "tbpUserAssignment";
            this.tbpUserAssignment.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUserAssignment.Size = new System.Drawing.Size(583, 429);
            this.tbpUserAssignment.TabIndex = 1;
            this.tbpUserAssignment.Text = "User to Model Roles Assignment";
            this.tbpUserAssignment.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Model User Role";
            // 
            // cmbModelUserRole
            // 
            this.cmbModelUserRole.FormattingEnabled = true;
            this.cmbModelUserRole.Location = new System.Drawing.Point(167, 7);
            this.cmbModelUserRole.Name = "cmbModelUserRole";
            this.cmbModelUserRole.Size = new System.Drawing.Size(410, 24);
            this.cmbModelUserRole.TabIndex = 1;
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
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(6, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 386);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Assign Users";
            // 
            // lsvAssignedUsers
            // 
            this.lsvAssignedUsers.FullRowSelect = true;
            this.lsvAssignedUsers.HideSelection = false;
            this.lsvAssignedUsers.Location = new System.Drawing.Point(325, 40);
            this.lsvAssignedUsers.Margin = new System.Windows.Forms.Padding(4);
            this.lsvAssignedUsers.Name = "lsvAssignedUsers";
            this.lsvAssignedUsers.Size = new System.Drawing.Size(237, 269);
            this.lsvAssignedUsers.TabIndex = 17;
            this.lsvAssignedUsers.UseCompatibleStateImageBehavior = false;
            this.lsvAssignedUsers.View = System.Windows.Forms.View.Details;
            // 
            // lsvAvailableUsers
            // 
            this.lsvAvailableUsers.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvAvailableUsers.FullRowSelect = true;
            this.lsvAvailableUsers.HideSelection = false;
            this.lsvAvailableUsers.Location = new System.Drawing.Point(7, 44);
            this.lsvAvailableUsers.Margin = new System.Windows.Forms.Padding(4);
            this.lsvAvailableUsers.Name = "lsvAvailableUsers";
            this.lsvAvailableUsers.Size = new System.Drawing.Size(237, 269);
            this.lsvAvailableUsers.TabIndex = 16;
            this.lsvAvailableUsers.UseCompatibleStateImageBehavior = false;
            this.lsvAvailableUsers.View = System.Windows.Forms.View.Details;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(254, 151);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(63, 28);
            this.button4.TabIndex = 15;
            this.button4.Text = "<<";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(254, 115);
            this.btnDeleteSelected.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(63, 28);
            this.btnDeleteSelected.TabIndex = 14;
            this.btnDeleteSelected.Text = "<";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            // 
            // btnAssignSelected
            // 
            this.btnAssignSelected.Location = new System.Drawing.Point(254, 80);
            this.btnAssignSelected.Margin = new System.Windows.Forms.Padding(4);
            this.btnAssignSelected.Name = "btnAssignSelected";
            this.btnAssignSelected.Size = new System.Drawing.Size(63, 28);
            this.btnAssignSelected.TabIndex = 13;
            this.btnAssignSelected.Text = ">";
            this.btnAssignSelected.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 44);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 28);
            this.button1.TabIndex = 12;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Assigned Users";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Available Users";
            // 
            // frmModelRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 510);
            this.Controls.Add(this.tbcModelUsers);
            this.Controls.Add(this.cmbConfiguration);
            this.Controls.Add(this.label1);
            this.Name = "frmModelRoles";
            this.Text = "frmModelRoles";
            this.tbcModelUsers.ResumeLayout(false);
            this.tbpModelRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tbpUserAssignment.ResumeLayout(false);
            this.tbpUserAssignment.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbConfiguration;
        private System.Windows.Forms.TabControl tbcModelUsers;
        private System.Windows.Forms.TabPage tbpModelRoles;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tbpUserAssignment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbModelUserRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvAssignedUsers;
        private System.Windows.Forms.ListView lsvAvailableUsers;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnAssignSelected;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}