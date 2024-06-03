using System.Text.Json.Serialization;
using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.App.DTO;

public class CreateLicensePlateDTO
{
    public string Type { get; private set; }
    public string Value { get; private set; }

    [JsonConstructor]
    public CreateLicensePlateDTO(string type, string value)
    {
        Type = type;
        Value = value;
    }

    public AbstractLicensePlate ToDomainModel()
    {
        return Type switch
        {
            "FR" => new FrLicensePlate(Value),
            "DE" => new DeLicensePlate(Value),
            _ => throw new ArgumentException("Invalid license plate type")
        };
    }
}