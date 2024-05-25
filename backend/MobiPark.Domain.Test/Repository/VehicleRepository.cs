using System.Text.Json;
using System.Text.Json.Serialization;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Test.Repository;

public class VehicleRepository : IVehicleRepository
{
    public List<Vehicle> vehicles = new List<Vehicle>();
    
    public Vehicle CreateVehicle(string type, string maker, string licensePlate)
    {
        switch (type)
        {
            case "Car":
                return VehicleFactory.CreateCar(maker, licensePlate);
            case "Motorcycle":
                return VehicleFactory.CreateMotorcycle(maker, licensePlate);
            default:
                throw new InvalidOperationException("Invalid vehicle type");
        }
    }

    public List<Vehicle> GetVehicles()
    {
        return vehicles;
    }
}