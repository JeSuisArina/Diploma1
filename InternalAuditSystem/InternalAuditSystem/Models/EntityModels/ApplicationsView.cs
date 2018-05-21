namespace InternalAuditSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ApplicationsView")]
    public partial class ApplicationsView
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
        [StringLength(100)]
        public string StandartName { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime ApplicationDateTime { get; set; }

        [StringLength(400)]
        public string ApplicationContent { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicationId { get; set; }
    }
}
