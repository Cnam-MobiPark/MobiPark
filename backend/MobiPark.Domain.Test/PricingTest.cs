using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Services;
using MobiPark.Domain.Test.Repository;

namespace MobiPark.Domain.Test;

public class PricingTest
{
    private readonly IPricingService _pricingService;
    private readonly IPricingRepository _pricingRepository;
    private readonly VehicleFactory _vehicleFactory;

    public PricingTest()
    {
        _vehicleFactory = new VehicleFactory();
        _pricingRepository = new PricingRepository();
        _pricingService = new PricingService(_pricingRepository);
    }

    [Fact]
    [Trait("Category", "Pricing Calculation")]
    public void CalculatePrice_Should_Return_Correct_Price_For_Car_Without_Charging()
    {
        // Arrange
        var car = _vehicleFactory.CreateCar("Toyota", "ABC-1234");
        var startTime = new DateTime(2024, 5, 21, 8, 0, 0);
        var endTime = new DateTime(2024, 5, 21, 12, 0, 0);
        var isElectricCharging = false;

        // Act
        var price = _pricingService.CalculatePrice(car, startTime, endTime, isElectricCharging);

        // Assert
        Assert.Equal(20, price);
    }

    [Fact]
    [Trait("Category", "Pricing Calculation")]
    public void CalculatePrice_Should_Return_Correct_Price_For_Motorcycle_Without_Charging()
    {
        // Arrange
        var motorcycle = _vehicleFactory.CreateMotorcycle("Toyota", "ABC-1234");
        var startTime = new DateTime(2024, 5, 21, 8, 0, 0);
        var endTime = new DateTime(2024, 5, 21, 10, 0, 0);
        var isElectricCharging = false;

        // Act
        var price = _pricingService.CalculatePrice(motorcycle, startTime, endTime, isElectricCharging);

        // Assert
        Assert.Equal(6, price);
    }

    [Fact]
    [Trait("Category", "Pricing Calculation")]
    public void CalculatePrice_Should_Return_Correct_Price_For_Car_With_Charging()
    {
        // Arrange
        var car = _vehicleFactory.CreateCar("Toyota", "ABC-1234");
        var startTime = new DateTime(2024, 5, 21, 8, 0, 0);
        var endTime = new DateTime(2024, 5, 21, 12, 0, 0);
        var isElectricCharging = true;

        // Act
        var price = _pricingService.CalculatePrice(car, startTime, endTime, isElectricCharging);

        // Assert
        Assert.Equal(28, price);
    }
}