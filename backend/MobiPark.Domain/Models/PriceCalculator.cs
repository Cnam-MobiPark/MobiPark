using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;

namespace MobiPark.Domain.Models;

public class PriceCalculator : IPriceCalculator
{
    private const int DayPricePerHour = 2;
    private const int NightPricePerHour = 3;
    private const int MotorcyclesDiscount = 2;
    private const double ElectricalEngineChargingPrice = 0.16;

    public int CalculatePrice(Reservation reservation)
    {
        var price = 0;
        var hoursPrice = calculateHoursPrice(reservation);
        if (reservation.Vehicle.Engine is ElectricalEngine)
        {
            var chargingPrice = calculateChargingPrice(reservation);
            price = hoursPrice + (int)chargingPrice;
        }
        else
        {
            price = hoursPrice;
        }

        if (reservation.Vehicle is Motorcycle) price /= MotorcyclesDiscount;
        return price;
    }

    public int GetDayHours(Reservation reservation)
    {
        var startTime = reservation.ReservationStartTime;
        var endTime = reservation.ReservationEndTime;

        var dayStart = new TimeSpan(8, 0, 0); // 8:00 AM
        var dayEnd = new TimeSpan(20, 0, 0); // 8:00 PM

        if (startTime.TimeOfDay < dayStart) startTime = startTime.Date + dayStart;

        if (endTime.TimeOfDay > dayEnd) endTime = endTime.Date + dayEnd;

        if (startTime < endTime)
        {
            var dayHours = endTime - startTime;
            return (int)dayHours.TotalHours;
        }

        return 0;
    }


    public int GetNightHours(Reservation reservation)
    {
        var startTime = reservation.ReservationStartTime;
        var endTime = reservation.ReservationEndTime;

        var nightStart = new TimeSpan(20, 0, 0); // 8:00 PM
        var nightEnd = new TimeSpan(8, 0, 0); // 8:00 AM the next day

        var nightEndAdjusted = endTime.Date + nightEnd;

        var nightHours = TimeSpan.Zero;

        if (startTime.TimeOfDay < nightEnd)
        {
            if (endTime.TimeOfDay <= nightEnd)
                nightHours = endTime - startTime;
            else
                nightHours = nightEndAdjusted - startTime;
        }
        else if (startTime.TimeOfDay >= nightStart)
        {
            if (endTime.TimeOfDay <= nightStart)
                nightHours = endTime - startTime;
            else
                nightHours = startTime.Date.AddDays(1) + nightEnd - startTime;
        }
        else
        {
            if (endTime.TimeOfDay >= nightStart)
                nightHours = nightEndAdjusted - startTime + (endTime - (endTime.Date + nightStart));
            else
                nightHours = nightEndAdjusted - startTime;
        }

        return (int)nightHours.TotalHours;
    }


    public int calculateHoursPrice(Reservation reservation)
    {
        var dayHours = GetDayHours(reservation);
        var nightHours = GetNightHours(reservation);

        var price = dayHours * DayPricePerHour + nightHours * NightPricePerHour;
        return price;
    }

    public double calculateChargingPrice(Reservation reservation)
    {
        var electricalEngine = (ElectricalEngine)reservation.Vehicle.Engine;
        var batteryCapacity = electricalEngine.BatteryCapacity;
        var currentBatteryCapacity = electricalEngine.CurrentBatteryCapacity;

        var chargingPrice = (batteryCapacity - currentBatteryCapacity) * ElectricalEngineChargingPrice;
        return chargingPrice;
    }
}