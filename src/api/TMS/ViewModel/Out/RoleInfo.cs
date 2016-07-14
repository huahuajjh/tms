using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.Out
{
    public class RoleInfo : Entity.Role
    {
        public static RoleInfo ToModal(Entity.Role role)
        {
            RoleInfo info = new RoleInfo();
            info.Id = role.Id;
            info.Name = role.Name;
            info.Remarks = role.Remarks;
            return info;
        }
    }
}
