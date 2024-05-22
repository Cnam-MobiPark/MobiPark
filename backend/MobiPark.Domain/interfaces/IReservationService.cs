using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IReservationService
{
    Reservation CreateReservation(ParkingSpace parkingSpace, Vehicle.VehicleType vehicleType, DateTime startTime, DateTime endTime, bool isElectricCharging);
    Reservation? GetReservationById(int reservationId);
    void CancelReservation(Reservation reservation);
}
