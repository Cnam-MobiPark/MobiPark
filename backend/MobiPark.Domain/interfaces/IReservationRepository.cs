using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IReservationRepository
{
    Reservation Save(Reservation reservation);
    Reservation FindByPlate(string plate);
    void Cancel(Reservation reservation);
}