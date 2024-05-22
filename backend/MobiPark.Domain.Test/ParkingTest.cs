using MobiPark.Domain.Models;
using MobiPark.Domain.Services;
using MobiPark.Domain.Test.Repository;
using static MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Test;

public class ParkingTest
{
    [Fact]
    [Trait("Category", "Parking Vehicles")]
    public void ParkVehicle_Should_Park_A_Car()
    {
        // Arrange
        var repository = new ParkingRepository();
        AddSpaces(repository, VehicleType.Car, "free", 0, 1);
        var service = new ParkingService(repository);
        var vehicle = new Vehicle { Id = 1, Type = VehicleType.Car, Maker = "Toyota", LicensePlate = "ABC-1234" };

        // Act
        service.ParkVehicle(vehicle);

        // Assert
        var space = repository.spaces.First();
        Assert.NotNull(space);
        Assert.NotNull(space.Vehicle);
        Assert.Equal("occupied", space.Status);
        Assert.Equal(space.Vehicle.Type.ToString().ToLower(), space.Type);
    }

    [Fact]
    [Trait("Category", "Parking Vehicles")]
    public void ParkVehicle_Should_Park_A_Motorcycle()
    {
        // Arrange
        var repository = new ParkingRepository();
        AddSpaces(repository, VehicleType.Motorcycle, "free", 0, 1);
        var service = new ParkingService(repository);
        var vehicle = new Vehicle { Id = 1, Type = Vehicle.VehicleType.Motorcycle, Maker = "Honda", LicensePlate = "XYZ-987" };

        // Act
        service.ParkVehicle(vehicle);

        // Assert
        var space = repository.spaces.First();
        Assert.NotNull(space);
        Assert.NotNull(space.Vehicle);
        Assert.Equal("occupied", space.Status);
        Assert.Equal(space.Vehicle.Type.ToString().ToLower(), space.Type);
    }

    [Fact]
    [Trait("Category", "Parking Vehicles")]
    public void ParkVehicle_Should_Throw_Exception_When_No_Space_Available()
    {
        // Arrange
        var repository = new ParkingRepository();
        var service = new ParkingService(repository);
        var vehicle = new Vehicle { Id = 1, Type = VehicleType.Car, Maker = "Toyota", LicensePlate = "ABC-1234" };

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
        AddSpaces(repository, VehicleType.Car, "free", 0, 5);
        AddSpaces(repository, VehicleType.Motorcycle, "free", 5, 5);
        var service = new ParkingService(repository);

        // Act
        var spaces = service.GetAvailableSpaces();

        // Assert
        Assert.NotNull(spaces);
        Assert.Equal(10, spaces.Count);
    }

    [Fact]
    [Trait("Category", "Parking Spaces")]
    public void GetAvailableSpaces_Should_Return_Available_Spaces_Only_For_Cars()
    {
        // Arrange
        var repository = new ParkingRepository();
        AddSpaces(repository, VehicleType.Car, "free", 0, 5);
        AddSpaces(repository, VehicleType.Motorcycle, "free", 5, 5);
        var service = new ParkingService(repository);

        // Act
        var spaces = service.GetAvailableCarSpaces();

        // Assert
        Assert.NotNull(spaces);
        Assert.Equal(5, spaces.Count);
        Assert.All(spaces, space => Assert.True(space.Number < 5));
    }

    [Fact]
    [Trait("Category", "Parking Spaces")]
    public void GetAvailableSpaces_Should_Return_Available_Spaces_Only_For_Motorcycles()
    {
        // Arrange
        var repository = new ParkingRepository();
        AddSpaces(repository, VehicleType.Car, "free", 0, 5);
        AddSpaces(repository, VehicleType.Motorcycle, "free", 5, 5);
        var service = new ParkingService(repository);

        // Act
        var spaces = service.GetAvailableMotorcycleSpaces();

        // Assert
        Assert.NotNull(spaces);
        Assert.Equal(5, spaces.Count);
        Assert.All(spaces, space => Assert.True(space.Number >= 5));
    }

    private static void AddSpaces(ParkingRepository repository, VehicleType type, string status, int startIndex, int size)
    {
        for (int i = startIndex; i < startIndex + size; i++)
        {
            repository.spaces.Add(new() { Number = i, Type = type.ToString().ToLower(), Status = status });
        }
    }
}