namespace MobiPark.Domain.Models.Vehicle
{
    public class Car : Vehicle
    {
        public Car(string maker, AbstractLicensePlate licensePlate) : base(maker, licensePlate)
        {
        }
    }
}