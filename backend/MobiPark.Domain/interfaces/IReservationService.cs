using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces;

public interface IReservationService
{
    Reservation CreateReservation(ParkingSpace parkingSpace, Vehicle vehicle, DateTime startTime, DateTime endTime, bool isElectricCharging);
    Reservation? GetReservationById(int reservationId);
    void CancelReservation(Reservation reservation);
}
