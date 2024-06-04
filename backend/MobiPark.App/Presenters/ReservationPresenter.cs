using MobiPark.Domain.Models;

namespace MobiPark.App.Presenters;

public class ReservationPresenter
{
    public ReservationPresenter(Reservation reservation)
    {
        ReservationId = reservation.ReservationId;
        VehicleId = reservation.Vehicle.LicensePlate.Value;
        Vehicle = new VehiclePresenter(reservation.Vehicle);
        ParkingSpace = reservation.ParkingSpace;
    }

    public int ReservationId { get; }
    public string VehicleId { get; }
    public VehiclePresenter Vehicle { get; }
    public ParkingSpace ParkingSpace { get; }
}