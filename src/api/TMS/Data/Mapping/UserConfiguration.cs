using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    internal partial class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".User");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(50);
            Property(x => x.Account).HasColumnName("Account").IsRequired().HasMaxLength(50);
            Property(x => x.Password).HasColumnName("Password").IsOptional().HasMaxLength(50);
            Property(x => x.RoleId).HasColumnName("RoleId").IsRequired();
            Property(x => x.Birthday).HasColumnName("Birthday").IsRequired();
            Property(x => x.Gender).HasColumnName("Gender").IsRequired();
            Property(x => x.Qq).HasColumnName("QQ").IsOptional().HasMaxLength(50);
            Property(x => x.Mail).HasColumnName("Mail").IsOptional().HasMaxLength(50);
            Property(x => x.Phone).HasColumnName("Phone").IsOptional().HasMaxLength(50);
            Property(x => x.IdCard).HasColumnName("IdCard").IsOptional().HasMaxLength(50);
            Property(x => x.StateId).HasColumnName("StateId").IsRequired();
        }
    }
}
