using eh.attributes;
using eh.attributes.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excel.Out
{
    public class Scenery
    {
        [Col("A")]
        public int Id { get; set; }

        [Col("B")]
        public string Name { get; set; }

        [Col("C")]
        public string Remarks { get; set; }
    }
}
