namespace InternalAuditSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdjustmentView")]
    public partial class AdjustmentView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string UserLastName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserMiddleName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicationId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string StandartName { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime AdjustmentDateTime { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(400)]
        public string AdjustmentContent { get; set; }

        [Key]
        [Column(Order = 6)]
        public byte[] AdjustmentFile { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdjustmentId { get; set; }
    }
}
