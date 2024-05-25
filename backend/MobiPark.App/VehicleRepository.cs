using System.Text.Json;
using System.Text.Json.Serialization;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.App;

public class VehicleRepository : IVehicleRepository
{
    public List<Vehicle> vehicles = new List<Vehicle>();
    
    public VehicleRepository()
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
        
        var vehicleData = JsonSerializer.Deserialize<List<Vehicle>>(json, options) ?? throw new InvalidOperationException("Invalid vehicle data in JSON file.");
        vehicles = vehicleData;
    }
    
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