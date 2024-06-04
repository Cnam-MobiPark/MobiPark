namespace MobiPark.Domain.Models;

using ReservationId = int;

public class Reservation
{
    public Reservation(Vehicle.Vehicle vehicle, ParkingSpace parkingSpace, DateTime startTime, DateTime endTime)
    {
        ReservationId = new Random().Next(1, 1000);
        Vehicle = vehicle;
        ParkingSpace = parkingSpace;
        ReservationStartTime = startTime;
        ReservationEndTime = endTime;
        IsElectricCharging = parkingSpace.IsElectric;
        TotalPrice = 20;
    }

    public ReservationId ReservationId { get; set; }
    public ParkingSpace ParkingSpace { get; set; }
    public Vehicle.Vehicle Vehicle { get; set; }
    public DateTime ReservationStartTime { get; set; }
    public DateTime ReservationEndTime { get; set; }
    public bool IsElectricCharging { get; set; }
    public double TotalPrice { get; set; }
}