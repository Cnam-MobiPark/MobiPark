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
        
        public List<ParkingSpace> GetAvailableSpaces()
        {
            return _parkingLot.Spaces.Where(s => s.Status == "free").ToList();
        }
        
        public List<ParkingSpace> GetAvailableSpaces(Vehicle.VehicleType vehicletype)
        {
            return _parkingLot.Spaces.Where(s => s.Status == "free" && s.Type.Equals(vehicletype.ToString(), StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
        
        public ParkingSpace ParkVehicle(Vehicle vehicle)
        {
            var space = GetAvailableSpaces(vehicle.Type).FirstOrDefault();
            if (space == null)
            {
                throw new InvalidOperationException($"Could not find a parking space with ID {space.Number}");
            }

            if (space.Status != "free")
            {
                throw new InvalidOperationException($"Parking space {space.Number} is already occupied.");
            }
            space.Status = "occupied";
            space.Vehicle = vehicle;
            return space;
        }
    }
}