using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.Services;

public class PricingService : IPricingService
{
    
    private readonly IPricingRepository pricingRepository;
    
    public PricingService(IPricingRepository pricingRepository)
    {
        this.pricingRepository = pricingRepository;
    }
    
    public double CalculatePrice(Vehicle.VehicleType vehicleType, DateTime startTime, DateTime endTime, bool isElectricCharging)
    {
        return pricingRepository.CalculatePrice(vehicleType.ToString().ToLower(), startTime, endTime, isElectricCharging);
    }
}