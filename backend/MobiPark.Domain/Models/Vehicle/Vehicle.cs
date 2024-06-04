using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle.Engine;
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

        public Reservation Park(IClock clock, ParkingSpace parkingPlace, DateTime beginDateTime, DateTime endDateTime)
        {
            if (parkingPlace.Status == ParkingSpaceStatus.Occupied)
            {
                throw new VehicleCannotParkException("Parking space is already occupied");
            }
            
            if (parkingPlace.Size < GetSize())
            {
                throw new VehicleCannotParkException("Parking space is too small");
            }
            
            if (parkingPlace.IsElectric && Engine is ThermalEngine)
            {
                throw new VehicleCannotParkException("Parking space is electric only");
            }
            return new Reservation(clock, this, parkingPlace, beginDateTime, endDateTime);
        }

        public abstract VehicleSize GetSize();
    }
}