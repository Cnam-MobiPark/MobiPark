namespace MobiPark.Domain.Models.Vehicle;

public static class VehicleFactory
{
    public static Car CreateCar(string maker, AbstractLicensePlate licensePlate)
    {
        return new Car(maker, licensePlate);
    }
    
    public static Motorcycle CreateMotorcycle(string maker, AbstractLicensePlate licensePlate)
    {
        return new Motorcycle(maker, licensePlate);
    }
}