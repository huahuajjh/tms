using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
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
}
