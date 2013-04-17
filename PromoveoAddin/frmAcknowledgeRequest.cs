using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;

namespace PromoveoAddin
{
    public partial class frmAcknowledgeRequest : Form
    {
        public frmAcknowledgeRequest()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAcknowledgeRequest_Load(object sender, EventArgs e)
        {
            ConfigurationService.ConfigurationClient configurationClient = new ConfigurationService.ConfigurationClient();
            this.configurationBindingSource.DataSource = configurationClient.GetConfigurations();


        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            Visio.Document master = SingletonVisioApp.GetCurrentVisioInstance().VisioApp.ActiveDocument;
            if (master == null)
            {
                MessageBox.Show("You must open the master document in order to perform this operation.");
            }
            else
            {
                AcknowledgeRequestHelper acknRequestHelper = new AcknowledgeRequestHelper(Convert.ToInt32(this.comboBox1.SelectedValue), master);
                acknRequestHelper.SendAcknowledgeRequest();
            }
        }
    }
}
