using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IReservationRepository
{
    Task<Reservation> Save(Reservation reservation);
    Task<List<Reservation>> GetReservations();
    Task<Reservation> FindByPlate(string plate);
    void Cancel(Reservation reservation);
}