using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditControlSystem.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public int StandartId { get; set; }
        public DateTime ApplicationDateTime { get; set; }
        public string ApplicationContent { get; set; }
        public byte[] ApplicationFile { get; set; }
    }
}