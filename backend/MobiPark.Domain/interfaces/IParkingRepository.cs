using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces;

public interface IParkingRepository
{
    List<ParkingSpace> GetSpaces();
    List<ParkingSpace> GetAvailableSpaces();
    List<ParkingSpace> GetAvailableSpaces(Vehicle vehicle);
    void ParkVehicle(Vehicle vehicle, ParkingSpace parkingSpace);
}