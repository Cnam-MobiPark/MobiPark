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
        

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _repository.GetVehicles();
        }
    }
}