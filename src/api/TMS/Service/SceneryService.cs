using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class SceneryService : IService.ISceneryService
    {
        private IRepository.IRepository repository;

        public SceneryService(IRepository.IRepository repository)
        {
            this.repository = repository;
        }

        public ViewModel.OperationState Add(ViewModel.In.Scenery scenery)
        {
            Entity.Scenery entity = scenery.ToEntity();
            this.repository.GetReposirotyFactory<Entity.Scenery>().Add(entity);
            this.repository.SaveChange();
            scenery.Id = entity.Id;
            Entity.UserScenery[] userScenery = scenery.ToUserScenery();
            this.repository.GetReposirotyFactory<Entity.UserScenery>().Add(userScenery);
            this.repository.SaveChange();
            return ViewModel.OperationState.success;
        }

        public ViewModel.PageModel<ViewModel.Out.Scenery> List(ViewModel.In.Page page, ViewModel.In.SceneryQuery query)
        {
            int code;
            bool isCode = int.TryParse(query.code, out code);
            IQueryable<Entity.Scenery> wheres = this.repository.GetReposirotyFactory<Entity.Scenery>().Query(d => d.IsDel == false);
            if(!string.IsNullOrEmpty(query.Name))
            {
                wheres = wheres.Where(d => d.Title.Contains(query.Name));
            }
            if (isCode)
            {
                wheres = wheres.Where(d => d.Id == code);
            }
            int pageCount = wheres.Count();
            ViewModel.Out.Scenery[] userInfos = wheres.OrderByDescending(d => d.Id).Skip((page.PageIndex - 1) * page.PageSize).Take(page.PageSize).ToList()
                .Select(d => {
                    int[] userIds = this.repository.GetReposirotyFactory<Entity.UserScenery>().Query(t => t.SceneryId == d.Id).Select(t => t.UserId).ToArray();
                    Entity.UserInfo[] infos = this.repository.GetReposirotyFactory<Entity.UserInfo>().Query(t=> userIds.Contains(t.Id)).ToArray();
                    return ViewModel.Out.Scenery.ToModel(d, infos);
                }).ToArray();
            return new ViewModel.PageModel<ViewModel.Out.Scenery>(pageCount, userInfos);
        }

        public ViewModel.OperationState Edit(ViewModel.In.Scenery scenery)
        {
            Entity.Scenery entity = this.repository.GetReposirotyFactory<Entity.Scenery>().Query(d => d.Id == scenery.Id).FirstOrDefault();
            if (entity == null) return ViewModel.OperationState.dataError;
            scenery.SetEntity(entity);
            this.repository.GetReposirotyFactory<Entity.UserScenery>().Delete(d=> d.SceneryId == entity.Id);
            this.repository.GetReposirotyFactory<Entity.UserScenery>().Add(scenery.ToUserScenery());
            if (this.repository.SaveChange() > 0)
                return ViewModel.OperationState.success;
            return ViewModel.OperationState.dataError;
        }

        public ViewModel.OperationState Del(int id)
        {
            Entity.Scenery entity = this.repository.GetReposirotyFactory<Entity.Scenery>().Query(d => d.Id == id).FirstOrDefault();
            if (entity == null) return ViewModel.OperationState.dataError;
            entity.IsDel = true;
            if (this.repository.SaveChange() > 0)
                return ViewModel.OperationState.success;
            return ViewModel.OperationState.dataError;
        }

        public ViewModel.OperationState Import(Excel.In.Scenery[] tickets)
        {
            Dictionary<Entity.Scenery, string[]> users = new Dictionary<Entity.Scenery, string[]>();
            foreach (var ticket in tickets)
            {
                Entity.Scenery scenery = new Entity.Scenery();
                scenery.IsDel = false;
                scenery.Remarks = ticket.Remarks;
                scenery.Title = ticket.Name;
                this.repository.GetReposirotyFactory<Entity.Scenery>().Add(scenery);
                if (ticket.Users.Length > 0)
                {
                    users.Add(scenery, ticket.Users);
                }
            }
            this.repository.SaveChange();
            foreach (KeyValuePair<Entity.Scenery, string[]> user in users)
            {
                this.repository.GetReposirotyFactory<Entity.User>().Query(d => user.Value.Contains(d.Account)).Select(d => d.Id)
                    .ToList().ForEach(id =>
                    {
                        Entity.UserScenery userScenery = new Entity.UserScenery();
                        userScenery.SceneryId = user.Key.Id;
                        userScenery.UserId = id;
                        this.repository.GetReposirotyFactory<Entity.UserScenery>().Add(userScenery);
                    });
            }
            this.repository.SaveChange();
            return ViewModel.OperationState.success;
        }

        public List<Excel.Out.Scenery> Export()
        {
            return this.repository.GetReposirotyFactory<Entity.Scenery>().ListAll().Select(d => new Excel.Out.Scenery() { Id = d.Id, Name = d.Title, Remarks = d.Remarks }).ToList();
        }
    }
}
