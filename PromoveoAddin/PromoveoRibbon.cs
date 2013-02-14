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

        private void btnCompareDocuments_Click(object sender, RibbonControlEventArgs e)
        {
            
            Visio.Application app = SingletonVisioApp.GetCurrentVisioInstance().VisioApp;
            string NameFile1 = OpenFile().FileName;
            string NameFile2 = OpenFile().FileName;
            string OutputDoc = app.Documents.AddEx("").Name;

            FileComparer comparer = new FileComparer();
            comparer.ComparePages(app.Documents[NameFile1].Pages[1], app.Documents[NameFile2].Pages[1], app.Documents[OutputDoc].Pages.Add());
        }


        private OpenFileDialog OpenFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All Visio Documents|*.vsd";
            DialogResult result = fileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                try
                {
                    SingletonVisioApp.GetCurrentVisioInstance().VisioApp.Documents.Open(fileDialog.FileName);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Error: " + Ex.Message);
                }
            }
            return fileDialog;
        }

    }
}
