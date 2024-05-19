using MobiPark.Dom.Models;

namespace MobiPark.Dom.Services.Interfaces
{
    public interface IParkingService
    {
        List<ParkingSpace> GetSpaces();
    }
}