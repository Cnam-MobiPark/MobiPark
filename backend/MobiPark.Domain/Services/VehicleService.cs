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
        
        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _repository.GetVehicles();
        }
        
        public async Task<Vehicle> GetVehicle(string licensePlate)
        {
            return await _repository.GetVehicle(licensePlate);
        }
        
        public async Task<Vehicle> CreateVehicle(string type, string maker, AbstractLicensePlate licensePlate, Engine engine)
        {
            return await _repository.CreateVehicle(type, maker, licensePlate, engine);
        }
    }
}