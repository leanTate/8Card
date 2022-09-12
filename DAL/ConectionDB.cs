using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BE;
using System.Diagnostics;

namespace DAL
{
    internal sealed class ConectionDB
    {
        private static ConectionDB _instance = null;
    public SqlConnection sqlConnection;
        private ConectionDB()
        {
            DotNetEnv.Env.TraversePath().Load();
            var connection = Environment.GetEnvironmentVariable("CONNECTIONSTR");
            sqlConnection = new SqlConnection(connection);
        }
        public static ConectionDB Instance
        {
            get {
                if (_instance == null)_instance = new ConectionDB();

                return _instance; 
            }
        }
        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
    }
}
