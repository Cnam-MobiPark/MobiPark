using System.Text.Json;
using System.Text.Json.Serialization;
using MobiPark.Domain.Models;
using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly List<Vehicle> _vehicles;

        public VehicleService()
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

            _vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json, options) ?? throw new InvalidOperationException("Invalid vehicle data in JSON file.");
        }

        public List<Vehicle> GetVehicles()
        {
            return _vehicles;
        }
    }
}