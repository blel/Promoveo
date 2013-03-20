namespace PromoveoAddin.MasterDataManagement
{
    partial class frmConfigurations
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
            this.dgvConfigurations = new System.Windows.Forms.DataGridView();
            this.promoveoDataSet = new PromoveoAddin.Data.PromoveoDataSet();
            this.configurationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.configurationTableAdapter = new PromoveoAddin.Data.PromoveoDataSetTableAdapters.ConfigurationTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigurations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.promoveoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConfigurations
            // 
            this.dgvConfigurations.AutoGenerateColumns = false;
            this.dgvConfigurations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfigurations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dgvConfigurations.DataSource = this.configurationBindingSource;
            this.dgvConfigurations.Location = new System.Drawing.Point(13, 13);
            this.dgvConfigurations.Name = "dgvConfigurations";
            this.dgvConfigurations.Size = new System.Drawing.Size(259, 237);
            this.dgvConfigurations.TabIndex = 0;
            this.dgvConfigurations.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConfigurations_RowLeave);
            // 
            // promoveoDataSet
            // 
            this.promoveoDataSet.DataSetName = "PromoveoDataSet";
            this.promoveoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // configurationBindingSource
            // 
            this.configurationBindingSource.DataMember = "Configuration";
            this.configurationBindingSource.DataSource = this.promoveoDataSet;
            // 
            // configurationTableAdapter
            // 
            this.configurationTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // frmConfigurations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.dgvConfigurations);
            this.Name = "frmConfigurations";
            this.Text = "frmConfigurations";
            this.Load += new System.EventHandler(this.frmConfigurations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigurations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.promoveoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configurationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConfigurations;
        private Data.PromoveoDataSet promoveoDataSet;
        private System.Windows.Forms.BindingSource configurationBindingSource;
        private Data.PromoveoDataSetTableAdapters.ConfigurationTableAdapter configurationTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}