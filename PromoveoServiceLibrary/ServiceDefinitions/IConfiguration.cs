using System;
using System.ServiceModel;
using System.Collections.Generic;
namespace PromoveoServiceLibrary.ServiceDefinitions
{
    [ServiceContract]
    interface IConfiguration
    {
        [OperationContract]
        string GetVisioMasterFileName(int configurationID);

        [OperationContract]
        void SetVisioMasterFileName(int configurationID, string visioMasterFilename);

        [OperationContract]
        IList<DataAccessLayer.Configuration> GetConfigurations();

        [OperationContract]
        int CreateConfiguration(DataAccessLayer.Configuration configuration);
        
        [OperationContract]
        void UpdateConfiguration(DataAccessLayer.Configuration configuration);
        
        [OperationContract]
        void DeleteConfiguration(DataAccessLayer.Configuration configuration);
    }
}
