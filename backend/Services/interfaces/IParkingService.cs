using MobiPark.Models;

namespace MobiPark.Services.Interfaces
{

    public interface IParkingService
    {
        List<Space> GetSpaces();
    }
}