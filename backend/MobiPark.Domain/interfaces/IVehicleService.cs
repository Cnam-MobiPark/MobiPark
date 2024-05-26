using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Domain.Interfaces
{
    public interface IVehicleService
    {
        Vehicle CreateVehicle(string type, string maker, AbstractLicensePlate licensePlate, Engine engine);
        List<Vehicle> GetVehicles();
    }
}