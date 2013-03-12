using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.Diagnostics;

namespace PromoveoAddin
{
    public class DocumentComparer
    {
        private Visio.Document _documentA;
        private Visio.Document _documentB;
        private Visio.Document _resultingDocument;
        private Visio.Application _app;
        private List<string> _guidsOfNilPages = new List<string>();

        public DocumentComparer(Visio.Application app, Visio.Document documentA, Visio.Document documentB)
        {
            _documentA = documentA;
            _documentB = documentB;
            _resultingDocument = app.Documents.Add("");

            //visio creates an initial (I call it "nil") page
            //just in case there are any more, give the same a guid name
            //these pages are removed at the end.
            if (_resultingDocument.Pages.Count > 0)
            {
                foreach (Visio.Page page in _resultingDocument.Pages)
                {
                    page.Name = Guid.NewGuid().ToString();
                    _guidsOfNilPages.Add(page.Name);
                }
            }

            _app = app;
        }

        public void CompareDocuments()
        {
            //Copy all deleted pages
            GetPagesOnXExceptOnY(_documentA, _documentB, "RGB(255,200,200)");
            //copy all new pages
            GetPagesOnXExceptOnY(_documentB, _documentA, "RGB(200,255,200)");

            foreach (Visio.Page page in GetIntersectionPages())
            {
                Visio.Page resultPage = _resultingDocument.Pages.Add();
                PagePreparer preparer = new PagePreparer(_resultingDocument, resultPage, page);
                preparer.CopyFormatToDestinationPage(false);
                //Now compare the content of the page....
                PageComparer pageComparer = new PageComparer(_app, _documentA.Pages[page.Name], _documentB.Pages[page.Name], resultPage);
                pageComparer.ComparePages();
            }

            //remove nil pages
            foreach (string guid in _guidsOfNilPages)
            {
                _resultingDocument.Pages[guid].Delete(Convert.ToInt16(false));
            }

        }

        /// <summary>
        /// Adds a page to the resultDoc for each page which is on DocX but not on DocY.
        /// Marks the page with a rectangle with color RGBColor
        /// </summary>
        /// <param name="DocX"></param>
        /// <param name="DocY"></param>
        /// <param name="RGBColor"></param>
        private void GetPagesOnXExceptOnY(Visio.Document DocX, Visio.Document DocY, string RGBColor)
        {
            var difference = (from cc in DocX.Pages.Cast<Visio.Page>()
                              select cc).Except(DocY.Pages.Cast<Visio.Page>(),new PageNameEqualityComparer()).ToArray();
            foreach (Visio.Page page in difference)
            {
                Visio.Page resultPage = _resultingDocument.Pages.Add();
                PagePreparer preparer = new PagePreparer(_resultingDocument, resultPage, page);
                preparer.CopyFormatToDestinationPage(false);
                preparer.CopyPage();

                Visio.Shape resultRect = resultPage.DrawRectangle(0, 0, resultPage.PageSheet.Cells["PageWidth"].Result[Visio.VisUnitCodes.visInches], resultPage.PageSheet.Cells["PageHeight"].Result[Visio.VisUnitCodes.visInches]);
                resultRect.SendToBack();
                resultRect.Cells["FillForegnd"].FormulaU = RGBColor;
            }
        }

        /// <summary>
        /// Formats the to Page similar to the from page and 
        /// copies all from FromPage to ToPage
        /// </summary>
        /// <param name="fromPage">Source page</param>
        /// <param name="toPage">Destination page</param>
        //private void CopyPage(Visio.Page fromPage, Visio.Page toPage)
        //{
        //    PagePreparer preparer = new PagePreparer(toPage, fromPage);
        //    preparer.CopyFormatToDestinationPage();
        //    //Copy shapes
        //    fromPage.AddGuide((short)Visio.VisGuideTypes.visPoint, 0, 0);
        //    Visio.Selection selection = fromPage.CreateSelection(Visio.VisSelectionTypes.visSelTypeAll);
        //    selection.Copy();
        //    toPage.Paste();
        //    Visio.Selection resultSelection = toPage.CreateSelection(Visio.VisSelectionTypes.visSelTypeAll);
        //    double origX, origY, newX, newY, dummy1, dummy2;
        //    selection.BoundingBox(1, out origX, out origY, out dummy1, out dummy2);
        //    resultSelection.BoundingBox(1, out newX, out newY, out dummy1, out dummy2);
        //    double diffX = origX - newX;
        //    double diffY = origY - newY;
        //    resultSelection.Move(diffX, diffY);
        //}

        //private void SetupDestinationPage(Visio.Page fromPage, Visio.Page toPage)
        //{
        //    //Copy name and orientation
        //    toPage.Name = fromPage.Name;
        //    toPage.PageSheet.Cells["PageHeight"].FormulaU = fromPage.PageSheet.Cells["PageHeight"].get_ResultStr(Visio.VisUnitCodes.visInches);
        //    toPage.PageSheet.Cells["PageWidth"].FormulaU = fromPage.PageSheet.Cells["PageWidth"].get_ResultStr(Visio.VisUnitCodes.visInches);
        //    toPage.PageSheet.Cells["PrintPageOrientation"].FormulaU = fromPage.PageSheet.Cells["PrintPageOrientation"].get_ResultStrU(Visio.VisUnitCodes.visNumber);
            
        //}


        public List<Visio.Page> GetIntersectionPages()
        {
            return (from cc in _documentB.Pages.Cast<Visio.Page>()
                    select cc).Intersect(from ccc in _documentA.Pages.Cast<Visio.Page>()
                                         select ccc, new PageNameEqualityComparer()).ToList();
        }



        
    }
}
