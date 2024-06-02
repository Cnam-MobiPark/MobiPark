using Microsoft.EntityFrameworkCore;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Infra;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ParkingSpace> ParkingSpaces { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParkingSpace>()
            .HasKey(p => p.Number);

        modelBuilder.Entity<ParkingSpace>()
            .Property(p => p.Number)
            .HasColumnName("Number");
        
        modelBuilder.Entity<Vehicle>()
            .HasKey(v => v.LicensePlate);
        
        modelBuilder.Entity<Vehicle>()
            .Property(v => v.LicensePlate)
            .HasColumnName("LicensePlate");
        
        modelBuilder.Entity<Reservation>()
            .HasKey(r => r.ReservationId);
        
        modelBuilder.Entity<Reservation>()
            .Property(r => r.ReservationId)
            .HasColumnName("Id");
        
    }
}