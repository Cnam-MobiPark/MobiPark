using MobiPark.Domain.Exceptions;

namespace MobiPark.Domain.Models.Vehicle.Engine
{
    public class ElectricalEngine : Engine
    {
        public readonly int batteryCapacity;
        public int currentBatteryCapacity { get; private set; }
        public int batteryLevel => (currentBatteryCapacity * 100) / batteryCapacity;
    
        public ElectricalEngine(int batteryCapacity, int currentBatteryCapacity)
        {
            if (batteryCapacity <= 0)
            {
                throw new InvalidBatteryException("Battery capacity : " + batteryCapacity + " cannot be negative or zero.");
            }
            
            if (currentBatteryCapacity < 0)
            {
                throw new InvalidBatteryException("Current battery capacity : " + currentBatteryCapacity + " cannot be negative.");
            }
            if (currentBatteryCapacity > batteryCapacity)
            {
                throw new InvalidBatteryException("Current battery capacity : " + currentBatteryCapacity + " cannot be greater than battery capacity : " + batteryCapacity);
            }
            
            this.batteryCapacity = batteryCapacity;
            this.currentBatteryCapacity = currentBatteryCapacity;
        }
    }
}