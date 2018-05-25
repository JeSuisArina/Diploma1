namespace InternalAuditSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersView")]
    public partial class UsersView
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
        [StringLength(50)]
        public string UserEmail { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(15)]
        public string UserPhone { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(150)]
        public string SubdivisionName { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(20)]
        public string Role { get; set; }
    }
}
