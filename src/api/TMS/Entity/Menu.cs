using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class Menu
    {
        public int Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public string Ico { get; set; } // Ico
        public byte Sort { get; set; } // Sort
        public int? PaterId { get; set; } // PaterId
        public string Type { get; set; } // Type
        public string Link { get; set; } // Link

        public Menu()
        {
            Sort = 0;
        }
    }
}
