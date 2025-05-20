using Microsoft.EntityFrameworkCore;
using Panase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Infrastructure.Data
{
    public class ApiContext:DbContext
    {
        public ApiContext(DbContextOptions options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<SessionNote> SessionNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // BaseEntity için Id ve audit alanları (dilersen buradan yönetebilirsin)
            modelBuilder.Entity<BaseEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreatedDate)
                      .IsRequired()
                      .HasDefaultValueSql("NOW()");

                entity.Property(e => e.UpdatedDate);
            });

            // Patient entity configuration
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patients");

                entity.Property(p => p.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasIndex(p => p.Email)
                      .IsUnique();

                // İlişki: Patient -> Appointment (1-many)
                entity.HasMany(p => p.Appointments)
                      .WithOne(a => a.Patient)
                      .HasForeignKey(a => a.PatientId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Doctor entity configuration
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctors");

                entity.Property(d => d.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(d => d.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(d => d.Specialty)
                    .HasMaxLength(150);

                // İlişki: Doctor -> Appointment (1-many)
                entity.HasMany(d => d.Appointments)
                      .WithOne(a => a.Doctor)
                      .HasForeignKey(a => a.DoctorId)
                      .OnDelete(DeleteBehavior.Restrict); // Doktor silindiğinde randevular kalabilir (örnek)
            });

            // Appointment entity configuration
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointments");

                entity.Property(a => a.AppointmentDate)
                    .IsRequired();

                entity.Property(a => a.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                // İlişki: Appointment -> SessionNote (1-many)
                entity.HasMany(a => a.SessionNotes)
                      .WithOne(sn => sn.Appointment)
                      .HasForeignKey(sn => sn.AppointmentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // SessionNote entity configuration
            modelBuilder.Entity<SessionNote>(entity =>
            {
                entity.ToTable("SessionNotes");

                entity.Property(sn => sn.Note)
                    .IsRequired();

                entity.Property(sn => sn.CreatedAt)
                    .IsRequired()
                    .HasDefaultValueSql("NOW()");
            });
        }
    }
}
