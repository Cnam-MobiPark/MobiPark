using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IPricingService
{
    double CalculatePrice(Vehicle.VehicleType vehicleType, DateTime startTime, DateTime endTime, bool isElectricCharging);
}
