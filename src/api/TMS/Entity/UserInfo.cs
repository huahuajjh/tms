using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class UserInfo
    {
        public int Id { get; set; } // Id
        public string Name { get; set; } // Name
        public string Account { get; set; } // Account
        public string Password { get; set; } // Password
        public int RoleId { get; set; } // RoleId
        public DateTime Birthday { get; set; } // Birthday
        public byte Gender { get; set; } // Gender
        public string Qq { get; set; } // QQ
        public string Mail { get; set; } // Mail
        public string Phone { get; set; } // Phone
        public string IdCard { get; set; } // IdCard
        public int StateId { get; set; } // StateId
        public string RoleName { get; set; } // RoleName
        public string Remarks { get; set; } // remarks
        public string Title { get; set; } // Title
        public bool IsLogin { get; set; } // IsLogin
    }
}
