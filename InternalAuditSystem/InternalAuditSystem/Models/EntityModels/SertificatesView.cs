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
        [StringLength(50)]
        public string SubdivisionName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string StandartName { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime SertificateDate { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime SertificateShelfLife { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SertificateId { get; set; }
    }
}
