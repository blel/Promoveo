using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace PromoveoAddin
{
    public class PagePreparer
    {
        private Visio.Page _destinationPage;
        private Visio.Page _sourcePage;
        
        public PagePreparer(Visio.Page destinationPage, Visio.Page sourcePage)
        {
            _destinationPage = destinationPage;
            _sourcePage = sourcePage;
        }

        public void CopyFormatToDestinationPage()
        {
            //Copy name and orientation
            try
            {
                _destinationPage.Name = _sourcePage.Name;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message);

                _destinationPage.Name = Guid.NewGuid().ToString();
            }

            _destinationPage.PageSheet.Cells["PageHeight"].FormulaU = _sourcePage.PageSheet.Cells["PageHeight"].get_ResultStr(Visio.VisUnitCodes.visInches);
            _destinationPage.PageSheet.Cells["PageWidth"].FormulaU = _sourcePage.PageSheet.Cells["PageWidth"].get_ResultStr(Visio.VisUnitCodes.visInches);
            _destinationPage.PageSheet.Cells["PrintPageOrientation"].FormulaU = _sourcePage.PageSheet.Cells["PrintPageOrientation"].get_ResultStrU(Visio.VisUnitCodes.visNumber);

        }

        public void CopyPage()
        {
            _sourcePage.AddGuide((short)Visio.VisGuideTypes.visPoint, 0, 0);
            Visio.Selection selection = _sourcePage.CreateSelection(Visio.VisSelectionTypes.visSelTypeAll);
            selection.Copy();
            _destinationPage.Paste();
            Visio.Selection resultSelection = _destinationPage.CreateSelection(Visio.VisSelectionTypes.visSelTypeAll);
            double origX, origY, newX, newY, dummy1, dummy2;
            selection.BoundingBox(1, out origX, out origY, out dummy1, out dummy2);
            resultSelection.BoundingBox(1, out newX, out newY, out dummy1, out dummy2);
            double diffX = origX - newX;
            double diffY = origY - newY;
            resultSelection.Move(diffX, diffY);
        }

    }
}
