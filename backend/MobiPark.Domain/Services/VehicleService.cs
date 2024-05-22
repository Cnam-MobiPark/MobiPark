using MobiPark.Domain.Models;
using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }
        
        public Vehicle CreateVehicle(Vehicle.VehicleType type, string maker, string licensePlate)
        {
            return _repository.CreateVehicle(type, maker, licensePlate);
        }

        public List<Vehicle> GetVehicles()
        {
            return _repository.GetVehicles();
        }
    }
}