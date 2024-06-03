using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Domain.Models.Vehicle
{
    public abstract class Vehicle
    {
        public string Maker { get; set; }
        public AbstractLicensePlate LicensePlate { get; init; }
        public Engine.Engine Engine { get; set; }

        protected Vehicle(string maker, AbstractLicensePlate licensePlate, Engine.Engine engine)  
        {
            Maker = maker;
            LicensePlate = licensePlate;
            Engine = engine;
        }
        
        public Reservation Park(ParkingSpace parkingPlace, DateTime beginDateTime, DateTime endDateTime)
        {
            return null;
        }

        public abstract VehicleSize GetSize();
    }
}