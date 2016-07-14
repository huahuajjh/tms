using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    internal partial class UserStateConfiguration : EntityTypeConfiguration<UserState>
    {
        public UserStateConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".UserState");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(50);
            Property(x => x.IsLogin).HasColumnName("IsLogin").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}
