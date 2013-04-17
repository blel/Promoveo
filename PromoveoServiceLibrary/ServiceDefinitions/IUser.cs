using System;
using PromoveoServiceLibrary.DataAccessLayer;
using System.ServiceModel;
using System.Collections.Generic;

namespace PromoveoServiceLibrary.ServiceDefinitions
{
    [ServiceContract]
    interface IUser
    {
        [OperationContract]
        void DeleteUser(User user);
        
        [OperationContract]
        User GetUser(int Id);
        
        [OperationContract]
        System.Collections.Generic.IList<User> GetUsers();
        
        [OperationContract]
        int InsertUser(User user);
        
        [OperationContract]
        void UpdateUser(User user);
    }
}
