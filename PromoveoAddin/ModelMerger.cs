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
            LocalizeVisioHyperlinks();
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
            Visio.Page resultPage = _resultDoc.Pages.Add();
            PagePreparer preparer = new PagePreparer(resultPage, pageToMerge);
            preparer.CopyFormatToDestinationPage();
            preparer.CopyPage();
        }


        private List<Visio.Hyperlink> GetHyperlinks(Visio.Page page)
        {
            List<Visio.Hyperlink> resultList = new List<Visio.Hyperlink>();
            foreach (Visio.Shape shape in page.Shapes)
            {
                resultList.AddRange(shape.Hyperlinks.Cast<Visio.Hyperlink>().ToList());
            }
            return resultList;
        }

        private void LocalizeVisioHyperlinks()
        {
            foreach (Visio.Page page in _resultDoc.Pages)
            {
                foreach (Visio.Hyperlink link in GetHyperlinks(page))
                {
                    if (IsVisioFile(link.Address))
                    {
                        if (string.IsNullOrEmpty(link.SubAddress))
                        {
                            string FirstPageNameOfDoc = GetFirstPageNameOfDoc(link.Address);
                            if (IsPageAvailable(FirstPageNameOfDoc))
                                link.SubAddress = FirstPageNameOfDoc;
                            else
                                MessageBox.Show("The Link Target is not available.");

                        }
                        else
                        {
                            if (IsPageAvailable(link.SubAddress))
                            {
                                link.Address = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show("The Link Target is not available.");
                            }
                        }
                    }
                }
            }
        }

        private bool IsVisioFile(string fileName)
        {
            List<string> VisioExtensions = new List<string>() { ".vsd" };
            string extension = fileName.Substring(fileName.Length - 4, 4);
            if (!string.IsNullOrEmpty(VisioExtensions.Find(cc => cc == extension)))
                return true;
            return false;
        }

        private string GetFirstPageNameOfDoc(string filename)
        {
            var document = _app.VisioApp.Documents.OpenEx(filename, (short)Visio.VisOpenSaveArgs.visOpenHidden + (short)Visio.VisOpenSaveArgs.visOpenDontList);
            string pageName = document.Pages[1].Name;
            document.Saved = true;
            document.Close();
            return pageName;
        }

        private bool IsPageAvailable(string pageName)
        {
            return _resultDoc.Pages.Cast<Visio.Page>().ToList().Find(cc =>cc.Name == pageName)!=null; 
                  
        }


    }
}
