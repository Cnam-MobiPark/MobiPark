using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces
{
    public interface IVehicleService
    {
        Vehicle CreateVehicle(string type, string maker, string licensePlate);
        List<Vehicle> GetVehicles();
    }
}