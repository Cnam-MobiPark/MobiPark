using System.Text.Json.Serialization;

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
}