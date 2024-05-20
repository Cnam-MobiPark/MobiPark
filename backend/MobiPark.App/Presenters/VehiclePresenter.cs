using MobiPark.Domain.Models;

namespace MobiPark.App.Presenters;

public class VehiclePresenter
{
    public int Id { get; private set; }
    public Vehicle.VehicleType Type { get; private set; }
    public string Maker { get; private set; }
    public string LicensePlate { get; private set; }
    
    public VehiclePresenter(Vehicle vehicle)
    {
        Id = vehicle.Id;
        Type = vehicle.Type;
        Maker = vehicle.Maker;
        LicensePlate = vehicle.LicensePlate;
    }
}