﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.entites
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string mail { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public int dni { get; set; }
        public int celphone { get; set; }
        public string token { get; set; } = string.Empty;
        public int saldo { get; set; }
        public int cbu { get; set; }

    }
}
