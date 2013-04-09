using System;
using System.ServiceModel;
namespace PromoveoWebService.ServiceDefinitions
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
        PromoveoWebService.Data.PromoveoDataSet.ProcessModelDataTable GetProcessModels();

        [OperationContract]
        PromoveoWebService.Data.PromoveoDataSet.ProcessModelDataTable GetProcessModels(int configurationID);

        [OperationContract]
        PromoveoWebService.Data.PromoveoDataSet.ProcessModelUsersDataTable GetUsers(string processModel);

        [OperationContract]
        bool HasNewModels(System.Collections.Generic.List<string> modelNames, int configurationID, out System.Collections.Generic.List<string> newModels);

        [OperationContract]
        void Insert(string modelName, int configID);

        [OperationContract]
        bool IsModelOfConfiguration(string modelName, int configurationID);

        [OperationContract]
        void SetAcknowledgeState(int configurationID, string modelName, PromoveoWebService.AcknowledgeState state);
    }
}
