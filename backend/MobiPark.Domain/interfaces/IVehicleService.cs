using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Domain.Interfaces
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetVehicles();
        Task<Vehicle> CreateVehicle(string type, string maker, AbstractLicensePlate licensePlate, Engine engine);
        Task<Vehicle> GetVehicle(string licensePlate);
    }
}