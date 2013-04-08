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
            adapter.Insert(modelName, "", null, configID,null);
        }

        public bool IsModelOfConfiguration(string modelName, int configurationID)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            ProcessModelTableAdapter adapter = new ProcessModelTableAdapter();
            adapter.Fill(ds.ProcessModel);
            return (from cc in ds.ProcessModel
                    where cc.FK_Configuration == configurationID &&
                          cc.ProcessModel == modelName
                    select cc).Count() > 0;
        }


        public bool HasNewModels(Visio.Document document, int configurationID, out List<string> newModels)
        {
            bool hasNewModels = false;
            newModels = new List<string>();
            var processModels = this.GetProcessModels(configurationID);
            if (document != null)
            {
                foreach (string modelName in document.Pages.Cast<Visio.Page>().Select(cc => cc.Name))
                {
                    if (processModels.Rows.Cast<Data.PromoveoDataSet.ProcessModelRow>().Where(cc => cc.ProcessModel == modelName).Count() == 0)
                    {
                        hasNewModels = true;
                        newModels.Add(modelName);
                    }

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

        public void CreateVersion(string modelName, int configurationID)
        {
            ProcessModelTableAdapter adapter = new ProcessModelTableAdapter();
            PromoveoDataSet ds = new PromoveoDataSet();
            adapter.Fill(ds.ProcessModel);
            PromoveoDataSet.ProcessModelRow model = (from cc in ds.ProcessModel
                        where cc.ProcessModel == modelName && cc.FK_Configuration == configurationID
                        select cc).FirstOrDefault();
            if (model != null)
            {
                if (string.IsNullOrWhiteSpace(model.PublishingVersion))
                {
                    model.PublishingVersion = "1";
                }
                else
                {
                    model.PublishingVersion = (Convert.ToInt32(model.PublishingVersion) + 1).ToString();
                }
            }
            adapter.Update(ds.ProcessModel);
        }

        public void SetAcknowledgeState(int configurationID, string modelName, AcknowledgeState state)
        {
            PromoveoDataSet.ProcessModelDataTable pmTable = new PromoveoDataSet.ProcessModelDataTable();
            Data.PromoveoDataSetTableAdapters.ProcessModelTableAdapter adapter = new ProcessModelTableAdapter();
            adapter.Fill(pmTable);

            PromoveoDataSet.ProcessModelRow rowToUpdate = (from cc in pmTable
                                                          where cc.ProcessModel == modelName && cc.FK_Configuration == configurationID
                                                           select cc).FirstOrDefault();
            if (rowToUpdate == null)
            { 
                throw new Exception(string.Format("No configuration available with Key = {0} and model name = {1}", configurationID, modelName));
            }
            AcknowledgeState stateOfRowToUpdate = AcknowledgeState.None;
            if (rowToUpdate.AcknowledgeState != null)
            {
                 stateOfRowToUpdate = (AcknowledgeState)Enum.Parse(typeof(AcknowledgeState), rowToUpdate.AcknowledgeState);
            }
            switch (stateOfRowToUpdate)
            {
                case AcknowledgeState.Acknowledged:
                    rowToUpdate.AcknowledgeState = state.ToString();
                    break;
                case AcknowledgeState.Merged:
                    if (state == AcknowledgeState.MergedAndPublished)
                    {
                        rowToUpdate.AcknowledgeState = state.ToString();
                    }
                    break;
                case AcknowledgeState.MergedAndPublished:
                    if (state == AcknowledgeState.Acknowledged)
                        rowToUpdate.AcknowledgeState = state.ToString();
                    break;
                default:
                    rowToUpdate.AcknowledgeState = state.ToString();
                    break;
            }
            adapter.Update(pmTable);
        }



    }

}


