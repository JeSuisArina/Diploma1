namespace AuditControlSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Standart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Standart()
        {
            Applications = new HashSet<Application>();
            Sertificates = new HashSet<Sertificate>();
        }

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
        public virtual ICollection<Application> Applications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sertificate> Sertificates { get; set; }
    }
}
