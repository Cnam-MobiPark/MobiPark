using System.Text.Json;
using MobiPark.Domain.Models;
using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _repository;

        public ParkingService(IParkingRepository repository)
        {
            _repository = repository;
        }

        public List<ParkingSpace> GetAvailableCarSpaces()
        {
            return _repository.GetAvailableSpaces(Vehicle.VehicleType.Car);
        }

        public List<ParkingSpace> GetAvailableMotorcycleSpaces()
        {
            return _repository.GetAvailableSpaces(Vehicle.VehicleType.Motorcycle);
        }

        public List<ParkingSpace> GetAvailableSpaces()
        {
            return _repository.GetAvailableSpaces();
        }

        public List<ParkingSpace> GetSpaces()
        {
            throw new NotImplementedException();
        }

        public ParkingSpace ParkVehicle(Vehicle vehicle)
        {
            var space = _repository.GetAvailableSpaces(vehicle.Type).FirstOrDefault()
                ?? throw new InvalidOperationException("No available parking spaces.");

            _repository.ParkVehicle(vehicle, space);

            return space;
        }
    }
}