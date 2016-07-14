using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.Out
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Remarks { get; set; }

        public Permission[] Permissions { get; set; }

        public static Role ToModel(Entity.Role role)
        {
            Role model = new Role();
            model.Id = role.Id;
            model.Name = role.Name;
            model.Remarks = role.Remarks;
            return model;
        }

        public static Role ToModel(Entity.Role role, Entity.Menu[] menus)
        {
            Role model = ToModel(role);
            model.Permissions = Permission.EntityToModel(menus);
            return model;
        }
    }
}
