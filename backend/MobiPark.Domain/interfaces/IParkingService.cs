using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces
{
    public interface IParkingService
    {
        List<ParkingSpace> GetSpaces();
        List<ParkingSpace> GetAvailableSpaces();
        ParkingSpace ParkVehicle(Vehicle vehicle, int spaceId);
    }
}