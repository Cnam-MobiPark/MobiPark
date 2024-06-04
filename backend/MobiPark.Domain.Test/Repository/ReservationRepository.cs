using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.Test.Repository;

public class ReservationRepository : IReservationRepository
{
    private readonly List<Reservation> _reservations = [];

    public void Save(Reservation reservation)
    {
        _reservations.Add(reservation);
    }

    public Reservation FindById(int reservationId)
    {
        var res = _reservations.FirstOrDefault(r => r.ReservationId == reservationId);
        if (res is null) throw new NotFoundException("No reservation found");

        return res;
    }

    public void Cancel(Reservation reservation)
    {
        _reservations.Remove(reservation);
    }
}