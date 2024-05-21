using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces
{
    public interface IParkingService
    {
        List<ParkingSpace> GetSpaces();
        ParkingSpace ParkVehicle(Vehicle vehicle, int spaceId);
    }
}