namespace InternalAuditSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sertificates
    {
        [Key]
        public int SertificateId { get; set; }

        public int SubdivisionId { get; set; }

        public DateTime SertificateDate { get; set; }

        public int? UserId { get; set; }

        public bool Discrepancy { get; set; }

        public virtual Subdivisions Subdivisions { get; set; }
    }
}
