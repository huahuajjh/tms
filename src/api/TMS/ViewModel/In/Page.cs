using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.In
{
    public class Page
    {
        private int pageIndex;

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
    }
}
