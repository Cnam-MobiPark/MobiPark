using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Services;

public class PricingService : IPricingService
{
    
    private readonly IPricingRepository pricingRepository;
    
    public PricingService(IPricingRepository pricingRepository)
    {
        this.pricingRepository = pricingRepository;
    }
    
    public double CalculatePrice(Vehicle vehicle, DateTime startTime, DateTime endTime, bool isElectricCharging)
    {
        return pricingRepository.CalculatePrice(vehicle, startTime, endTime, isElectricCharging);
    }
}