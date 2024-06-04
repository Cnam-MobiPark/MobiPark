using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces;

public interface IPricingRepository
{
    Pricing GetPricing(string vehicleType);
    void AddPricing(Pricing pricing);
    double CalculatePrice(Vehicle vehicle, DateTime startTime, DateTime endTime, bool isElectricCharging);
}