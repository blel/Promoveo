namespace PromoveoAddin
{
    partial class frmAcknowledgeRequest
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.configurationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            
            this.label1 = new System.Windows.Forms.Label();
            
            this.btnSendRequest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).BeginInit();
            
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.configurationBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(88, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(227, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "Id";
            // 
            // configurationBindingSource
            // 
            this.configurationBindingSource.DataMember = "Configuration";
            
            // 
            // promoveoDataSet
            // 
    
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Configuration";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // configurationTableAdapter
            // 
         
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Location = new System.Drawing.Point(224, 227);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(91, 23);
            this.btnSendRequest.TabIndex = 2;
            this.btnSendRequest.Text = "Send Request";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // frmAcknowledgeRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 262);
            this.Controls.Add(this.btnSendRequest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "frmAcknowledgeRequest";
            this.Text = "frmAcknowledgeRequest";
            this.Load += new System.EventHandler(this.frmAcknowledgeRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).EndInit();
 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        
        private System.Windows.Forms.BindingSource configurationBindingSource;
        
        private System.Windows.Forms.Button btnSendRequest;
    }
}