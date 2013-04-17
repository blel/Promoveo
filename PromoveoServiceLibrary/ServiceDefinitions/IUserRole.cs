using System;
using System.ServiceModel;
using System.Collections.Generic;
namespace PromoveoServiceLibrary.ServiceDefinitions
{
    [ServiceContract]
    interface IUserRole
    {
        [OperationContract]
        void AssignUser(int roleID, int userID);

        [OperationContract]
        IList<DataAccessLayer.User> GetAssignedUsers(int roleID);

        [OperationContract]
        IList<DataAccessLayer.User> GetUnassignedUsers(int roleID);

        [OperationContract]
        void RemoveUser(int roleID, int userID);
    }
}
