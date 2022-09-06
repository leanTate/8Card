using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.entites;

namespace BE
{
    internal class session
    {
        private static session _instance = null;

        public User user { get; set; }

        public static session Instance
        {
            get
            {
                if (_instance == null)_instance = new session();
                
                return _instance;
            }
        }
        public static bool login(User user)
        {
            if (_instance == null)
            {
                _instance = new session();
                _instance.user = user;
                Console.WriteLine("Se inicio sesion");
                return true;
            }
            else {
                Console.WriteLine("Ya hay una sesion iniciada");
                return false;
            }
        }
        public static bool logout()
        {
            if (_instance != null)
            {
                _instance = null;
                Console.WriteLine("Se cerro la sesion");
                return true;
            }
            else {
                Console.WriteLine("No hay una sesion iniciada");
                return false;
            }
        }
    }
}
