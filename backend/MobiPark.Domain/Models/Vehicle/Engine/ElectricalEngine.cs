using MobiPark.Domain.Exceptions;

namespace MobiPark.Domain.Models.Vehicle.Engine
{
    public class ElectricalEngine : Engine
    {
        public int BatteryCapacity { get; private set; }
        public int CurrentBatteryCapacity { get; private set; }
        public int BatteryLevel => (CurrentBatteryCapacity * 100) / BatteryCapacity;

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

            BatteryCapacity = batteryCapacity;
            CurrentBatteryCapacity = currentBatteryCapacity;
        }

        // Parameterless constructor for EF
        private ElectricalEngine() { }
    }
}