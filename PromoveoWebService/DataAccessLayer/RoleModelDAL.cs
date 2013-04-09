using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PromoveoWebService.DataAccessLayer
{
    public class RoleModelDAL : DALBaseClass, PromoveoWebService.ServiceDefinitions.IRoleModel
    {
        
        
        public Data.PromoveoDataSet.ProcessModel_PublishingPlatformRoleDataTable GetModelsOfRole(int RoleId)
        {
            Data.PromoveoDataSet.ProcessModel_PublishingPlatformRoleDataTable _roleModelTable =
                new Data.PromoveoDataSet.ProcessModel_PublishingPlatformRoleDataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM ProcessModel_PublishingPlatformRole WHERE FK_PublishingPlatformRole = " + RoleId,
                base._connectionString);
            adapter.Fill(_roleModelTable);
            return _roleModelTable;
        }

        public bool IsChecked(string Model, int RoleID)
        {
            ProcessModelDAL pmDal = new ProcessModelDAL();
            int pmId = pmDal.GetModelID(Model);
            Data.PromoveoDataSet.ProcessModel_PublishingPlatformRoleDataTable roleModelTable = new Data.PromoveoDataSet.ProcessModel_PublishingPlatformRoleDataTable();
            Data.PromoveoDataSetTableAdapters.ProcessModel_PublishingPlatformRoleTableAdapter roleModelAdapter = new Data.PromoveoDataSetTableAdapters.ProcessModel_PublishingPlatformRoleTableAdapter();
            roleModelAdapter.Fill(roleModelTable);
            var row = (from cc in roleModelTable.AsEnumerable()
                       where cc.FK_ProcessModel == pmId &&
                             cc.FK_PublishingPlatformRole == RoleID
                       select cc).FirstOrDefault();
            return (row != null);

        }

        
        public void PersistRoleModelAssignment(string Model, int RoleID, bool isChecked)
        {
            ProcessModelDAL pmDal = new ProcessModelDAL();
            int pmId = pmDal.GetModelID(Model);
            
            Data.PromoveoDataSet.ProcessModel_PublishingPlatformRoleDataTable roleModelTable = new Data.PromoveoDataSet.ProcessModel_PublishingPlatformRoleDataTable();
            Data.PromoveoDataSetTableAdapters.ProcessModel_PublishingPlatformRoleTableAdapter roleModelAdapter = new Data.PromoveoDataSetTableAdapters.ProcessModel_PublishingPlatformRoleTableAdapter();
            roleModelAdapter.Fill(roleModelTable);
            var row = (from cc in roleModelTable.AsEnumerable() 
                where cc.FK_ProcessModel == pmId &&
                      cc.FK_PublishingPlatformRole == RoleID
                select cc).FirstOrDefault();
            if (isChecked)
            {
                if (row == null)
                {
                    roleModelAdapter.Insert(pmId, RoleID);
                }
            }
            else
            {
                if (row != null)
                {
                    //TODO: got an error here, before I had three parameters, now the ID only
                    roleModelAdapter.Delete(row.Id);
                }
            }
        }


    }
}
