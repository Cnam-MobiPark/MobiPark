using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.Test.Repository;

public class ReservationRepository : IReservationRepository
{
    private readonly List<Reservation> _reservations = new List<Reservation>();

    public void AddReservation(Reservation reservation)
    {
        _reservations.Add(reservation);
    }

    public Reservation GetReservation(int reservationId)
    {
        return _reservations.FirstOrDefault(r => r.ReservationId == reservationId);
    }

    public void RemoveReservation(int reservationId)
    {
        var reservation = GetReservation(reservationId);
        if (reservation != null)
        {
            _reservations.Remove(reservation);
        }
    }
}
