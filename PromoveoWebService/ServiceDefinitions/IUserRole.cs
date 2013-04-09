using System;
using System.ServiceModel;
namespace PromoveoWebService.ServiceDefinitions
{
    [ServiceContract]
    interface IUserRole
    {
        [OperationContract]
        void AssignUser(int roleID, int userID);

        [OperationContract]
        System.Collections.Generic.IEnumerable<PromoveoWebService.Data.PromoveoDataSet.PublishingPlatformUserRow> GetAssignedUsers(int roleID);

        [OperationContract]
        System.Collections.Generic.IEnumerable<PromoveoWebService.Data.PromoveoDataSet.PublishingPlatformUserRow> GetUnassignedUsers(int roleID);

        [OperationContract]
        void RemoveUser(int roleID, int userID);
    }
}
