using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces
{
    public interface IParkingService
    {
        List<ParkingSpace> GetSpaces();
        List<ParkingSpace> GetAvailableSpaces();
        List<ParkingSpace> GetAvailableSpaces(Vehicle.VehicleType vehicletype);
        ParkingSpace ParkVehicle(Vehicle vehicle);
    }
}