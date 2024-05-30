using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Domain.Models.Vehicle;

public class Motorcycle : Vehicle
{
    public Motorcycle(string maker, AbstractLicensePlate licensePlate, Engine.Engine engine) : base(maker, licensePlate, engine)
    {
    }
}