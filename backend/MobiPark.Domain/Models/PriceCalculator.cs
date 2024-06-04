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
            price = hoursPrice + (int) chargingPrice;
        } else
        {
            price = hoursPrice;
        }
        if (reservation.Vehicle is Motorcycle)
        {
            price /= MotorcyclesDiscount;
        }
        return price;
    }
    
    public int GetDayHours(Reservation reservation)
    {
        var startTime = reservation.ReservationStartTime;
        var endTime = reservation.ReservationEndTime;
        
        var dayHours = (int) (endTime - startTime).TotalHours;
        return dayHours;
    }
    
    public int GetNightHours(Reservation reservation)
    {
        var startTime = reservation.ReservationStartTime;
        var endTime = reservation.ReservationEndTime;
        
        var nightHours = (int) (endTime - startTime).TotalHours;
        return nightHours;
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
        var electricalEngine = (ElectricalEngine) reservation.Vehicle.Engine;
        var batteryCapacity = electricalEngine.BatteryCapacity;
        var currentBatteryCapacity = electricalEngine.CurrentBatteryCapacity;
        
        var chargingPrice = (batteryCapacity - currentBatteryCapacity) * ElectricalEngineChargingPrice;
        return chargingPrice;
    }
}