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
    private SqlConnection sqlConnection;
        public ConectionDB()
        {
            DotNetEnv.Env.TraversePath().Load();
            var connection = Environment.GetEnvironmentVariable("CONNECTIONSTR");
            sqlConnection = new SqlConnection(connection);
        }
        private void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        private void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public static bool Login(string query){
            ConectionDB connect = new ConectionDB();
            SqlDataReader reader = null;
            //instancia una tabla de datos
            //abre la conexion con el metodo privado
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = query;
            sqlCmd.Connection = connect.sqlConnection;
            connect.OpenConnection();
            reader = sqlCmd.ExecuteReader();
            string a="" ;
            while (reader.Read())
            {
                a = reader.GetValue(4).ToString();
            }
            connect.CloseConnection();
            return a != "" ? true : false;
        }
    }
}
