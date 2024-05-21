using System.Text.Json;
using MobiPark.Domain.Models;
using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Services
{
    public class ParkingService : IParkingService
    {
        private readonly ParkingLot _parkingLot;

        public ParkingService(IParkingRepository repository)
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
        
        public ParkingSpace ParkVehicle(int vehicleId, int spaceId)
        {
            var space = _parkingLot.Spaces.FirstOrDefault(s => s.Number == spaceId);
            if (space == null)
            {
                throw new InvalidOperationException($"Could not find a parking space with ID {spaceId}");
            }

            if (space.Status != "free")
            {
                throw new InvalidOperationException($"Parking space {spaceId} is already occupied.");
            }

            space.Vehicle = new Vehicle { Id = vehicleId };
            return space;
        }
    }
}