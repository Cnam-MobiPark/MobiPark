using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces
{
    public interface IVehicleService
    {
        List<Vehicle> GetVehicles();
    }
}