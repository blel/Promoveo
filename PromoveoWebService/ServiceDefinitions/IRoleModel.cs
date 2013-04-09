using System;
using System.ServiceModel;
namespace PromoveoWebService.ServiceDefinitions
{
    [ServiceContract]
    interface IRoleModel
    {
        [OperationContract]
        PromoveoWebService.Data.PromoveoDataSet.ProcessModel_PublishingPlatformRoleDataTable GetModelsOfRole(int RoleId);

        [OperationContract]
        bool IsChecked(string Model, int RoleID);

        [OperationContract]
        void PersistRoleModelAssignment(string Model, int RoleID, bool isChecked);
    }
}
