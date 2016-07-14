using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class Scenery
    {
        public int Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public string Remarks { get; set; } // Remarks
        public bool IsDel { get; set; } // IsDel
    }
}
