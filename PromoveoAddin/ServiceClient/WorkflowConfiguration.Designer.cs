namespace PromoveoAddin
{
    partial class WorkflowConfiguration
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtWorkflowServiceAddress = new System.Windows.Forms.TextBox();
            this.txtWorkflowName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrintIcon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Workflow Service Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Workflow Name";
            // 
            // txtWorkflowServiceAddress
            // 
            this.txtWorkflowServiceAddress.Location = new System.Drawing.Point(192, 13);
            this.txtWorkflowServiceAddress.Name = "txtWorkflowServiceAddress";
            this.txtWorkflowServiceAddress.Size = new System.Drawing.Size(359, 22);
            this.txtWorkflowServiceAddress.TabIndex = 2;
            // 
            // txtWorkflowName
            // 
            this.txtWorkflowName.Location = new System.Drawing.Point(192, 41);
            this.txtWorkflowName.Name = "txtWorkflowName";
            this.txtWorkflowName.Size = new System.Drawing.Size(359, 22);
            this.txtWorkflowName.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(462, 209);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(89, 32);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(367, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtExportPath
            // 
            this.txtExportPath.Location = new System.Drawing.Point(192, 109);
            this.txtExportPath.Name = "txtExportPath";
            this.txtExportPath.Size = new System.Drawing.Size(359, 22);
            this.txtExportPath.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Export Path";
            // 
            // txtPrintIcon
            // 
            this.txtPrintIcon.Location = new System.Drawing.Point(192, 81);
            this.txtPrintIcon.Name = "txtPrintIcon";
            this.txtPrintIcon.Size = new System.Drawing.Size(359, 22);
            this.txtPrintIcon.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Print Icon";
            // 
            // WorkflowConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 253);
            this.Controls.Add(this.txtPrintIcon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtExportPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtWorkflowName);
            this.Controls.Add(this.txtWorkflowServiceAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WorkflowConfiguration";
            this.Text = "WorkflowConfiguration";
            this.Activated += new System.EventHandler(this.WorkflowConfiguration_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWorkflowServiceAddress;
        private System.Windows.Forms.TextBox txtWorkflowName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtExportPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrintIcon;
        private System.Windows.Forms.Label label4;
    }
}