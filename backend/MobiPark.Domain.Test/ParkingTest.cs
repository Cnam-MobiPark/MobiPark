using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Services;
using MobiPark.Domain.Test.Repository;

namespace MobiPark.Domain.Test;

public class ParkingTest
{
    
    [Fact]
    [Trait("Category", "Parking Vehicles")]
    public void ParkVehicle_Should_Park_A_Car()
    {
        // Arrange
        var repository = new FakeParkingRepository();
        AddSpaces(repository, "Car", "free", 0, 1);
        var service = new ParkingService(repository);
        var vehicle = VehicleFactory.CreateCar("Toyota", new FrLicensePlate("AB-123-CD"));

        // Act
        service.ParkVehicle(vehicle);

        // Assert
        var space = repository.spaces.First();
        Assert.NotNull(space);
        Assert.NotNull(space.Vehicle);
        Assert.Equal("occupied", space.Status);
        Assert.Equal(vehicle.GetType().Name.ToLower(), space.Type);
    }

    [Fact]
    [Trait("Category", "Parking Vehicles")]
    public void ParkVehicle_Should_Park_A_Motorcycle()
    {
        // Arrange
        var repository = new FakeParkingRepository();
        AddSpaces(repository, "Motorcycle", "free", 0, 1);
        var service = new ParkingService(repository);
        var vehicle = VehicleFactory.CreateMotorcycle("Toyota", new FrLicensePlate("AB-123-CD"));

        // Act
        service.ParkVehicle(vehicle);

        // Assert
        var space = repository.spaces.First();
        Assert.NotNull(space);
        Assert.NotNull(space.Vehicle);
        Assert.Equal("occupied", space.Status);
        Assert.Equal(vehicle.GetType().Name.ToLower(), space.Type);
    }

    [Fact]
    [Trait("Category", "Parking Vehicles")]
    public void ParkVehicle_Should_Throw_Exception_When_No_Space_Available()
    {
        // Arrange
        var repository = new FakeParkingRepository();
        var service = new ParkingService(repository);
        var vehicle = VehicleFactory.CreateCar("Toyota", new FrLicensePlate("AB-123-CD"));

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => service.ParkVehicle(vehicle));
        Assert.Equal("No available parking spaces.", exception.Message);
    }

    [Fact]
    [Trait("Category", "Parking Spaces")]
    public void GetAvailableSpaces_Should_Return_Available_Spaces()
    {
        // Arrange
        var repository = new FakeParkingRepository();
        AddSpaces(repository, "Car", "free", 0, 5);
        AddSpaces(repository, "Motorcycle", "free", 5, 5);
        var service = new ParkingService(repository);

        // Act
        var spaces = service.GetAvailableSpaces();

        // Assert
        Assert.NotNull(spaces);
        Assert.Equal(10, spaces.Count);
    }

    [Fact]
    [Trait("Category", "Parking Spaces")]
    public void GetAvailableSpacesFor_Should_Return_Available_Spaces_Only_For_Cars()
    {
        // Arrange
        var repository = new FakeParkingRepository();
        AddSpaces(repository, "Car", "free", 0, 5);
        AddSpaces(repository, "Motorcycle", "free", 5, 5);
        var service = new ParkingService(repository);
        var vehicle = VehicleFactory.CreateCar("Toyota", new FrLicensePlate("AB-123-CD"));

        // Act
        var spaces = service.GetAvailableSpacesFor(vehicle);

        // Assert
        Assert.NotNull(spaces);
        Assert.Equal(5, spaces.Count);
        Assert.All(spaces, space => Assert.True(space.Number < 5));
    }

    [Fact]
    [Trait("Category", "Parking Spaces")]
    public void GetAvailableSpacesFor_Should_Return_Available_Spaces_Only_For_Motorcycles()
    {
        // Arrange
        var repository = new FakeParkingRepository();
        AddSpaces(repository, "Car", "free", 0, 5);
        AddSpaces(repository, "Motorcycle", "free", 5, 5);
        var service = new ParkingService(repository);
        var vehicle = VehicleFactory.CreateMotorcycle("Toyota", new FrLicensePlate("AB-123-CD"));

        // Act
        var spaces = service.GetAvailableSpacesFor(vehicle);

        // Assert
        Assert.NotNull(spaces);
        Assert.Equal(5, spaces.Count);
        Assert.All(spaces, space => Assert.True(space.Number >= 5));
    }

    private static void AddSpaces(FakeParkingRepository repository, string type, string status, int startIndex, int size)
    {
        for (int i = startIndex; i < startIndex + size; i++)
        {
            repository.spaces.Add(new() { Number = i, Type = type.ToLower(), Status = status });
        }
    }
}