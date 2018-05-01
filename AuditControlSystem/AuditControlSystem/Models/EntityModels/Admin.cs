namespace AuditControlSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin()
        {
            Adjustments = new HashSet<Adjustment>();
            Newses = new HashSet<News>();
        }

        public int AdminId { get; set; }

        public bool RoleAuditor { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminName { get; set; }

        [StringLength(50)]
        public string AdminMiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminEmail { get; set; }

        [Required]
        [StringLength(15)]
        public string AdminPhone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adjustment> Adjustments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> Newses { get; set; }
    }
}
