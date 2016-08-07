using attributes;
using eh.attributes;
using eh.attributes.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excel.In
{
    public class Scenery
    {
        [Col("A")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataMaxlength(20)]
        public string Name { get; set; }

        [Col("B")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataMaxlength(200)]
        public string Remarks { get; set; }

        [Col("C")]
        [ColDataValid(DataTypeEnum.STRING)]
        public string User { get; set; }

        public string[] Users
        {
            get
            {
                if (string.IsNullOrEmpty(this.User)) return new string[0];
                return this.User.Replace("，", ",").Split(',');
            }
        }
    }
}
