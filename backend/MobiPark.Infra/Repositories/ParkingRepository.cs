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

    public async Task<Vehicle> GetVehicle(string licensePlate)
    {
        var vehicleEntity = await _context.Vehicles
            .FirstOrDefaultAsync(v => v.Plate == licensePlate);
        return vehicleEntity.ToDomainModel();
    }

    public async Task<List<ParkingSpace>> GetSpaces()
    {
        return await _context.ParkingSpaces.ToListAsync();
    }

    public async Task<List<ParkingSpace>> GetAvailableSpaces()
    {
        return await _context.ParkingSpaces
            .Where(p => p.Status == ParkingSpaceStatus.Available)
            .ToListAsync();
    }

    public async Task<List<ParkingSpace>> GetAvailableSpaces(Vehicle vehicle)
    {
        return await _context.ParkingSpaces
            .Where(p => p.Status == ParkingSpaceStatus.Available && p.Size == vehicle.GetSize())
            .ToListAsync();
    }

    public void ParkVehicle(Vehicle vehicle, ParkingSpace parkingSpace)
    {
        parkingSpace.Status = ParkingSpaceStatus.Occupied;
        _context.ParkingSpaces.Update(parkingSpace);
        _context.SaveChanges();
    }
}