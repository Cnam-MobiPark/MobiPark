using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Test.Repository;

public class FakeParkingRepository : IParkingRepository
{
    public readonly List<ParkingSpace> spaces = [];

    public Task<Vehicle> GetVehicle(string licensePlate)
    {
        throw new NotImplementedException();
    }

    Task<List<ParkingSpace>> IParkingRepository.GetSpaces()
    {
        throw new NotImplementedException();
    }

    public Task<List<ParkingSpace>> GetAvailableSpaces()
    {
        return Task.FromResult(spaces.Where(s => s.Status == ParkingSpaceStatus.Available).ToList());
    }

    public Task<List<ParkingSpace>> GetAvailableSpaces(Vehicle vehicle)
    {
        return Task.FromResult(spaces
            .Where(s => s.Status == ParkingSpaceStatus.Available && s.Size == vehicle.GetSize()).ToList());
    }

    public void ParkVehicle(Vehicle vehicle, ParkingSpace parkingSpace)
    {
        if (parkingSpace.Status != ParkingSpaceStatus.Available)
            throw new InvalidOperationException($"Parking space {parkingSpace.Number} is already occupied.");
        parkingSpace.Status = ParkingSpaceStatus.Occupied;
    }

    public List<ParkingSpace> GetSpaces()
    {
        return spaces;
    }
}