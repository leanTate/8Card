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
    public class UserDAO
    {
        public UserDAO()
        {

        }
        public User Login(string mail)
        {
                User user = new User();
            try
            {
                ConectionDB connect = new ConectionDB();
                SqlDataReader reader = null;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"SELECT* FROM users WHERE email = '{mail}'";
                sqlCmd.Connection = connect.sqlConnection;
                connect.OpenConnection();
                reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    user.id = Convert.ToInt32(reader.GetValue(0));
                    user.userName = reader.GetValue(1).ToString();
                    user.lastName = reader.GetValue(2).ToString();
                    user.mail = reader.GetValue(3).ToString();
                    user.password= reader.GetValue(4).ToString();
                    user.dni = Convert.ToInt32(reader.GetValue(5));
                    user.celphone = Convert.ToInt32(reader.GetValue(6));
                }
                connect.CloseConnection();
                return user;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;
        }
    }
}
