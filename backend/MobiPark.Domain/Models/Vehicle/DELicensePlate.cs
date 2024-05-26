namespace MobiPark.Domain.Models.Vehicle
{
    public class DeLicensePlate : AbstractLicensePlate
    {
        public DeLicensePlate(string value) : base(value)
        {
        }

        protected override bool IsValid(string value)
        {
            // German license plate format: ABC X 1234
            var regex = new System.Text.RegularExpressions.Regex("^[A-Z]{1,3} [A-Z]{1,2} [0-9]{1,4}$");
            return regex.IsMatch(value);
        }
    }
}