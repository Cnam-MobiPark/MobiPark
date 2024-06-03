using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IReservationRepository
{
    void Save(Reservation reservation);
    Reservation FindById(int reservationId);
    void Cancel(Reservation reservation);
}
