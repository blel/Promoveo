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
        delegate void ChangeProgressBar(int percentage);
        
        public frmPublishDialog()
        {
            InitializeComponent();
            bgrWorker.DoWork +=  new DoWorkEventHandler(bgrWorker_DoWork);
            bgrWorker.WorkerReportsProgress = true;
            bgrWorker.ProgressChanged += new ProgressChangedEventHandler(bgrWorker_ProgressChanged);
        }

        public void ChangeTheProgressBar(int precentage)
        {
            pgbProgress.Value = precentage;
        }



        void bgrWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            pgbProgress.Invoke(new ChangeProgressBar(ChangeTheProgressBar),e.ProgressPercentage);
            
        }

        void bgrWorker_DoWork(object sender, DoWorkEventArgs e)
        {


                BackgroundWorkerArgs args = (BackgroundWorkerArgs)e.Argument;
                CustomPublisher publisher = new CustomPublisher(SingletonVisioApp.GetCurrentVisioInstance().VisioApp,
                    args.Filename, args.ConfigurationID, bgrWorker);

                publisher.StartPublish(true);
            
        }

        

        private void frmPublishDialog_Load(object sender, EventArgs e)
        {
            this.configurationTableAdapter.Fill(this.promoveoDataSet.Configuration);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int configID = Convert.ToInt32(((DataRowView)this.cmbConfiguration.SelectedItem).Row[0]);
            List<string> newModels;
            MasterDataManagement.ProcessModelDAL processModelDAL = new MasterDataManagement.ProcessModelDAL();

            bool hasNewModels = processModelDAL.HasNewModels(SingletonVisioApp.GetCurrentVisioInstance().VisioApp.ActiveDocument, configID
                    , out newModels);
            if ((hasNewModels && chkAddModels.Checked) || !hasNewModels)
            {
                processModelDAL.AddNewModels(newModels, configID);
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "Html Page (*.htm, *.html)|*.htm;*html";
                fileDialog.FileName = System.IO.Path.GetFileNameWithoutExtension(SingletonVisioApp.GetCurrentVisioInstance().VisioApp.ActiveDocument.Name);
                DialogResult result = fileDialog.ShowDialog();
                pgbProgress.Maximum = 100;// SingletonVisioApp.GetCurrentVisioInstance().VisioApp.ActiveDocument.Pages.Count;
                pgbProgress.Step = 1;

                if (result != DialogResult.Cancel)
                {
                    BackgroundWorkerArgs bgrArgs = new BackgroundWorkerArgs();
                    bgrArgs.ConfigurationID = Convert.ToInt32(this.cmbConfiguration.SelectedValue);
                    bgrArgs.Filename = fileDialog.FileName;
                    if (!bgrWorker.IsBusy)
                    {
                        bgrWorker.RunWorkerAsync(bgrArgs);
                    }
                    //CustomPublisher publisher = new CustomPublisher(SingletonVisioApp.GetCurrentVisioInstance().VisioApp,
                    //    fileDialog.FileName, Convert.ToInt32(this.cmbConfiguration.SelectedValue));

                    //publisher.StartPublish(true);
                }
            }
            else
            {
                MessageBox.Show("There are new models for the selected configuration. Add the models and appropriate user rights first, and publish again.");
            }
            

        }




    }

    public class BackgroundWorkerArgs
    {
        public string Filename { get; set; }
        public int ConfigurationID { get; set; }
    }



}
