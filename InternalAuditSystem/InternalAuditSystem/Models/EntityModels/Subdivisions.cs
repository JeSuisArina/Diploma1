namespace InternalAuditSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subdivisions
    {
        [Key]
        public int SubdivisionId { get; set; }

        [Required]
        [StringLength(50)]
        public string SubdivisionName { get; set; }
    }
}
