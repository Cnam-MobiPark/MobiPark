using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Exceptions;

public class PricingNotFoundException : NotFoundException
{
    public PricingNotFoundException(string vehicleType) : base($"Pricing not found for vehicle type {vehicleType}") { }
}