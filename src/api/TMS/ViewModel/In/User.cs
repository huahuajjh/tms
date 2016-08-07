using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.In
{
    public class User: Entity.User
    {
        public Entity.User toEntity()
        {
            Entity.User user = new Entity.User();
            user.Account = this.Account;
            user.Birthday = this.Birthday;
            user.Gender = this.Gender;
            user.Id = this.Id;
            user.IdCard = this.IdCard;
            user.Mail = this.Mail;
            user.Name = this.Name;
            user.Password = this.Password;
            user.Phone = this.Phone;
            user.Qq = this.Qq;
            user.RoleId = this.RoleId;
            user.StateId = this.StateId;
            user.Type = this.Type;
            return user;
        }

        public void setInEntity(Entity.User user)
        {
            user.Birthday = this.Birthday;
            user.Gender = this.Gender;
            user.IdCard = this.IdCard;
            user.Mail = this.Mail;
            user.Name = this.Name;
            user.Phone = this.Phone;
            user.Qq = this.Qq;
            user.RoleId = this.RoleId;
            user.Type = this.Type;
        }
    }
}
