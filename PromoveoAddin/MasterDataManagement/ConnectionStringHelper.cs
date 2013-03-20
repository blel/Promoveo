using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace PromoveoAddin.MasterDataManagement
{
    public  class ConnectionStringHelper
    {

        private Dictionary<string, string> _properties = new Dictionary<string, string>();
        private string _connectionString;
     
        public Dictionary<string, string> Properties { get {return _properties;} }
        
        public ConnectionStringHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PromoveoAddin.Properties.Settings.PromoveoDBConnectionString"].ConnectionString;
            string[]  _connectionStringProperties = _connectionString.Split(';');
            foreach (string property in _connectionStringProperties)
            {
                string[] currentProperty = property.Split('=');
                if (currentProperty.Count()==2)
                  _properties.Add(currentProperty[0].Trim(), currentProperty[1].Trim());
            }


        }

        
        public  string GetDBServer()
        {
            return Properties.Where(cc=>cc.Key == "Data Source").Single().Value;
        }

        public string GetDBName()
        {
            return Properties.Where(cc => cc.Key == "Initial Catalog").Single().Value;
        }


    }
}
