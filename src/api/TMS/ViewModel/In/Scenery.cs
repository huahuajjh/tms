using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.In
{
    public class Scenery : Entity.Scenery
    {
        public string UserIds { get; set; }

        public Entity.Scenery ToEntity()
        {
            Entity.Scenery scenery = new Entity.Scenery();
            scenery.IsDel = this.IsDel;
            scenery.Remarks = this.Remarks;
            scenery.Title = this.Title;
            return scenery;
        }

        public void SetEntity(Entity.Scenery scenery)
        {
            scenery.Remarks = this.Remarks;
            scenery.Title = this.Title;
        }

        public Entity.UserScenery[] ToUserScenery()
        {
            List<Entity.UserScenery> list = new List<Entity.UserScenery>();
            if (!string.IsNullOrEmpty(this.UserIds))
            {
                string[] userIds = UserIds.Split(',');
                foreach (var userId in userIds)
                {
                    Entity.UserScenery userScenery = new Entity.UserScenery();
                    userScenery.UserId = int.Parse(userId);
                    userScenery.SceneryId = this.Id;
                    list.Add(userScenery);
                }
            }
            return list.ToArray();
        }
    }
}
