namespace AuditControlSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adjustment
    {
        public int AdjustmentId { get; set; }

        public int ApplicationId { get; set; }

        public int AdminId { get; set; }

        public DateTime AdjustmentDateTime { get; set; }

        [Required]
        [StringLength(400)]
        public string AdjustmentContent { get; set; }

        [Required]
        public byte[] AdjustmentFile { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual Application Application { get; set; }
    }
}
