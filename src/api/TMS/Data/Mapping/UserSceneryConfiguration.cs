using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    internal partial class UserSceneryConfiguration : EntityTypeConfiguration<UserScenery>
    {
        public UserSceneryConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".UserScenery");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            Property(x => x.SceneryId).HasColumnName("SceneryId").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}
