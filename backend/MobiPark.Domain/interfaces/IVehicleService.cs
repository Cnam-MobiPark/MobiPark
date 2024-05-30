using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces
{
    public interface IVehicleService
    {
        List<Vehicle> GetVehicles();
    }
}