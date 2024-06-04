namespace MobiPark.Domain.Exceptions;

public class PricingNotFoundException(string vehicleType)
    : NotFoundException($"Pricing not found for vehicle type {vehicleType}");