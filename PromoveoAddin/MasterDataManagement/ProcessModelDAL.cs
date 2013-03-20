using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PromoveoAddin.Data;
using PromoveoAddin.Data.PromoveoDataSetTableAdapters;
using System.Data.SqlClient;

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




    }
}
