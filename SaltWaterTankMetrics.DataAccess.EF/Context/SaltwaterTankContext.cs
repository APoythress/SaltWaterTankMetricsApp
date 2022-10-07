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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaltWaterTankMetric>(entity =>
            {
                entity.HasKey(e => e.MetricsID);

                entity.Property(e => e.MetricsID)
                    .HasColumnType("int")
                    .HasColumnName("MetricsID");

                entity.Property(e => e.MetricsDate)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasColumnName("MetricsDate");

                entity.Property(e => e.SaltWaterTemp)
                    .IsRequired()
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("SaltWaterTemp");

                entity.Property(e => e.SaltWaterDKH)
                    .IsRequired()
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("SaltWaterDKH");

                entity.Property(e => e.SaltWaterNH3)
                    .IsRequired()
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("SaltWaterNH3");

                entity.Property(e => e.SaltWaterPH)
                    .IsRequired()
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("SaltWaterPH");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
