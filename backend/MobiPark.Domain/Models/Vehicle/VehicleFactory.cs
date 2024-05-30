using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Domain.Models.Vehicle;

public static class VehicleFactory
{
    public static Car CreateCar(string maker, AbstractLicensePlate licensePlate, Engine.Engine engine)
    {
        return new Car(maker, licensePlate, engine);
    }
    
    public static Motorcycle CreateMotorcycle(string maker, AbstractLicensePlate licensePlate, Engine.Engine engine)
    {
        return new Motorcycle(maker, licensePlate, engine);
    }
}