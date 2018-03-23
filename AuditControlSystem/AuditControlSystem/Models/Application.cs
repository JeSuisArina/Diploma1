using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditControlSystem.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int SubdivisionId { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationContent { get; set; }
        public byte[] ApplicationFile { get; set; }
        public DateTime ApplicationDateTime { get; set; }
    }
}