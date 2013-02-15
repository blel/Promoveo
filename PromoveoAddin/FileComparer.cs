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


        public FileComparer()
        {
            
        }

        public void CompareFile(Visio.Document doc1, Visio.Document doc2)
        {

        }

        public void ComparePages(Visio.Page page1, Visio.Page page2, Visio.Page resultPage)
        {
            SingletonVisioApp.GetCurrentVisioInstance().VisioApp.EventsEnabled = Convert.ToInt16(false);
            GetMissingShapesOnPage2(page1, page2, resultPage);
            GetAdditionalShapesOnPage2(page1, page2, resultPage);
            GetModifiedShapes(page1, page2, resultPage);
            SingletonVisioApp.GetCurrentVisioInstance().VisioApp.EventsEnabled = Convert.ToInt16(true);
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
                        Visio.Shape resultShape = DropShapeOnPage(shape, resultPage);
                        resultShape.Cells["LineColor"].FormulaU = "RGB(255,0,0)";
                    }
                    else
                    {
                          //  Visio.Shape resultShape = DropShapeOnPage(shape, resultPage);
                        //}
                    }


                }

            }

        }

        public void GetAdditionalShapesOnPage2(Visio.Page page1, Visio.Page page2, Visio.Page resultPage)
        {
            foreach (Visio.Shape shape in page2.Shapes)
            {
                if (string.IsNullOrEmpty(shape.get_UniqueID((short)Visio.VisUniqueIDArgs.visGetGUID)))
                {
                    MessageBox.Show("Shape without Unique ID found. Comparing this shape is not possible.");
                }
                else
                {
                    if (page1.Shapes.ItemFromUniqueID[shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID]].UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID] !=
                        shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID])
                    {
                        Visio.Shape resultShape = DropShapeOnPage(shape, resultPage);
                        resultShape.Cells["LineColor"].FormulaU = "RGB(0,255,0)";
                    }
                    else
                    {
                        //  Visio.Shape resultShape = DropShapeOnPage(shape, resultPage);
                        //}
                    }


                }

            }
        }

        public void GetModifiedShapes(Visio.Page page1, Visio.Page page2, Visio.Page resultPage)
        {
            foreach (Visio.Shape shape in page1.Shapes)
            {
                if (string.IsNullOrEmpty(shape.get_UniqueID((short)Visio.VisUniqueIDArgs.visGetGUID)))
                {
                    MessageBox.Show("Shape without Unique ID found. Comparing this shape is not possible.");
                }
                else
                {
                    Visio.Shape comparedShape = page2.Shapes.ItemFromUniqueID[shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID]];

                    if (comparedShape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID] ==
                        shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID])
                    {
                        if (IsShapeModified(shape, comparedShape))
                        {
                            Visio.Shape resultShape = DropShapeOnPage(comparedShape, resultPage);
                            resultShape.Cells["LineColor"].FormulaU = "RGB(0,0,255)";
                        }
                        else
                        {
                            Visio.Shape resultShape = DropShapeOnPage(shape, resultPage);
                        }

                    }

                }

            }
        }

        private Visio.Shape DropShapeOnPage(Visio.Shape shape, Visio.Page resultPage)
        {
            double X;
            double Y;
            shape.Cells["EventDrop"].FormulaU = "";
            shape.Cells["EventMultiDrop"].FormulaU = "";
            X = Convert.ToDouble(shape.Cells["PinX"].Result[Visio.VisUnitCodes.visInches]);
            Y = Convert.ToDouble(shape.Cells["PinY"].Result[Visio.VisUnitCodes.visInches]);
            return resultPage.Drop(shape, X, Y);
        }

        private bool IsShapeModified(Visio.Shape shape1, Visio.Shape shape2)
        {
            bool result = false;

            result = shape1.Cells["PinX"].Result[(short)Visio.VisUnitCodes.visInches] != shape2.Cells["PinX"].Result[(short)Visio.VisUnitCodes.visInches] ?
                 true: result;

            result = shape1.Cells["PinY"].Result[(short)Visio.VisUnitCodes.visInches] != shape2.Cells["PinY"].Result[(short)Visio.VisUnitCodes.visInches] ?
                 true : result;
            return result;
 


        }


    }
}
