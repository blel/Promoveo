using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;


namespace PromoveoAddin
{
    public class PageComparer
    {
        private Visio.Page _page1;
        private Visio.Page _page2;
        private Visio.Page _resultPage;
        private Visio.Application _app;

        public PageComparer(Visio.Application app, Visio.Page page1, Visio.Page page2, Visio.Page resultPage)
        {
            _page1 = page1;
            _page2 = page2;
            _resultPage = resultPage;
            _app = app;
        }

        public void ComparePages()
        {
            _app.EventsEnabled = Convert.ToInt16(false);
            GetMissingShapesOnPage2();
            GetAdditionalShapesOnPage2();
            GetModifiedShapes();
            GetConnectors();
            _app.EventsEnabled = Convert.ToInt16(true);
        }

        public void GetMissingShapesOnPage2()
        {
            var normalShapes = from cc in _page1.Shapes.Cast<Visio.Shape>()
                               where Convert.ToBoolean(cc.OneD) == false
                               select cc;
            foreach (Visio.Shape shape in normalShapes)
            {
                if (string.IsNullOrEmpty(shape.get_UniqueID((short)Visio.VisUniqueIDArgs.visGetGUID)))
                {
                    MessageBox.Show("Shape without Unique ID found. Comparing this shape is not possible.");
                }
                else
                {
                    if (_page2.Shapes.ItemFromUniqueID[shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID]].UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID] !=
                        shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID])
                    {                       
                        Visio.Shape resultShape = DropShapeOnPage(shape, _resultPage);
                        String originalUID = shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID];
                        resultShape.Cells["LineColor"].FormulaU = "RGB(255,0,0)";
                        resultShape.Data1 = originalUID;
                    }
                    else
                    {
                          //  Visio.Shape resultShape = DropShapeOnPage(shape, resultPage);
                        //}
                    }


                }

            }

        }

        public void GetAdditionalShapesOnPage2()
        {
            var normalShapes = from cc in _page2.Shapes.Cast<Visio.Shape>()
                               where Convert.ToBoolean(cc.OneD) == false
                               select cc;
            
            foreach (Visio.Shape shape in normalShapes)
            {
                if (string.IsNullOrEmpty(shape.get_UniqueID((short)Visio.VisUniqueIDArgs.visGetGUID)))
                {
                    MessageBox.Show("Shape without Unique ID found. Comparing this shape is not possible.");
                }
                else
                {
                    if (_page1.Shapes.ItemFromUniqueID[shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID]].UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID] !=
                        shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID])
                    {

                        Visio.Shape resultShape = DropShapeOnPage(shape, _resultPage);
                        resultShape.Cells["LineColor"].FormulaU = "RGB(0,255,0)";
                        String originalUID = shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID];
                        resultShape.Data1 = originalUID;


                    }

                }

            }
        }

        public void GetConnectors()
        {
            var connectorShapes = from cc in _page1.Shapes.Cast<Visio.Shape>()
                                 where Convert.ToBoolean(cc.OneD) == true
                                 select cc;

            foreach (Visio.Shape connector in connectorShapes)
            {
                if (string.IsNullOrEmpty(connector.get_UniqueID((short)Visio.VisUniqueIDArgs.visGetGUID)))
                {
                    MessageBox.Show("Shape without Unique ID found. Comparing this shape is not possible.");
                }
                else
                {
                    Visio.Shape connector2 = _page2.Shapes.ItemFromUniqueID[connector.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID]];
                    if (connector2.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID] ==
                        connector.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID])
                    {

                        if (AreEqual(connector, connector2))
                        {
                            Visio.Shape resultShape = DropShapeOnPage(connector2, _resultPage);
                            string uID = connector2.Connects[1].ToSheet.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID];
                            Visio.Shape fromShape = GetResultpageShape(uID);
                            Visio.Shape toShape = GetResultpageShape(connector2.Connects[2].ToSheet.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID]);



                            resultShape.Cells["BeginX"].GlueTo(fromShape.Cells["PinX"]);
                            resultShape.Cells["EndX"].GlueTo(toShape.Cells["PinX"]);
                        }


                    }

                }

            }


        }

        private Visio.Shape GetResultpageShape(string uID)
        {
            return (from cc in _resultPage.Shapes.Cast<Visio.Shape>()
                    where cc.Data1 == uID
                    select cc).FirstOrDefault();
        }


        public void GetFromToShapes( Visio.Shape inShape, out Visio.Shape fromShape, out Visio.Shape toShape)
        {
            
            if (inShape.Connects.Count > 2)
            {
                MessageBox.Show("To many shapes...");
                fromShape = null;
                toShape = null;
            }
            else
            {
                fromShape = inShape.Connects[1].ToSheet;
                MessageBox.Show(fromShape.Name);
                toShape = inShape.Connects[2].ToSheet;
                MessageBox.Show(toShape.Name);
            }
        }

        private bool AreEqual(Visio.Shape connector1, Visio.Shape connector2)
        {
            bool result= false;
            Visio.Shape connector1FromShape, connector1ToShape, connector2FromShape, connector2ToShape;
            GetFromToShapes(connector1, out connector1FromShape, out connector1ToShape);
            GetFromToShapes(connector2, out connector2FromShape, out connector2ToShape);

            if (connector1FromShape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID] == connector2FromShape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID] &&
                connector1ToShape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID] == connector2ToShape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID])
                result = true;

            return result;
        }

        public void GetModifiedShapes()
        {
            var normalShapes = from cc in _page1.Shapes.Cast<Visio.Shape>()
                               where Convert.ToBoolean(cc.OneD) == false
                               select cc;
            foreach (Visio.Shape shape in normalShapes)
            {
                if (string.IsNullOrEmpty(shape.get_UniqueID((short)Visio.VisUniqueIDArgs.visGetGUID)))
                {
                    MessageBox.Show("Shape without Unique ID found. Comparing this shape is not possible.");
                }
                else
                {
                    Visio.Shape comparedShape = _page2.Shapes.ItemFromUniqueID[shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID]];

                    if (comparedShape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID] ==
                        shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID])
                    {
                        if (IsShapeModified(shape, comparedShape))
                        {
                            Visio.Shape resultShape = DropShapeOnPage(comparedShape, _resultPage);
                            resultShape.Cells["LineColor"].FormulaU = "RGB(0,0,255)";
                            String originalUID = shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID];
                            resultShape.Data1 = originalUID;
                        }
                        else
                        {
                            Visio.Shape resultShape = DropShapeOnPage(shape, _resultPage);
                            String originalUID = shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID];
                            resultShape.Data1 = originalUID;
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
