using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Users
    {
        public Users(string mail, string password)
        {
            this.mail = mail;
            this.password = password;
        }

        public string mail { get; set; }
        public string password { get; set; }
    }
}
