using IService.IRegisterService;
using Library.Constant;
using Library.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Application.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Services对象
        /// </summary>
        private IServicesFactory Service;

        /// <summary>
        /// 初始化Services
        /// </summary>
        protected BaseController()
        {
            Service = Di.GetInstance<IServicesFactory>(DiKey.BLLKEY, true);
        }

        protected T GetService<T>()
        {
            return Service.GetService<T>();
        }
    }
}
