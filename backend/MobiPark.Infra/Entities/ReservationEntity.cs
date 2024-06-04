using MobiPark.Domain.Models;

namespace MobiPark.Infra.Entities;

public class ReservationEntity
{
    public int ReservationId { get; set; }
    public string VehicleId { get; set; }
    public VehicleEntity Vehicle { get; set; }
    public ParkingSpace ParkingSpace { get; set; }
}