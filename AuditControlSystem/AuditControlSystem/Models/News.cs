using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditControlSystem.Models
{
    public class News
    {
        public int NewsId { get; set; }
        public int AdminId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public DateTime NewsDateTime { get; set; }
    }
}