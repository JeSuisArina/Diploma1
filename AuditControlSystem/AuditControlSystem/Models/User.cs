using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditControlSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int SubdivisionId { get; set; }
        public string UserName { get; set; }
        public string UserMiddleName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
    }
}