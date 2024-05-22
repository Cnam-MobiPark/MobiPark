namespace MobiPark.Domain.Models;

using VehicleId = int;

public class Vehicle
{
    public enum VehicleType
    {
        Car,
        Motorcycle
    }
    public VehicleId Id { get; set; }
    public VehicleType Type { get; set; }
    public string Maker { get; set; }
    public string LicensePlate { get; set; }
}