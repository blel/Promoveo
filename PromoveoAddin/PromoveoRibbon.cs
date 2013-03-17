using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace PromoveoAddin
{
    public partial class PromoveoRibbon
    {
        private void PromoveoRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }



        private void btnTest_Click(object sender, RibbonControlEventArgs e)
        {
            Visio.Application app = SingletonVisioApp.GetCurrentVisioInstance().VisioApp;
            FileHelper.OpenFile();
            Visio.Document Doc1 = app.ActiveDocument;
            FileHelper.OpenFile();
            Visio.Document Doc2 = app.ActiveDocument;
            DocumentComparer docComparer = new DocumentComparer(app, Doc1, Doc2);
            docComparer.CompareDocuments();
        }

        private void btnWebService_Click(object sender, RibbonControlEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SingletonVisioApp.GetCurrentVisioInstance().WorkflowAddress) ||
                string.IsNullOrWhiteSpace(SingletonVisioApp.GetCurrentVisioInstance().WorkflowName))
            {
                MessageBox.Show("No Workflow Service Data setup. Please setup the data in the configuration tab.", "Promoveo For Visio");
            }
            else
            {
                ServiceClient.WorkflowCommunicator workflowCommunicator =
                    new ServiceClient.WorkflowCommunicator(SingletonVisioApp.GetCurrentVisioInstance().WorkflowAddress,
                                                           SingletonVisioApp.GetCurrentVisioInstance().WorkflowName);
                try
                {
                    InputBox inputBox = new InputBox();
                    workflowCommunicator.StartSPDefaultApprovalWorkflow(inputBox.ShowInputBox("Enter the item on which you want to start the workflow:"), null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            SingletonVisioApp singleton = SingletonVisioApp.GetCurrentVisioInstance();
            WorkflowConfiguration workflowConfig = new WorkflowConfiguration();
            workflowConfig.Show();
        }

        private void btnPublish_Click(object sender, RibbonControlEventArgs e)
        {
            CustomPublisher publisher = new CustomPublisher(SingletonVisioApp.GetCurrentVisioInstance().VisioApp);
            publisher.StartPublish(true);
        }

        private void btnMerge_Click(object sender, RibbonControlEventArgs e)
        {
            MergeVisioFiles mergeVisioFiles = new MergeVisioFiles();
            mergeVisioFiles.Show();
        }

        private void btnRoles_Click(object sender, RibbonControlEventArgs e)
        {
            UserManagement.PublishingPlatformRole frmRoles = new UserManagement.PublishingPlatformRole();
            frmRoles.Show();
        }

        private void btnSerialize_Click(object sender, RibbonControlEventArgs e)
        {
            UserManagement.PublishingPlatformSerializer serializer = new UserManagement.PublishingPlatformSerializer("D:\\tmp\\users.xml");
            serializer.PrepareObjects();
            serializer.SerializeModelUsers();
            
        }

    }
}
