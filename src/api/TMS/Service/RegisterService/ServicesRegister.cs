using IService.IRegisterService;
using Library.Constant;
using Library.DI;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Service.RegisterService
{
    /// <summary>
    /// 服务注册器，该类无法被继承，提供用户需求服务注册机制，当用户需求服务时，注册服务实现类
    /// </summary>
    public sealed class ServicesRegister:IServicesRegister
    {

        //fields
        /// <summary>
        /// 服务列表，列表维护所有注册到到字典的服务
        /// </summary>
        private static Dictionary<Type, Type> _servicesDic = new Dictionary<Type, Type>();

        /// <summary>
        /// 服务注册方法，注册服务进去
        /// </summary>
        /// <param name="serviceKey">服务key，唯一标识服务，便于标识，建议使用服务类的全限定名称</param>
        /// <param name="service">被注册的服务对象</param>
        public void RegisteService<T, I>()
        {
            Type t = typeof(T);
            Type type = typeof(I);
            if (!t.IsInterface || type == null || !type.IsClass) {
                return;
            }
            //注册服务
            _servicesDic.Add(t, type); 
        }

        /// <summary>
        /// 根据serviceKey获取服务
        /// </summary>
        /// <param name="serviceKey">serviceKey，服务的唯一标识</param>
        public T GetService<T>()
        {
            Type t = typeof(T);
            if(!_servicesDic.ContainsKey(t)) return default(T);
            Type type = _servicesDic[t];
            IRepository.IRepository repository = Di.GetInstance<IRepository.IRepository>(DiKey.DALKEY, true);
            if (null == CallContext.GetData(type.Name))
            {
                //如果不存在，说明是第一次请求创建对象,该对象在线程级别提供数据共享
                CallContext.SetData(type.Name, (T)Activator.CreateInstance(type, repository));
            }
            return (T)CallContext.GetData(type.Name);
        }
        
    }
}
