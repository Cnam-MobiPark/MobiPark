using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.App.Presenters;

public class VehiclePresenter
{
    public string Type { get; private set; }
    public string Maker { get; private set; }
    public AbstractLicensePlate LicensePlate { get; private set; }
    
    public VehiclePresenter(Vehicle vehicle)
    {
        Type = vehicle.GetType().Name;
        Maker = vehicle.Maker;
        LicensePlate = vehicle.LicensePlate;
    }
}