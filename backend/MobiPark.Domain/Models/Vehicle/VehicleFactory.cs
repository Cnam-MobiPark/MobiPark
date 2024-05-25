using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Models.Vehicle;

public class VehicleFactory
{
    public Car CreateCar(string maker, string licensePlate)
    {
        return new Car
        {
            Maker = maker,
            LicensePlate = licensePlate
        };
    }
    
    public Motorcycle CreateMotorcycle(string maker, string licensePlate)
    {
        return new Motorcycle
        {
            Maker = maker,
            LicensePlate = licensePlate
        };
    }
}