using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class RoleMenu
    {
        public int Id { get; set; } // Id (Primary key)
        public int RoleId { get; set; } // RoleId
        public int MenuId { get; set; } // MenuId
    }
}
