using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Services;
using MobiPark.Domain.Test.Repository;

namespace MobiPark.Domain.Test;

public class VehicleTest
{

    private readonly VehicleService _vehicleService;

    public VehicleTest()
    {
        var vehicleRepository = new VehicleRepository();
        _vehicleService = new VehicleService(vehicleRepository);
    }

    [Fact]
    [Trait("Category", "Creating Vehicles")]
    public void CreateVehicle_ShouldCreateVehicle()
    {
        // Arrange
        var maker = "Toyota";
        var licensePlate = new FrLicensePlate("AB-123-CD");

        // Act
        var vehicle = VehicleFactory.CreateCar(maker, licensePlate);

        // Assert
        Assert.NotNull(vehicle);
        Assert.IsType<Car>(vehicle);
        Assert.Equal(maker, vehicle.Maker);
        Assert.Equal(licensePlate, vehicle.LicensePlate);
    }
    
    [Fact]
    [Trait("Category", "Creating Vehicles")]
    public void CreateVehicle_ShouldThrowException_WhenLicensePlateIsNull()
    {
        // Arrange
        var maker = "Toyota";

        // Act
        Action act = () => VehicleFactory.CreateCar(maker, new FrLicensePlate("null"));

        // Assert
        var exception = Assert.Throws<InvalidLicensePlateException>(act);
        Assert.Equal("Invalid license plate: null", exception.Message);
        
    }
    
    [Fact]
    [Trait("Category", "Creating Vehicles")]
    public void CreateVehicle_ShouldThrowException_WhenLicensePlateIsInvalidforFr()
    {
        // Arrange
        var maker = "Toyota";
        var invalidLicensePlate = "AB-123-CD-123";

        // Act
        Action act = () => VehicleFactory.CreateCar(maker, new FrLicensePlate(invalidLicensePlate));

        // Assert
        var exception = Assert.Throws<InvalidLicensePlateException>(act);
        Assert.Equal("Invalid license plate: " + invalidLicensePlate, exception.Message);
    }
    
    [Fact]
    [Trait("Category", "Creating Vehicles")]
    public void CreateVehicle_ShouldWork_WhenLicensePlateIsValidforFr()
    {
        // Arrange
        var maker = "Toyota";
        var licensePlate = new FrLicensePlate("AB-123-CD");

        // Act
        var vehicle = VehicleFactory.CreateCar(maker, licensePlate);

        // Assert
        Assert.NotNull(vehicle);
        Assert.IsType<Car>(vehicle);
        Assert.Equal(maker, vehicle.Maker);
        Assert.Equal(licensePlate, vehicle.LicensePlate);
    }
    
    [Fact]
    [Trait("Category", "Creating Vehicles")]
    public void CreateVehicle_ShouldThrowException_WhenLicensePlateIsInvalidforDe()
    {
        // Arrange
        var maker = "Toyota";
        var invalidLicensePlate = "AB-123-CD";
        
        // Act
        Action act = () => VehicleFactory.CreateCar(maker, new DeLicensePlate(invalidLicensePlate));
        
        // Assert
        var exception = Assert.Throws<InvalidLicensePlateException>(act);
        Assert.Equal("Invalid license plate: " + invalidLicensePlate, exception.Message);
    }
    
    [Fact]
    [Trait("Category", "Creating Vehicles")]
    public void CreateVehicle_ShouldWork_WhenLicensePlateIsValidforDe()
    {
        // Arrange
        var maker = "Toyota";
        var licensePlate = new DeLicensePlate("A X 1234");

        // Act
        var vehicle = VehicleFactory.CreateCar(maker, licensePlate);

        // Assert
        Assert.NotNull(vehicle);
        Assert.IsType<Car>(vehicle);
        Assert.Equal(maker, vehicle.Maker);
        Assert.Equal(licensePlate, vehicle.LicensePlate);
    }
}