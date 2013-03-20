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
    public partial class frmPublishDialog : Form
    {
        public frmPublishDialog()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmPublishDialog_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'promoveoDataSet.Configuration' table. You can move, or remove it, as needed.
            this.configurationTableAdapter.Fill(this.promoveoDataSet.Configuration);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int configID = Convert.ToInt32(((DataRowView)this.cmbConfiguration.SelectedItem).Row[0]);
            List<string> newModels;
            bool hasNewModels = HasNewModels(SingletonVisioApp.GetCurrentVisioInstance().VisioApp.ActiveDocument, configID
                    , out newModels);
            if ((hasNewModels && chkAddModels.Checked) || !hasNewModels)
            {
                AddNewModels(newModels, configID);
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "Html Page (*.htm, *.html)|*.htm;*html";
                fileDialog.FileName = System.IO.Path.GetFileNameWithoutExtension(SingletonVisioApp.GetCurrentVisioInstance().VisioApp.ActiveDocument.Name);
                DialogResult result = fileDialog.ShowDialog();
                if (result != DialogResult.Cancel)
                {
                    CustomPublisher publisher = new CustomPublisher(SingletonVisioApp.GetCurrentVisioInstance().VisioApp,
                        fileDialog.FileName);

                    publisher.StartPublish(true);
                }
            }
            else
            {
                MessageBox.Show("There are new models for the selected configuration. Add the models and appropriate user rights first, and publish again.");
            }
            

        }

        private bool HasNewModels(Visio.Document document, int configurationID, out List<string> newModels)
        {
            bool hasNewModels = false;
            newModels = new List<string>();
            MasterDataManagement.ProcessModelDAL processModelDAL = new MasterDataManagement.ProcessModelDAL();
            var processModels = processModelDAL.GetProcessModels(configurationID);
            foreach (string modelName in document.Pages.Cast<Visio.Page>().Select(cc => cc.Name))
            {
                if (processModels.Rows.Cast<Data.PromoveoDataSet.ProcessModelRow>().Where(cc => cc.ProcessModel == modelName).Count() == 0)
                {
                    hasNewModels = true;
                    newModels.Add(modelName);
                }

            }
            return hasNewModels;
        }

        private void AddNewModels(List<string> modelNames, int configurationID)
        {
            MasterDataManagement.ProcessModelDAL processModelDAL = new MasterDataManagement.ProcessModelDAL();

            foreach (string modelName in modelNames)
            {
                processModelDAL.Insert(modelName, configurationID);
            }

        }


    }
}
