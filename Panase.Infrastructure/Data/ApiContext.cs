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

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<SessionNote> SessionNotes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // BaseEntity - common fields
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).Property<DateTime>("CreatedDate").HasDefaultValueSql("NOW()");
                    modelBuilder.Entity(entityType.ClrType).Property<DateTime?>("UpdatedDate");
                }
            }

            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.LastName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.Role).IsRequired().HasMaxLength(50);

                // 1-1 ilişkiler
                entity.HasOne(u => u.DoctorProfile)
                      .WithOne(d => d.User)
                      .HasForeignKey<Doctor>(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(u => u.PatientProfile)
                      .WithOne(p => p.User)
                      .HasForeignKey<Patient>(p => p.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Doctor
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctors");

                entity.Property(d => d.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(d => d.LastName).IsRequired().HasMaxLength(100);
                entity.Property(d => d.Specialty).HasMaxLength(150);
                entity.Property(d => d.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(d => d.Email).IsUnique();
                entity.Property(d => d.PhoneNumber).HasMaxLength(20);

                entity.HasMany(d => d.Appointments)
                      .WithOne(a => a.Doctor)
                      .HasForeignKey(a => a.DoctorId)
                      .OnDelete(DeleteBehavior.Restrict); // doktor silinse bile randevular kalabilir
            });

            // Patient
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patients");

                entity.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(p => p.LastName).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(p => p.Email).IsUnique();
                entity.Property(p => p.PhoneNumber).HasMaxLength(20);

                entity.HasMany(p => p.Appointments)
                      .WithOne(a => a.Patient)
                      .HasForeignKey(a => a.PatientId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Appointment
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointments");

                entity.Property(a => a.AppointmentDate).IsRequired();
                entity.Property(a => a.Status).IsRequired().HasMaxLength(50);

                entity.HasMany(a => a.SessionNotes)
                      .WithOne(sn => sn.Appointment)
                      .HasForeignKey(sn => sn.AppointmentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // SessionNote
            modelBuilder.Entity<SessionNote>(entity =>
            {
                entity.ToTable("SessionNotes");

                entity.Property(sn => sn.Note).IsRequired();
                entity.Property(sn => sn.CreatedAt).IsRequired().HasDefaultValueSql("NOW()");
            });
        }

    }
}
