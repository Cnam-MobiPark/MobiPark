using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.Test;

public class ParkingRepository : IParkingRepository
{
    public List<ParkingSpace> GetSpaces()
    {
        return new List<ParkingSpace>
        {
            new ParkingSpace { Number = 1, Type = "car", Status = "free" },
            new ParkingSpace { Number = 2, Type = "car", Status = "free" },
            new ParkingSpace { Number = 3, Type = "car", Status = "free" }
        };
    }

    public ParkingSpace ParkVehicle(int vehicleId, int spaceId)
    {
        var space = GetSpaces().FirstOrDefault(s => s.Number == spaceId);
        space.Status = "occupied";
        space.Vehicle = new Vehicle { Id = vehicleId };
        return space;
    }
}