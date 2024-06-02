using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Infra.Entities;

public class FrLicensePlateEntity : LicensePlateEntity
{
    public FrLicensePlateEntity() { }

    public FrLicensePlateEntity(FrLicensePlate licensePlate)
    {
        Value = licensePlate.Value;
    }

    public override AbstractLicensePlate ToDomainModel()
    {
        return new FrLicensePlate(Value);
    }
}