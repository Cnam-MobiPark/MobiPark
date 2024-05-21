using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Services;

namespace MobiPark.Domain.Test;

public class ParkingTest
{
    [Fact]
    [Trait("Category", "Parking Vehicles")]
    public void ParkVehicle_Should_Park_A_Vehicle()
    {
        // Arrange
        var repository = new ParkingRepository();
        var service = new ParkingService(repository);
        var vehicle = new Vehicle { Id = 1, Type = Vehicle.VehicleType.Car, Maker = "Toyota", LicensePlate = "ABC-1234" };
            
        // Act
        var space = service.ParkVehicle(vehicle, 1);

        // Assert
        Assert.NotNull(space);
        Assert.NotNull(space.Vehicle);
        Assert.Equal("occupied", space.Status);
        Assert.Equal(1, space.Vehicle.Id);
    }

    [Fact]
    [Trait("Category", "Parking Spaces")]

    public void GetAvailableSpaces_Should_Return_Available_Spaces()
    {
        // Arrange
        var repository = new ParkingRepository();
        var service = new ParkingService(repository);

        // Act
        var spaces = service.GetAvailableSpaces();

        // Assert
        Assert.NotNull(spaces);
        Assert.NotEmpty(spaces);
        Assert.All(spaces, s => Assert.Equal("free", s.Status));
    }
}