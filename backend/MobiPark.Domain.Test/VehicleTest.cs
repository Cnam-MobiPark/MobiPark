using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Factories;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;
using MobiPark.Domain.Test.Repository;

namespace MobiPark.Domain.Test;

public class VehicleTest
{
    private static Car MakeCar()
    {
        const string maker = "Toyota";
        var licensePlate = new FrLicensePlate("AB-123-CD");
        var vehicle = VehicleFactory.CreateCar(maker, licensePlate, new ThermalEngine());
        return vehicle;
    }
    
    private static Car MakeElectricCar()
    {
        const string maker = "Toyota";
        var licensePlate = new FrLicensePlate("AB-123-CD");
        var vehicle = VehicleFactory.CreateCar(maker, licensePlate, new ElectricalEngine(100, 50));
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
        var parkingPlace = new ParkingSpace(1,VehicleSize.Medium, false);

        var beginDateTime = new DateTime(2022, 11, 10, 14, 10, 0);
        var endDateTime = new DateTime(2022, 11, 10, 15, 10, 0);
        var fakeClock = new FakeClock(beginDateTime.AddMinutes(-10));
        Reservation reservation = vehicle.Park(fakeClock, parkingPlace, beginDateTime, endDateTime);
        
        Assert.Equal(reservation.Vehicle, vehicle);
        Assert.Equal(reservation.ParkingSpace, parkingPlace);
        Assert.False(reservation.IsElectricCharging);
        Assert.Equal(beginDateTime, reservation.ReservationStartTime);
        Assert.Equal(endDateTime, reservation.ReservationEndTime);
        Assert.Equal(20, reservation.TotalPrice);
    }
    
    [Fact]
    [Trait("Vehicle", "Vehicle should park")]
    public void Vehicle_ShouldParkAndCharge()
    {
        // Arrange
        var vehicle = MakeElectricCar();
        var parkingPlace = new ParkingSpace(1,VehicleSize.Medium, true);

        var beginDateTime = new DateTime(2022, 11, 10, 14, 10, 0);
        var endDateTime = new DateTime(2022, 11, 10, 15, 10, 0);
        var fakeClock = new FakeClock(beginDateTime.AddMinutes(-10));
        Reservation reservation = vehicle.Park(fakeClock, parkingPlace, beginDateTime, endDateTime);
        
        Assert.Equal(reservation.Vehicle, vehicle);
        Assert.Equal(reservation.ParkingSpace, parkingPlace);
        Assert.True(reservation.IsElectricCharging);
        Assert.Equal(beginDateTime, reservation.ReservationStartTime);
        Assert.Equal(endDateTime, reservation.ReservationEndTime);
    }
    
    [Fact]
    [Trait("Vehicle", "Vehicle shouldn't park")]
    public void Vehicle_ShouldNotParkIfIsElectricAndNotCharging()
    {
        // Arrange
        var vehicle = MakeCar();
        var parkingPlace = new ParkingSpace(1,VehicleSize.Medium, true);

        var beginDateTime = new DateTime(2022, 11, 10, 14, 10, 0);
        var endDateTime = new DateTime(2022, 11, 10, 15, 10, 0);
        var fakeClock = new FakeClock(beginDateTime.AddMinutes(-10));
        Action act = () => vehicle.Park(fakeClock, parkingPlace, beginDateTime, endDateTime);
        
        Assert.Throws<VehicleCannotParkException>(act);
    }
    
    [Fact]
    [Trait("Vehicle", "Vehicle shouldn't park")]
    public void Vehicle_ShouldNotParkIfParkingSpaceIsOccupied()
    {
        // Arrange
        var vehicle = MakeCar();
        var parkingPlace = new ParkingSpace(1,VehicleSize.Medium, false);
        parkingPlace.Status = ParkingSpaceStatus.Occupied;

        var beginDateTime = new DateTime(2022, 11, 10, 14, 10, 0);
        var endDateTime = new DateTime(2022, 11, 10, 15, 10, 0);
        var fakeClock = new FakeClock(beginDateTime.AddMinutes(-10));
        Action act = () => vehicle.Park(fakeClock, parkingPlace, beginDateTime, endDateTime);
        
        Assert.Throws<VehicleCannotParkException>(act);
    }
    
    [Fact]
    [Trait("Vehicle", "Vehicle shouldn't park")]
    public void Vehicle_ShouldNotParkIfParkingSpaceIsTooSmall()
    {
        // Arrange
        var vehicle = MakeCar();
        var parkingPlace = new ParkingSpace(1,VehicleSize.Small, false);

        var beginDateTime = new DateTime(2022, 11, 10, 14, 10, 0);
        var endDateTime = new DateTime(2022, 11, 10, 15, 10, 0);
        var fakeClock = new FakeClock(beginDateTime.AddMinutes(-10));
        Action act = () => vehicle.Park(fakeClock, parkingPlace, beginDateTime, endDateTime);
        
        Assert.Throws<VehicleCannotParkException>(act);
    }
}