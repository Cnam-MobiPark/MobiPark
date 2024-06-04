using Microsoft.EntityFrameworkCore;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Infra;

public class ParkingRepository : IParkingRepository
{
    private readonly ApplicationDbContext _context;

    public ParkingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Vehicle? GetVehicle(string licensePlate)
    {
        var vehicleEntity = _context.Vehicles
            .FirstOrDefault(v => v.Plate == licensePlate);
        return vehicleEntity?.ToDomainModel();
    }

    public List<ParkingSpace> GetSpaces()
    {
        return _context.ParkingSpaces.ToList();
    }

    public List<ParkingSpace> GetAvailableSpaces()
    {
        return _context.ParkingSpaces
            .Where(p => p.Status == ParkingSpaceStatus.Available)
            .ToList();
    }

    public List<ParkingSpace> GetAvailableSpaces(Vehicle vehicle)
    {
        var spaces = _context.ParkingSpaces;
        var spacesList = spaces.ToList();
        var availableSpaces = spacesList.Where(p => p.Status == ParkingSpaceStatus.Available && p.Size == vehicle.GetSize()).ToList();
        return availableSpaces;
    }

    public void ParkVehicle(Vehicle vehicle, ParkingSpace parkingSpace)
    {
        parkingSpace.Status = ParkingSpaceStatus.Occupied;
        _context.ParkingSpaces.Update(parkingSpace);
        _context.SaveChanges();
    }
}