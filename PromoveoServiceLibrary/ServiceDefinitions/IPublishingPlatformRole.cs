using System;
using PromoveoServiceLibrary.DataAccessLayer;
using System.ServiceModel;

namespace PromoveoServiceLibrary.ServiceDefinitions
{
    [ServiceContract]
    interface IPublishingPlatformRole
    {
        [OperationContract]
        int CreateRole(Role role);

        [OperationContract]
        Role GetRole(int Id);

        [OperationContract]
        System.Collections.Generic.IList<Role> GetRoles();

        [OperationContract]
        void UpdateRole(Role role);
    }
}
