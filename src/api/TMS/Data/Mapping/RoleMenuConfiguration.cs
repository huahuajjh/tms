using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    internal partial class RoleMenuConfiguration : EntityTypeConfiguration<RoleMenu>
    {
        public RoleMenuConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".RoleMenu");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RoleId).HasColumnName("RoleId").IsRequired();
            Property(x => x.MenuId).HasColumnName("MenuId").IsRequired();
        }
    }
}
