using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class SuperUser
    {
        public int Id { get; set; } // Id (Primary key)
        public string Account { get; set; } // Account
        public string Password { get; set; } // Password
    }
}
