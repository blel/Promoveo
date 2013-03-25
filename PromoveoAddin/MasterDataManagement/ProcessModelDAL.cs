using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PromoveoAddin.Data;
using PromoveoAddin.Data.PromoveoDataSetTableAdapters;
using System.Data.SqlClient;
using Visio = Microsoft.Office.Interop.Visio;
using Office = Microsoft.Office.Core;

namespace PromoveoAddin.MasterDataManagement
{
    public class ProcessModelDAL:DALBaseClass
    {
        public PromoveoDataSet.ProcessModelDataTable GetProcessModels(int configurationID)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter("SELECT * FROM ProcessModel WHERE FK_Configuration = " + configurationID,
                    base._connectionString);
            sqlAdapter.Fill(ds.ProcessModel);
            return ds.ProcessModel;
        }

        public void Insert(string modelName, int configID)
        {
            ProcessModelTableAdapter adapter = new ProcessModelTableAdapter();
            adapter.Insert(modelName, "", null, configID);
        }


        public bool HasNewModels(Visio.Document document, int configurationID, out List<string> newModels)
        {
            bool hasNewModels = false;
            newModels = new List<string>();
            var processModels = this.GetProcessModels(configurationID);
            foreach (string modelName in document.Pages.Cast<Visio.Page>().Select(cc => cc.Name))
            {
                if (processModels.Rows.Cast<Data.PromoveoDataSet.ProcessModelRow>().Where(cc => cc.ProcessModel == modelName).Count() == 0)
                {
                    hasNewModels = true;
                    newModels.Add(modelName);
                }

            }
            return hasNewModels;
        }

        public void AddNewModels(List<string> modelNames, int configurationID)
        {
            MasterDataManagement.ProcessModelDAL processModelDAL = new MasterDataManagement.ProcessModelDAL();

            foreach (string modelName in modelNames)
            {
                processModelDAL.Insert(modelName, configurationID);
            }

        }

    }
}
