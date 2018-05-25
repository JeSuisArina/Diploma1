namespace InternalAuditSystem.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Applications
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Applications()
        {
            Adjustments = new HashSet<Adjustments>();
        }

        [Key]
        public int ApplicationId { get; set; }

        public int UserId { get; set; }

        public int StandartId { get; set; }

        public DateTime ApplicationDateTime { get; set; }

        [StringLength(400)]
        public string ApplicationContent { get; set; }

        public int ApplicationStatusId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adjustments> Adjustments { get; set; }

        public virtual ApplicationStatuses ApplicationStatuses { get; set; }

        public virtual Standarts Standarts { get; set; }

        public virtual Users Users { get; set; }
    }
}
