using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace PromoveoAddin
{
    /// <summary>
    /// this class does some additional tasks before calling the html publish
    /// function of visio.
    /// Even after the file has been published, some changes are done to the
    /// javascript files, and a xml file is created (userdata) containing the publishing platform
    /// users per model.
    /// </summary>
    public class CustomPublisher
    {
        private Visio.Document _document;
        private Visio.Application _app;
        private string _exportPath;
        private string _exportFileName;
        private string _exportFileSubDirectory;
        private string _printIcon;
        private int _configurationID;
        private BackgroundWorker _worker;
        public CustomPublisher(Visio.Application app, string fileName, int configurationID, BackgroundWorker worker)
        {
            _app = app;
            _document = app.ActiveDocument;
            //Path only where export files are saved
            _exportPath = FileHelper.EnsureTailBackslash(System.IO.Path.GetDirectoryName(fileName));
            //filename only of export file
            _exportFileName = System.IO.Path.GetFileNameWithoutExtension(fileName);
            //relative subpath to the export path
            _exportFileSubDirectory = _exportFileName + "_files\\";
            _configurationID = configurationID;
            _printIcon = SingletonVisioApp.GetCurrentVisioInstance().PrintIcon;
            _worker = worker;
        }

        public void StartPublish(bool includePrint)
        {
            try
            {
                System.IO.Directory.CreateDirectory(_exportPath + _exportFileSubDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when trying to create the directory: " + ex.Message);
            }
            if (includePrint)
            {
                Resources.Resources.print_icon_tcm46_328106.Save(_exportPath + _exportFileSubDirectory + "printicon.bmp");
                AddPdfToPages();
            }
            SetAcknowledgeState();
            SaveAsHtml();
        }

        /// <summary>
        /// creates a printable pdf for each page and links it to the visio page.
        /// </summary>
        private void AddPdfToPages()
        {
            try
            {
                for (int i = 1; i <= _document.Pages.Count; i++)
                {
                    //add watermark and export pdf
                    Visio.Shape watermark = AddWatermark(i);
                }
                for (int i = 1; i <= _document.Pages.Count; i++)
                {
                    try
                    {
                        _document.ExportAsFixedFormat(Visio.VisFixedFormatTypes.visFixedFormatPDF,
                            string.Format("{0}{1}.pdf", _exportPath + _exportFileSubDirectory, _document.Pages[i].Name),
                            Visio.VisDocExIntent.visDocExIntentPrint, Visio.VisPrintOutRange.visPrintFromTo, i, i);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("The pdf for page {0} could not be created. Error description: {1}", _document.Pages[i].Name,
                            ex.Message));
                    }
                }
                for (int i = 1; i <= _document.Pages.Count; i++)
                {

                    //remove watermark and add the printer icon
                    _document.Pages[i].Shapes["watermark"+i].Delete();

                    AddPrintIcon(i);
                    double temp = (double)i / (double)_document.Pages.Count * 100;

                    _worker.ReportProgress(Convert.ToInt32(temp));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }

        private void AddPrintIcon(int pageIndex)
        {
           
             
             if (_document.Pages[pageIndex].Shapes.Cast<Visio.Shape>().Where(cc => (cc.Name == "printicon" + pageIndex)).Count() == 0)
            {

                //drop the icon
                Visio.Shape shape = _document.Pages[pageIndex].Import(_exportPath + _exportFileSubDirectory + "printicon.bmp");
                shape.Name = "printicon" + pageIndex;
                shape.Cells["PinX"].FormulaU = "0";
                shape.Cells["PinY"].FormulaU = "0";

                //add hyperlink
                Visio.Hyperlink hyperlink = shape.Hyperlinks.Add();
                hyperlink.Name = "Link" + pageIndex;
                hyperlink.IsDefaultLink = Convert.ToInt16(true);
                hyperlink.Description = _document.Pages[pageIndex].Name;
                hyperlink.Address = string.Format("{0}{1}.pdf", _exportFileSubDirectory, _document.Pages[pageIndex].Name);
       
                
            }
            
        }

        private void SetAcknowledgeState()
        {
            foreach (Visio.Page page in _document.Pages)
            {
                MasterDataManagement.ProcessModelDAL pmDal = new MasterDataManagement.ProcessModelDAL();
                try
                {
                    pmDal.SetAcknowledgeState(_configurationID, page.Name, AcknowledgeState.MergedAndPublished);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
            settings.TargetPath = string.Format("{0}{1}.htm", _exportPath, _exportFileName);
            saveAsWebObj.CreatePages();
            
            OverwriteFramesetJs();
            SerializePublishPlatformUsers();

        }

        /// <summary>
        /// This method overwrites the frameset.js file which is created by the visio html publish function
        /// </summary>
        private void OverwriteFramesetJs()
        {
            string frameset = Resources.Resources.frameset;
            frameset = frameset.Replace("##FOLDERNAME##", FileHelper.EnsureNoTailBackslash(_exportFileSubDirectory));
            using (FileStream fs = File.Create(_exportPath+ _exportFileSubDirectory + "frameset.js"))
            using (TextWriter tw = new StreamWriter(fs))
            {
                tw.Write(frameset);
            }
        }

        /// <summary>
        /// creates an instance of the publishingplatformserializer and 
        /// creates the userdata.xml file.
        /// </summary>
        /// <param name="targetPath"></param>
        private void SerializePublishPlatformUsers()
        {         
            UserManagement.PublishingPlatformSerializer serializer =
                new UserManagement.PublishingPlatformSerializer(string.Format("{0}userdata.xml", _exportPath+_exportFileSubDirectory));
            serializer.PrepareObjects(_configurationID);
            serializer.SerializeModelUsers();
        }


        /// <summary>
        /// Adds a "watermark" to the visio page given by the index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Visio.Shape AddWatermark(int index)
        {
            Visio.Shape watermark = _document.Pages[index].DrawRectangle(0.787402, 3.464567, 11.023622, 5.11811);
            watermark.Name = "watermark" + index;
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
