using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.Services;

public class PricingService : IPricingService
{
    public double CalculatePrice(Vehicle.VehicleType vehicleType, DateTime startTime, DateTime endTime, bool isElectricCharging)
    {
        var price = vehicleType switch
        {
            Vehicle.VehicleType.Car => 5,
            Vehicle.VehicleType.Motorcycle => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(vehicleType), vehicleType, null)
        };

        if (isElectricCharging)
        {
            price += 2;
        }

        var duration = endTime - startTime;
        var hours = (int)Math.Ceiling(duration.TotalHours);
        price *= hours;
        return price;
    }
}