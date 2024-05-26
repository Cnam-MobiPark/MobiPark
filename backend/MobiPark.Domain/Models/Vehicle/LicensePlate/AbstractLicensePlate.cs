using MobiPark.Domain.Exceptions;

namespace MobiPark.Domain.Models.Vehicle.LicensePlate
{
    public abstract class AbstractLicensePlate
    {
        public string Value { get; protected set; }

        protected AbstractLicensePlate(string value)
        {
            if ((string.IsNullOrWhiteSpace(value)) || (!IsValid(value)))
            {
                throw new InvalidLicensePlateException(value);
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