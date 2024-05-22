using MobiPark.Domain.Models;
using MobiPark.Domain.Services;

namespace MobiPark.Domain.Test;

public class VehicleTest
{
    
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
        var type = Vehicle.VehicleType.Car;
        var maker = "Toyota";
        var licensePlate = "ABC123";
        
        // Act
        var vehicle = _vehicleService.CreateVehicle(type, maker, licensePlate);
        
        // Assert
        Assert.NotNull(vehicle);
        Assert.Equal(type, vehicle.Type);
        Assert.Equal(maker, vehicle.Maker);
        Assert.Equal(licensePlate, vehicle.LicensePlate);
    }
    
    
    [Fact]
    [Trait("Category", "Creating Vehicles")]
    public void GetVehicles_ReturnsVehicles()
    {
        // Arrange
        var vehicleService = new VehicleService();

        // Act
        var vehicles = vehicleService.GetVehicles();

        // Assert
        Assert.NotNull(vehicles);
        Assert.NotEmpty(vehicles);
    }
}