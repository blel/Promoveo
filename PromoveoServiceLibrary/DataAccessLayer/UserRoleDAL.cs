using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PromoveoServiceLibrary.Data;
using PromoveoServiceLibrary.Data.PromoveoDataSetTableAdapters;

namespace PromoveoServiceLibrary.DataAccessLayer
{
    public class UserRoleDAL : DALBaseClass, PromoveoServiceLibrary.ServiceDefinitions.IUserRole
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
        public IList<User> GetAssignedUsers(int roleID)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            UserRoleAssignmentTableAdapter userRoleAdapter = new UserRoleAssignmentTableAdapter();
            userRoleAdapter.Fill(ds.UserRoleAssignment,roleID);
            return ds.UserRoleAssignment.Select(cc => new User() { Email = cc.Email,
                Shortname = cc.Shortname,
                Name = cc.Name,
                Id = cc.Id }).ToList();
        }

        public IList<User> GetUnassignedUsers(int roleID)
        {
            IList<User> allUsers = new UserDAL().GetUsers();
            return allUsers.Except(GetAssignedUsers(roleID)).ToList();
        }

        public void AssignUser(int roleID, int userID)
        {
            if (!IsUserAssigned(roleID, userID))
            {
                PublishingPlatformUser_PublishingPlatformRoleTableAdapter userRoleAdapter = new PublishingPlatformUser_PublishingPlatformRoleTableAdapter();
                userRoleAdapter.Insert(roleID, userID);
            }
        }

        public void RemoveUser(int roleID, int userID)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            PublishingPlatformUser_PublishingPlatformRoleTableAdapter userRoleAdapter = new PublishingPlatformUser_PublishingPlatformRoleTableAdapter();
            userRoleAdapter.Fill(ds.PublishingPlatformUser_PublishingPlatformRole);
            if (IsUserAssigned(roleID, userID))
            {
                PromoveoDataSet.PublishingPlatformUser_PublishingPlatformRoleRow userToPublishingPlatformRoleAssignment ;
                userToPublishingPlatformRoleAssignment = ds.PublishingPlatformUser_PublishingPlatformRole.Where(cc => cc.FK_PublishingPlatformRole == roleID && cc.FK_PublishingPlatformUser == userID).Single();
                userRoleAdapter.Delete(userToPublishingPlatformRoleAssignment.Id, userToPublishingPlatformRoleAssignment.FK_PublishingPlatformRole, userToPublishingPlatformRoleAssignment.FK_PublishingPlatformUser);
            }
        }

        private bool IsUserAssigned(int roleID, int userID)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            PublishingPlatformUser_PublishingPlatformRoleTableAdapter userRoleAdapter = new PublishingPlatformUser_PublishingPlatformRoleTableAdapter();
            userRoleAdapter.Fill(ds.PublishingPlatformUser_PublishingPlatformRole);
            
            var assignedUsers = ds.PublishingPlatformUser_PublishingPlatformRole.Where(cc => (cc.FK_PublishingPlatformRole == roleID && cc.FK_PublishingPlatformUser == userID));
            if (assignedUsers.Count() > 0)
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// Conditions when thwo PublishingPlatformUserRows are equal
    /// </summary>
    public class UserEqualityComparer : IEqualityComparer<PromoveoDataSet.PublishingPlatformUserRow>
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
