using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
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
}
