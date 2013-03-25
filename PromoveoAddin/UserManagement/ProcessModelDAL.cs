using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PromoveoAddin.Data;
using PromoveoAddin.Data.PromoveoDataSetTableAdapters;

namespace PromoveoAddin.UserManagement
{
    public class ProcessModelDAL:DALBaseClass
    {
        public PromoveoDataSet.ProcessModelDataTable GetProcessModels()
        {
            ProcessModelTableAdapter adapter = new ProcessModelTableAdapter();
            PromoveoDataSet.ProcessModelDataTable table = new PromoveoDataSet.ProcessModelDataTable();
            adapter.Fill(table);
            return table;
        }

        public PromoveoDataSet.ProcessModelDataTable GetProcessModels(int configurationID)
        {
            SqlDataAdapter sqlAdapter = new SqlDataAdapter("SELECT * FROM ProcessModel WHERE FK_Configuration = " + configurationID, base._connectionString);
            PromoveoDataSet.ProcessModelDataTable table = new PromoveoDataSet.ProcessModelDataTable();
            sqlAdapter.Fill(table);
            return table;
        }


        public int GetModelID(string processModel)
        {
           ProcessModelTableAdapter adapter = new ProcessModelTableAdapter();
            PromoveoDataSet.ProcessModelDataTable table = new PromoveoDataSet.ProcessModelDataTable();
            adapter.Fill(table);
            return (from cc in table.AsEnumerable()
                    where cc.ProcessModel == processModel
                    select cc).First().Id;

        }

        public PromoveoDataSet.ProcessModelUsersDataTable GetUsers(string processModel)
        {
            ProcessModelUsersTableAdapter pmuAdapter = new ProcessModelUsersTableAdapter();

            return pmuAdapter.GetData1(processModel);





        }




    }
}
