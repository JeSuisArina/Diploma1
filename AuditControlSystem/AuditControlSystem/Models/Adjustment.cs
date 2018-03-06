using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditControlSystem.Models
{
    public class Adjustment
    {
        public int AdjustmentId { get; set; }
        public int ApplicationId { get; set; }
        public string AuditorId { get; set; }
        public string AdjustmentContent { get; set; }
        public string AdjustmentFileName { get; set; }
        public DateTime AdjustmentDateTime { get; set; }
    }
}