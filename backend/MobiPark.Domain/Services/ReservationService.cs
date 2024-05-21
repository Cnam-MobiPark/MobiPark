using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.Services
{
    public class ReservationService : IReservationService
    {
        private readonly List<Reservation> _reservations;
        private readonly IParkingService _parkingService;

        public ReservationService(List<Reservation> reservations, IParkingService parkingService)
        {
            _reservations = reservations;
            _parkingService = parkingService;
        }

        public Reservation CreateReservation(int parkingSpaceId, Vehicle.VehicleType vehicleType, DateTime startTime, DateTime endTime, bool isElectricCharging)
        {
            var reservation = new Reservation
            {
                ReservationId = _reservations.Count + 1,
                ParkingSpace = _parkingService.GetAvailableSpaces().FirstOrDefault(p => p.Number == parkingSpaceId),
                VehicleType = vehicleType,
                ReservationStartTime = startTime,
                ReservationEndTime = endTime,
                IsElectricCharging = isElectricCharging,
                TotalPrice = CalculateTotalPrice(startTime, endTime, isElectricCharging)
            };

            _reservations.Add(reservation);

            return reservation;
        }

        public Reservation GetReservation(int reservationId)
        {
            return _reservations.FirstOrDefault(r => r.ReservationId == reservationId);
        }

        public void CancelReservation(int reservationId)
        {
            var reservation = _reservations.FirstOrDefault(r => r.ReservationId == reservationId);

            if (reservation != null)
            {
                _reservations.Remove(reservation);
            }
        }

        private double CalculateTotalPrice(DateTime startTime, DateTime endTime, bool isElectricCharging)
        {
            var duration = endTime - startTime;
            var hours = duration.TotalHours;
            var pricePerHour = isElectricCharging ? 10 : 5;

            return hours * pricePerHour;
        }
    }
}
