using Microsoft.EntityFrameworkCore;
using MobiPark.Domain.Models;
using MobiPark.Infra.Entities;

namespace MobiPark.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<VehicleEntity> Vehicles { get; set; }
        public DbSet<LicensePlateEntity> LicensePlates { get; set; }
        public DbSet<EngineEntity> Engines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingSpace>()
                .HasKey(p => p.Number);

            modelBuilder.Entity<ParkingSpace>()
                .Property(p => p.Number)
                .HasColumnName("Number");

            // LicensePlate configuration
            modelBuilder.Entity<LicensePlateEntity>()
                .HasDiscriminator<string>("LicensePlateType")
                .HasValue<DeLicensePlateEntity>("DeLicensePlate")
                .HasValue<FrLicensePlateEntity>("FrLicensePlate");

            modelBuilder.Entity<LicensePlateEntity>()
                .HasKey(lp => lp.Value);

            modelBuilder.Entity<LicensePlateEntity>()
                .Property(lp => lp.Value)
                .HasColumnName("LicensePlate");

            // EngineEntity configuration
            modelBuilder.Entity<EngineEntity>()
                .HasDiscriminator<string>("EngineType")
                .HasValue<ThermalEngineEntity>("Thermal")
                .HasValue<ElectricalEngineEntity>("Electrical");

            // VehicleEntity configuration
            modelBuilder.Entity<VehicleEntity>()
                .HasDiscriminator<string>("VehicleType")
                .HasValue<MotorcycleEntity>("Motorcycle")
                .HasValue<CarEntity>("Car");

            modelBuilder.Entity<VehicleEntity>()
                .HasKey(v => v.LicensePlateValue);

            modelBuilder.Entity<VehicleEntity>()
                .HasOne(v => v.LicensePlate)
                .WithMany()
                .HasForeignKey(v => v.LicensePlateValue);

            modelBuilder.Entity<VehicleEntity>()
                .HasOne(v => v.Engine)
                .WithMany()
                .HasForeignKey(v => v.EngineId);
        }
    }
}
