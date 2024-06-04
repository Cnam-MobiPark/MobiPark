using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces;

public interface IParkingRepository
{
    Task<Vehicle> GetVehicle(string licensePlate);
    Task<List<ParkingSpace>> GetSpaces();
    Task<List<ParkingSpace>> GetAvailableSpaces();
    Task<List<ParkingSpace>> GetAvailableSpaces(Vehicle vehicle);
    void ParkVehicle(Vehicle vehicle, ParkingSpace parkingSpace);
}