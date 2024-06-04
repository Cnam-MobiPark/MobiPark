using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Domain.Models.Vehicle;

public class Car : Vehicle
{
    public Car(string maker, AbstractLicensePlate licensePlate, Engine.Engine engine) : base(maker, licensePlate,
        engine)
    {
    }

    public override VehicleSize GetSize()
    {
        return VehicleSize.Medium;
    }
}