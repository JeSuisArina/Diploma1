using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditControlSystem.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminMiddleName { get; set; }
        public string AdminLastName { get; set; }
        public string AdminPhone { get; set; }
        public string AdminEmail { get; set; }
    }
}