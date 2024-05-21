using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Services;

namespace MobiPark.Domain.Test;

public class ParkingTest
{
    [Fact]
    public void ParkVehicle()
    {
        // Arrange
        var repository = new ParkingRepository();
        var service = new ParkingService(repository);

        // Act
        var space = service.ParkVehicle(1, 1);

        // Assert
        Assert.NotNull(space);
        Assert.Equal("occupied", space.Status);
        Assert.Equal(1, space.Vehicle.Id);
    }
}