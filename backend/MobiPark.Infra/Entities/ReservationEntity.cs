using MobiPark.Domain.Models;

namespace MobiPark.Infra.Entities;

public class ReservationEntity
{
    public ReservationEntity()
    {
    }
    
    public ReservationEntity(Reservation reservation)
    {
        ReservationId = reservation.ReservationId;
        VehicleId = reservation.Vehicle.LicensePlate.Value;
        Vehicle = new VehicleEntity(reservation.Vehicle);
        ParkingSpace = reservation.ParkingSpace;
    }
    public int ReservationId { get; set; }
    public string VehicleId { get; set; }
    public VehicleEntity Vehicle { get; set; }
    public ParkingSpace ParkingSpace { get; set; }
    
    public Reservation ToDomainModel()
    {
        return new Reservation(ReservationId, Vehicle.ToDomainModel(), ParkingSpace);
    }
}