using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces
{
    public interface IVehicleService
    {
        Vehicle CreateVehicle(Vehicle.VehicleType type, string maker, string licensePlate);
        List<Vehicle> GetVehicles();
    }
}