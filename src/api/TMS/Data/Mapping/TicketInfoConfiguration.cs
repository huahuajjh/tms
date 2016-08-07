using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Data.Mapping
{
    internal partial class TicketInfoConfiguration : EntityTypeConfiguration<TicketInfo>
    {
        public TicketInfoConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".TicketInfo");
            HasKey(x => new { x.Id, x.Gender, x.SceneryId, x.PlayTime, x.PlayDate, x.BuyNumber, x.IsPay, x.State, x.TakeState, x.CreateTime, x.IsDel, x.TakeNum });

            Property(x => x.Id).HasColumnName("Id").IsRequired();
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(50);
            Property(x => x.Phone).HasColumnName("Phone").IsOptional().HasMaxLength(50);
            Property(x => x.IdCard).HasColumnName("IdCard").IsOptional().HasMaxLength(50);
            Property(x => x.Gender).HasColumnName("Gender").IsRequired();
            Property(x => x.Community).HasColumnName("Community").IsOptional().HasMaxLength(50);
            Property(x => x.Unit).HasColumnName("Unit").IsOptional().HasMaxLength(50);
            Property(x => x.SceneryId).HasColumnName("SceneryId").IsRequired();
            Property(x => x.PlayTime).HasColumnName("PlayTime").IsRequired();
            Property(x => x.PlayDate).HasColumnName("PlayDate").IsRequired();
            Property(x => x.BuyNumber).HasColumnName("BuyNumber").IsRequired();
            Property(x => x.IsPay).HasColumnName("IsPay").IsRequired();
            Property(x => x.Recommender).HasColumnName("Recommender").IsOptional().HasMaxLength(50);
            Property(x => x.Remarks).HasColumnName("Remarks").IsOptional().HasMaxLength(200);
            Property(x => x.State).HasColumnName("State").IsRequired();
            Property(x => x.StateUserId).HasColumnName("StateUserId").IsOptional();
            Property(x => x.StateMsg).HasColumnName("StateMsg").IsOptional().HasMaxLength(200);
            Property(x => x.TakeState).HasColumnName("TakeState").IsRequired();
            Property(x => x.UserId).HasColumnName("UserId").IsOptional();
            Property(x => x.CreateTime).HasColumnName("CreateTime").IsRequired();
            Property(x => x.IsDel).HasColumnName("IsDel").IsRequired();
            Property(x => x.Code).HasColumnName("Code").IsOptional().HasMaxLength(50);
            Property(x => x.SceneryTitle).HasColumnName("SceneryTitle").IsOptional().HasMaxLength(50);
            Property(x => x.SceneryRemarks).HasColumnName("SceneryRemarks").IsOptional().HasMaxLength(200);
            Property(x => x.CreateUserName).HasColumnName("CreateUserName").IsOptional().HasMaxLength(50);
            Property(x => x.CreateUserAccount).HasColumnName("CreateUserAccount").IsOptional().HasMaxLength(50);
            Property(x => x.StateUserName).HasColumnName("StateUserName").IsOptional().HasMaxLength(50);
            Property(x => x.StateUserAccount).HasColumnName("StateUserAccount").IsOptional().HasMaxLength(50);
            Property(x => x.CreateUserType).HasColumnName("CreateUserType").IsOptional();
            Property(x => x.StateUserType).HasColumnName("StateUserType").IsOptional();
            Property(x => x.SmsState).HasColumnName("SMSState").IsOptional();
            Property(x => x.TakeNum).HasColumnName("TakeNum").IsRequired();
            Property(x => x.CreateQq).HasColumnName("CreateQQ").IsOptional().HasMaxLength(50);
            Property(x => x.CreateMail).HasColumnName("CreateMail").IsOptional().HasMaxLength(50);
            Property(x => x.CreatePhone).HasColumnName("CreatePhone").IsOptional().HasMaxLength(50);
            Property(x => x.IsCode).HasColumnName("IsCode").IsOptional();
        }
    }
}
