using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PromoveoAddin.MasterDataManagement
{
    public partial class frmConfigurations : Form
    {
        public frmConfigurations()
        {
            InitializeComponent();
        }

        private void frmConfigurations_Load(object sender, EventArgs e)
        {
            ConfigurationService.ConfigurationClient configurationClient = new ConfigurationService.ConfigurationClient();
            this.configurationBindingSource.DataSource = configurationClient.GetConfigurations();

        }

        private void dgvConfigurations_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //this.configurationTableAdapter.Update(promoveoDataSet);
        }

        private void dgvConfigurations_Validated(object sender, EventArgs e)
        {
            //this.configurationTableAdapter.Update(promoveoDataSet);
        }
    }
}
