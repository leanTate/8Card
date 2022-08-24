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
        public List<Users> Read(string query){

            SqlDataReader reader = null;
            //instancia una tabla de datos
            //abre la conexion con el metodo privado
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = query;
            sqlCmd.Connection = this.sqlConnection;
            OpenConnection();
            reader = sqlCmd.ExecuteReader();
            List<Users> users = new List<Users>();
            while (reader.Read())
            {
                Users usr = new Users();
                usr.name = reader.GetValue(0).ToString();
                usr.lastname = reader.GetValue(1).ToString();
                users.Add(usr);
            }
            CloseConnection();
            return users;
        }
    }
}
