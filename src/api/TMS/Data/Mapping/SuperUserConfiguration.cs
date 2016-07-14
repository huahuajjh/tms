using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    internal partial class SuperUserConfiguration : EntityTypeConfiguration<SuperUser>
    {
        public SuperUserConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".SuperUser");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Account).HasColumnName("Account").IsRequired().HasMaxLength(50);
            Property(x => x.Password).HasColumnName("Password").IsRequired().HasMaxLength(50);
        }
    }
}
