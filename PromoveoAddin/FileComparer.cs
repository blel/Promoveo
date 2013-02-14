using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace PromoveoAddin
{
    public class FileComparer
    {
        public void CompareFile(Visio.Document doc1, Visio.Document doc2)
        {

        }

        public void ComparePages(Visio.Page page1, Visio.Page page2, Visio.Page resultPage)
        {
            GetMissingShapesOnPage2(page1, page2, resultPage);
        }


        public void GetMissingShapesOnPage2(Visio.Page page1, Visio.Page page2, Visio.Page resultPage)
        {
            foreach (Visio.Shape shape in page1.Shapes)
            {
                if (string.IsNullOrEmpty(shape.get_UniqueID((short)Visio.VisUniqueIDArgs.visGetGUID)))
                {
                    MessageBox.Show("Shape without Unique ID found. Comparing this shape is not possible.");
                }
                else
                {
                    if (page2.Shapes.ItemFromUniqueID[shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID]].UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID] !=
                        shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID])
                    {
                        MessageBox.Show(string.Format("Shape {0} is missing on page 2.", shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID]));
                        
                        Visio.Shape resultShape = DropShapeOnPage(shape, resultPage);
                        resultShape.Cells["LineColor"].FormulaU = "RGB(255,0,0)";
                    }
                    else
                    {
                        if (shape.Type == (short)Visio.VisShapeTypes.visTypeGroup)
                        {
                            Visio.Shape resultShape = DropShapeOnPage(shape, resultPage);
                        }
                    }


                }

            }

        }

        public void GetAdditionalShapesOnPage2(Visio.Page page1, Visio.Page page2, Visio.Page resultPage)
        {

        }

        public void GetModifiedShapes(Visio.Page page1, Visio.Page page2, Visio.Page resultPage)
        {

        }

        private Visio.Shape DropShapeOnPage(Visio.Shape shape, Visio.Page resultPage)
        {
            double X;
            double Y;
            X = Convert.ToDouble(shape.Cells["PinX"].Result[Visio.VisUnitCodes.visInches]);
            Y = Convert.ToDouble(shape.Cells["PinY"].Result[Visio.VisUnitCodes.visInches]);
            return resultPage.Drop(shape, X, Y);
        }




    }
}
