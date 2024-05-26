namespace MobiPark.Domain.Models.Vehicle.Engine
{
    public class ElectricalEngine : Engine
    {
        public readonly int batteryCapacity;
        public int currentBatteryCapacity { get; private set; }
        public int batteryLevel => (currentBatteryCapacity * 100) / batteryCapacity;
    
        public ElectricalEngine(int batteryCapacity, int currentBatteryCapacity)
        {
            this.batteryCapacity = batteryCapacity;
            this.currentBatteryCapacity = currentBatteryCapacity;
        }
    }
}