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

        public virtual DbSet<Adjustments> Adjustments { get; set; }
        public virtual DbSet<Applications> Applications { get; set; }
        public virtual DbSet<ApplicationStatuses> ApplicationStatuses { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sertificates> Sertificates { get; set; }
        public virtual DbSet<Standarts> Standarts { get; set; }
        public virtual DbSet<Subdivisions> Subdivisions { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<AdjustmentView> AdjustmentView { get; set; }
        public virtual DbSet<ApplicationsView> ApplicationsView { get; set; }
        public virtual DbSet<NewsView> NewsView { get; set; }
        public virtual DbSet<SertificatesView> SertificatesView { get; set; }
        public virtual DbSet<UsersView> UsersView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applications>()
                .HasMany(e => e.Adjustments)
                .WithRequired(e => e.Applications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationStatuses>()
                .Property(e => e.ApplicationStatus)
                .IsFixedLength();

            modelBuilder.Entity<ApplicationStatuses>()
                .HasMany(e => e.Applications)
                .WithRequired(e => e.ApplicationStatuses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.Role)
                .IsFixedLength();

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Roles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Standarts>()
                .Property(e => e.StandartName)
                .IsFixedLength();

            modelBuilder.Entity<Standarts>()
                .HasMany(e => e.Applications)
                .WithRequired(e => e.Standarts)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subdivisions>()
                .Property(e => e.SubdivisionName)
                .IsFixedLength();

            modelBuilder.Entity<Subdivisions>()
                .HasMany(e => e.Sertificates)
                .WithRequired(e => e.Subdivisions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserPhone)
                .IsFixedLength();

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Adjustments)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Applications)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.News)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdjustmentView>()
                .Property(e => e.StandartName)
                .IsFixedLength();

            modelBuilder.Entity<ApplicationsView>()
                .Property(e => e.StandartName)
                .IsFixedLength();

            modelBuilder.Entity<ApplicationsView>()
                .Property(e => e.SubdivisionName)
                .IsFixedLength();

            modelBuilder.Entity<ApplicationsView>()
                .Property(e => e.ApplicationStatus)
                .IsFixedLength();

            modelBuilder.Entity<SertificatesView>()
                .Property(e => e.SubdivisionName)
                .IsFixedLength();

            modelBuilder.Entity<UsersView>()
                .Property(e => e.UserPhone)
                .IsFixedLength();

            modelBuilder.Entity<UsersView>()
                .Property(e => e.SubdivisionName)
                .IsFixedLength();

            modelBuilder.Entity<UsersView>()
                .Property(e => e.Role)
                .IsFixedLength();
        }
    }
}
