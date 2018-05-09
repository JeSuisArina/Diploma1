namespace InternalAuditSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adjustments
    {
        [Key]
        public int AdjustmentId { get; set; }

        public int ApplicationId { get; set; }

        public int UserId { get; set; }

        public DateTime AdjustmentDateTime { get; set; }

        [Required]
        [StringLength(400)]
        public string AdjustmentContent { get; set; }

        [Required]
        public byte[] AdjustmentFile { get; set; }

        public virtual Users Users { get; set; }

        public virtual Applications Applications { get; set; }
    }
}
