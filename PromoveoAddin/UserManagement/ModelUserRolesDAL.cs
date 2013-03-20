using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PromoveoAddin.Data;
using PromoveoAddin.Data.PromoveoDataSetTableAdapters;
using System.Data.SqlClient;

namespace PromoveoAddin.UserManagement
{
    public class ModelUserRolesDAL:DALBaseClass
    {
        public PromoveoDataSet.ModelUserGroupDataTable GetModelUserRoles(int configurationID)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter("SELECT * FROM ModelUserGroup WHERE FK_Configuration =" + configurationID,base._connectionString);
            sqlAdapter.Fill(ds.ModelUserGroup);
            
            return ds.ModelUserGroup;
        }

        public void Update(PromoveoDataSet.ModelUserGroupDataTable dataTable)
        {
            ModelUserGroupTableAdapter tableAdapter = new ModelUserGroupTableAdapter();
            tableAdapter.Update(dataTable);
        }


    }
}
