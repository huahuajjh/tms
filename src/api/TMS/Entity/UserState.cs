using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class UserState
    {
        public int Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public bool IsLogin { get; set; } // IsLogin
    }
}
