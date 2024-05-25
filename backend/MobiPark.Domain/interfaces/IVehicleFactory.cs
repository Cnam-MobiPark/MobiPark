using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces;

public interface IVehicleFactory
{
    Car CreateCar(string maker, string licensePlate);
    Motorcycle CreateMotorcycle(string maker, string licensePlate);
}