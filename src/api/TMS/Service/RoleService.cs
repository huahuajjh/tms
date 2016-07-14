using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class RoleService: IService.IRoleService
    {
        private IRepository.IRepository repository;

        public RoleService(IRepository.IRepository repository)
        {
            this.repository = repository;
        }

        public ViewModel.OperationState Add(ViewModel.In.Role role)
        {
            Entity.Role roleModel = role.ToEntity();
            repository.GetReposirotyFactory<Entity.Role>().Add(roleModel);
            repository.SaveChange();
            Entity.RoleMenu[] arr = role.ToRoleMenu();
            foreach (var permission in arr)
            {
                permission.RoleId = roleModel.Id;
                repository.GetReposirotyFactory<Entity.RoleMenu>().Add(permission);
            }
            repository.SaveChange();
            return ViewModel.OperationState.success;
        }

        public ViewModel.PageModel<ViewModel.Out.Role> List(ViewModel.In.Page page)
        {
            int pageCount;
            List<Entity.Role> roles = repository.GetReposirotyFactory<Entity.Role>().QueryByPage(d => d.Id, page.PageSize, page.PageIndex, out pageCount).ToList();
            List<ViewModel.Out.Role> list = new List<ViewModel.Out.Role>(roles.Count);
            roles.ForEach(r => {
                int[] menuIds = repository.GetReposirotyFactory<Entity.RoleMenu>().Query(d => d.RoleId == r.Id).Select(d=>d.MenuId).ToArray();
                Entity.Menu[] menus = repository.GetReposirotyFactory<Entity.Menu>().Query(d => menuIds.Contains(d.Id)).ToArray();
                list.Add(ViewModel.Out.Role.ToModel(r, menus));
            });
            ViewModel.PageModel<ViewModel.Out.Role> pageModel = new ViewModel.PageModel<ViewModel.Out.Role>(pageCount, list);
            return pageModel;
        }

        public ViewModel.Out.Role Info(int id)
        {
            Entity.Role role = repository.GetReposirotyFactory<Entity.Role>().Query(d => d.Id == id).FirstOrDefault();
            if (role == null) return null;
            int[] menuIds = repository.GetReposirotyFactory<Entity.RoleMenu>().Query(d => d.RoleId == role.Id).Select(d => d.MenuId).ToArray();
            Entity.Menu[] menus = repository.GetReposirotyFactory<Entity.Menu>().Query(d => menuIds.Contains(d.Id)).ToArray();
            return ViewModel.Out.Role.ToModel(role, menus);
        }

        public ViewModel.OperationState Del(int id)
        {
            repository.GetReposirotyFactory<Entity.Role>().Delete(d => d.Id == id);
            repository.GetReposirotyFactory<Entity.RoleMenu>().Delete(d => d.RoleId == id);
            if (repository.SaveChange() > 0) 
            {
                return ViewModel.OperationState.success;
            }
            return ViewModel.OperationState.existError;
        }

        public ViewModel.OperationState Edit(ViewModel.In.Role role)
        {
            Entity.Role roleEntity = repository.GetReposirotyFactory<Entity.Role>().Query(d => d.Id == role.Id).FirstOrDefault();
            if (roleEntity == null) return ViewModel.OperationState.dataError;
            role.SetEntity(roleEntity);
            repository.GetReposirotyFactory<Entity.RoleMenu>().Delete(d=>d.RoleId == role.Id);
            repository.GetReposirotyFactory<Entity.RoleMenu>().Add(role.ToRoleMenu());
            if(repository.SaveChange() > 0)
            {
                return ViewModel.OperationState.success;
            }
            return ViewModel.OperationState.dataError;
        }

        public ViewModel.Out.Role[] All()
        {
            List<Entity.Role> roles = repository.GetReposirotyFactory<Entity.Role>().ListAll();
            List<ViewModel.Out.Role> list = new List<ViewModel.Out.Role>(roles.Count);
            roles.ForEach(r =>
            {
                int[] menuIds = repository.GetReposirotyFactory<Entity.RoleMenu>().Query(d => d.RoleId == r.Id).Select(d => d.MenuId).ToArray();
                Entity.Menu[] menus = repository.GetReposirotyFactory<Entity.Menu>().Query(d => menuIds.Contains(d.Id)).ToArray();
                list.Add(ViewModel.Out.Role.ToModel(r, menus));
            });
            return list.ToArray();
        }


        public ViewModel.Out.RoleInfo[] AllInfo()
        {
            return this.repository.GetReposirotyFactory<Entity.Role>().ListAll().Select(d => ViewModel.Out.RoleInfo.ToModal(d)).ToArray();
        }
    }
}
