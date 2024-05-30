using System.Text.Json;
using System.Text.Json.Serialization;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;

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
    
    public Vehicle CreateVehicle(string type, string maker, AbstractLicensePlate licensePlate, Engine engine)
    {
        switch (type)
        {
            case "Car":
                return VehicleFactory.CreateCar(maker, licensePlate, engine);
            case "Motorcycle":
                return VehicleFactory.CreateMotorcycle(maker, licensePlate, engine);
            default:
                throw new InvalidOperationException("Invalid vehicle type");
        }
    }

    public List<Vehicle> GetVehicles()
    {
        return vehicles;
    }
}