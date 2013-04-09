using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PromoveoWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config fD:\Users\Elias\Documents\Visual Studio 2012\Projects\Promoveo\PromoveoAddin\Data\ile together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class PromoveoService : ServiceDefinitions.IConfiguration, ServiceDefinitions.IModelUserRoles
        //TODO: , ServiceDefinitions.IProcessModel,
        //TODO: ServiceDefinitions.IPublishingPlatformRolesDAL,ServiceDefinitions.IRoleModel,ServiceDefinitions.IUserRole
    {
        public string GetVisioMasterFileName(int configurationID)
        {
            DataAccessLayer.ConfigurationDAL configurationDAL = new DataAccessLayer.ConfigurationDAL();
            return configurationDAL.GetVisioMasterFileName(configurationID);
        }

        public void SetVisioMasterFileName(int configurationID, string visioMasterFilename)
        {
            DataAccessLayer.ConfigurationDAL configurationDAL = new DataAccessLayer.ConfigurationDAL();
            configurationDAL.SetVisioMasterFileName(configurationID, visioMasterFilename);
        }


        public void AssignUser(int configurationID, int modelRoleID, int userID)
        {
            DataAccessLayer.ModelUserRolesDAL modelUserRolesDAL = new DataAccessLayer.ModelUserRolesDAL();
            modelUserRolesDAL.AssignUser(configurationID, modelRoleID, userID);
        }

        public PromoveoWebService.Data.PromoveoDataSet.PublishingPlatformUserDataTable GetAssignedUser(int modelRoleID, int configurationID)
        {
            DataAccessLayer.ModelUserRolesDAL modelUserRolesDAL = new DataAccessLayer.ModelUserRolesDAL();
            return modelUserRolesDAL.GetAssignedUser(modelRoleID, configurationID);
        }


        public PromoveoWebService.Data.PromoveoDataSet.PublishingPlatformUserDataTable GetAvailableUser(int modelRoleID, int configurationID)
        {
            DataAccessLayer.ModelUserRolesDAL modelUserRolesDAL = new DataAccessLayer.ModelUserRolesDAL();
            return modelUserRolesDAL.GetAvailableUser(modelRoleID, configurationID);
        }

        public PromoveoWebService.Data.PromoveoDataSet.ModelUserGroupDataTable GetModelUserRoles(int configurationID)
        {
            DataAccessLayer.ModelUserRolesDAL modelUserRolesDAL = new DataAccessLayer.ModelUserRolesDAL();
            return modelUserRolesDAL.GetModelUserRoles(configurationID);
        }

        public void RemoveUser(int configurationID, int modelRoleID, int userID)
        {
            DataAccessLayer.ModelUserRolesDAL modelUserRolesDAL = new DataAccessLayer.ModelUserRolesDAL();
            modelUserRolesDAL.RemoveUser(configurationID, modelRoleID, userID);
        }

        public void Update(PromoveoWebService.Data.PromoveoDataSet.ModelUserGroupDataTable dataTable)
        {
            DataAccessLayer.ModelUserRolesDAL modelUserRolesDAL = new DataAccessLayer.ModelUserRolesDAL();
            modelUserRolesDAL.Update(dataTable);
        }



    }
}
