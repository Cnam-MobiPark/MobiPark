using Microsoft.EntityFrameworkCore;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;
using MobiPark.Infra.Entities;

namespace MobiPark.Infra.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly ApplicationDbContext _context;

    public VehicleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Vehicle Save(Vehicle vehicle)
    {
        var entity = new VehicleEntity(vehicle);
        _context.Add(entity);
        _context.SaveChanges();
        return entity.ToDomainModel();
    }

    public Vehicle CreateVehicle(string type, string maker, AbstractLicensePlate licensePlate,
        Engine engine)
    {
        Vehicle vehicle = type switch
        {
            "Car" => new Car(maker, licensePlate, engine),
            "Motorcycle" => new Motorcycle(maker, licensePlate, engine),
            _ => throw new InvalidOperationException("Unknown vehicle type")
        };
        _context.Vehicles.Add(new VehicleEntity(vehicle));
        _context.SaveChanges();
        return vehicle;
    }

    public List<Vehicle> GetVehicles()
    {
        return _context.Vehicles
            .Select(v => v.ToDomainModel())
            .ToList();
    }

    public Vehicle? FindByPlate(string licensePlate)
    {
        var vehicle = _context.Vehicles
            .FirstOrDefault(v => v.Plate == licensePlate);
        return vehicle?.ToDomainModel();
    }
}