using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.App;

public class ParkingRepository : IParkingRepository
{
    public List<ParkingSpace> GetSpaces()
    {
        return new List<ParkingSpace>
        {
            new ParkingSpace { Number = 1, Type = "car", Status = "free" },
            new ParkingSpace { Number = 2, Type = "car", Status = "free" },
            new ParkingSpace { Number = 3, Type = "car", Status = "free" },
            new ParkingSpace { Number = 4, Type = "car", Status = "free" },
            new ParkingSpace { Number = 5, Type = "car", Status = "free" }
        };
    }
    
    public List<ParkingSpace> GetAvailableSpaces()
    {
        return GetSpaces().Where(s => s.Status == "free").ToList();
    }
    
    public List<ParkingSpace> GetAvailableSpaces(Vehicle.VehicleType vehicletype)
    {
        return GetSpaces().Where(s => s.Status == "free" && s.Type == vehicletype.ToString().ToLower()).ToList();
    }

    public ParkingSpace ParkVehicle(Vehicle vehicle)
    {
        var space = GetSpaces().FirstOrDefault();
        if (space == null)
        {
            throw new InvalidOperationException($"Could not find a parking space with ID {space.Number}");
        }

        if (space.Status != "free")
        {
            throw new InvalidOperationException($"Parking space {space.Number} is already occupied.");
        }
        space.Status = "occupied";
        space.Vehicle = vehicle;
        return space;
    }
}