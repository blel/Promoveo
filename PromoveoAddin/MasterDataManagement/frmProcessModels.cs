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
            // TODO: This line of code loads data into the 'promoveoDataSet.Configuration' table. You can move, or remove it, as needed.
            this.configurationTableAdapter.Fill(this.promoveoDataSet.Configuration);

            // TODO: This line of code loads data into the 'promoveoDataSet.PublishingPlatformUser' table. You can move, or remove it, as needed.
            this.publishingPlatformUserTableAdapter.Fill(this.promoveoDataSet.PublishingPlatformUser);
            // TODO: This line of code loads data into the 'promoveoDataSet.ProcessModel' table. You can move, or remove it, as needed.

            MasterDataManagement.ProcessModelDAL dal = new ProcessModelDAL();
            foreach (Data.PromoveoDataSet.ProcessModelRow row in dal.GetProcessModels(1).Rows)
            {
                this.promoveoDataSet.ProcessModel.ImportRow(row);
            }
           // this.processModelTableAdapter.Fill(this.promoveoDataSet.ProcessModel);

        }



        private void dgvModels_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            this.processModelTableAdapter.Update(this.promoveoDataSet.ProcessModel);
        }
    }
}
