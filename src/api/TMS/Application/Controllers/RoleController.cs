using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class RoleController : BaseController
    {
        private IService.IRoleService roleService;

        public RoleController()
        {
            roleService = GetService<IService.IRoleService>();
        }

        public ActionResult All()
        {
            return Json(roleService.All(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllInfo()
        {
            return Json(roleService.AllInfo(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(ViewModel.In.Role role)
        {
            if(roleService.Add(role) == ViewModel.OperationState.success)
            {
                return new HttpStatusCodeResult(200);
            }
            return new HttpStatusCodeResult(412);
        }

        public ActionResult List(ViewModel.In.Page page)
        {
            ViewModel.PageModel<ViewModel.Out.Role> list = roleService.List(page);
            return Json(list);
        }


        public ActionResult Info(int id)
        {
            ViewModel.Out.Role data = roleService.Info(id);
            return Json(data);
        }

        public ActionResult Del(int id)
        {
            if (roleService.Del(id) == ViewModel.OperationState.success)
            {
                return new HttpStatusCodeResult(200);
            }
            return new HttpStatusCodeResult(412);
        }
        public ActionResult Edit(ViewModel.In.Role role)
        {
            if (roleService.Edit(role) == ViewModel.OperationState.success)
            {
                return new HttpStatusCodeResult(200);
            }
            return new HttpStatusCodeResult(412);
        }

    }
}
