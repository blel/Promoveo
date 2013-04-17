using System;
using System.ServiceModel;
using System.Collections.Generic;

namespace PromoveoServiceLibrary.ServiceDefinitions
{
    [ServiceContract]
    interface IProcessModel
    {
        [OperationContract]
        void AddNewModels(System.Collections.Generic.List<string> modelNames, int configurationID);

        [OperationContract]
        void CreateVersion(string modelName, int configurationID);

        [OperationContract]
        int GetModelID(string processModel);

        [OperationContract]
        IList<DataAccessLayer.ProcessModel> GetProcessModels();

        [OperationContract(Name="GetProcessModelsByConfigID")]
        IList<DataAccessLayer.ProcessModel> GetProcessModels(int configurationID);

        [OperationContract]
        IList<DataAccessLayer.User> GetUsers(string processModel);

        [OperationContract]
        List<string> GetNewModelNames(System.Collections.Generic.List<string> modelNames, int configurationID);

        [OperationContract]
        void Insert(string modelName, int configID);

        [OperationContract]
        bool IsModelOfConfiguration(string modelName, int configurationID);

        [OperationContract]
        void SetAcknowledgeState(int configurationID, string modelName, PromoveoServiceLibrary.AcknowledgeState state);
    }
}
