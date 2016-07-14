using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.Out;

namespace ViewModel.Out
{
    public class User : Entity.UserInfo
    {
        private Permission[] permissions = new Permission[0];

        public Permission[] Permissions
        {
            get { return permissions; }
            set { permissions = value; }
        }

        public static User EntityToModel(Entity.UserInfo user, Entity.Menu[] menus = null)
        {
            if (user == null) return null;
            User userInfo = new User();
            userInfo.Account = user.Account;
            userInfo.Birthday = user.Birthday;
            userInfo.Gender = user.Gender;
            userInfo.Id = user.Id;
            userInfo.IdCard = user.IdCard;
            userInfo.IsLogin = user.IsLogin;
            userInfo.Mail = user.Mail;
            userInfo.Name = user.Name;
            userInfo.Phone = user.Phone;
            userInfo.Qq = user.Qq;
            userInfo.Remarks = user.Remarks;
            userInfo.RoleId = user.RoleId;
            userInfo.RoleName = user.RoleName;
            userInfo.Title = user.Title;
            userInfo.StateId = user.StateId;
            if (menus != null)
            {
                List<Permission> listData = new List<Permission>();
                foreach (var menu in menus)
                {
                    listData.Add(Permission.EntityToModel(menu));
                    userInfo.permissions = listData.ToArray();
                }
            }
            return userInfo;
        }


        public static User EntityToModel(Entity.SuperUser user, Entity.Menu[] menus = null)
        {
            if (user == null) return null;
            User userInfo = new User();
            userInfo.Account = user.Account;
            userInfo.Id = user.Id;
            userInfo.Name = "超级管理员";
            userInfo.RoleName = "管理员";
            if (menus != null)
            {
                List<Permission> listData = new List<Permission>();
                foreach (var menu in menus)
                {
                    listData.Add(Permission.EntityToModel(menu));
                }
                userInfo.permissions = listData.ToArray();
            }
            return userInfo;
        }
    }
}
