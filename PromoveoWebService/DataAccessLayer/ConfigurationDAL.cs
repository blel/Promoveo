using PromoveoWebService.Data;
using PromoveoWebService.Data.PromoveoDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromoveoWebService.DataAccessLayer
{
    public class ConfigurationDAL : DALBaseClass, PromoveoWebService.ServiceDefinitions.IConfiguration
    {
        public string GetVisioMasterFileName(int configurationID)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            ConfigurationTableAdapter configurationTableAdapter = new ConfigurationTableAdapter();
            configurationTableAdapter = new ConfigurationTableAdapter();
            configurationTableAdapter.Fill(ds.Configuration);
            return (from cc in ds.Configuration
                    where cc.Id == configurationID
                    select cc.VisioMasterFilename).FirstOrDefault();
        }

        public void SetVisioMasterFileName(int configurationID, string visioMasterFilename)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            ConfigurationTableAdapter configurationTableAdapter = new ConfigurationTableAdapter();
            configurationTableAdapter.Fill(ds.Configuration);
            PromoveoDataSet.ConfigurationRow  configurationToUpdate = (from cc in ds.Configuration
                                                where cc.Id == configurationID
                                                select cc).Single();
            configurationToUpdate.VisioMasterFilename = visioMasterFilename;
            configurationTableAdapter.Update(configurationToUpdate);
        }

    }
}
