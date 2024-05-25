using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

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

        public Reservation CreateReservation(ParkingSpace parkingSpace, Vehicle vehicle, DateTime startTime, DateTime endTime, bool isElectricCharging)
        {
            var reservation = new Reservation
            {
                ReservationId = _reservations.Count + 1,
                ParkingSpace = parkingSpace,
                Vehicle = vehicle,
                ReservationStartTime = startTime,
                ReservationEndTime = endTime,
                IsElectricCharging = isElectricCharging,
                TotalPrice = CalculateTotalPrice(startTime, endTime, isElectricCharging)
            };

            _reservations.Add(reservation);

            return reservation;
        }

        public Reservation? GetReservationById(int reservationId)
        {
            return _reservations.FirstOrDefault(r => r.ReservationId == reservationId);
        }

        public void CancelReservation(Reservation reservation)
        {
            _reservations.Remove(reservation);
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
