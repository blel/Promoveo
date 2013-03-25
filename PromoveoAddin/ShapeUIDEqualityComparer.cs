using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;

namespace PromoveoAddin
{
    public class ShapeUIDEqualityComparer:IEqualityComparer<Visio.Shape>
    {
        public bool Equals(Visio.Shape shape1, Visio.Shape shape2)
        {
            string uidShape1 = ShapeHelper.GetGUID(shape1);
            string uidShape2 = ShapeHelper.GetGUID(shape2);

            if (uidShape1 == uidShape2)
                return true;
            return false;
        }

        public int GetHashCode(Visio.Shape shape)
        {
            string uidShape = ShapeHelper.GetGUID(shape);
            return uidShape.GetHashCode();
        }



    }
}
