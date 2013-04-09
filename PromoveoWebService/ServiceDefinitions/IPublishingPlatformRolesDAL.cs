using System;
using System.ServiceModel;
namespace PromoveoWebService.ServiceDefinitions
{
    [ServiceContract]
    interface IPublishingPlatformRolesDAL
    {
        [OperationContract]
        void CreateRole(PromoveoWebService.Data.PromoveoDataSet.PublishingPlatformRoleDataTable data);
    }
}
