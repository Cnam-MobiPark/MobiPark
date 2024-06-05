using MobiPark.Domain.Exceptions;
using MobiPark.Domain.Interfaces;

namespace MobiPark.Domain.UseCases;

public class ParkVehicleUseCase(IVehicleRepository vehicleRepository, IParkingRepository parkingRepository)
{
    public void Execute(string licensePlate)
    {
        var vehicle = vehicleRepository.FindByPlate(licensePlate);
        if (vehicle == null) throw new NotFoundException("Vehicle not found");
        var firstAvailableSpace = parkingRepository.GetAvailableSpaces(vehicle).FirstOrDefault();
        if (firstAvailableSpace == null) throw new InvalidOperationException("No available parking spaces");
        parkingRepository.ParkVehicle(vehicle, firstAvailableSpace);
    }
}