using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel
{
    public class PageModel<T>
    {
        public PageModel() { }

        public PageModel(int pageCount) { this.PageCount = pageCount; }

        public PageModel(T[] datas) { this.Datas = datas; }

        public PageModel(int pageCount, T[] datas) { this.PageCount = pageCount; this.Datas = datas; }

        public PageModel(int pageCount, List<T> datas) { this.PageCount = pageCount; this.Datas = datas.ToArray(); }

        public int PageCount { get; set; }

        public T[] Datas { get; set; }
    }
}
