using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;
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
        var vehicle = VehicleFactory.CreateCar(maker, licensePlate, new ThermalEngine());

        // Assert
        Assert.NotNull(vehicle);
        Assert.IsType<Car>(vehicle);
        Assert.Equal(maker, vehicle.Maker);
        Assert.Equal(licensePlate, vehicle.LicensePlate);
    }
}