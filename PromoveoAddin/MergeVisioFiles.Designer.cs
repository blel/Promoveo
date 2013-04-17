namespace PromoveoAddin
{
    partial class MergeVisioFiles
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
            this.lbFilesToMerge = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.rdbExistingFile = new System.Windows.Forms.RadioButton();
            this.rdbNewFile = new System.Windows.Forms.RadioButton();
            this.chkReplacePages = new System.Windows.Forms.CheckBox();
            this.chkCreateVersions = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbConfiguration = new System.Windows.Forms.ComboBox();
            this.configurationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFilesToMerge
            // 
            this.lbFilesToMerge.FormattingEnabled = true;
            this.lbFilesToMerge.Location = new System.Drawing.Point(9, 36);
            this.lbFilesToMerge.Margin = new System.Windows.Forms.Padding(2);
            this.lbFilesToMerge.Name = "lbFilesToMerge";
            this.lbFilesToMerge.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbFilesToMerge.Size = new System.Drawing.Size(342, 303);
            this.lbFilesToMerge.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Files to merge:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(274, 343);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 31);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(9, 343);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(74, 31);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(274, 584);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(74, 31);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(8, 584);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 31);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtTarget);
            this.groupBox1.Controls.Add(this.rdbExistingFile);
            this.groupBox1.Controls.Add(this.rdbNewFile);
            this.groupBox1.Location = new System.Drawing.Point(9, 389);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 111);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Merge into:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(265, 62);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(74, 31);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(7, 68);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(253, 20);
            this.txtTarget.TabIndex = 2;
            // 
            // rdbExistingFile
            // 
            this.rdbExistingFile.AutoSize = true;
            this.rdbExistingFile.Location = new System.Drawing.Point(7, 44);
            this.rdbExistingFile.Name = "rdbExistingFile";
            this.rdbExistingFile.Size = new System.Drawing.Size(80, 17);
            this.rdbExistingFile.TabIndex = 1;
            this.rdbExistingFile.Text = "Existing File";
            this.rdbExistingFile.UseVisualStyleBackColor = true;
            this.rdbExistingFile.CheckedChanged += new System.EventHandler(this.rdbExistingFile_CheckedChanged);
            // 
            // rdbNewFile
            // 
            this.rdbNewFile.AutoSize = true;
            this.rdbNewFile.Checked = true;
            this.rdbNewFile.Location = new System.Drawing.Point(7, 20);
            this.rdbNewFile.Name = "rdbNewFile";
            this.rdbNewFile.Size = new System.Drawing.Size(66, 17);
            this.rdbNewFile.TabIndex = 0;
            this.rdbNewFile.TabStop = true;
            this.rdbNewFile.Text = "New File";
            this.rdbNewFile.UseVisualStyleBackColor = true;
            // 
            // chkReplacePages
            // 
            this.chkReplacePages.AutoSize = true;
            this.chkReplacePages.Checked = true;
            this.chkReplacePages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReplacePages.Location = new System.Drawing.Point(8, 507);
            this.chkReplacePages.Name = "chkReplacePages";
            this.chkReplacePages.Size = new System.Drawing.Size(177, 17);
            this.chkReplacePages.TabIndex = 7;
            this.chkReplacePages.Text = "Replace pages with same name";
            this.chkReplacePages.UseVisualStyleBackColor = true;
            // 
            // chkCreateVersions
            // 
            this.chkCreateVersions.AutoSize = true;
            this.chkCreateVersions.Checked = true;
            this.chkCreateVersions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreateVersions.Location = new System.Drawing.Point(8, 530);
            this.chkCreateVersions.Name = "chkCreateVersions";
            this.chkCreateVersions.Size = new System.Drawing.Size(100, 17);
            this.chkCreateVersions.TabIndex = 8;
            this.chkCreateVersions.Text = "Create Versions";
            this.chkCreateVersions.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 554);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Use configuration:";
            // 
            // cmbConfiguration
            // 
            this.cmbConfiguration.DataSource = this.configurationBindingSource;
            this.cmbConfiguration.FormattingEnabled = true;
            this.cmbConfiguration.Location = new System.Drawing.Point(108, 551);
            this.cmbConfiguration.Name = "cmbConfiguration";
            this.cmbConfiguration.Size = new System.Drawing.Size(240, 21);
            this.cmbConfiguration.TabIndex = 10;
            this.cmbConfiguration.ValueMember = "Id";
            // 
            // MergeVisioFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 626);
            this.Controls.Add(this.cmbConfiguration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkCreateVersions);
            this.Controls.Add(this.chkReplacePages);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFilesToMerge);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MergeVisioFiles";
            this.Text = "MergeVisioFiles";
            this.Load += new System.EventHandler(this.MergeVisioFiles_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbFilesToMerge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.RadioButton rdbExistingFile;
        private System.Windows.Forms.RadioButton rdbNewFile;
        private System.Windows.Forms.CheckBox chkReplacePages;
        private System.Windows.Forms.CheckBox chkCreateVersions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbConfiguration;
        private System.Windows.Forms.BindingSource configurationBindingSource;



    }
}