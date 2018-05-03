namespace InternalAuditSystem.Models.EntityModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AuditContext : DbContext
    {
        public AuditContext()
            : base("name=AuditContext")
        {
        }

        public virtual DbSet<Standarts> Standarts { get; set; }
        public virtual DbSet<Subdivisions> Subdivisions { get; set; }
        public virtual DbSet<AdjustmentView> AdjustmentView { get; set; }
        public virtual DbSet<ApplicationsView> ApplicationsView { get; set; }
        public virtual DbSet<NewsView> NewsView { get; set; }
        public virtual DbSet<SertificatesView> SertificatesView { get; set; }
        public virtual DbSet<UsersView> UsersView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Standarts>()
                .Property(e => e.StandartName)
                .IsFixedLength();

            modelBuilder.Entity<Subdivisions>()
                .Property(e => e.SubdivisionName)
                .IsFixedLength();

            modelBuilder.Entity<AdjustmentView>()
                .Property(e => e.StandartName)
                .IsFixedLength();

            modelBuilder.Entity<ApplicationsView>()
                .Property(e => e.StandartName)
                .IsFixedLength();

            modelBuilder.Entity<SertificatesView>()
                .Property(e => e.SubdivisionName)
                .IsFixedLength();

            modelBuilder.Entity<SertificatesView>()
                .Property(e => e.StandartName)
                .IsFixedLength();

            modelBuilder.Entity<UsersView>()
                .Property(e => e.UserPhone)
                .IsFixedLength();

            modelBuilder.Entity<UsersView>()
                .Property(e => e.SubdivisionName)
                .IsFixedLength();
        }
    }
}
