using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PromoveoWebService.Data;
using PromoveoWebService.Data.PromoveoDataSetTableAdapters;

namespace PromoveoWebService.DataAccessLayer
{
    public class UserRoleDAL : DALBaseClass, PromoveoWebService.ServiceDefinitions.IUserRole
    {
        /// <summary>
        /// This function is a little bit shaky. First, in the dataset, a query is created which returns
        /// the users assigned to a role, and then a IEnumerable of UserRow is created.
        /// The reason is, that I want to use Except in the GetUnassignedUsers, and both Assigned and Unassigned Users shall return
        /// the same type.
        /// Instead of creatign a query, the result set could be retrieved programmatically.
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public IEnumerable<Data.PromoveoDataSet.PublishingPlatformUserRow> GetAssignedUsers(int roleID)
        {
            Data.PromoveoDataSet ds = new Data.PromoveoDataSet();
            Data.PromoveoDataSetTableAdapters.UserRoleAssignmentTableAdapter userRoleAdapter = new Data.PromoveoDataSetTableAdapters.UserRoleAssignmentTableAdapter();
            userRoleAdapter.Fill(ds.UserRoleAssignment,roleID);
            PromoveoDataSet.PublishingPlatformUserDataTable userTable = new PromoveoDataSet.PublishingPlatformUserDataTable();
            foreach (Data.PromoveoDataSet.UserRoleAssignmentRow row in ds.UserRoleAssignment.Rows)
            {
                Data.PromoveoDataSet.PublishingPlatformUserRow newUserRow = userTable.NewPublishingPlatformUserRow();
                newUserRow.Id = row.Id;
                newUserRow.Name = row.Name;
                newUserRow.Shortname = row.Shortname;
                newUserRow.Email = row["Email"] == DBNull.Value?null:row.Email;
                userTable.AddPublishingPlatformUserRow(newUserRow);
            }
            return userTable.AsEnumerable();
        }

        public IEnumerable<Data.PromoveoDataSet.PublishingPlatformUserRow> GetUnassignedUsers(int roleID)
        {
            Data.PromoveoDataSet ds = new Data.PromoveoDataSet();
            Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter userAdapter = new Data.PromoveoDataSetTableAdapters.PublishingPlatformUserTableAdapter();
            userAdapter.Fill(ds.PublishingPlatformUser);
            return ds.PublishingPlatformUser.Except(GetAssignedUsers(roleID), new UserEqualityComparer());        
        }

        public void AssignUser(int roleID, int userID)
        {
            PromoveoDataSet.PublishingPlatformUser_PublishingPlatformRoleRow assignedUser;
            if (!IsUserAssigned(roleID, userID, out assignedUser))
            {
                PublishingPlatformUser_PublishingPlatformRoleTableAdapter userRoleAdapter = new PublishingPlatformUser_PublishingPlatformRoleTableAdapter();
                userRoleAdapter.Insert(roleID, userID);
            }
        }

        public void RemoveUser(int roleID, int userID)
        {
            PromoveoDataSet.PublishingPlatformUser_PublishingPlatformRoleRow assignedUser;
            PromoveoDataSet ds = new PromoveoDataSet();
            PublishingPlatformUser_PublishingPlatformRoleTableAdapter userRoleAdapter = new PublishingPlatformUser_PublishingPlatformRoleTableAdapter();
            
            if (IsUserAssigned(roleID, userID,out assignedUser))
            {
                //TODO: got an error here, before I had three parameters, now the ID only
                userRoleAdapter.Delete(assignedUser.Id);
            }
        }


        private bool IsUserAssigned(int roleID, int userID, out PromoveoDataSet.PublishingPlatformUser_PublishingPlatformRoleRow assignedUser)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            PublishingPlatformUser_PublishingPlatformRoleTableAdapter userRoleAdapter = new PublishingPlatformUser_PublishingPlatformRoleTableAdapter();
            userRoleAdapter.Fill(ds.PublishingPlatformUser_PublishingPlatformRole);
            var assignedUsers = ds.PublishingPlatformUser_PublishingPlatformRole.Where(cc => (cc.FK_PublishingPlatformRole == roleID && cc.FK_PublishingPlatformUser == userID));
            if (assignedUsers.Count() > 0)
                assignedUser = assignedUsers.First();
            else
                assignedUser = null;
            return assignedUser != null;
        }
    }

    /// <summary>
    /// Conditions when thwo PublishingPlatformUserRows are equal
    /// </summary>
    public class UserEqualityComparer : IEqualityComparer<Data.PromoveoDataSet.PublishingPlatformUserRow>
    {
        public bool Equals(PromoveoDataSet.PublishingPlatformUserRow x, PromoveoDataSet.PublishingPlatformUserRow y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(PromoveoDataSet.PublishingPlatformUserRow obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
