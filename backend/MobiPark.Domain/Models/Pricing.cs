namespace MobiPark.Domain.Models;

using VehicleId = int;

public class Pricing
{
    
    public VehicleId Id { get; set; }
    public Vehicle.VehicleType VehicleType { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsElectricCharging { get; set; }
    public double Price { get; set; }
}
