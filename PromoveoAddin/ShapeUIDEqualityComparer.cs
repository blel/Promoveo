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
            CheckUID(shape1);
            CheckUID(shape2);

            if (shape1.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID] == shape2.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID])
                return true;
            return false;
        }

        public int GetHashCode(Visio.Shape shape)
        {
            CheckUID(shape);
            return shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID].GetHashCode();
        }

        private void CheckUID(Visio.Shape shape)
        {
            string uid = shape.UniqueID[(short)Visio.VisUniqueIDArgs.visGetGUID];
            if (string.IsNullOrEmpty(uid))
                throw new Exception (string.Format("The shape {0} does not have a UID.", shape.Name));
        }

    }
}
