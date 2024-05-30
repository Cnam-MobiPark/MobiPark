using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Domain.Test.Repository;

public class VehicleRepository : IVehicleRepository
{
    public List<Vehicle> vehicles = new List<Vehicle>();
    
    public Vehicle CreateVehicle(string type, string maker, AbstractLicensePlate licensePlate, Engine engine)
    {
        switch (type)
        {
            case "Car":
                return new Car(maker, licensePlate, engine);
            case "Motorcycle":
                return new Motorcycle(maker, licensePlate, engine);
            default:
                throw new InvalidOperationException("Invalid vehicle type");
        }
    }

    public List<Vehicle> GetVehicles()
    {
        return vehicles;
    }
}