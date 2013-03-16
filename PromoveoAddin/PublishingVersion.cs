using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;

namespace PromoveoAddin
{
    public class PublishingVersion
    {
        private static List<string> _pages;

        private PublishingVersion() { }

        public static void GetVersion(Visio.Page page)
        {
            string resultPage = _pages.Find(cc => cc == page.Name );
            if (string.IsNullOrEmpty(resultPage))
            {
                _pages.Add(resultPage);
                GetNewVersion(page);

                
            }
        }

        private static void GetNewVersion(Visio.Page page)
        {
            Visio.Shape versionBlock = page.Shapes.Cast<Visio.Shape>().ToList().Find(cc => (cc.Name == "VersionBlock"));
            if (versionBlock != null)
            {
                versionBlock.Shapes["Version"].Text = "new version";
                //return (Convert.ToInt32(currentVersion) + 1).ToString();
            }
            else
            {
                Visio.Shape version = page.DrawRectangle(0, 0, 200, 99);
                version.Text = "Publishing Version: 1";
                version.Name = "Version";
                Visio.Shape dateShape = page.DrawRectangle(0, 100, 200, 199);
                dateShape.Text = string.Format("Published on: {0:d}", DateTime.Now);
                dateShape.Name = "Date";
                Visio.Selection selectVersionShapes = page.CreateSelection(Visio.VisSelectionTypes.visSelTypeEmpty);
                selectVersionShapes.Select(version, 2);
                selectVersionShapes.Select(dateShape, 2);
                versionBlock = selectVersionShapes.Group();
                versionBlock.Name = "VersionBlock";
                

            }

        }

    }
}
