using MobiPark.Domain.Models;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _repository;

        public ParkingService(IParkingRepository repository)
        {
            _repository = repository;
        }
        
        public List<ParkingSpace> GetAvailableSpaces()
        {
            return _repository.GetAvailableSpaces();
        }
        
        public List<ParkingSpace> GetAvailableSpacesFor(Vehicle vehicle)
        {
            return _repository.GetAvailableSpaces(vehicle);
        }

        public List<ParkingSpace> GetSpaces()
        {
            return _repository.GetSpaces();
        }

        public ParkingSpace ParkVehicle(Vehicle vehicle)
        {
            var space = _repository.GetAvailableSpaces(vehicle).FirstOrDefault()
                ?? throw new InvalidOperationException("No available parking spaces.");

            _repository.ParkVehicle(vehicle, space);

            return space;
        }
    }
}