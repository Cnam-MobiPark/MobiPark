using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Services;

namespace MobiPark.Domain.Test;

public class ParkingTest
{
    [Fact]
    [Trait("Category", "Parking Vehicles")]
    public void ParkVehicle_Should_Park_A_Car()
    {
        // Arrange
        var repository = new ParkingRepository();
        var service = new ParkingService(repository);
        var vehicle = new Vehicle { Id = 1, Type = Vehicle.VehicleType.Car, Maker = "Toyota", LicensePlate = "ABC-1234" };

        // Act
        var space = service.ParkVehicle(vehicle);

        // Assert
        Assert.NotNull(space);
        Assert.NotNull(space.Vehicle);
        Assert.Equal("occupied", space.Status);
        Assert.Equal(space.Vehicle.Type.ToString().ToLower(), space.Type);
        Assert.Equal(1, space.Number);
    }
    
    [Fact]
    [Trait("Category", "Parking Vehicles")]
    public void ParkVehicle_Should_Park_A_Motorcycle()
    {
        // Arrange
        var repository = new ParkingRepository();
        var service = new ParkingService(repository);
        var vehicle = new Vehicle { Id = 1, Type = Vehicle.VehicleType.Motorcycle, Maker = "Honda", LicensePlate = "XYZ-987" };

        // Act
        var space = service.ParkVehicle(vehicle);

        // Assert
        Assert.NotNull(space);
        Assert.NotNull(space.Vehicle);
        Assert.Equal("occupied", space.Status);
        Assert.Equal(space.Vehicle.Type.ToString().ToLower(), space.Type);
        Assert.Equal(3, space.Number);
    }
    
    [Fact]
    [Trait("Category", "Parking Vehicles")]
    public void ParkVehicle_Should_Throw_Exception_When_No_Space_Available()
    {
        // Arrange
        var repository = new ParkingRepository();
        var service = new ParkingService(repository);
        var vehicle = new Vehicle { Id = 1, Type = Vehicle.VehicleType.Car, Maker = "Toyota", LicensePlate = "ABC-1234" };
        
        foreach (var space in service.GetAvailableSpaces(vehicle.Type))
        {
            service.ParkVehicle(new Vehicle { Id = space.Number, Type = vehicle.Type, Maker = "TestMaker", LicensePlate = "TEST" + space.Number });
        }

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => service.ParkVehicle(vehicle));
        Assert.Equal("No available parking spaces.", exception.Message);
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
    
    [Fact]
    [Trait("Category", "Parking Spaces")]
    public void GetAvailableSpaces_Should_Return_Available_Spaces_Only_For_Cars()
    {
        // Arrange
        var repository = new ParkingRepository();
        var service = new ParkingService(repository);

        // Act
        var spaces = service.GetAvailableSpaces(Vehicle.VehicleType.Car);

        // Assert
        Assert.NotNull(spaces);
        Assert.NotEmpty(spaces);
        Assert.All(spaces, s => Assert.Equal("car", s.Type));
    }
    
    [Fact]
    [Trait("Category", "Parking Spaces")]
    public void GetAvailableSpaces_Should_Return_Available_Spaces_Only_For_Motorcycles()
    {
        // Arrange
        var repository = new ParkingRepository();
        var service = new ParkingService(repository);

        // Act
        var spaces = service.GetAvailableSpaces(Vehicle.VehicleType.Motorcycle);

        // Assert
        Assert.NotNull(spaces);
        Assert.NotEmpty(spaces);
        Assert.All(spaces, s => Assert.Equal("motorcycle", s.Type));
    }
    
}