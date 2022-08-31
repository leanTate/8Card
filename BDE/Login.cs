using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using BE;
using DAL;
namespace BDE
{
    public class Login
    {
        public static bool login(string mail, string pass) {
            Console.WriteLine(pass);
            return (ConectionDB.Login($"SELECT * FROM users WHERE email='{mail}' and pass='{pass}'"));
        }
    }
}
