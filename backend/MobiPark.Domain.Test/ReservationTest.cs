using System.Diagnostics;
using MobiPark.Domain.Factories;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;
using MobiPark.Domain.Services;
using MobiPark.Domain.Test.Repository;

namespace MobiPark.Domain.Test
{
    public class ReservationTest
    {
        private readonly List<Reservation> _reservations;
        private readonly IParkingService _parkingService;

        public ReservationTest()
        {
            _reservations = new List<Reservation>();
            var parkingRepository = new FakeParkingRepository();
            //_parkingService = new ParkingService(parkingRepository);
            //_reservationService = new ReservationService(_reservations, _parkingService);
        }

        private Vehicle MakeCar()
        {
            var plate = new FrLicensePlate("AB-123-CD");
            var engine = new ThermalEngine();
            var vehicle = VehicleFactory.CreateCar("Toyota", plate, engine);
            return vehicle;
        }

        [Fact]
        [Trait("Reservation", "Create a reservation")]
        public void CreateReservation_Should_Create_A_New_Reservation()
        {
            // Arrange
            var parkingSpace = new ParkingSpace(1, VehicleSize.Medium);
            var vehicle = MakeCar();
            var startTime = new DateTime(2024, 5, 21, 8, 0, 0);
            var endTime = new DateTime(2024, 5, 21, 12, 0, 0);
            var isElectricCharging = false;

            // Act
            var reservation = new Reservation(vehicle, parkingSpace, startTime, endTime, isElectricCharging);

            // Assert
            Assert.NotNull(reservation);
            Assert.Equal(parkingSpace, reservation.ParkingSpace);
            Assert.Equal(vehicle, reservation.Vehicle);
            Assert.Equal(startTime, reservation.ReservationStartTime);
            Assert.Equal(endTime, reservation.ReservationEndTime);
            Assert.Equal(isElectricCharging, reservation.IsElectricCharging);
            Assert.Equal(20, reservation.TotalPrice);
        }

        [Fact]
        [Trait("Reservation", "Should throw an error if invalid datetime")]
        public void CreateReservation_Should_Throw_An_Exception()
        {
            var parkingSpace = new ParkingSpace(1, VehicleSize.Medium);
            var vehicle = MakeCar();
            var startTime = new DateTime(2024, 5, 21, 8, 0, 0);
            var endTime = new DateTime(2024, 5, 21, 12, 0, 0);

            Action act = () => new Reservation(vehicle, parkingSpace, startTime, endTime);
            
            // Assert
        }

        /*[Fact]
        [Trait("Reservation", "Reservation Management")]
        public void GetReservation_Should_Return_Existing_Reservation()
        {
            // Arrange
            var reservationId = 1;
            var vehicle = VehicleFactory.CreateCar("Toyota", new FrLicensePlate("AB-123-CD"), new ThermalEngine());
            var reservation = new Reservation
            {
                ReservationId = reservationId,
                Vehicle = vehicle,
                ReservationStartTime = DateTime.Now,
                ReservationEndTime = DateTime.Now.AddHours(1)
            };
            _reservations.Add(reservation);

            // Act
            var result = _reservationService.GetReservationById(reservationId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(reservationId, result.ReservationId);
        }*/

        /*[Fact]
        [Trait("Category", "Reservation Management")]
        public void CancelReservation_Should_Remove_Existing_Reservation()
        {
            // Arrange
            var reservationId = 1;
            var vehicle = VehicleFactory.CreateCar("Toyota", new FrLicensePlate("AB-123-CD"), new ThermalEngine());
            var reservation = new Reservation
            {
                ReservationId = reservationId,
                Vehicle = vehicle,
                ReservationStartTime = DateTime.Now,
                ReservationEndTime = DateTime.Now.AddHours(1)
            };
            _reservations.Add(reservation);

            // Act
            _reservationService.CancelReservation(reservation);

            // Assert
            Assert.DoesNotContain(_reservations, r => r.ReservationId == reservationId);
        }*/
    }
}
