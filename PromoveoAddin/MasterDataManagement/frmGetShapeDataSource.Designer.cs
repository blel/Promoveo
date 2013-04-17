namespace PromoveoAddin.MasterDataManagement
{
    partial class frmGetShapeDataSource
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.txtModelUserRoleView = new System.Windows.Forms.TextBox();
            this.txtModelOwnerView = new System.Windows.Forms.TextBox();
            this.btnGetShapeData = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbConfiguration = new System.Windows.Forms.ComboBox();

            this.configurationBindingSource = new System.Windows.Forms.BindingSource(this.components);


            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Model User Role View";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Model Owner View";
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(148, 6);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(284, 20);
            this.txtDBServer.TabIndex = 4;
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(148, 32);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(284, 20);
            this.txtDBName.TabIndex = 5;
            // 
            // txtModelUserRoleView
            // 
            this.txtModelUserRoleView.Location = new System.Drawing.Point(148, 58);
            this.txtModelUserRoleView.Name = "txtModelUserRoleView";
            this.txtModelUserRoleView.Size = new System.Drawing.Size(284, 20);
            this.txtModelUserRoleView.TabIndex = 6;
            // 
            // txtModelOwnerView
            // 
            this.txtModelOwnerView.Location = new System.Drawing.Point(148, 84);
            this.txtModelOwnerView.Name = "txtModelOwnerView";
            this.txtModelOwnerView.Size = new System.Drawing.Size(284, 20);
            this.txtModelOwnerView.TabIndex = 7;
            // 
            // btnGetShapeData
            // 
            this.btnGetShapeData.Location = new System.Drawing.Point(330, 142);
            this.btnGetShapeData.Name = "btnGetShapeData";
            this.btnGetShapeData.Size = new System.Drawing.Size(102, 23);
            this.btnGetShapeData.TabIndex = 8;
            this.btnGetShapeData.Text = "Get Shape Data";
            this.btnGetShapeData.UseVisualStyleBackColor = true;
            this.btnGetShapeData.Click += new System.EventHandler(this.btnGetShapeData_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Configuration";
            // 
            // cmbConfiguration
            // 
            this.cmbConfiguration.DataSource = this.configurationBindingSource;
            this.cmbConfiguration.DisplayMember = "Name";
            this.cmbConfiguration.FormattingEnabled = true;
            this.cmbConfiguration.Location = new System.Drawing.Point(148, 110);
            this.cmbConfiguration.Name = "cmbConfiguration";
            this.cmbConfiguration.Size = new System.Drawing.Size(284, 21);
            this.cmbConfiguration.TabIndex = 10;
            this.cmbConfiguration.ValueMember = "Id";
            // 
            // promoveoDataSet
            // 

            // 
            // configurationBindingSource
            // 
            this.configurationBindingSource.DataMember = "Configuration";

            // 
            // configurationTableAdapter
            // 

            // 
            // frmGetShapeDataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 208);
            this.Controls.Add(this.cmbConfiguration);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGetShapeData);
            this.Controls.Add(this.txtModelOwnerView);
            this.Controls.Add(this.txtModelUserRoleView);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.txtDBServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmGetShapeDataSource";
            this.Text = "frmGetShapeDataSource";
            this.Load += new System.EventHandler(this.frmGetShapeDataSource_Load);

            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDBServer;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.TextBox txtModelUserRoleView;
        private System.Windows.Forms.TextBox txtModelOwnerView;
        private System.Windows.Forms.Button btnGetShapeData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbConfiguration;

        private System.Windows.Forms.BindingSource configurationBindingSource;

    }
}