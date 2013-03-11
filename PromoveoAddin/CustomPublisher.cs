using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace PromoveoAddin
{
    public class CustomPublisher
    {
        private Visio.Document _document;
        private Visio.Application _app;
        private string _exportPath;
        private string _printIcon;
        public CustomPublisher(Visio.Application app)
        {
            _app = app;
            _document = app.ActiveDocument;
            _exportPath = SingletonVisioApp.GetCurrentVisioInstance().ExportPath;
            _printIcon = SingletonVisioApp.GetCurrentVisioInstance().PrintIcon;

        }

        public void StartPublish(bool includePrint)
        {
            if (includePrint)
                AddPdfToPages();
            SaveAsHtml();
        }

        private void AddPdfToPages()
        {
            for (int i = 1; i <= _document.Pages.Count; i++)
            {

                Visio.Shape watermark = AddWatermark(i);
                _document.ExportAsFixedFormat(Visio.VisFixedFormatTypes.visFixedFormatPDF,
                    string.Format("{0}{1}.pdf", _exportPath, _document.Pages[i].Name),
                    Visio.VisDocExIntent.visDocExIntentPrint, Visio.VisPrintOutRange.visPrintFromTo, i, i);
                _document.Pages[i].Shapes[watermark.Name].Delete();
                Visio.Shape shape = _document.Pages[i].Import(_printIcon);
                shape.Cells["PinX"].FormulaU = "0";
                shape.Cells["PinY"].FormulaU = "0";
                Visio.Hyperlink hyperlink = shape.Hyperlinks.Add();
                hyperlink.Name = "Link"+i;
                hyperlink.IsDefaultLink = Convert.ToInt16(true);
                hyperlink.Description = _document.Pages[i].Name;
                hyperlink.Address = string.Format("{0}{1}.pdf",_exportPath, _document.Pages[i].Name);
            }
        }

        /// <summary>
        /// Saves the _document as web page with PNG format
        /// </summary>
        private void SaveAsHtml()
        {
            Microsoft.Office.Interop.Visio.SaveAsWeb.IVisSaveAsWeb saveAsWebObj =_app.SaveAsWebObject;
            Visio.SaveAsWeb.IVisWebPageSettings settings = saveAsWebObj.WebPageSettings;
            settings.PriFormat = "PNG";
            settings.SilentMode = Convert.ToInt16(true);
            settings.TargetPath = string.Format("{0}{1}.htm",_exportPath, _document.Name);
            saveAsWebObj.CreatePages();
        }

        private Visio.Shape AddWatermark(int index)
        {
            Visio.Shape watermark = _document.Pages[index].DrawRectangle(0.787402, 3.464567, 11.023622, 5.11811);
            watermark.Text = "Uncontrolled Copy!";
            watermark.SendToBack();
            watermark.FillStyle = "Text Only";
            watermark.LineStyle = "Text Only";
            watermark.CellsSRC[(short)Visio.VisSectionIndices.visSectionCharacter,0, (short)Visio.VisCellIndices.visCharacterSize].FormulaU = "60 pt";
            watermark.CellsSRC[(short)Visio.VisSectionIndices.visSectionCharacter, 0, (short)Visio.VisCellIndices.visCharacterColorTrans].FormulaU = "75%";
            return watermark;
        }



    }
}
