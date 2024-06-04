using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.App.Presenters;

public class VehiclePresenter
{
    public VehiclePresenter(Vehicle vehicle)
    {
        Type = vehicle.GetType().Name;
        Maker = vehicle.Maker;
        LicensePlateNumber = vehicle.LicensePlate.Value;
    }

    public string Type { get; private set; }
    public string Maker { get; private set; }
    public string LicensePlateNumber { get; private set; }
}