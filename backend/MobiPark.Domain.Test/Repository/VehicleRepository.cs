using System.Text.Json;
using System.Text.Json.Serialization;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.Test.Repository;

public class VehicleRepository : IVehicleRepository
{
    public List<Vehicle> vehicles = new List<Vehicle>();
    
    public Vehicle CreateVehicle(Vehicle.VehicleType type, string maker, string licensePlate)
    {
        var vehicle = new Vehicle
        {
            Type = type,
            Maker = maker,
            LicensePlate = licensePlate
        };
        return vehicle;
    }

    public List<Vehicle> GetVehicles()
    {
        return new List<Vehicle>
        {
            new() { Id = 1, Type = Vehicle.VehicleType.Car, Maker = "Toyota", LicensePlate = "ABC123" },
            new() { Id = 2, Type = Vehicle.VehicleType.Motorcycle, Maker = "Honda", LicensePlate = "XYZ987" },
            new() { Id = 3, Type = Vehicle.VehicleType.Car, Maker = "Ford", LicensePlate = "DEF456" }
        };
    }
}