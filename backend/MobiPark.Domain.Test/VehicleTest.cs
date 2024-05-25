using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Services;
using MobiPark.Domain.Test.Repository;

namespace MobiPark.Domain.Test;

public class VehicleTest
{
    
    private readonly VehicleService _vehicleService;
    private VehicleFactory _vehicleFactory;
    
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
        var licensePlate = "ABC123";
        
        // Act
        var vehicle = _vehicleFactory.CreateCar(maker, licensePlate);
        
        // Assert
        Assert.NotNull(vehicle);
        Assert.IsType<Car>(vehicle);
        Assert.Equal(maker, vehicle.Maker);
        Assert.Equal(licensePlate, vehicle.LicensePlate);
    }
    
    
    [Fact]
    [Trait("Category", "Creating Vehicles")]
    public void GetVehicles_ReturnsVehicles()
    {
        // Act
        var vehicles = _vehicleService.GetVehicles();

        // Assert
        Assert.NotNull(vehicles);
        Assert.NotEmpty(vehicles);
    }
}