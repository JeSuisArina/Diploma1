namespace AuditControlSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Newss")]
    public partial class News
    {
        [Key]
        public int NewsId { get; set; }

        public int AdminId { get; set; }

        [Required]
        [StringLength(50)]
        public string NewsTitle { get; set; }

        [Required]
        [StringLength(400)]
        public string NewsContent { get; set; }

        public DateTime NewsDateTime { get; set; }

        public virtual Admin Admin { get; set; }
    }
}
