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
