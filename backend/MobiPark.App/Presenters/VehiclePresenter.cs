using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.App.Presenters;

public class VehiclePresenter
{
    public string Type { get; private set; }
    public string Maker { get; private set; }
    public string LicensePlate { get; private set; }
    
    public VehiclePresenter(Vehicle vehicle)
    {
        Type = vehicle.GetType().Name;
        Maker = vehicle.Maker;
        LicensePlate = vehicle.LicensePlate;
    }
}