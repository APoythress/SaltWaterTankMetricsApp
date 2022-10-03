using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SaltWaterTankMetrics.DataAccess.EF.Models;

namespace SaltWaterTankMetrics.DataAccess.EF.Context
{
    public partial class SaltwaterTankContext : DbContext
    {
        public SaltwaterTankContext()
        {
        }

        public SaltwaterTankContext(DbContextOptions<SaltwaterTankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SaltWaterTankMetric> SaltWaterTankMetrics { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SaltwaterTank;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaltWaterTankMetric>(entity =>
            {
                entity.HasKey(e => e.TankId);

                entity.Property(e => e.TankId).HasColumnName("TankID");

                entity.Property(e => e.SaltWaterDkh)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("SaltWaterDKH");

                entity.Property(e => e.SaltWaterNh3)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("SaltWaterNH3");

                entity.Property(e => e.SaltWaterPh)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("SaltWaterPH");

                entity.Property(e => e.SaltWaterTemp).HasColumnType("decimal(2, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
