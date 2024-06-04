using MobiPark.Domain.Models.Vehicle.Engine;

namespace MobiPark.App.Presenters;

public class EnginePresenter
{
    public EnginePresenter(Engine engine)
    {
        EngineType = engine.GetType().ToString();
        if (engine is not ElectricalEngine electricalEngine) return;
        BatteryCapacity = electricalEngine.BatteryCapacity;
        CurrentBatteryCapacity = electricalEngine.CurrentBatteryCapacity;
    }

    public string EngineType { get; }
    public int BatteryCapacity { get; }
    public int CurrentBatteryCapacity { get; }
}