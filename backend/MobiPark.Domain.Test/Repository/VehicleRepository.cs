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
        var path = Path.Combine(AppContext.BaseDirectory, "vehicles.json");
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Could not find the file at {path}");
        }

        var json = File.ReadAllText(path);
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json, options) ??
                    throw new InvalidOperationException("Invalid vehicle data in JSON file.");
        return vehicles;
    }
}