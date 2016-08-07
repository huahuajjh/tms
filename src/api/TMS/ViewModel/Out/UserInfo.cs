using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.Out
{
    public class UserInfo : Entity.UserInfo
    {
        public string TypeStr
        {
            get
            {
                switch (this.UserType)
                {
                    case 0:
                        return "平台管理员";
                    case 1:
                        return "代理商";
                    case 2:
                        return "景点管理员";
                    case 255:
                        return "超级管理员";
                    default:
                        return "其他用户";
                }
            }
        }

        public static UserInfo ToModel(Entity.UserInfo userInfo)
        {
            UserInfo info = new UserInfo();
            info.Account = userInfo.Account;
            info.Birthday = userInfo.Birthday;
            info.Gender = userInfo.Gender;
            info.Id = userInfo.Id;
            info.IdCard = userInfo.IdCard;
            info.IsLogin = userInfo.IsLogin;
            info.Mail = userInfo.Mail;
            info.Name = userInfo.Name;
            info.Password = userInfo.Password;
            info.Phone = userInfo.Phone;
            info.Qq = userInfo.Qq;
            info.Remarks = userInfo.Remarks;
            info.RoleId = userInfo.RoleId;
            info.RoleName = userInfo.RoleName;
            info.StateId = userInfo.StateId;
            info.Title = userInfo.Title;
            info.UserType = userInfo.UserType;
            return info;
        }
    }
}
