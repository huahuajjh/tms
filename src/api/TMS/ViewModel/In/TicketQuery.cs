using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.In
{
    public class TicketQuery
    {
        public string Code { get; set; }

        public string Phone { get; set; }

        public string IdCard { get; set; }

        public string PlayTime { get; set; }

        public string SceneryId { get; set; }

        public string SceneryName { get; set; }

        public bool? IsPay { get; set; }

        public byte? State { get; set; }

        public string CreateStartTime { get; set; }

        public string CreateEndTime { get; set; }

        public string Recommender { get; set; }

        public bool? TakeState { get; set; }

        public byte? SMSState { get; set; }

        public int? CreateUserId { get; set; }

        public string CreateIds { get; set; }
    }
}
