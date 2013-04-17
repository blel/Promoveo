using PromoveoServiceLibrary.Data;
using PromoveoServiceLibrary.Data.PromoveoDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromoveoServiceLibrary.DataAccessLayer
{
    public class ConfigurationDAL : DALBaseClass, PromoveoServiceLibrary.ServiceDefinitions.IConfiguration
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

        public IList<Configuration> GetConfigurations()
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            ConfigurationTableAdapter configurationAdapter = new ConfigurationTableAdapter();
            configurationAdapter.Fill(ds.Configuration);
            return ds.Configuration.Select(cc => new Configuration() { Id = cc.Id, Name = cc.Name, VisioMasterFilename = cc.VisioMasterFilename }).ToList();
        }

        public int CreateConfiguration(Configuration configuration)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            ConfigurationTableAdapter configurationAdapter = new ConfigurationTableAdapter();
            int Id = configurationAdapter.Insert(configuration.Name, configuration.VisioMasterFilename);
            ds.AcceptChanges();
            return Id;
        }

        public void UpdateConfiguration(Configuration configuration)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            ConfigurationTableAdapter configurationAdapter = new ConfigurationTableAdapter();
            configurationAdapter.Fill(ds.Configuration);
            PromoveoDataSet.ConfigurationRow rowToUpdate = ds.Configuration.Where(cc => cc.Id == configuration.Id).Single();
            rowToUpdate.Name = configuration.Name;
            rowToUpdate.VisioMasterFilename = configuration.VisioMasterFilename;
            ds.AcceptChanges();
        }

        public void DeleteConfiguration(Configuration configuration)
        {
            PromoveoDataSet ds = new PromoveoDataSet();
            ConfigurationTableAdapter configurationAdapter = new ConfigurationTableAdapter();
            configurationAdapter.Delete(configuration.Id, configuration.Name, configuration.VisioMasterFilename);
            ds.AcceptChanges();
        }
    }
}
