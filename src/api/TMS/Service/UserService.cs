using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class UserService : IUserService
    {
        private IRepository.IRepository repository;

        public UserService(IRepository.IRepository repository)
        {
            this.repository = repository;
        }

        public ViewModel.OperationState Login(ViewModel.In.Login user)
        {
            Entity.SuperUser superUser = this.repository.GetReposirotyFactory<Entity.SuperUser>().Query(d => d.Account == user.UserName).FirstOrDefault();
            if (superUser != null)
            {
                if (superUser.Password == user.Password)
                {
                    return ViewModel.OperationState.success;
                }
                else
                {
                    return ViewModel.OperationState.passwordError;
                }
            }
            Entity.UserInfo userInfo = this.repository.GetReposirotyFactory<Entity.UserInfo>().Query(d => d.Account == user.UserName && d.IsLogin == true).FirstOrDefault();
            if (userInfo != null)
            {
                if (userInfo.Password == user.Password)
                {
                    return ViewModel.OperationState.success;
                }
                else
                {
                    return ViewModel.OperationState.passwordError;
                }
            }
            return ViewModel.OperationState.userNameError;
        }

        public ViewModel.Out.User Info(string userName)
        {
            Entity.UserInfo userInfo = this.repository.GetReposirotyFactory<Entity.UserInfo>().Query(d => d.Account == userName).FirstOrDefault();
            if (userInfo != null)
            {
                int[] menuIds = repository.GetReposirotyFactory<Entity.RoleMenu>().Query(d => d.RoleId == userInfo.RoleId).Select(d => d.MenuId).ToArray();
                Entity.Menu[] menus = repository.GetReposirotyFactory<Entity.Menu>().Query(d => menuIds.Contains(d.Id)).ToArray();
                return ViewModel.Out.User.EntityToModel(userInfo, menus);
            }
            Entity.SuperUser superUser = this.repository.GetReposirotyFactory<Entity.SuperUser>().Query(d => d.Account == userName).FirstOrDefault();
            if (superUser != null)
            {
                superUser.Id = -1;
                Entity.Menu[] array = this.repository.GetReposirotyFactory<Entity.Menu>().ArrayAll();
                return ViewModel.Out.User.EntityToModel(superUser, array);
            }
            return null;
        }

        public ViewModel.OperationState Exist(string userName)
        {
            if (this.repository.GetReposirotyFactory<Entity.User>().Query(d => d.Account == userName).Count() > 0 || this.repository.GetReposirotyFactory<Entity.SuperUser>().Query(d => d.Account == userName).Count() > 0)
            {
                return ViewModel.OperationState.existError;
            }
            return ViewModel.OperationState.success;
        }

        public ViewModel.OperationState Add(ViewModel.In.User user)
        {
            user.StateId = 1;
            user.Password = "123456";
            this.repository.GetReposirotyFactory<Entity.User>().Add(user.toEntity());
            if (this.repository.SaveChange() > 0)
            {
                return ViewModel.OperationState.success;
            }
            return ViewModel.OperationState.dataError;
        }

        public ViewModel.OperationState Edit(ViewModel.In.User user)
        {
            Entity.User userInfo = this.repository.GetReposirotyFactory<Entity.User>().Query(d => d.Id == user.Id).FirstOrDefault();
            if (userInfo == null) return ViewModel.OperationState.dataError;
            user.setInEntity(userInfo);
            if (this.repository.SaveChange() > 0)
            {
                return ViewModel.OperationState.success;
            }
            return ViewModel.OperationState.dataError;
        }

        public ViewModel.OperationState Del(int id)
        {
            this.repository.GetReposirotyFactory<Entity.User>().Delete(d => d.Id == id);
            if (this.repository.SaveChange() > 0)
            {
                return ViewModel.OperationState.success;
            }
            return ViewModel.OperationState.dataError;
        }

        public ViewModel.OperationState State(int id, int stateId)
        {
            Entity.User userInfo = this.repository.GetReposirotyFactory<Entity.User>().Query(d => d.Id == id).FirstOrDefault();
            userInfo.StateId = stateId;
            if (this.repository.SaveChange() > 0)
            {
                return ViewModel.OperationState.success;
            }
            return ViewModel.OperationState.dataError;
        }


        public ViewModel.OperationState Password(string userName, string oldPassword, string newPassword)
        {
            Entity.User userInfo = this.repository.GetReposirotyFactory<Entity.User>().Query(d => d.Account == userName).FirstOrDefault();
            if (userInfo != null)
            {
                if (userInfo.Password != oldPassword) return ViewModel.OperationState.dataError;
                userInfo.Password = newPassword;
            }
            else
            {
                Entity.SuperUser superUser = this.repository.GetReposirotyFactory<Entity.SuperUser>().Query(d => d.Account == userName).FirstOrDefault();
                if (superUser != null)
                {
                    if (superUser.Password != oldPassword) return ViewModel.OperationState.dataError;
                    superUser.Password = newPassword;
                }
            }
            if (this.repository.SaveChange() > 0)
            {
                return ViewModel.OperationState.success;
            }
            return ViewModel.OperationState.dataError;
        }


        public ViewModel.PageModel<ViewModel.Out.UserInfo> list(ViewModel.In.Page page, ViewModel.In.UserQuery query)
        {
            IQueryable<Entity.UserInfo> wheres = this.repository.GetReposirotyFactory<Entity.UserInfo>().Query(d => true);
            if (!string.IsNullOrEmpty(query.Name))
            {
                wheres = wheres.Where(d => d.Name.Contains(query.Name));
            }
            if(!string.IsNullOrEmpty(query.Account))
            {
                wheres = wheres.Where(d => d.Account.Contains(query.Account));
            }
            if (query.Type != null)
            {
                wheres = wheres.Where(d => d.UserType == query.Type);
            }
            int pageCount = wheres.Count();
            ViewModel.Out.UserInfo[] userInfos = wheres.OrderByDescending(d => d.Id).Skip((page.PageIndex - 1) * page.PageSize).Take(page.PageSize).ToList()
                .Select(d => ViewModel.Out.UserInfo.ToModel(d)).ToArray();
            return new ViewModel.PageModel<ViewModel.Out.UserInfo>(pageCount, userInfos);
        }


        public ViewModel.OperationState InitPassword(int id)
        {
            this.repository.GetReposirotyFactory<Entity.User>().Query(d => d.Id == id).ToList().ForEach(d=> d.Password = "123456");
            if (this.repository.SaveChange() > 0)
                return ViewModel.OperationState.success;
            return ViewModel.OperationState.dataError;
        }


        public ViewModel.Out.UserState[] AllState()
        {
            return this.repository.GetReposirotyFactory<Entity.UserState>().ListAll().Select(d => ViewModel.Out.UserState.ToModel(d)).ToArray();
        }
    }
}
