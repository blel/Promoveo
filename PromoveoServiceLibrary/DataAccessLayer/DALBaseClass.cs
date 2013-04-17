using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PromoveoServiceLibrary.DataAccessLayer
{
    public abstract class DALBaseClass:IDisposable
    {
        protected string _connectionString = ConfigurationManager.ConnectionStrings["PromoveoAddin.Properties.Settings.PromoveoDBConnectionString"].ConnectionString;
        private SqlConnection _connection; 
                                 
        
        public DALBaseClass()
        {
            _connection = new SqlConnection(_connectionString);
        }


        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool flag)
        {
            _connection.Dispose();
            //this.Dispose(); //TODO: not sure what happens here. When issued as a  web service, this results in a endless loop
        }


    }
}
