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
    public void CreatingALicensePlateWithNullValue_ShouldThrowException()
    {
        // Arrange
        var nullLicensePlate = (string)null;

        // Act
        Action act = () => new FrLicensePlate(nullLicensePlate);
        
        // Assert
        Assert.Throws<InvalidLicensePlateException>(act);
        
    }
    
    [Fact]
    [Trait("Category", "Creating Vehicles")]
    public void CreatingALicensePlateWithInvalidValue_ShouldThrowExceptionforFr()
    {
        // Arrange
        var maker = "Toyota";
        var invalidLicensePlate = "AB-123-CD-123";

        // Act
        Action act = () => new FrLicensePlate(invalidLicensePlate);

        // Assert
        var exception = Assert.Throws<InvalidLicensePlateException>(act);
    }
    
    [Fact]
    [Trait("Category", "Creating Vehicles")]
    public void CreatingALicensePlateWithGoodValue_ShouldWorkforFr()
    {
        // Arrange
        var maker = "Toyota";
        var licensePlate = "AB-123-CD";

        // Act
        Action act = () => new FrLicensePlate(licensePlate);

        // Assert
        Assert.NotNull(act);
    }
    
    [Fact]
    [Trait("Category", "Creating Vehicles")]
    public void CreatingALicensePlateWithInvalidValue_ShouldThrowExceptionforDe()
    {
        // Arrange
        var maker = "Toyota";
        var invalidLicensePlate = "AB-123-CD";
        
        // Act
        Action act = () => new DeLicensePlate(invalidLicensePlate);
        
        // Assert
        Assert.Throws<InvalidLicensePlateException>(act);
    }
    
    [Fact]
    [Trait("Category", "Creating Vehicles")]
    public void CreatingALicensePlateWithGoodValue_ShouldWorkforDe()
    {
        // Arrange
        var maker = "Toyota";
        var licensePlate = "A X 1234";

        // Act
        Action act = () => new DeLicensePlate(licensePlate);

        // Assert
        Assert.NotNull(act);
    }
}