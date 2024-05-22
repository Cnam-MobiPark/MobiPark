using System.Text.Json;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.App.Database.Repositories;

public class ParkingRepository : IParkingRepository
{
    public List<ParkingSpace> GetAvailableSpaces(Vehicle.VehicleType? vehicleType = null)
    {
        throw new NotImplementedException();
    }

    public void ParkVehicle(Vehicle vehicle, ParkingSpace space)
    {
        throw new NotImplementedException();
    }

    public void ParkVehicle(Vehicle vehicle, int spaceId)
    {
        throw new NotImplementedException();
    }
}