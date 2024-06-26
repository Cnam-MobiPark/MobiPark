using System.Text.RegularExpressions;

namespace MobiPark.Domain.Models.Vehicle.LicensePlate;

public class FrLicensePlate : AbstractLicensePlate
{
    public FrLicensePlate(string value) : base(value)
    {
    }

    protected override bool IsValid(string value)
    {
        // French license plate format: XX-000-XX
        var regex = new Regex("(^[A-Z]{2}-[0-9]{3}-[A-Z]{2}$)");
        return regex.IsMatch(value);
    }
}