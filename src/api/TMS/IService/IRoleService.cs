using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IService
{
    public interface IRoleService
    {
        ViewModel.Out.Role[] All();

        ViewModel.Out.RoleInfo[] AllInfo();

        ViewModel.OperationState Add(ViewModel.In.Role role);

        ViewModel.PageModel<ViewModel.Out.Role> List(ViewModel.In.Page page);

        ViewModel.Out.Role Info(int id);

        ViewModel.OperationState Del(int id);

        ViewModel.OperationState Edit(ViewModel.In.Role role);
    }
}
