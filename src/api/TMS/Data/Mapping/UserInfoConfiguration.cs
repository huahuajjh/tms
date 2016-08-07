using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    internal partial class UserInfoConfiguration : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".UserInfo");
            HasKey(x => new { x.Id, x.Account, x.RoleId, x.Birthday, x.Gender, x.StateId, x.UserType });

            Property(x => x.Id).HasColumnName("Id").IsRequired();
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
            Property(x => x.RoleName).HasColumnName("RoleName").IsOptional().HasMaxLength(50);
            Property(x => x.Remarks).HasColumnName("remarks").IsOptional().HasMaxLength(200);
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(50);
            Property(x => x.IsLogin).HasColumnName("IsLogin").IsOptional();
            Property(x => x.UserType).HasColumnName("UserType").IsRequired();
        }
    }
}
