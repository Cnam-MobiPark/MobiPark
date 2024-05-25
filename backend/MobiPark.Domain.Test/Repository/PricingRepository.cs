using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Test.Repository
{
    public class PricingRepository : IPricingRepository
    {
        private readonly List<Pricing> _pricings;

        public PricingRepository()
        {
            _pricings = new List<Pricing>
            {
                new Pricing { Vehicle = new Car(), Price = 5 },
                new Pricing { Vehicle = new Motorcycle(), Price = 3 }
            };
        }

        public Pricing GetPricing(string vehicleType)
        {
            if (string.IsNullOrWhiteSpace(vehicleType))
            {
                throw new ArgumentException("Vehicle type cannot be null or empty", nameof(vehicleType));
            }

            var pricing = _pricings.FirstOrDefault(p => p.Vehicle.GetType().Name == vehicleType);
            if (pricing == null)
            {
                throw new PricingNotFoundException(vehicleType);
            }

            return pricing;
        }

        public void AddPricing(Pricing pricing)
        {
            if (_pricings == null)
                throw new InvalidOperationException("Pricing data is not initialized.");

            _pricings.Add(pricing);
        }

        public double CalculatePrice(Vehicle vehicle, DateTime startTime, DateTime endTime, bool isElectricCharging)
        {
            var vehicleTypeName = vehicle.GetType().Name;
            var pricing = GetPricing(vehicleTypeName);
            if (pricing == null)
            {
                throw new PricingNotFoundException(vehicleTypeName);
            }

            var price = pricing.Price;
            if (isElectricCharging)
            {
                price += 2;
            }

            var duration = endTime - startTime;
            var hours = (int)Math.Ceiling(duration.TotalHours);
            price *= hours;

            return price;
        }


    }
}