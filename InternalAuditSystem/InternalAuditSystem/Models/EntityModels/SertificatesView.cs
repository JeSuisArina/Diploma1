namespace InternalAuditSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SertificatesView")]
    public partial class SertificatesView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(150)]
        public string SubdivisionName { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime SertificateDate { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SertificateId { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool Discrepancy { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string UserLastName { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserMiddleName { get; set; }
    }
}
