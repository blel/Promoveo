using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PromoveoAddin
{
    public partial class WorkflowConfiguration : Form
    {
        public WorkflowConfiguration()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SingletonVisioApp.GetCurrentVisioInstance().WorkflowName = this.txtWorkflowName.Text;
            SingletonVisioApp.GetCurrentVisioInstance().WorkflowAddress = this.txtWorkflowServiceAddress.Text;
            SingletonVisioApp.GetCurrentVisioInstance().ExportPath = this.txtExportPath.Text;
            SingletonVisioApp.GetCurrentVisioInstance().PrintIcon = this.txtPrintIcon.Text;
            this.Close();
        }

        private void WorkflowConfiguration_Activated(object sender, EventArgs e)
        {
            this.txtWorkflowName.Text = SingletonVisioApp.GetCurrentVisioInstance().WorkflowName;
            this.txtWorkflowServiceAddress.Text = SingletonVisioApp.GetCurrentVisioInstance().WorkflowAddress;
            this.txtPrintIcon.Text = SingletonVisioApp.GetCurrentVisioInstance().PrintIcon;
            this.txtExportPath.Text = SingletonVisioApp.GetCurrentVisioInstance().ExportPath;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
