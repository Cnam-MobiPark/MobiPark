namespace MobiPark.Domain.Models.Vehicle.Engine;

public class ElectricalEngine : Engine
{
    public readonly int batteryCapacity;
    public int batteryLevel { get; private set; }
    
    public ElectricalEngine(int batteryCapacity)
    {
        this.batteryCapacity = batteryCapacity;
        this.batteryLevel = batteryCapacity;
    }
}