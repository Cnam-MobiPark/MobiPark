namespace MobiPark.Domain.Models.Vehicle;

public class Motorcycle : Vehicle
{
    public Motorcycle(string maker, AbstractLicensePlate licensePlate) : base(maker, licensePlate)
    {
    }
}