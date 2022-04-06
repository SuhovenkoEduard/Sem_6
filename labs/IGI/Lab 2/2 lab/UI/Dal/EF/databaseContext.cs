using System;
using Dal.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Dal
{
    public partial class databaseContext : DbContext
    {
        public databaseContext()
        {
        }

        public databaseContext(DbContextOptions<databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<StudInfo> StudInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(Config.DbConfig());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.HasIndex(e => e.Id, "ix_Address_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ExistAddress).HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasIndex(e => e.Id, "ix_Courses_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CourseName).HasColumnType("VARCHAR");

                entity.Property(e => e.Description).HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<StudInfo>(entity =>
            {
                entity.ToTable("StudInfo");

                entity.HasIndex(e => e.Id, "ix_StudInfo_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateEnrolled).HasColumnType("VARCHAR");

                entity.Property(e => e.FirstName).HasColumnType("VARCHAR");

                entity.Property(e => e.Gender).HasColumnType("VARCHAR");

                entity.Property(e => e.Graduate).HasColumnType("VARCHAR");

                entity.Property(e => e.LastName).HasColumnType("VARCHAR");

                entity.Property(e => e.MiddleName).HasColumnType("VARCHAR");

                entity.Property(e => e.YearGraduate).HasColumnType("VARCHAR");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.StudInfos)
                    .HasForeignKey(d => d.AddressId);

                entity.HasOne(d => d.CourseCodeNavigation)
                    .WithMany(p => p.StudInfos)
                    .HasForeignKey(d => d.CourseCode);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
