using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.Models;

using ReservationId = int;

public class Reservation
{
    public Reservation(IClock clock, Vehicle.Vehicle vehicle, ParkingSpace parkingSpace, DateTime startTime, DateTime endTime, bool withElectricCharge = false)
    {
        var now = clock.Now();
        if (now > startTime)
            throw new InvalidDateException("Reservation start time must be in the future");
        if (startTime > endTime)
            throw new InvalidDateException("Reservation start time must be before end time");
        
        ReservationId = new Random().Next(1, 1000);
        Vehicle = vehicle;
        ParkingSpace = parkingSpace;
        ReservationStartTime = startTime;
        ReservationEndTime = endTime;
        IsElectricCharging = withElectricCharge;
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
