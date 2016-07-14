using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    internal partial class MenuConfiguration : EntityTypeConfiguration<Menu>
    {
        public MenuConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Menu");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(50);
            Property(x => x.Ico).HasColumnName("Ico").IsOptional().HasMaxLength(50);
            Property(x => x.Sort).HasColumnName("Sort").IsRequired();
            Property(x => x.PaterId).HasColumnName("PaterId").IsOptional();
            Property(x => x.Type).HasColumnName("Type").IsRequired().HasMaxLength(50);
            Property(x => x.Link).HasColumnName("Link").IsRequired().HasMaxLength(50);
        }
    }
}
