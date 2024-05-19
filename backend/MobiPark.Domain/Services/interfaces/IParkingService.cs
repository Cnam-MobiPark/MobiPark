using MobiPark.Domain.Models;

namespace MobiPark.Domain.Services.Interfaces
{
    public interface IParkingService
    {
        List<ParkingSpace> GetSpaces();
    }
}