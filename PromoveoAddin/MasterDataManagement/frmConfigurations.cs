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
            // TODO: This line of code loads data into the 'promoveoDataSet.Configuration' table. You can move, or remove it, as needed.
            this.configurationTableAdapter.Fill(this.promoveoDataSet.Configuration);

        }

        private void dgvConfigurations_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.configurationTableAdapter.Update(this.promoveoDataSet.Configuration);
        }
    }
}
