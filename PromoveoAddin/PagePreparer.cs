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
        private Visio.Document _resultDocument;

        public PagePreparer(Visio.Document doc, Visio.Page destinationPage, Visio.Page sourcePage)
        {
            _destinationPage = destinationPage;
            _sourcePage = sourcePage;
            _resultDocument = doc;
        }

        public void CopyFormatToDestinationPage(bool replacePages)
        {
            var pageWithSameName = _resultDocument.Pages.Cast<Visio.Page>().ToList().Find(cc => cc.Name == _sourcePage.Name);
            if (pageWithSameName != null)
            {
                if (replacePages)
                {



                    string pageName = pageWithSameName.Name;
                    _resultDocument.Pages[pageWithSameName.Name].Delete(Convert.ToInt16(false));
                    _destinationPage.Name = pageName;

                }
                else
                {
                    _destinationPage.Name = Guid.NewGuid().ToString();
                }
            }
            else
            {
                _destinationPage.Name = _sourcePage.Name;

            }

            //copy properties from source to dstination page
            _destinationPage.PageSheet.Cells["PageHeight"].FormulaU = _sourcePage.PageSheet.Cells["PageHeight"].get_ResultStr(Visio.VisUnitCodes.visInches);

            _destinationPage.PageSheet.Cells["PageWidth"].FormulaU = _sourcePage.PageSheet.Cells["PageWidth"].get_ResultStr(Visio.VisUnitCodes.visInches);

            _destinationPage.PageSheet.Cells["PrintPageOrientation"].FormulaU = _sourcePage.PageSheet.Cells["PrintPageOrientation"].get_ResultStrU(Visio.VisUnitCodes.visNumber);

            _destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPage, (short)Visio.VisCellIndices.visPageShdwOffsetX].FormulaU =
                _sourcePage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPage, (short)Visio.VisCellIndices.visPageShdwOffsetX].FormulaU;

            _destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPage, (short)Visio.VisCellIndices.visPageShdwOffsetY].FormulaU =
                _sourcePage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPage, (short)Visio.VisCellIndices.visPageShdwOffsetY].FormulaU;

            _destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOPlaceStyle].FormulaForceU =
                _sourcePage.PageSheet.CellsU["PlaceStyle"].FormulaU;
            //_destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLORouteStyle].FormulaForceU = "6"
            //_destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOLineToNodeX].FormulaForceU = "3.175 mm"
            //_destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOLineToNodeY].FormulaForceU = "3.175 mm"
            //_destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOBlockSizeX].FormulaForceU = "6.35 mm"
            //_destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOBlockSizeY].FormulaForceU = "6.35 mm"
            //_destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOAvenueSizeX].FormulaForceU = "15 mm"
            //_destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOAvenueSizeY].FormulaForceU = "15 mm"
            //_destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOLineToLineX].FormulaForceU = "3.175 mm"
            //_destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOLineToLineY].FormulaForceU = "3.175 mm"
            //_destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOSplit].FormulaForceU = "1"

            _destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPrintProperties, (short)Visio.VisCellIndices.visPrintPropertiesLeftMargin].FormulaU =
                _sourcePage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPrintProperties, (short)Visio.VisCellIndices.visPrintPropertiesLeftMargin].FormulaU;

            _destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPrintProperties, (short)Visio.VisCellIndices.visPrintPropertiesRightMargin].FormulaU =
                _sourcePage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPrintProperties, (short)Visio.VisCellIndices.visPrintPropertiesRightMargin].FormulaU;

            _destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPrintProperties, (short)Visio.VisCellIndices.visPrintPropertiesTopMargin].FormulaU =
                _sourcePage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPrintProperties, (short)Visio.VisCellIndices.visPrintPropertiesTopMargin].FormulaU;

            _destinationPage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPrintProperties, (short)Visio.VisCellIndices.visPrintPropertiesBottomMargin].FormulaU =
                _sourcePage.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPrintProperties, (short)Visio.VisCellIndices.visPrintPropertiesTopMargin].FormulaU;

            //_destinationPage.PageSheet.CellsSRC(visSectionUser, 0, visUserValue).FormulaForceU = "36"
            //_destinationPage.PageSheet.CellsSRC(visSectionUser, 1, visUserValue).FormulaForceU = "16"
            //_destinationPage.PageSheet.CellsSRC(visSectionUser, 2, visUserValue).FormulaForceU = "0"

        }

        public void CopyPage()
        {
            Visio.Shape Guide = _sourcePage.AddGuide((short)Visio.VisGuideTypes.visPoint, 0, 0);
            Guide.Name = "TemporaryGuide";
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
            _sourcePage.Shapes["TemporaryGuide"].Delete();
            _destinationPage.Shapes["TemporaryGuide"].Delete();
        }
    }
}

