using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces;

public interface IReservationService
{
    Reservation? GetReservationById(int reservationId);
    void CancelReservation(Reservation reservation);
}
