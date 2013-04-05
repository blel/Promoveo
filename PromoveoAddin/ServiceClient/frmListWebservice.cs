using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PromoveoAddin.ServiceClient
{
    public partial class frmListWebservice : Form
    {
        public frmListWebservice()
        {
            InitializeComponent();
        }

        private void btnGetList_Click(object sender, EventArgs e)
        {
            try
            {
                PromoveoAddin.ServiceClient.ListsCommunicator listCommunicator = new ListsCommunicator(this.txtServiceAddress.Text);
                this.txtResult.Text= listCommunicator.GetList(this.txtListName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
