using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace PromoveoAddin
{
    public class ModelMerger
    {
        SingletonVisioApp _app;
        Visio.Page _initialPageToRemove;
        Visio.Document _resultDoc;
        public List<string> FilesToMerge { get; set; }


        public  ModelMerger()
        {
            _app = SingletonVisioApp.GetCurrentVisioInstance();
        }

        private void CloseAllOpenFiles()
        {
            for (int i = _app.VisioApp.Documents.Count; i > 0; i--)
            {
                _app.VisioApp.Documents[i].Close();
            }
        }

        public void StartMerge()
        {
            CloseAllOpenFiles();
            _resultDoc = _app.VisioApp.Documents.Add("");
            _initialPageToRemove = _resultDoc.Pages[1];
            _initialPageToRemove.Name = Guid.NewGuid().ToString();
            foreach (string fileName in FilesToMerge)
            {
                Merge(fileName);
            }
            _resultDoc.Pages[_initialPageToRemove.Name].Delete(Convert.ToInt16(false));
        }

        private void Merge(string fileName)
        {
            Visio.Document docToMerge = _app.VisioApp.Documents.Open(fileName);
            foreach (Visio.Page pageToMerge in docToMerge.Pages)
            {
                MergePage(pageToMerge);
            }
            docToMerge.Saved = true;
            docToMerge.Close();
        }

        private void MergePage(Visio.Page pageToMerge)
        {
            PagePreparer preparer = new PagePreparer(_resultDoc.Pages.Add(), pageToMerge);
            preparer.CopyFormatToDestinationPage();
            preparer.CopyPage();
        }




    }
}
