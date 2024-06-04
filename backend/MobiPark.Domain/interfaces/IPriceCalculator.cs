using MobiPark.Domain.Models;
using MobiPark.Domain.Models.Vehicle;

namespace MobiPark.Domain.Interfaces;

public interface IPriceCalculator
{
    public int CalculatePrice(Reservation reservation);
}