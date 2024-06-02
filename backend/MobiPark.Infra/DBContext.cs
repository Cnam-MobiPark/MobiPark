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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingSpace>()
                .HasKey(p => p.Number);

            modelBuilder.Entity<VehicleEntity>()
                .HasKey(v => v.Plate);
        }
    }
}
