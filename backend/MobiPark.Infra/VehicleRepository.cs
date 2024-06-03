using Microsoft.EntityFrameworkCore;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;
using MobiPark.Infra.Entities;

namespace MobiPark.Infra;

public class VehicleRepository : IVehicleRepository
{
    private readonly ApplicationDbContext _context;

    public VehicleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Vehicle> CreateVehicle(string type, string maker, AbstractLicensePlate licensePlate, Engine engine)
    {
        Vehicle vehicle = type switch
        {
            "Car" => new Car(maker, licensePlate, engine),
            "Motorcycle" => new Motorcycle(maker, licensePlate, engine),
            _ => throw new InvalidOperationException("Unknown vehicle type")
        };
        await _context.Vehicles.AddAsync(new VehicleEntity(vehicle));
        await _context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<List<Vehicle>> GetVehicles()
    {
        return await _context.Vehicles
            .Select(v => v.ToDomainModel())
            .ToListAsync();
    }
    
    public async Task<Vehicle> GetVehicle(string licensePlate)
    {
        var vehicle = await _context.Vehicles
            .FirstOrDefaultAsync(v => v.Plate == licensePlate);
        if (vehicle == null)
        {
            throw new InvalidOperationException("Vehicle not found.");
        }
        return vehicle.ToDomainModel();
    }
}