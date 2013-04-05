namespace PromoveoAddin.ServiceClient
{
    partial class frmListWebservice
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
            this.txtServiceAddress = new System.Windows.Forms.TextBox();
            this.txtListName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetList = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service Address";
            // 
            // txtServiceAddress
            // 
            this.txtServiceAddress.Location = new System.Drawing.Point(104, 13);
            this.txtServiceAddress.Name = "txtServiceAddress";
            this.txtServiceAddress.Size = new System.Drawing.Size(335, 20);
            this.txtServiceAddress.TabIndex = 1;
            // 
            // txtListName
            // 
            this.txtListName.Location = new System.Drawing.Point(104, 39);
            this.txtListName.Name = "txtListName";
            this.txtListName.Size = new System.Drawing.Size(335, 20);
            this.txtListName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "List Name";
            // 
            // btnGetList
            // 
            this.btnGetList.Location = new System.Drawing.Point(361, 227);
            this.btnGetList.Name = "btnGetList";
            this.btnGetList.Size = new System.Drawing.Size(75, 23);
            this.btnGetList.TabIndex = 4;
            this.btnGetList.Text = "Get List";
            this.btnGetList.UseVisualStyleBackColor = true;
            this.btnGetList.Click += new System.EventHandler(this.btnGetList_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(16, 66);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(420, 155);
            this.txtResult.TabIndex = 5;
            // 
            // frmListWebservice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 262);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGetList);
            this.Controls.Add(this.txtListName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServiceAddress);
            this.Controls.Add(this.label1);
            this.Name = "frmListWebservice";
            this.Text = "frmListWebservice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServiceAddress;
        private System.Windows.Forms.TextBox txtListName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetList;
        private System.Windows.Forms.TextBox txtResult;
    }
}