using MobiPark.Domain.Models;
using MobiPark.Domain.Services;

namespace MobiPark.Domain.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ParkVehicle()
    {
        var repository = new ParkingRepository();
        var service = new ParkingService(repository);
        var space = service.ParkVehicle(1, 1);
        Assert.AreEqual("occupied", space.Status);
        Assert.AreEqual(1, space.Vehicle.Id);
    }
}