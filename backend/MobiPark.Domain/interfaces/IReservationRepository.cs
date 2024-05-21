using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IReservationRepository
{
    void AddReservation(Reservation reservation);
    Reservation GetReservation(int reservationId);
    void RemoveReservation(int reservationId);
}
