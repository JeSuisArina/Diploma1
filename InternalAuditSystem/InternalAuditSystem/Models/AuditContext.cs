namespace InternalAuditSystem.Models
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

        public virtual DbSet<Adjustment> Adjustments { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<News> Newses { get; set; }
        public virtual DbSet<Sertificate> Sertificates { get; set; }
        public virtual DbSet<Standart> Standarts { get; set; }
        public virtual DbSet<Subdivision> Subdivisions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Adjustments)
                .WithRequired(e => e.Admin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Newses)
                .WithRequired(e => e.Admin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Application>()
                .HasMany(e => e.Adjustments)
                .WithRequired(e => e.Application)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<News>()
                .Property(e => e.NewsTitle)
                .IsFixedLength();

            modelBuilder.Entity<Standart>()
                .Property(e => e.StandartName)
                .IsFixedLength();

            modelBuilder.Entity<Standart>()
                .HasMany(e => e.Applications)
                .WithRequired(e => e.Standart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Standart>()
                .HasMany(e => e.Sertificates)
                .WithRequired(e => e.Standart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subdivision>()
                .Property(e => e.SubdivisionName)
                .IsFixedLength();

            modelBuilder.Entity<Subdivision>()
                .HasMany(e => e.Sertificates)
                .WithRequired(e => e.Subdivision)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subdivision>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Subdivision)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPhone)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Applications)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
