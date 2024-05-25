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
            if (_pricings == null)
                throw new InvalidOperationException("Pricing data is not initialized.");

            var pricing = _pricings.FirstOrDefault(p => Type.GetType(p.Vehicle.ToString()).Name == vehicleType);

            if (pricing == null)
                throw new KeyNotFoundException($"No pricing found for vehicle type: {vehicleType}");

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
            var pricing = GetPricing(Type.GetType(vehicle.ToString()).Name);
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