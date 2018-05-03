namespace InternalAuditSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Standarts
    {
        [Key]
        public int StandartId { get; set; }

        [Required]
        [StringLength(30)]
        public string StandartName { get; set; }

        [Required]
        [StringLength(100)]
        public string StandartDescription { get; set; }

        [Required]
        public byte[] StandartFile { get; set; }
    }
}
