using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Services;

namespace MobiPark.Domain.Test;

public class PricingTest
{
    private readonly IPricingService _pricingService;

    public PricingTest()
    {
        _pricingService = new PricingService();
    }

    [Fact]
    [Trait("Category", "Pricing Calculation")]
    public void CalculatePrice_Should_Return_Correct_Price_For_Car_Without_Charging()
    {
        // Arrange
        var vehicleType = Vehicle.VehicleType.Car;
        var startTime = new DateTime(2024, 5, 21, 8, 0, 0);
        var endTime = new DateTime(2024, 5, 21, 12, 0, 0);
        var isElectricCharging = false;

        // Act
        var price = _pricingService.CalculatePrice(vehicleType, startTime, endTime, isElectricCharging);

        // Assert
        Assert.Equal(20, price);
    }

    [Fact]
    [Trait("Category", "Pricing Calculation")]
    public void CalculatePrice_Should_Return_Correct_Price_For_Motorcycle_Without_Charging()
    {
        // Arrange
        var vehicleType = Vehicle.VehicleType.Motorcycle;
        var startTime = new DateTime(2024, 5, 21, 8, 0, 0);
        var endTime = new DateTime(2024, 5, 21, 10, 0, 0);
        var isElectricCharging = false;

        // Act
        var price = _pricingService.CalculatePrice(vehicleType, startTime, endTime, isElectricCharging);

        // Assert
        Assert.Equal(6, price);
    }

    [Fact]
    [Trait("Category", "Pricing Calculation")]
    public void CalculatePrice_Should_Return_Correct_Price_For_Car_With_Charging()
    {
        // Arrange
        var vehicleType = Vehicle.VehicleType.Car;
        var startTime = new DateTime(2024, 5, 21, 8, 0, 0);
        var endTime = new DateTime(2024, 5, 21, 12, 0, 0);
        var isElectricCharging = true;

        // Act
        var price = _pricingService.CalculatePrice(vehicleType, startTime, endTime, isElectricCharging);

        // Assert
        Assert.Equal(28, price);
    }
}