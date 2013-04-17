namespace PromoveoAddin
{
    partial class frmPublishDialog
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbConfiguration = new System.Windows.Forms.ComboBox();
            this.configurationBindingSource = new System.Windows.Forms.BindingSource(this.components);

            this.chkAddModels = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.bgrWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).BeginInit();

            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 30);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Please select the configuration you want to use for this publish:";
            // 
            // cmbConfiguration
            // 
            this.cmbConfiguration.DataSource = this.configurationBindingSource;
            this.cmbConfiguration.DisplayMember = "Name";
            this.cmbConfiguration.FormattingEnabled = true;
            this.cmbConfiguration.Location = new System.Drawing.Point(13, 50);
            this.cmbConfiguration.Name = "cmbConfiguration";
            this.cmbConfiguration.Size = new System.Drawing.Size(259, 21);
            this.cmbConfiguration.TabIndex = 1;
            this.cmbConfiguration.ValueMember = "Id";
            // 
            // configurationBindingSource
            // 


            // 
            // promoveoDataSet
            // 

            // 
            // configurationTableAdapter
            // 

            // 
            // chkAddModels
            // 
            this.chkAddModels.AutoSize = true;
            this.chkAddModels.Location = new System.Drawing.Point(13, 78);
            this.chkAddModels.Name = "chkAddModels";
            this.chkAddModels.Size = new System.Drawing.Size(220, 17);
            this.chkAddModels.TabIndex = 2;
            this.chkAddModels.Text = "Add new process models to configuration";
            this.chkAddModels.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(197, 227);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(13, 154);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(259, 23);
            this.pgbProgress.TabIndex = 4;
            // 
            // frmPublishDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chkAddModels);
            this.Controls.Add(this.cmbConfiguration);
            this.Controls.Add(this.textBox1);
            this.Name = "frmPublishDialog";
            this.Text = "frmPublishDialog";
            this.Load += new System.EventHandler(this.frmPublishDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbConfiguration;

        private System.Windows.Forms.BindingSource configurationBindingSource;

        private System.Windows.Forms.CheckBox chkAddModels;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.ComponentModel.BackgroundWorker bgrWorker;

    }
}