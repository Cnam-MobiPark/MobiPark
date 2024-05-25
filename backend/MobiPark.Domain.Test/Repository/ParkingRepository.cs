using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Test.Repository;

public class ParkingRepository : IParkingRepository
{
    public readonly List<ParkingSpace> spaces = [];
    
    public List<ParkingSpace> GetSpaces()
    {
        return spaces;
    }
    
    public List<ParkingSpace> GetAvailableSpaces()
    {
        return spaces.Where(s => s.Status == "free").ToList();
    }
    public List<ParkingSpace> GetAvailableSpaces(Vehicle vehicle)
    {
        return spaces.Where(s => s.Status == "free" && Type.GetType(s.Type) == vehicle.GetType()).ToList();
    }

    public void ParkVehicle(Vehicle vehicle, ParkingSpace parkingSpace)
    {
        if (parkingSpace.Status != "free")
        {
            throw new InvalidOperationException($"Parking space {parkingSpace.Number} is already occupied.");
        }
        parkingSpace.Status = "occupied";
        parkingSpace.Vehicle = vehicle;
    }
}