using System;
using System.ServiceModel;

namespace PromoveoWebService.ServiceDefinitions
{
    [ServiceContract]
    interface IConfiguration
    {
        [OperationContract]
        string GetVisioMasterFileName(int configurationID);

        [OperationContract]
        void SetVisioMasterFileName(int configurationID, string visioMasterFilename);
    }
}
