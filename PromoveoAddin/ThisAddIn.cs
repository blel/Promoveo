using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;

namespace PromoveoAddin
{
    public partial class ThisAddIn
    {

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            SingletonVisioApp.GetCurrentVisioInstance().VisioApp.BeforeDocumentSave += VisioApp_BeforeDocumentSave;
            SingletonVisioApp.GetCurrentVisioInstance().VisioApp.BeforeDocumentSaveAs += VisioApp_BeforeDocumentSaveAs;

        }

        void VisioApp_BeforeDocumentSaveAs(Visio.Document Doc)
        {
            SaveWithGUID();
        }

        void VisioApp_BeforeDocumentSave(Visio.Document Doc)
        {
            SaveWithGUID();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void SaveWithGUID()
        {
            Visio.Document currentDoc = SingletonVisioApp.GetCurrentVisioInstance().VisioApp.ActiveDocument;

            foreach (Visio.Page page in currentDoc.Pages)
            {
                foreach (Visio.Shape shape in page.Shapes)
                {
                    shape.get_UniqueID ((short)Visio.VisUniqueIDArgs.visGetOrMakeGUID);
                }
            }
        }


        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
