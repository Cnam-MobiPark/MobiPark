using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IReservationService
{
    Reservation CreateReservation(int parkingSpaceId, Vehicle.VehicleType vehicleType, DateTime startTime, DateTime endTime, bool isElectricCharging);
    Reservation GetReservation(int reservationId);
    void CancelReservation(int reservationId);
}
