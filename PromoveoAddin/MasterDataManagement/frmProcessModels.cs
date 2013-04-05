using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PromoveoAddin.MasterDataManagement
{
    public partial class frmProcessModels : Form
    {
        public frmProcessModels()
        {
            InitializeComponent();
        }

        private void frmProcessModels_Load(object sender, EventArgs e)
        {
            this.configurationTableAdapter.Fill(this.promoveoDataSet.Configuration);
            this.publishingPlatformUserTableAdapter.Fill(this.promoveoDataSet.PublishingPlatformUser);
            this.processModelBindingSource.Filter = string.Format("FK_Configuration = {0}", GetConfigurationID());
            this.processModelTableAdapter.Fill(this.promoveoDataSet.ProcessModel);
        }

        private int GetConfigurationID()
        {
            if (this.cmbConfiguration.Items.Count > 0 && this.cmbConfiguration.SelectedItem != null)
                return Convert.ToInt32(((DataRowView)this.cmbConfiguration.SelectedItem).Row[0]);
            return 0;
        }

        private void dgvModels_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            this.processModelTableAdapter.Update(this.promoveoDataSet.ProcessModel);
        }

        private void cmbConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.processModelBindingSource.Filter = string.Format("FK_Configuration = {0}", GetConfigurationID());
        }

        private void btnCreateModels_Click(object sender, EventArgs e)
        {
            int configID = Convert.ToInt32(this.cmbConfiguration.SelectedValue.ToString());// Convert.ToInt32(((DataRowView)this.cmbConfiguration.SelectedItem).Row[0]);
            List<string> newModels;
            MasterDataManagement.ProcessModelDAL processModelDAL = new MasterDataManagement.ProcessModelDAL();

            bool hasNewModels = processModelDAL.HasNewModels(SingletonVisioApp.GetCurrentVisioInstance().VisioApp.ActiveDocument, configID
                    , out newModels);
            processModelDAL.AddNewModels(newModels, configID);
            this.processModelTableAdapter.Fill(this.promoveoDataSet.ProcessModel);
            
        }
    }
}
