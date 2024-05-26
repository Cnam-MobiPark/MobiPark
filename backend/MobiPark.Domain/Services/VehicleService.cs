using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }
        
        public Vehicle CreateVehicle(string type, string maker, AbstractLicensePlate licensePlate)
        {
            return _repository.CreateVehicle(type, maker, licensePlate);
        }

        public List<Vehicle> GetVehicles()
        {
            return _repository.GetVehicles();
        }
    }
}