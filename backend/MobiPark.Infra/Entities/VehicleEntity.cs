using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;
using MobiPark.Infra.Entities;

public abstract class VehicleEntity
{
    public string Maker { get; set; }
    public string LicensePlateValue { get; set; } // Foreign key
    public LicensePlateEntity LicensePlate { get; set; }
    public int EngineId { get; set; } // Foreign key
    public EngineEntity Engine { get; set; }

    protected VehicleEntity() { }

    protected VehicleEntity(Vehicle vehicle)
    {
        Maker = vehicle.Maker;
        LicensePlate = vehicle.LicensePlate switch
        {
            DeLicensePlate de => new DeLicensePlateEntity(de),
            FrLicensePlate fr => new FrLicensePlateEntity(fr),
            _ => throw new InvalidOperationException("Unknown license plate type")
        };
        LicensePlateValue = vehicle.LicensePlate.Value;
        Engine = vehicle.Engine switch
        {
            ElectricalEngine electrical => new ElectricalEngineEntity(electrical),
            ThermalEngine thermal => new ThermalEngineEntity(thermal),
            _ => throw new InvalidOperationException("Unknown engine type")
        };
    }

    public abstract Vehicle ToDomainModel();
}