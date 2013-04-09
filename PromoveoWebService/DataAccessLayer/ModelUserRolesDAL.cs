using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PromoveoWebService.Data;
using PromoveoWebService.Data.PromoveoDataSetTableAdapters;
using System.Data.SqlClient;

namespace PromoveoWebService.DataAccessLayer
{
    public class ModelUserRolesDAL : DALBaseClass, PromoveoWebService.ServiceDefinitions.IModelUserRoles
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

        public Data.PromoveoDataSet.PublishingPlatformUserDataTable GetAssignedUser(int modelRoleID, int configurationID)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter("SELECT * FROM PublishingPlatformUser INNER JOIN UserToModelUserGroupAssignment ON " +
                                                           "PublishingPlatformUser.Id = UserToModelUserGroupAssignment.FK_User " +
                                                           "INNER JOIN ModelUserGroup ON UserToModelUserGroupAssignment.FK_ModelUserGroup = " +
                                                           "ModelUserGroup.Id WHERE ModelUserGroup.FK_Configuration = " + configurationID +
                                                           " AND ModelUserGroup.Id = " + modelRoleID, base._connectionString);
            sqlAdapter.Fill(ds.PublishingPlatformUser);
            return ds.PublishingPlatformUser;
        }

        public Data.PromoveoDataSet.PublishingPlatformUserDataTable GetAvailableUser(int modelRoleID, int configurationID)
        {
            Data.PromoveoDataSet.PublishingPlatformUserDataTable assignedUser = GetAssignedUser(modelRoleID, configurationID);
            PromoveoDataSet ds = new PromoveoDataSet();
            Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter userAdapter = new PublishingPlatformUserTableAdapter();
            userAdapter.Fill(ds.PublishingPlatformUser);
            var result = ds.PublishingPlatformUser.Except(assignedUser, new UserEqualityComparer());
            Data.PromoveoDataSet.PublishingPlatformUserDataTable availableUser = new PromoveoDataSet.PublishingPlatformUserDataTable();
            foreach (var row in result)
            {
                availableUser.ImportRow(row);
            }
            return availableUser;
        }

        public void AssignUser(int configurationID, int modelRoleID, int userID)
        {
            PromoveoDataSet.UserToModelUserGroupAssignmentRow modelUserAssignment;
            if (!IsUserAssigned(configurationID, modelRoleID, userID, out modelUserAssignment))
            {
                UserToModelUserGroupAssignmentTableAdapter modelUserRoleAdapter = new UserToModelUserGroupAssignmentTableAdapter();
                modelUserRoleAdapter.Insert(userID, modelRoleID);
            }

        }


        public void RemoveUser(int configurationID, int modelRoleID, int userID)
        {
            PromoveoDataSet.UserToModelUserGroupAssignmentRow modelUserAssignment;
            if (IsUserAssigned(configurationID, modelRoleID, userID, out modelUserAssignment))
            {
                UserToModelUserGroupAssignmentTableAdapter modelUserRoleAdapter = new UserToModelUserGroupAssignmentTableAdapter();
                //TODO: got an error here, before I had three parameters, now the ID only
                modelUserRoleAdapter.Delete(modelUserAssignment.Id);
            }
        }

        private bool IsUserAssigned(int configurationID, int modelRoleID, int userID, out PromoveoDataSet.UserToModelUserGroupAssignmentRow modelUserAssignment)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter( "SELECT * FROM UserToModelUserGroupAssignment " +
                                        "INNER JOIN ModelUserGroup ON UserToModelUserGroupAssignment.FK_ModelUserGroup = ModelUserGroup.Id " +
                                        "WHERE UserToModelUserGroupAssignment.FK_User = " + userID +
                                        " AND ModelUserGroup.Id = " + modelRoleID +
                                        " AND ModelUserGroup.FK_Configuration = " + configurationID, base._connectionString);
            sqlAdapter.Fill(ds.UserToModelUserGroupAssignment);
            if (ds.UserToModelUserGroupAssignment.Count > 0)
            {
                modelUserAssignment = ds.UserToModelUserGroupAssignment.First();
                return true;
            }
            else
            {
                modelUserAssignment = null;
                return false;
            }
        }



    }

    
}
