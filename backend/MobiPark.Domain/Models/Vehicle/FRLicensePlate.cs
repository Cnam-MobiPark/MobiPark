namespace MobiPark.Domain.Models.Vehicle
{
    public class FrLicensePlate : AbstractLicensePlate
    {
        public FrLicensePlate(string value) : base(value)
        {
        }

        protected override bool IsValid(string value)
        {
            // French license plate format: XX-000-XX
            var regex = new System.Text.RegularExpressions.Regex("(^[A-Z]{2}-[0-9]{3}-[A-Z]{2}$)");
            return regex.IsMatch(value);
        }
    }
}