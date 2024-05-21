using System.Text.Json;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using Xunit.Sdk;

namespace MobiPark.Domain.Test;

public class ParkingRepository : IParkingRepository
{
    public readonly List<ParkingSpace> spaces = [];

    public List<ParkingSpace> GetAvailableSpaces(Vehicle.VehicleType? vehicleType = null)
    {
        return spaces.Where(s => s.Status == "free" && (vehicleType == null || s.Type == vehicleType.ToString().ToLower())).ToList();
    }

    public void ParkVehicle(Vehicle vehicle, int spaceId)
    {
        var space = spaces.Find(space => space.Number == spaceId)
            ?? throw new NullReferenceException($"No parking space with number {spaceId} exists");

        if (space.Status != "free")
        {
            throw new InvalidOperationException($"Parking space {space.Number} is already occupied.");
        }
        space.Status = "occupied";
        space.Vehicle = vehicle;
    }
}