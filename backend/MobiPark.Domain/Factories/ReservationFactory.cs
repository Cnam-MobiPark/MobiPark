using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Factories;

public class ReservationFactory(IClock clock)
{
    public Reservation MakeReservation(Vehicle vehicle, ParkingSpace parkingSpace, DateTime startTime, DateTime endTime)
    {
        var now = clock.Now();
        if (now > startTime)
            throw new InvalidDateException("Reservation start time must be in the future");
        if (startTime > endTime)
            throw new InvalidDateException("Reservation start time must be before end time");

        return new Reservation(vehicle, parkingSpace, startTime, endTime);
    }
}