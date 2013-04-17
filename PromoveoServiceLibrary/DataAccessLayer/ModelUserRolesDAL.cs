using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PromoveoServiceLibrary.Data;
using PromoveoServiceLibrary.Data.PromoveoDataSetTableAdapters;
using System.Data.SqlClient;

namespace PromoveoServiceLibrary.DataAccessLayer
{
    public class ModelUserRolesDAL : DALBaseClass, PromoveoServiceLibrary.ServiceDefinitions.IModelUserRoles
    {
        public IList<Role> GetModelUserRoles(int configurationID)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter("SELECT * FROM ModelUserGroup WHERE FK_Configuration =" + configurationID,base._connectionString);
            sqlAdapter.Fill(ds.ModelUserGroup);
            List<Role> modelUserRoles = new List<Role>();
            modelUserRoles.AddRange(ds.ModelUserGroup.Select(cc=> new Role(){Id = cc.Id, FK_Configuration = cc.FK_Configuration, Name= cc.Name}));
            return modelUserRoles;
        }

        //public void Update(PromoveoDataSet.ModelUserGroupDataTable dataTable)
        //{
        //    ModelUserGroupTableAdapter tableAdapter = new ModelUserGroupTableAdapter();
        //    tableAdapter.Update(dataTable);
        //}

        public IList<User> GetAssignedUser(int modelRoleID, int configurationID)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter("SELECT * FROM PublishingPlatformUser INNER JOIN UserToModelUserGroupAssignment ON " +
                                                           "PublishingPlatformUser.Id = UserToModelUserGroupAssignment.FK_User " +
                                                           "INNER JOIN ModelUserGroup ON UserToModelUserGroupAssignment.FK_ModelUserGroup = " +
                                                           "ModelUserGroup.Id WHERE ModelUserGroup.FK_Configuration = " + configurationID +
                                                           " AND ModelUserGroup.Id = " + modelRoleID, base._connectionString);
            sqlAdapter.Fill(ds.PublishingPlatformUser);
            List<User> users = new List<User>();
            users.AddRange( ds.PublishingPlatformUser.Select(cc=>new User(){Id = cc.Id, Name = cc.Name, Shortname = cc.Shortname, Email = cc.Email}));
            return users;
        }

        public IList<User> GetAvailableUser(int modelRoleID, int configurationID)
        {
            IList<User> assignedUser = GetAssignedUser(modelRoleID, configurationID);
            PromoveoDataSet ds = new PromoveoDataSet();
            Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter userAdapter = new PublishingPlatformUserTableAdapter();
            userAdapter.Fill(ds.PublishingPlatformUser);
            List<User> allUsers = new List<User>();
            allUsers.AddRange(ds.PublishingPlatformUser.Select(cc=>new User(){ Email = cc.Email, Shortname  = cc.Shortname, Name= cc.Name, Id=cc.Id}));          
            return allUsers.Except(assignedUser).ToList();
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
                modelUserRoleAdapter.Delete(modelUserAssignment.Id, modelUserAssignment.FK_User, modelUserAssignment.FK_ModelUserGroup);
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
