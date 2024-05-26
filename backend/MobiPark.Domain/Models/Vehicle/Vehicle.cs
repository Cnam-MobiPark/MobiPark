namespace MobiPark.Domain.Models.Vehicle
{
    public abstract class Vehicle
    {
        public string Maker { get; set; }
        public AbstractLicensePlate LicensePlate { get; init; }

        protected Vehicle(string maker, AbstractLicensePlate licensePlate)  
        {
            Maker = maker;
            LicensePlate = licensePlate;
        }
    }
}