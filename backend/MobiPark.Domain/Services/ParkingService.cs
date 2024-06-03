using MobiPark.Domain.Models;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _repository;
        private readonly IVehicleRepository _vehicleRepository;

        public ParkingService(IParkingRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<List<ParkingSpace>> GetAvailableSpaces()
        {
            return await _repository.GetAvailableSpaces();
        }
        
        public async Task<List<ParkingSpace>> GetAvailableSpacesFor(Vehicle vehicle)
        {
            return await _repository.GetAvailableSpaces(vehicle);
        }

        public async Task<List<ParkingSpace>> GetSpaces()
        {
            return await _repository.GetSpaces();
        }

        public async Task<ParkingSpace> ParkVehicle(string licensePlate)
        {
            var vehicle = await _vehicleRepository.GetVehicle(licensePlate)
                ?? throw new InvalidOperationException("Vehicle not found.");
            var space = await _repository.GetAvailableSpaces(vehicle)
                ?? throw new InvalidOperationException("No available parking spaces.");

            var firstAvailableSpace = space.First();
            _repository.ParkVehicle(vehicle, firstAvailableSpace);

            return firstAvailableSpace;
        }
    }
}