using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces
{
    public interface IParkingService
    {
        List<ParkingSpace> GetSpaces();
        List<ParkingSpace> GetAvailableSpaces();
        List<ParkingSpace> GetAvailableSpacesFor(Vehicle vehicle);
        ParkingSpace ParkVehicle(Vehicle vehicle);
    }
}