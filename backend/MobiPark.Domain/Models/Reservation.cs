namespace MobiPark.Domain.Models;

public class Reservation
{
    public int ReservationId { get; set; }
    public ParkingSpace ParkingSpace { get; set; }
    public Vehicle.VehicleType VehicleType { get; set; }
    public DateTime ReservationStartTime { get; set; }
    public DateTime ReservationEndTime { get; set; }
    public bool IsElectricCharging { get; set; }
    public double TotalPrice { get; set; }
}
