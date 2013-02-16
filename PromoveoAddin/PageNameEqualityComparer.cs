using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;

namespace PromoveoAddin
{
    public class PageNameEqualityComparer : IEqualityComparer<Visio.Page>
    {
        public bool Equals(Visio.Page page1, Visio.Page page2)
        {
            if (page1.Name == page2.Name)
                return true;
            return false;
        }

        public int GetHashCode(Visio.Page page)
        {
            return page.Name.GetHashCode();
        }

    }
}
