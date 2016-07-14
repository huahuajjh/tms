using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class SceneryController : BaseController
    {
        private IService.ISceneryService sceneryService = null;

        public SceneryController()
        {
            sceneryService = GetService<IService.ISceneryService>();
        }

        public ActionResult Add(ViewModel.In.Scenery scenery)
        {
            if(sceneryService.Add(scenery) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(412);
        }

        public ActionResult List(ViewModel.In.Page page, ViewModel.In.SceneryQuery query)
        {
            return Json(this.sceneryService.List(page, query));
        }

        public ActionResult Edit(ViewModel.In.Scenery scenery)
        {
            if (sceneryService.Edit(scenery) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(412);
        }

        public ActionResult Del(int id)
        {
            if (sceneryService.Del(id) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(412);
        }
    }
}
