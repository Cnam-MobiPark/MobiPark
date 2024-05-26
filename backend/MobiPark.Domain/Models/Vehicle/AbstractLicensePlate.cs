using MobiPark.Domain.Exceptions;

namespace MobiPark.Domain.Models.Vehicle
{
    public abstract class AbstractLicensePlate
    {
        public string Value { get; protected set; }

        protected AbstractLicensePlate(string value)
        {
            if (!IsValid(value))
            {
                throw new InvalidLicensePlateException(value);
            }
            
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullLicensePlateException();
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