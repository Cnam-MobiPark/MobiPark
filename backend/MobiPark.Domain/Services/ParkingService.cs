using System.Text.Json;
using MobiPark.Domain.Models;
using MobiPark.Domain.Services.Interfaces;

namespace MobiPark.Domain.Services
{
    public class ParkingService : IParkingService
    {
        private readonly ParkingLot _parkingLot;

        public ParkingService()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "parking.json");
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Could not find the file at {path}");
            }

            var json = File.ReadAllText(path);
            _parkingLot = JsonSerializer.Deserialize<ParkingLot>(json) ?? throw new InvalidOperationException("Invalid parking data in JSON file.");
        }

        public List<ParkingSpace> GetSpaces()
        {
            return _parkingLot.Spaces;
        }
    }
}