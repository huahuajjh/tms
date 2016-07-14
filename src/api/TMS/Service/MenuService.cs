using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class MenuService : IService.IMenuService
    {
        private IRepository.IRepository repository;

        public MenuService(IRepository.IRepository repository)
        {
            this.repository = repository;
        }

        public ViewModel.Out.Permission[] All()
        {
            Entity.Menu[] menus = repository.GetReposirotyFactory<Entity.Menu>().ArrayAll();
            return ViewModel.Out.Permission.EntityToModel(menus);
        }
    }
}
