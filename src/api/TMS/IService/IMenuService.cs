﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IService
{
    public interface IMenuService
    {
        ViewModel.Out.Permission[] All();
    }
}
