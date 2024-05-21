using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces
{
    public interface IParkingService
    {
        List<ParkingSpace> GetSpaces();
        List<ParkingSpace> GetAvailableSpaces();
        List<ParkingSpace> GetAvailableCarSpaces();
        List<ParkingSpace> GetAvailableMotorcycleSpaces();
        ParkingSpace ParkVehicle(Vehicle vehicle);
    }
}