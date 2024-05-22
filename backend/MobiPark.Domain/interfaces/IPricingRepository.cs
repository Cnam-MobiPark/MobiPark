using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IPricingRepository
{
    Pricing GetPricing(string vehicleType);
    void AddPricing(Pricing pricing);
    double CalculatePrice(string vehicleType, DateTime startTime, DateTime endTime, bool isElectricCharging);
}
