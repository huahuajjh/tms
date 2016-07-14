using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    internal partial class SceneryConfiguration : EntityTypeConfiguration<Scenery>
    {
        public SceneryConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Scenery");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(50);
            Property(x => x.Remarks).HasColumnName("Remarks").IsOptional().HasMaxLength(200);
            Property(x => x.IsDel).HasColumnName("IsDel").IsRequired();
        }
    }
}
