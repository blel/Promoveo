using System;
using System.ServiceModel;
namespace PromoveoWebService.ServiceDefinitions
{
    [ServiceContract]
    interface IModelUserRoles
    {
        [OperationContract]
        void AssignUser(int configurationID, int modelRoleID, int userID);

        [OperationContract]
        PromoveoWebService.Data.PromoveoDataSet.PublishingPlatformUserDataTable GetAssignedUser(int modelRoleID, int configurationID);

        [OperationContract]
        PromoveoWebService.Data.PromoveoDataSet.PublishingPlatformUserDataTable GetAvailableUser(int modelRoleID, int configurationID);

        [OperationContract]
        PromoveoWebService.Data.PromoveoDataSet.ModelUserGroupDataTable GetModelUserRoles(int configurationID);

        [OperationContract]
        void RemoveUser(int configurationID, int modelRoleID, int userID);

        [OperationContract]
        void Update(PromoveoWebService.Data.PromoveoDataSet.ModelUserGroupDataTable dataTable);
    }
}
