using IRepository;
using Library.Constant;
using Library.DI;
using System;
using System.Collections.Generic;

namespace Repository
{
    /// <summary>
    /// 仓储实现类，提供实体工厂和存储过程执行
    /// </summary>
    public class Repository : IRepository.IRepository
    {
        private IDataContext DbContext;
        private Dictionary<Type, object> baseRepository = new Dictionary<Type,object>();

        public Repository()
        {
            this.DbContext = Di.GetInstance<Data.DB_Context>(DiKey.DBCONTEXT, true);
        }

        /// <summary>
        /// 实体工厂
        /// </summary>
        /// <typeparam name="T">实体类型参数</typeparam>
        /// <returns>实体工厂</returns>
        public IBaseRepository<T> GetReposirotyFactory<T>() where T : class
        {
            Type type = typeof(T);
            if (!baseRepository.ContainsKey(type)) {
                baseRepository.Add(type, new BaseRepository<T>(DbContext));
            }
            return (BaseRepository<T>)baseRepository[type];
        }

        /// <summary>
        /// 存储过程
        /// </summary>
        /// <returns>存储过程</returns>
        public IExecuteSp GetSpInstance()
        {
            return ExecuteSp.GetInstance(DbContext);
        }

        /// <summary>
        /// 持久化保存，新增，删除，修改都需要调用此方法来持久化数据
        /// </summary>
        public int SaveChange()
        {
            return DbContext.SaveChanges();
        }
    }
}
