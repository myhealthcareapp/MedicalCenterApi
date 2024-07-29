using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    internal class MedicalCenterDBContext(DbContextOptions<MedicalCenterDBContext> options) : DbContext(options)
    {
        internal DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        internal DbSet<Medicine> Medicines { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Doctors;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>()
                .OwnsOne(r => r.Address);

            modelBuilder.Entity<Patient>()
                .HasMany(r => r.Medicine)
                .WithOne()
                .HasForeignKey(d => d.PatientId);
        }

    }
}
