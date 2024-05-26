using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }
        
        public Vehicle CreateVehicle(string type, string maker, AbstractLicensePlate licensePlate, Engine engine)
        {
            return _repository.CreateVehicle(type, maker, licensePlate, engine);
        }
        

        public List<Vehicle> GetVehicles()
        {
            return _repository.GetVehicles();
        }
    }
}