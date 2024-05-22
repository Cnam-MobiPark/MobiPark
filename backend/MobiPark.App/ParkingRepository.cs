using System.Text.Json;
using System.Text.Json.Serialization;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.App;

public class ParkingRepository : IParkingRepository
{
    
    public readonly List<ParkingSpace> spaces = [];
    
    public ParkingRepository()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "parking.json");
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

        var parking = JsonSerializer.Deserialize<ParkingLot>(json, options) ?? throw new InvalidOperationException("Invalid vehicle data in JSON file.");
        spaces = parking.Spaces;
    }
    
    
    public List<ParkingSpace> GetSpaces()
    {
        return spaces;
    }
    public List<ParkingSpace> GetAvailableSpaces(Vehicle.VehicleType? vehicleType = null)
    {
        return spaces.Where(s => s.Status == "free" && (vehicleType == null || s.Type == vehicleType.ToString().ToLower())).ToList();
    }

    public void ParkVehicle(Vehicle vehicle, ParkingSpace space)
    {
        if (space.Status != "free")
        {
            throw new InvalidOperationException($"Parking space {space.Number} is already occupied.");
        }
        space.Status = "occupied";
        space.Vehicle = vehicle;
    }
}