using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.Out
{
    public class Scenery : Entity.Scenery
    {
        public UserInfo[] Users { get; set; }

        public static Scenery ToModel(Entity.Scenery scenery)
        {
            Scenery model = new Scenery();
            model.Id = scenery.Id;
            model.IsDel = scenery.IsDel;
            model.Remarks = scenery.Remarks;
            model.Title = scenery.Title;

            return model;
        }

        public static Scenery ToModel(Entity.Scenery scenery, Entity.UserInfo[] userInfos)
        {
            Scenery model = new Scenery();
            model.Id = scenery.Id;
            model.IsDel = scenery.IsDel;
            model.Remarks = scenery.Remarks;
            model.Title = scenery.Title;
            if (userInfos != null)
            {
                List<UserInfo> list = new List<UserInfo>();
                foreach (var userInfo in userInfos)
                {
                    list.Add(UserInfo.ToModel(userInfo));
                }
                model.Users = list.ToArray();
            }
            else
            {
                model.Users = new UserInfo[0];
            }
            return model;
        }
    }
}
