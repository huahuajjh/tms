using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
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
}
