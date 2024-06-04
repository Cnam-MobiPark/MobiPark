using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces;

public interface IPricingService
{
    double CalculatePrice(Vehicle vehicle, DateTime startTime, DateTime endTime, bool isElectricCharging);
}