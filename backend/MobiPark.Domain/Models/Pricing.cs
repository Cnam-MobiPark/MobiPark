namespace MobiPark.Domain.Models;

using VehicleId = int;

public class Pricing
{
    
    public VehicleId Id { get; set; }
    public Vehicle.VehicleType VehicleType { get; set; }
    public double BaseRate { get; set; }
    public double WeekendRate { get; set; }
    public double NightRate { get; set; }
    public double ElectricChargingRate { get; set; }
    public double LateFee { get; set; }
}
