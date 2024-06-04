using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces
{
    public interface IParkingService
    {
        Task<List<ParkingSpace>> GetSpaces();
        Task<List<ParkingSpace>> GetAvailableSpaces();
        Task<List<ParkingSpace>> GetAvailableSpacesFor(Vehicle vehicle);
        Task<ParkingSpace> ParkVehicle(string licensePlate);
    }
}