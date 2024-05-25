using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces;

public interface IVehicleRepository
{
    public Vehicle CreateVehicle(string type, string maker, string licensePlate);
    public List<Vehicle> GetVehicles();
}