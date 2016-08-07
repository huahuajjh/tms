using IService;
using IService.IRegisterService;
using Library.Constant;
using Service.RegisterService;
using System;
using System.Runtime.Remoting.Messaging;

namespace Service.RegisterService
{
    /// <summary>
    /// 服务工厂，该工厂产生服务
    /// </summary>
    /// <typeparam name="T">服务具体类型参数</typeparam>
    public class ServicesFactory : IServicesFactory
    {

        //ctors
        /// <summary>
        /// 初始化服务工厂
        /// </summary>
        static ServicesFactory()
        {
            _register.RegisteService<IUserService, UserService>();
            _register.RegisteService<IRoleService, RoleService>();
            _register.RegisteService<IMenuService, MenuService>();
            _register.RegisteService<ISceneryService, SceneryService>();
            _register.RegisteService<ITicketService, TicketService>();
        }

        /// <summary>
        /// 根据服务key获取服务
        /// </summary>
        /// <param name="serviceKey">服务key</param>
        /// <returns>服务对象接口</returns>
        public T GetService<T>()
        {
            return _register.GetService<T>();
        }

        //通过工厂获取服务注册器
        private static IServicesRegister _register = new ServicesRegister();
    }
}
