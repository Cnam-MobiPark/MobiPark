using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Domain.Factories;

public class VehicleFactory
{
    public static Car CreateCar(string maker, AbstractLicensePlate licensePlate, Engine engine)
    {
        return new Car(maker, licensePlate, engine);
    }
    
    public static Motorcycle CreateMotorcycle(string maker, AbstractLicensePlate licensePlate, Engine engine)
    {
        return new Motorcycle(maker, licensePlate, engine);
    }
}