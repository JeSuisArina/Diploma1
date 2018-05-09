namespace InternalAuditSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Standarts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Standarts()
        {
            Applications = new HashSet<Applications>();
            Sertificates = new HashSet<Sertificates>();
        }

        [Key]
        public int StandartId { get; set; }

        [Required]
        [StringLength(30)]
        public string StandartName { get; set; }

        [Required]
        [StringLength(100)]
        public string StandartDescription { get; set; }

        [Required]
        public byte[] StandartFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applications> Applications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sertificates> Sertificates { get; set; }
    }
}
