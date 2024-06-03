using MobiPark.Domain.Factories;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;
using MobiPark.Domain.Test.Repository;

namespace MobiPark.Domain.Test;

public class VehicleTest
{
    public VehicleTest()
    {
    }

    private Car MakeCar()
    {
        var maker = "Toyota";
        var licensePlate = new FrLicensePlate("AB-123-CD");
        var vehicle = VehicleFactory.CreateCar(maker, licensePlate, new ThermalEngine());
        return vehicle;
    }

    [Fact]
    [Trait("Vehicle", "Creating Vehicles")]
    public void Vehicle_ShouldCreateVehicle()
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

    [Fact]
    [Trait("Vehicle", "Vehicle should park")]
    public void Vehicle_ShouldPark()
    {
        // Arrange
        var vehicle = MakeCar();
        var parkingPlace = new ParkingSpace(1,VehicleSize.Medium);

        var beginDateTime = new DateTime(2022, 11, 10, 14, 10, 0);
        var endDateTime = new DateTime(2022, 11, 10, 15, 10, 0);
        Reservation reservation = vehicle.Park(parkingPlace, beginDateTime, endDateTime);
        
        Assert.Equal(reservation.Vehicle, vehicle);
        Assert.Equal(reservation.ParkingSpace, parkingPlace);
        Assert.False(reservation.IsElectricCharging);
        Assert.Equal(beginDateTime, reservation.ReservationStartTime);
        Assert.Equal(endDateTime, reservation.ReservationEndTime);
        // TODO: define the price algorithm
        Assert.Equal(10, reservation.TotalPrice);
    }
}