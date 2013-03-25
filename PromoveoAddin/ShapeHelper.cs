using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
namespace PromoveoAddin
{
    public static class ShapeHelper
    {
        public static void CreateGUID(Visio.Shape shape)
        {
            if (!Convert.ToBoolean(shape.CellExistsU["Prop.DiffGUID", (short)0]))
            {
                int row = shape.AddNamedRow((short)Visio.VisSectionIndices.visSectionProp,
                                        "DiffGUID",
                                        (short)Visio.VisRowTags.visTagDefault);

                shape.CellsSRC[(short)Visio.VisSectionIndices.visSectionProp,
                               (short)row,
                               (short)Visio.VisCellIndices.visCustPropsLabel].FormulaU = "\"DiffGUID\"";
                shape.CellsSRC[(short)Visio.VisSectionIndices.visSectionProp,
               (short)row,
               (short)Visio.VisCellIndices.visCustPropsInvis].FormulaU = "1";
                shape.CellsSRC[(short)Visio.VisSectionIndices.visSectionProp,
                               (short)row,
                               (short)Visio.VisCellIndices.visCustPropsValue].FormulaU = "\"" + Guid.NewGuid().ToString() + "\"";
            }
        }

        public static string GetGUID(Visio.Shape shape)
        {
            string uid;
            if (Convert.ToBoolean(shape.CellExistsU["Prop.DiffGUID", (short)0]))
            {
                string tmp = shape.CellsU["Prop.DiffGUID"].FormulaU;
                uid = tmp.Substring(1, tmp.Length - 2);
            }
            else
            {
                uid = shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID];
            }
            if (string.IsNullOrEmpty(uid))
                throw new Exception(string.Format("The shape {0} does not have a UID.", shape.Name));
            return uid;
        }

        public static Visio.Shape FindShapeByGUID(Visio.Page page, string GUID)
        {
            return (from cc in page.Shapes.Cast<Visio.Shape>()
                    where GetGUID(cc) == GUID
                    select cc).SingleOrDefault();
        }

    }
}
