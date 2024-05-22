using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IParkingRepository
{
    List<ParkingSpace> GetAvailableSpaces(Vehicle.VehicleType? vehicleType = null);
    void ParkVehicle(Vehicle vehicle, ParkingSpace parkingSpace);
}