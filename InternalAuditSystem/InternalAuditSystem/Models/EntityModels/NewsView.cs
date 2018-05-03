namespace InternalAuditSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsView")]
    public partial class NewsView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(400)]
        public string NewsContent { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime NewsDateTime { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string UserLastName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserMiddleName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NewsId { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string NewsTitle { get; set; }
    }
}
