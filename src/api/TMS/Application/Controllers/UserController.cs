using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Application.Controllers
{
    public class UserController : BaseController 
    {
        private IService.IUserService userService = null;

        public UserController()
        {
            userService = GetService<IService.IUserService>();
        }

        public ActionResult Login(ViewModel.In.Login login)
        {
            ViewModel.OperationState state = userService.Login(login);
            if (state == ViewModel.OperationState.success)
            {
                string code = Library.Helper.DES.Encrypt_DES(login.UserName);
                return Content(code);
            }
            return new HttpStatusCodeResult(412);
        }

        public ActionResult Info(string sessionId)
        {
            string userName = Library.Helper.DES.Decrypt_DES(sessionId);
            if(!string.IsNullOrEmpty(userName))
            {
                ViewModel.Out.User user = userService.Info(userName);
                return Json(user);
            }
            return new HttpStatusCodeResult(412);
        }

        public ActionResult Password(string sessionId, string oldPassword, string newPassword)
        {
            string userName = Library.Helper.DES.Decrypt_DES(sessionId);
            ViewModel.OperationState state = userService.Password(userName, oldPassword, newPassword);
            if (state == ViewModel.OperationState.success) return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(412);
        }

        public ActionResult Exists(string userName)
        {
            if(userService.Exist(userName) == ViewModel.OperationState.success)
            {
                return new HttpStatusCodeResult(200);
            }
            return new HttpStatusCodeResult(412);
        }

        public ActionResult Add(ViewModel.In.User user)
        {
            if(userService.Add(user) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(412);
        }

        public ActionResult List(ViewModel.In.Page page, ViewModel.In.UserQuery query)
        {
            return Json(userService.list(page, query));
        }

        public ActionResult Edit(ViewModel.In.User user)
        {
            if(this.userService.Edit(user) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(412);
        }

        public ActionResult State(int id, int stateId)
        {
            if (this.userService.State(id, stateId) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(200);
        }

        public ActionResult Del(int id)
        {
            if (this.userService.Del(id) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(412);
        }

        public ActionResult InitPassword(int id)
        {
            if (this.userService.InitPassword(id) == ViewModel.OperationState.success)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(200);
        }

        public ActionResult StateAll()
        {
            return Json(userService.AllState());
        }
    }
}
