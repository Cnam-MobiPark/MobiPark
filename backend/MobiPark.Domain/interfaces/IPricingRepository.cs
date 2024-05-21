using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IPricingRepository
{
    Pricing GetPricing(string vehicleType);
}
