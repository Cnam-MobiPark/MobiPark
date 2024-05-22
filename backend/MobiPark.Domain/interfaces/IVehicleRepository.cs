using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IVehicleRepository
{
    public Vehicle CreateVehicle(Vehicle.VehicleType type, string maker, string licensePlate);
    public List<Vehicle> GetVehicles();
}