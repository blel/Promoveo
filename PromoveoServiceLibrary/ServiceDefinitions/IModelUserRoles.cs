using System;
using System.ServiceModel;
using System.Collections.Generic;
namespace PromoveoServiceLibrary.ServiceDefinitions
{
    [ServiceContract]
    interface IModelUserRoles
    {
        [OperationContract]
        void AssignUser(int configurationID, int modelRoleID, int userID);

        [OperationContract]
        IList<DataAccessLayer.User> GetAssignedUser(int modelRoleID, int configurationID);

        [OperationContract]
        IList<DataAccessLayer.User> GetAvailableUser(int modelRoleID, int configurationID);

        [OperationContract]
        IList<DataAccessLayer.Role> GetModelUserRoles(int configurationID);

        [OperationContract]
        void RemoveUser(int configurationID, int modelRoleID, int userID);

        //[OperationContract]
        //void Update(Data.PromoveoDataSet.ModelUserGroupDataTable dataTable);
    }
}
