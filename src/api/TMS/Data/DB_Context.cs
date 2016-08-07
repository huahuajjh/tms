using Data.Mapping;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Data
{
    public partial class DB_Context : DbContext, IRepository.IDataContext
    {

        static DB_Context()
        {
            Database.SetInitializer<DB_Context>(null);
        }

        public DB_Context()
            : base("Name=DB_ConnStr")
        {
        }

        public DB_Context(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new MenuConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new RoleMenuConfiguration());
            modelBuilder.Configurations.Add(new SceneryConfiguration());
            modelBuilder.Configurations.Add(new SuperUserConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserSceneryConfiguration());
            modelBuilder.Configurations.Add(new UserStateConfiguration());
            modelBuilder.Configurations.Add(new UserInfoConfiguration());
            modelBuilder.Configurations.Add(new TicketConfiguration());
            modelBuilder.Configurations.Add(new TicketCodeConfiguration());
            modelBuilder.Configurations.Add(new TicketInfoConfiguration());
        }

        public IQueryable<T> ExecuteStoredProcedure<T>(string query, params object[] parameters)
        {
            return base.Database.SqlQuery<T>(query, parameters).AsQueryable();
        }
    }
}
