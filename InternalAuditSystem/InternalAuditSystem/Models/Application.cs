namespace InternalAuditSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Application
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Application()
        {
            Adjustments = new HashSet<Adjustment>();
        }

        public int ApplicationId { get; set; }

        public int UserId { get; set; }

        public int StandartId { get; set; }

        public DateTime ApplicationDateTime { get; set; }

        [StringLength(400)]
        public string ApplicationContent { get; set; }

        [Required]
        public byte[] ApplicationFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adjustment> Adjustments { get; set; }

        public virtual Standart Standart { get; set; }

        public virtual User User { get; set; }
    }
}
