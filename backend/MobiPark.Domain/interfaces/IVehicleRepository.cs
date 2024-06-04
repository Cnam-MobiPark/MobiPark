using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Domain.Interfaces;

public interface IVehicleRepository
{
    public Vehicle Save(Vehicle vehicle);
    public Vehicle CreateVehicle(string type, string maker, AbstractLicensePlate licensePlate, Engine engine);
    public List<Vehicle> GetVehicles();
    public Vehicle? FindByPlate(string licensePlate);
}