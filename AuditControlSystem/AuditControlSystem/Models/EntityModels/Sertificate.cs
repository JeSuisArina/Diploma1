namespace AuditControlSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sertificate
    {
        public int SertificateId { get; set; }

        public int SubdivisionId { get; set; }

        public int StandartId { get; set; }

        public DateTime SertificateDate { get; set; }

        public DateTime SertificateShelfLife { get; set; }

        public virtual Subdivision Subdivision { get; set; }

        public virtual Standart Standart { get; set; }
    }
}
