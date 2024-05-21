using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IParkingRepository
{
    List<ParkingSpace> GetSpaces();
    ParkingSpace ParkVehicle(int vehicleId, int spaceId);
}