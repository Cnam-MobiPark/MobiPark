using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces;

public interface IVehicleRepository
{
    public Vehicle CreateVehicle(string type, string maker, AbstractLicensePlate licensePlate);
    public List<Vehicle> GetVehicles();
}