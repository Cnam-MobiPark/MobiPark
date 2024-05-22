using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.Test;

public class ParkingRepository : IParkingRepository
{
    public readonly List<ParkingSpace> spaces = [];
    
    public List<ParkingSpace> GetSpaces()
    {
        return spaces;
    }
    public List<ParkingSpace> GetAvailableSpaces(Vehicle.VehicleType? vehicleType = null)
    {
        return spaces.Where(s => s.Status == "free" && (vehicleType == null || s.Type == vehicleType.ToString().ToLower())).ToList();
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