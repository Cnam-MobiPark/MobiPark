using MobiPark.Domain.Models;

namespace MobiPark.Domain.Interfaces;

public interface IPriceCalculator
{
    public int CalculatePrice(Reservation reservation);
}