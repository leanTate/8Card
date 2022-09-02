using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class ConectionDB
    {
    public SqlConnection sqlConnection;
        public ConectionDB()
        {
            DotNetEnv.Env.TraversePath().Load();
            var connection = Environment.GetEnvironmentVariable("CONNECTIONSTR");
            sqlConnection = new SqlConnection(connection);
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
