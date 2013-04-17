using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;

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
            ConfigurationService.ConfigurationClient configurationClient = new ConfigurationService.ConfigurationClient();
            this.configurationBindingSource.DataSource = configurationClient.GetConfigurations();
            
            //this.publishingPlatformUserTableAdapter.Fill(this.promoveoDataSet.PublishingPlatformUser);
            this.processModelBindingSource.Filter = string.Format("FK_Configuration = {0}", GetConfigurationID());
            ProcessModelService.ProcessModelClient processModelClient = new ProcessModelService.ProcessModelClient();
            this.processModelBindingSource.DataSource = processModelClient.GetProcessModels();
        }

        private int GetConfigurationID()
        {
            if (this.cmbConfiguration.Items.Count > 0 && this.cmbConfiguration.SelectedItem != null)
                return Convert.ToInt32(((DataRowView)this.cmbConfiguration.SelectedItem).Row[0]);
            return 0;
        }

        private void dgvModels_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //this.processModelTableAdapter.Update(this.promoveoDataSet.ProcessModel);
        }

        private void cmbConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.processModelBindingSource.Filter = string.Format("FK_Configuration = {0}", GetConfigurationID());
        }

        private void btnCreateModels_Click(object sender, EventArgs e)
        {
            int configID = Convert.ToInt32(this.cmbConfiguration.SelectedValue.ToString());// Convert.ToInt32(((DataRowView)this.cmbConfiguration.SelectedItem).Row[0]);
           
            ProcessModelService.ProcessModelClient processModelClient = new ProcessModelService.ProcessModelClient();
            string[] newModels = processModelClient.GetNewModelNames(SingletonVisioApp.GetCurrentVisioInstance().VisioApp.ActiveDocument.Pages.Cast<Visio.Page>().Select(cc=>cc.Name).ToArray(),configID);

            processModelClient.AddNewModels(newModels, configID);
            this.processModelBindingSource.DataSource = processModelClient.GetProcessModels();
          
            
        }
    }
}
