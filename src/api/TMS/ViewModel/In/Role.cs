using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.In
{
    public class Role
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public string Remarks { get; set; }

        public string Permissions { get; set; }

        public Entity.Role ToEntity() 
        {
            Entity.Role role = new Entity.Role();
            role.Name = this.Name;
            role.Remarks = this.Remarks;
            return role;
        }

        public void SetEntity(Entity.Role role)
        {
            role.Name = this.Name;
            role.Remarks = this.Remarks;
        }

        public Entity.RoleMenu[] ToRoleMenu()
        {
            List<Entity.RoleMenu> list = new List<Entity.RoleMenu>();
            if (!string.IsNullOrEmpty(Permissions))
            {
                string[] permissions = Permissions.Split(',');
                foreach (var permission in permissions)
                {
                    Entity.RoleMenu roleMenu = new Entity.RoleMenu();
                    roleMenu.MenuId = int.Parse(permission);
                    roleMenu.RoleId = this.Id;
                    list.Add(roleMenu);
                }
            }
            return list.ToArray();
        }
    }
}
