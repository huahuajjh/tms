using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.Out
{
    public class Permission : Entity.Menu
    {
        public static Permission EntityToModel(Entity.Menu menu)
        {
            Permission permission = new Permission();
            permission.Ico = menu.Ico;
            permission.Id = menu.Id;
            permission.Link = menu.Link;
            permission.PaterId = menu.PaterId;
            permission.Sort = menu.Sort;
            permission.Title = menu.Title;
            permission.Type = menu.Type;
            return permission;
        }

        public static Permission[] EntityToModel(Entity.Menu[] menus)
        {
            List<Permission> pers = new List<Permission>();
            foreach (var menu in menus)
            {
                pers.Add(EntityToModel(menu));
            }
            return pers.ToArray();
        }
    }
}
