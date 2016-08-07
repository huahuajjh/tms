using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excel
{
    public class Model<T>
    {
        public Model() { }

        public Model(IList<T> datas, IList<string> errors)
        {
            if (datas == null) datas = new List<T>(0);
            this.Datas = datas.ToArray();
            if (errors == null) errors = new List<string>(0);
            this.Errors = errors.ToArray();
        }

        public T[] Datas { get; set; }

        public string[] Errors { get; set; }
    }
}
