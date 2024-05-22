using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Services;
using MobiPark.Domain.Test.Repository;

namespace MobiPark.Domain.Test
{
    public class ReservationTest
    {
        private readonly List<Reservation> _reservations;
        private readonly IParkingService _parkingService;
        private readonly IReservationService _reservationService;

        public ReservationTest()
        {
            _reservations = new List<Reservation>();
            var parkingRepository = new ParkingRepository();
            _parkingService = new ParkingService(parkingRepository);
            _reservationService = new ReservationService(_reservations, _parkingService);
        }

        [Fact]
        [Trait("Category", "Reservation Management")]
        public void CreateReservation_Should_Create_A_New_Reservation()
        {
            // Arrange
            var parkingSpace = new ParkingSpace { Number = 1, Type = "car", Status = "free" };
            var vehicleType = Vehicle.VehicleType.Car;
            var startTime = new DateTime(2024, 5, 21, 8, 0, 0);
            var endTime = new DateTime(2024, 5, 21, 12, 0, 0);
            var isElectricCharging = false;

            // Act
            var reservation = _reservationService.CreateReservation(parkingSpace, vehicleType, startTime, endTime, isElectricCharging);

            // Assert
            Assert.NotNull(reservation);
            Assert.Equal(parkingSpace, reservation.ParkingSpace);
            Assert.Equal(vehicleType, reservation.VehicleType);
            Assert.Equal(startTime, reservation.ReservationStartTime);
            Assert.Equal(endTime, reservation.ReservationEndTime);
            Assert.Equal(isElectricCharging, reservation.IsElectricCharging);
            Assert.Equal(20, reservation.TotalPrice);
        }

        [Fact]
        [Trait("Category", "Reservation Management")]
        public void GetReservation_Should_Return_Existing_Reservation()
        {
            // Arrange
            var reservationId = 1;
            var reservation = new Reservation
            {
                ReservationId = reservationId,
                VehicleType = Vehicle.VehicleType.Car,
                ReservationStartTime = DateTime.Now,
                ReservationEndTime = DateTime.Now.AddHours(1)
            };
            _reservations.Add(reservation);

            // Act
            var result = _reservationService.GetReservationById(reservationId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(reservationId, result.ReservationId);
        }

        [Fact]
        [Trait("Category", "Reservation Management")]
        public void CancelReservation_Should_Remove_Existing_Reservation()
        {
            // Arrange
            var reservationId = 1;
            var reservation = new Reservation
            {
                ReservationId = reservationId,
                VehicleType = Vehicle.VehicleType.Car,
                ReservationStartTime = DateTime.Now,
                ReservationEndTime = DateTime.Now.AddHours(1)
            };
            _reservations.Add(reservation);

            // Act
            _reservationService.CancelReservation(reservation);

            // Assert
            Assert.DoesNotContain(_reservations, r => r.ReservationId == reservationId);
        }
    }
}
