﻿using System;
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
            int.TryParse(query.code, out code);
            int pageCount;
            ViewModel.Out.Scenery[] userInfos = this.repository.GetReposirotyFactory<Entity.Scenery>()
                .QueryByPage(
                    d => ((d.Title.Contains(query.Name) && !string.IsNullOrEmpty(query.Name)) ||
                        (code != 0 && d.Id == code) ||
                        (string.IsNullOrEmpty(query.Name) && code == 0)) && d.IsDel == false,
                    d => d.Id,
                    page.PageSize,
                    page.PageIndex,
                    out pageCount
                ).ToList().Select(d => {
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
    }
}
