using System.Text.Json.Serialization;

namespace MobiPark.App.DTO;

public class CreateEngineDTO
{
    [JsonConstructor]
    public CreateEngineDTO(string engineType, int? batteryCapacity, int? currentBatteryCapacity)
    {
        EngineType = engineType;
        BatteryCapacity = batteryCapacity;
        CurrentBatteryCapacity = currentBatteryCapacity;
    }

    public string EngineType { get; private set; }
    public int? BatteryCapacity { get; private set; }
    public int? CurrentBatteryCapacity { get; private set; }
}