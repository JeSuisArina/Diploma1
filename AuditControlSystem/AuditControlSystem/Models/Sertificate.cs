using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditControlSystem.Models
{
    public class Sertificate
    {
        public int SertificateId { get; set; }
        public int SubdivisionId { get; set; }
        public int StandartId { get; set; }
        public DateTime SertificateDate { get; set; }
        public DateTime SertificateShelfLife { get; set; }
    }
}