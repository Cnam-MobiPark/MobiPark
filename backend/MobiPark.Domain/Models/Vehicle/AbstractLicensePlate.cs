namespace MobiPark.Domain.Models.Vehicle
{
    public abstract class AbstractLicensePlate
    {
        public string Value { get; protected set; }

        protected AbstractLicensePlate(string value)
        {
            if (!IsValid(value))
            {
                throw new ArgumentException("Invalid license plate format.");
            }
            Value = value;
        }

        protected abstract bool IsValid(string value);

        public override string ToString()
        {
            return Value;
        }
    }
}