using MobiPark.Domain.Factories;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;
using MobiPark.Domain.Services;
using MobiPark.Domain.Test.Repository;

namespace MobiPark.Domain.Test;

public class PricingTest
{
    private static readonly FrLicensePlate LicensePlate = new("AB-123-CD");
    private static Vehicle MakeThermalCar()
    {
        return VehicleFactory.CreateCar("Toyota", LicensePlate, new ThermalEngine());
    }

    private static Vehicle MakeMotorcycle()
    {
        return VehicleFactory.CreateMotorcycle("Yamaha", LicensePlate, new ThermalEngine());
    }
    
    private static Vehicle MakeElectricalCar( int currentBatteryCapacity = 100, int batteryCapacity = 100)
    {
        var electricalEngine = new ElectricalEngine(batteryCapacity, currentBatteryCapacity);
        return VehicleFactory.CreateCar("Tesla", LicensePlate, electricalEngine);
    }
    
    private static Reservation MakeReservation(Vehicle vehicle)
    {
        var parkingSpace = new ParkingSpace(1, VehicleSize.Medium);
        var startTime = new DateTime(2024, 5, 21, 8, 0, 0);
        var endTime = new DateTime(2024, 5, 21, 12, 0, 0);

        var fakeClock = new FakeClock(new DateTime(2024, 5, 21, 10, 0, 0));
        var reservation = new Reservation(fakeClock, vehicle, parkingSpace, startTime, endTime);
        return reservation;
    }
    
    [Fact]
    [Trait("Category", "Pricing Calculation")]
    public void CalculatePrice_Should_Return_Correct_Price_For_Car_Without_Charging()
    {
        // Arrange
        var car = MakeThermalCar();
        var reservation = MakeReservation(car);
        var priceCalculator = new PriceCalculator();

        // Act
        var price = priceCalculator.CalculatePrice(reservation);

        // Assert
        Assert.Equal(20, price);
    }

    [Fact]
    [Trait("Category", "Pricing Calculation")]
    public void CalculatePrice_Should_Return_Correct_Price_For_Motorcycle_Without_Charging()
    {
        // Arrange
        var motorcycle = MakeMotorcycle();
        var reservation = MakeReservation(motorcycle);
        var priceCalculator = new PriceCalculator();

        // Act
        var price = priceCalculator.CalculatePrice(reservation);

        // Assert
        Assert.Equal(6, price);
    }

    [Fact]
    [Trait("Category", "Pricing Calculation")]
    public void CalculatePrice_Should_Return_Correct_Price_For_Car_With_Charging()
    {
        // Arrange
        var electricalCar = MakeElectricalCar(50);
        var reservation = MakeReservation(electricalCar);
        var priceCalculator = new PriceCalculator();

        // Act
        var price = priceCalculator.CalculatePrice(reservation);

        // Assert
        Assert.Equal(28, price);
    }

    [Fact]
    [Trait("Category", "Pricing Calculation")]
    public void CalculatePrice_Should_Return_Correct_Price_For_ElectricalCar_ChargeWithAlreadyFullBattery()
    {
        // Arrange
        var electricalCar = MakeElectricalCar();
        var reservation = MakeReservation(electricalCar);
        var priceCalculator = new PriceCalculator();

        // Act
        var price = priceCalculator.CalculatePrice(reservation);

        // Assert
        Assert.Equal(28, price);
    }
}