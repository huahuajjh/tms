using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class MenuController : BaseController
    {
        private IService.IMenuService roleService = null;

        public MenuController()
        {
            roleService = GetService<IService.IMenuService>();
        }

        public ActionResult All()
        {
            var datas = roleService.All();
            return Json(datas);
        }

    }
}
