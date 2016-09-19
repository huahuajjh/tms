

// This file was automatically generated.
// Do not make changes directly to this file - edit the template instead.
// 
// The following connection settings were used to generate this file
// 
//     Configuration file:     "Template\App.config"
//     Connection String Name: "DB_ConnStr"
//     Connection String:      "server=.;UID=sa;PWD=123456;database=TMS"

// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace Template
{
    // ************************************************************************
    // Database context
    public partial class DB_Context : DbContext, IDB_Context
    {
        public IDbSet<Menu> Menus { get; set; } // Menu
        public IDbSet<Role> Roles { get; set; } // Role
        public IDbSet<RoleMenu> RoleMenus { get; set; } // RoleMenu
        public IDbSet<Scenery> Sceneries { get; set; } // Scenery
        public IDbSet<SuperUser> SuperUsers { get; set; } // SuperUser
        public IDbSet<Ticket> Tickets { get; set; } // Ticket
        public IDbSet<TicketCode> TicketCodes { get; set; } // TicketCode
        public IDbSet<TicketInfo> TicketInfoes { get; set; } // TicketInfo
        public IDbSet<User> Users { get; set; } // User
        public IDbSet<UserInfo> UserInfoes { get; set; } // UserInfo
        public IDbSet<UserScenery> UserSceneries { get; set; } // UserScenery
        public IDbSet<UserState> UserStates { get; set; } // UserState

        static DB_Context()
        {
            Database.SetInitializer<DB_Context>(null);
        }

        public DB_Context()
            : base("Name=DB_ConnStr")
        {
        InitializePartial();
        }

        public DB_Context(string connectionString) : base(connectionString)
        {
        InitializePartial();
        }

        public DB_Context(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        InitializePartial();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new MenuConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new RoleMenuConfiguration());
            modelBuilder.Configurations.Add(new SceneryConfiguration());
            modelBuilder.Configurations.Add(new SuperUserConfiguration());
            modelBuilder.Configurations.Add(new TicketConfiguration());
            modelBuilder.Configurations.Add(new TicketCodeConfiguration());
            modelBuilder.Configurations.Add(new TicketInfoConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserInfoConfiguration());
            modelBuilder.Configurations.Add(new UserSceneryConfiguration());
            modelBuilder.Configurations.Add(new UserStateConfiguration());
        OnModelCreatingPartial(modelBuilder);
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new MenuConfiguration(schema));
            modelBuilder.Configurations.Add(new RoleConfiguration(schema));
            modelBuilder.Configurations.Add(new RoleMenuConfiguration(schema));
            modelBuilder.Configurations.Add(new SceneryConfiguration(schema));
            modelBuilder.Configurations.Add(new SuperUserConfiguration(schema));
            modelBuilder.Configurations.Add(new TicketConfiguration(schema));
            modelBuilder.Configurations.Add(new TicketCodeConfiguration(schema));
            modelBuilder.Configurations.Add(new TicketInfoConfiguration(schema));
            modelBuilder.Configurations.Add(new UserConfiguration(schema));
            modelBuilder.Configurations.Add(new UserInfoConfiguration(schema));
            modelBuilder.Configurations.Add(new UserSceneryConfiguration(schema));
            modelBuilder.Configurations.Add(new UserStateConfiguration(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(DbModelBuilder modelBuilder);
    }

    // ************************************************************************
    // POCO classes

    // Menu
    public partial class Menu
    {
        public int Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public string Ico { get; set; } // Ico
        public byte Sort { get; set; } // Sort
        public int? PaterId { get; set; } // PaterId
        public string Type { get; set; } // Type
        public string Link { get; set; } // Link

        public Menu()
        {
            Sort = 0;
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Role
    public partial class Role
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
        public string Remarks { get; set; } // remarks
    }

    // RoleMenu
    public partial class RoleMenu
    {
        public int Id { get; set; } // Id (Primary key)
        public int RoleId { get; set; } // RoleId
        public int MenuId { get; set; } // MenuId
    }

    // Scenery
    public partial class Scenery
    {
        public int Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public string Remarks { get; set; } // Remarks
        public bool IsDel { get; set; } // IsDel
    }

    // SuperUser
    public partial class SuperUser
    {
        public int Id { get; set; } // Id (Primary key)
        public string Account { get; set; } // Account
        public string Password { get; set; } // Password
    }

    // Ticket
    public partial class Ticket
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
        public string Phone { get; set; } // Phone
        public string IdCard { get; set; } // IdCard
        public byte Gender { get; set; } // Gender
        public string Community { get; set; } // Community
        public string Unit { get; set; } // Unit
        public int SceneryId { get; set; } // SceneryId
        public DateTime PlayTime { get; set; } // PlayTime
        public DateTime PlayDate { get; set; } // PlayDate
        public int BuyNumber { get; set; } // BuyNumber
        public bool IsPay { get; set; } // IsPay
        public string Recommender { get; set; } // Recommender
        public string Remarks { get; set; } // Remarks
        public byte State { get; set; } // State
        public int? StateUserId { get; set; } // StateUserId
        public string StateMsg { get; set; } // StateMsg
        public bool TakeState { get; set; } // TakeState
        public int? UserId { get; set; } // UserId
        public DateTime CreateTime { get; set; } // CreateTime
        public bool IsDel { get; set; } // IsDel
        public int TakeNum { get; set; } // TakeNum
        public byte? IsCode { get; set; } // IsCode
    }

    // TicketCode
    public partial class TicketCode
    {
        public int Id { get; set; } // Id (Primary key)
        public string Phone { get; set; } // Phone
        public int SceneryId { get; set; } // SceneryId
        public DateTime PlayDate { get; set; } // PlayDate
        public string Code { get; set; } // Code
        public byte State { get; set; } // State
        public byte IsCode { get; set; } // IsCode
        public string SmsContext { get; set; } // SMSContext
    }

    // TicketInfo
    public partial class TicketInfo
    {
        public int Id { get; set; } // Id
        public string Name { get; set; } // Name
        public string Phone { get; set; } // Phone
        public string IdCard { get; set; } // IdCard
        public byte Gender { get; set; } // Gender
        public string Community { get; set; } // Community
        public string Unit { get; set; } // Unit
        public int SceneryId { get; set; } // SceneryId
        public DateTime PlayTime { get; set; } // PlayTime
        public DateTime PlayDate { get; set; } // PlayDate
        public int BuyNumber { get; set; } // BuyNumber
        public bool IsPay { get; set; } // IsPay
        public string Recommender { get; set; } // Recommender
        public string Remarks { get; set; } // Remarks
        public byte State { get; set; } // State
        public int? StateUserId { get; set; } // StateUserId
        public string StateMsg { get; set; } // StateMsg
        public bool TakeState { get; set; } // TakeState
        public int? UserId { get; set; } // UserId
        public DateTime CreateTime { get; set; } // CreateTime
        public bool IsDel { get; set; } // IsDel
        public string Code { get; set; } // Code
        public string SceneryTitle { get; set; } // SceneryTitle
        public string SceneryRemarks { get; set; } // SceneryRemarks
        public string CreateUserName { get; set; } // CreateUserName
        public string CreateUserAccount { get; set; } // CreateUserAccount
        public string StateUserName { get; set; } // StateUserName
        public string StateUserAccount { get; set; } // StateUserAccount
        public byte? CreateUserType { get; set; } // CreateUserType
        public byte? StateUserType { get; set; } // StateUserType
        public byte? SmsState { get; set; } // SMSState
        public int TakeNum { get; set; } // TakeNum
        public string CreateQq { get; set; } // CreateQQ
        public string CreateMail { get; set; } // CreateMail
        public string CreatePhone { get; set; } // CreatePhone
        public byte? IsCode { get; set; } // IsCode
        public string SmsContext { get; set; } // SMSContext
    }

    // User
    public partial class User
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name
        public string Account { get; set; } // Account
        public string Password { get; set; } // Password
        public int RoleId { get; set; } // RoleId
        public DateTime Birthday { get; set; } // Birthday
        public byte Gender { get; set; } // Gender
        public string Qq { get; set; } // QQ
        public string Mail { get; set; } // Mail
        public string Phone { get; set; } // Phone
        public string IdCard { get; set; } // IdCard
        public int StateId { get; set; } // StateId
        public byte Type { get; set; } // Type
    }

    // UserInfo
    public partial class UserInfo
    {
        public int Id { get; set; } // Id
        public string Name { get; set; } // Name
        public string Account { get; set; } // Account
        public string Password { get; set; } // Password
        public int RoleId { get; set; } // RoleId
        public DateTime Birthday { get; set; } // Birthday
        public byte Gender { get; set; } // Gender
        public string Qq { get; set; } // QQ
        public string Mail { get; set; } // Mail
        public string Phone { get; set; } // Phone
        public string IdCard { get; set; } // IdCard
        public int StateId { get; set; } // StateId
        public string RoleName { get; set; } // RoleName
        public string Remarks { get; set; } // remarks
        public string Title { get; set; } // Title
        public bool? IsLogin { get; set; } // IsLogin
        public byte UserType { get; set; } // UserType
    }

    // UserScenery
    public partial class UserScenery
    {
        public int Id { get; set; } // Id (Primary key)
        public int UserId { get; set; } // UserId
        public int SceneryId { get; set; } // SceneryId
    }

    // UserState
    public partial class UserState
    {
        public int Id { get; set; } // Id (Primary key)
        public string Title { get; set; } // Title
        public bool IsLogin { get; set; } // IsLogin
    }


    // ************************************************************************
    // POCO Configuration

    // Menu
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
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Role
    internal partial class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Role");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(50);
            Property(x => x.Remarks).HasColumnName("remarks").IsOptional().HasMaxLength(200);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // RoleMenu
    internal partial class RoleMenuConfiguration : EntityTypeConfiguration<RoleMenu>
    {
        public RoleMenuConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".RoleMenu");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.RoleId).HasColumnName("RoleId").IsRequired();
            Property(x => x.MenuId).HasColumnName("MenuId").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Scenery
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
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // SuperUser
    internal partial class SuperUserConfiguration : EntityTypeConfiguration<SuperUser>
    {
        public SuperUserConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".SuperUser");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Account).HasColumnName("Account").IsRequired().HasMaxLength(50);
            Property(x => x.Password).HasColumnName("Password").IsRequired().HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Ticket
    internal partial class TicketConfiguration : EntityTypeConfiguration<Ticket>
    {
        public TicketConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Ticket");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
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
            Property(x => x.TakeNum).HasColumnName("TakeNum").IsRequired();
            Property(x => x.IsCode).HasColumnName("IsCode").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // TicketCode
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
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // TicketInfo
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
            Property(x => x.SmsContext).HasColumnName("SMSContext").IsOptional().HasMaxLength(200);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // User
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
            Property(x => x.Type).HasColumnName("Type").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // UserInfo
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
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // UserScenery
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

    // UserState
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

