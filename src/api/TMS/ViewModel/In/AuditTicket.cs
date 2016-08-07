﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.In
{
    public class AuditTicket
    {
        public int Id { get; set; }

        public byte State { get; set; }

        public string StateMsg { get; set; }

        public bool IsStateCode { get; set; }

        public int? StateUserId { get; set; }
    }
}
