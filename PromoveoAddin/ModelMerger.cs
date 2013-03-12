using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PromoveoAddin
{
    public class ModelMerger
    {
        #region fields
        
        //the app
        SingletonVisioApp _app;
        
        //temp field for auto created inital page
        Visio.Page _initialPageToRemove;
        
        //name of the target file, if files should merged in to existing target file
        string _targetFileName;

        //the result doc
        Visio.Document _resultDoc;

        //replace pages
        bool _replacePages;
        #endregion

        #region Properties
        public List<string> FilesToMerge { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ModelMerger(string targetFileName, bool replacePages)
        {
            _targetFileName = targetFileName;
            _replacePages = replacePages;
            _app = SingletonVisioApp.GetCurrentVisioInstance();
        }

        #endregion

        #region methods

        /// <summary>
        /// Closes all open files
        /// Not sure if needed in future
        /// </summary>
        private void CloseAllOpenFiles()
        {
            for (int i = _app.VisioApp.Documents.Count; i > 0; i--)
            {
                _app.VisioApp.Documents[i].Saved = true;
                _app.VisioApp.Documents[i].Close();
            }
        }


        /// <summary>
        /// Starts the merge operation
        /// Files to merge must have been set before (TODO: should  
        /// be passed as a parameter)
        /// </summary>
        public void StartMerge()
        {
            CloseAllOpenFiles();
            if (!string.IsNullOrWhiteSpace(_targetFileName))
            {
                _resultDoc = _app.VisioApp.Documents.Add(_targetFileName);
            }
            else
            {
                _resultDoc = _app.VisioApp.Documents.Add("");
                _initialPageToRemove = _resultDoc.Pages[1];
                _initialPageToRemove.Name = Guid.NewGuid().ToString();
            }
            
            
            foreach (string fileName in FilesToMerge)
            {
                _app.VisioApp.EventsEnabled = Convert.ToInt16( false);
                Merge(fileName);
                _app.VisioApp.EventsEnabled = Convert.ToInt16(true);
            }
            if (_initialPageToRemove != null)
            _resultDoc.Pages[_initialPageToRemove.Name].Delete(Convert.ToInt16(false));
            LocalizeVisioHyperlinks();
        }

        /// <summary>
        /// merges the document with fileName to the _resultDoc
        /// </summary>
        /// <param name="fileName"></param>
        private void Merge(string fileName)
        {
            Visio.Document docToMerge = _app.VisioApp.Documents.OpenEx(fileName,(short)Visio.VisOpenSaveArgs.visOpenHidden + (short)Visio.VisOpenSaveArgs.visOpenDontList);
            foreach (Visio.Page pageToMerge in docToMerge.Pages)
            {

                    MakeAbsoluteLinks(pageToMerge, docToMerge.Path);
                    MergePage(pageToMerge);
                
            }
            docToMerge.Saved = true;
            docToMerge.Close();
        }

        private void MakeAbsoluteLinks(Visio.Page page, string basePath)
        {
            Uri baseUri = new Uri(basePath);
            foreach (Visio.Shape shape in page.Shapes)
            {
                foreach (Visio.Hyperlink hyperlink in shape.Hyperlinks)
                {
                    if (!string.IsNullOrWhiteSpace(hyperlink.Address ))
                        hyperlink.Address = new Uri(baseUri, hyperlink.Address).ToString();
                
                }
            }
        }

        /// <summary>
        /// merges the page to the _resultdoc
        /// </summary>
        /// <param name="pageToMerge"></param>
        private void MergePage(Visio.Page pageToMerge)
        {
            Visio.Page resultPage = _resultDoc.Pages.Add();
            PagePreparer preparer = new PagePreparer(_resultDoc, resultPage, pageToMerge);
            preparer.CopyFormatToDestinationPage(_replacePages);
            preparer.CopyPage();
        }

        /// <summary>
        /// Returns a list of hyperlinks in a page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
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
                foreach (Visio.Hyperlink link in GetHyperlinks(page).Where(cc=>!string.IsNullOrWhiteSpace(cc.Address)))
                {
                    if (IsVisioFile(link.Address))
                    {
                        if (string.IsNullOrEmpty(link.SubAddress))
                        {
                            string FirstPageNameOfDoc = GetFirstPageNameOfDoc(link.Address);
                            if (IsPageAvailable(FirstPageNameOfDoc))
                            {
                                link.SubAddress = FirstPageNameOfDoc;
                                link.Address = string.Empty;
                            }
                            else
                                MessageBox.Show(string.Format("The Link Target is not available.\r\nLink: {0}\r\nPage: {1}", link.Address, link.SubAddress));
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

        public bool IsRelativeLink(string fileName)
        {
            string prefix = fileName.Substring(0, 3);
            Regex regex = new Regex(@"[a-z|A-Z]:\\");
            return !regex.IsMatch(prefix);
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
        #endregion
    }
}
