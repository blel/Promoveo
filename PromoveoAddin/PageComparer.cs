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
            //Get normal shapes either on page 1 or 2
            GetShapesOnXExceptY(_page1, _page2, "RGB(255,0,0)", false);
            GetShapesOnXExceptY(_page2, _page1, "RGB(0,255,0)", false);

            //Get shapes on both pages  - if the shape has been modified, mark it
            GetIntersectionShapes("RGB(0,0,255)", false);

            //Get connectors either on page 1 or on page 2
            GetShapesOnXExceptY(_page1, _page2, "RGB(255,0,0)", true);
            GetShapesOnXExceptY(_page2, _page1, "RGB(0,255,0)", true);
            
            //Get Connectors on both pages - if the connector has been modified, mark it
            GetIntersectionShapes("RGB(0,0,255)", true);

            _app.EventsEnabled = Convert.ToInt16(true);
        }

        private void GetShapesOnXExceptY(Visio.Page pageX, Visio.Page pageY, string Color, bool isConnector)
        {
            //Get all shapes 
            try
            {
                var ShapesOnXExceptY = (from cc in pageX.Shapes.Cast<Visio.Shape>()
                                        where Convert.ToBoolean(cc.OneD) == isConnector
                                        select cc).Except(from ccc in pageY.Shapes.Cast<Visio.Shape>()
                                                          where Convert.ToBoolean(ccc.OneD) == isConnector
                                                          select ccc, new ShapeUIDEqualityComparer());
                foreach (Visio.Shape shape in ShapesOnXExceptY)
                {
                    Visio.Shape resultShape = DropShapeOnPage(shape, _resultPage);
                    String originalUID = shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID];
                    resultShape.Cells["LineColor"].FormulaU = Color;
                    resultShape.Data1 = originalUID;
                    if (isConnector)
                    {
                        string uidShapeFrom = shape.Connects[1].ToSheet.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID];
                        string uidShapeTo = shape.Connects[2].ToSheet.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID];
                        Visio.Shape fromShape = GetResultpageShape(uidShapeFrom);
                        Visio.Shape toShape = GetResultpageShape(uidShapeTo);
                        resultShape.Cells["BeginX"].GlueTo(fromShape.Cells["PinX"]);
                        resultShape.Cells["EndX"].GlueTo(toShape.Cells["PinX"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Promoveo For Visio");
            }
        }



        private void GetIntersectionShapes(string color, bool isConnector)
        {
            try
            {
                var intersectionShapes = (from cc in _page1.Shapes.Cast<Visio.Shape>()
                                          where Convert.ToBoolean(cc.OneD) == isConnector
                                          select cc).Intersect(from ccc in _page2.Shapes.Cast<Visio.Shape>()
                                                               where Convert.ToBoolean(ccc.OneD) == isConnector
                                                               select ccc, new ShapeUIDEqualityComparer());
                foreach (Visio.Shape shape in intersectionShapes)
                {
                    if (!isConnector)
                    {
                        Visio.Shape comparedShape = _page2.Shapes.ItemFromUniqueID[shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID]];
                        if (IsShapeModified(shape, comparedShape))
                        {
                            Visio.Shape resultShape = DropShapeOnPage(comparedShape, _resultPage);
                            resultShape.Cells["LineColor"].FormulaU = color;
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
                    else
                    {
                        Visio.Shape connector2 = _page2.Shapes.ItemFromUniqueID[shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID]];
                        Visio.Shape resultShape = DropShapeOnPage(connector2, _resultPage);
                        string uID = connector2.Connects[1].ToSheet.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID];
                        Visio.Shape fromShape = GetResultpageShape(uID);
                        Visio.Shape toShape = GetResultpageShape(connector2.Connects[2].ToSheet.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID]);
                        resultShape.Cells["BeginX"].GlueTo(fromShape.Cells["PinX"]);
                        resultShape.Cells["EndX"].GlueTo(toShape.Cells["PinX"]);
                        if (!AreEqual(shape, connector2))
                        {
                            resultShape.Cells["LineColor"].FormulaU = "RGB(0,255,0)";
                            resultShape = DropShapeOnPage(shape, _resultPage);
                            uID = shape.Connects[1].ToSheet.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID];
                            fromShape = GetResultpageShape(uID);
                            toShape = GetResultpageShape(shape.Connects[2].ToSheet.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID]);
                            resultShape.Cells["BeginX"].GlueTo(fromShape.Cells["PinX"]);
                            resultShape.Cells["EndX"].GlueTo(toShape.Cells["PinX"]);
                            resultShape.Cells["LineColor"].FormulaU = "RGB(255,0,0)";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Promoveo For Visio");
            }
        }

        private bool IsShapeModified(Visio.Shape shape1, Visio.Shape shape2)
        {
            bool result = false;
            //X position
            result = shape1.Cells["PinX"].Result[(short)Visio.VisUnitCodes.visInches] != shape2.Cells["PinX"].Result[(short)Visio.VisUnitCodes.visInches] ?
                 true : result;
            //y position
            result = shape1.Cells["PinY"].Result[(short)Visio.VisUnitCodes.visInches] != shape2.Cells["PinY"].Result[(short)Visio.VisUnitCodes.visInches] ?
                 true : result;
            //text
            result = shape1.Text != shape2.Text ? true : result;
            return result;
        }

        private void GetConnectors()
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
                toShape = inShape.Connects[2].ToSheet;
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
    }
}
