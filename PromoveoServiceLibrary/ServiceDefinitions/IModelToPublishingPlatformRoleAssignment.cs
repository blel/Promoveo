using System;
using System.ServiceModel;
using System.Collections.Generic;

namespace PromoveoServiceLibrary.ServiceDefinitions
{
    [ServiceContract]
    interface IModelToPublishingPlatformRoleAssignment
    {
        [OperationContract]
        IList<DataAccessLayer.ModelToPublishingPlatformRoleAssignment> GetModelsOfRole(int RoleId);

        [OperationContract]
        bool IsChecked(string Model, int RoleID);

        [OperationContract]
        void PersistRoleModelAssignment(string Model, int RoleID, bool isChecked);
    }
}
