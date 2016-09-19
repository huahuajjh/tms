using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    internal partial class TicketCodeConfiguration : EntityTypeConfiguration<TicketCode>
    {
        public TicketCodeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".TicketCode");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Phone).HasColumnName("Phone").IsRequired().HasMaxLength(50);
            Property(x => x.SceneryId).HasColumnName("SceneryId").IsRequired();
            Property(x => x.PlayDate).HasColumnName("PlayDate").IsRequired();
            Property(x => x.Code).HasColumnName("Code").IsOptional().HasMaxLength(50);
            Property(x => x.State).HasColumnName("State").IsRequired();
            Property(x => x.IsCode).HasColumnName("IsCode").IsRequired();
            Property(x => x.SmsContext).HasColumnName("SMSContext").IsOptional().HasMaxLength(200);
        }
    }
}
