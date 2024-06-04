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
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingSpace>()
                .HasKey(p => p.Number);

            modelBuilder.Entity<VehicleEntity>()
                .HasKey(v => v.Plate);
            
            modelBuilder.Entity<ReservationEntity>()
                .HasKey(r => r.ReservationId);
            
            modelBuilder.Entity<UserEntity>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<ReservationEntity>()
                .HasOne(r => r.Vehicle)
                .WithOne(v => v.Reservation);

            modelBuilder.Entity<ReservationEntity>()
                .HasOne<ParkingSpace>(r => r.ParkingSpace);
        }
    }
}
