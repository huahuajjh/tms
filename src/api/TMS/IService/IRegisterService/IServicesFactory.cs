using System;
namespace IService.IRegisterService
{
    /// <summary>
    /// 应用层工厂接口，生产业务对象的策略
    /// </summary>
    public interface IServicesFactory
    {
        
        /// <summary>
        /// 根据服务key获取服务
        /// </summary>
        /// <param name="serviceKey">服务key</param>
        /// <returns>服务对象接口</returns>
        T GetService<T>();
    }
}
