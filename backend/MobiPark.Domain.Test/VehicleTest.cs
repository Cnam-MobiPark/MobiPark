using MobiPark.Domain.Services;

namespace MobiPark.Domain.Test;

public class VehicleTest
{
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