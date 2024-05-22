using MobiPark.Domain.Interfaces;
using MobiPark.Domain.Models;

namespace MobiPark.Domain.Test.Repository
{
    public class PricingRepository : IPricingRepository
    {
        private readonly List<Pricing> _pricings;

        public PricingRepository()
        {
            _pricings = new List<Pricing>
            {
                new Pricing { VehicleType = Vehicle.VehicleType.Car, Price = 5 },
                new Pricing { VehicleType = Vehicle.VehicleType.Motorcycle, Price = 3 }
            };
        }

        public Pricing GetPricing(string vehicleType)
        {
            if (_pricings == null)
                throw new InvalidOperationException("Pricing data is not initialized.");

            var pricing = _pricings.FirstOrDefault(p => p.VehicleType.ToString().Equals(vehicleType, StringComparison.OrdinalIgnoreCase));

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

        public double CalculatePrice(string vehicleType, DateTime startTime, DateTime endTime, bool isElectricCharging)
        {
            var pricing = GetPricing(vehicleType);
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