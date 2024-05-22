using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.Test.Repository;

public class PricingRepository : IPricingRepository
{
    private readonly List<Pricing> _pricings = new List<Pricing>
    {
        new Pricing { Id = 1, VehicleType = Vehicle.VehicleType.Car, BaseRate = 5.0, WeekendRate = 2.0, NightRate = 1.0, ElectricChargingRate = 3.0, LateFee = 10.0 },
        new Pricing { Id = 2, VehicleType = Vehicle.VehicleType.Motorcycle, BaseRate = 2.5, WeekendRate = 1.0, NightRate = 0.5, ElectricChargingRate = 1.5, LateFee = 5.0 }
    };

    public Pricing GetPricing(string vehicleType)
    {
        return _pricings.FirstOrDefault(p => p.VehicleType.ToString().Equals(vehicleType));
    }
}