using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AuditControlSystem.Models
{
    public class AuditContext : DbContext
    {
        public DbSet<Auditor> Auditors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Standart> Standarts { get; set; }
        public DbSet<Adjustment> Adjustments { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Sertificate> Sertificates { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
    }
}