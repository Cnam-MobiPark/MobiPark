namespace MobiPark.Domain.Models.Vehicle;

public static class VehicleFactory
{
    public static Car CreateCar(string maker, string licensePlate)
    {
        return new Car
        {
            Maker = maker,
            LicensePlate = licensePlate
        };
    }
    
    public static Motorcycle CreateMotorcycle(string maker, string licensePlate)
    {
        return new Motorcycle
        {
            Maker = maker,
            LicensePlate = licensePlate
        };
    }
}