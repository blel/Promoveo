using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PromoveoAddin
{
    public static class FileHelper
    {
        public static OpenFileDialog OpenFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All Visio Documents|*.vsd";
            
            DialogResult result = fileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                try
                {
                    SingletonVisioApp.GetCurrentVisioInstance().VisioApp.Documents.Open(fileDialog.FileName);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Error: " + Ex.Message);
                }
            }
            return fileDialog;
        }




        public static string EnsureTailBackslash(string path)
        {
            return path.Last() == '\\' ? path : path + '\\';
        }

        public static string EnsureNoTailBackslash(string path)
        {
            return path.Last() == '\\' ? path.Substring(0,path.Length-1) : path;
        }

    }
}
