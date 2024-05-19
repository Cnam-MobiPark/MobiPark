using System.Text.Json;
using MobiPark.Services.Interfaces;
using MobiPark.Models;

namespace MobiPark.Services
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

        public List<Space> GetSpaces()
        {
            return _parkingLot.Spaces;
        }
    }
}