using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditControlSystem.Models
{
    public class Auditor
    {
        public int AuditorId { get; set; }
        public string AuditorName { get; set; }
        public string AuditorMiddleName { get; set; }
        public string AuditorLastName { get; set; }
        public string AuditorPhone { get; set; }
        public string AuditorEmail { get; set; }
    }
}