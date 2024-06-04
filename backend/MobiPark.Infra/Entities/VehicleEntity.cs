using MobiPark.Domain.Models.Vehicle;
using MobiPark.Domain.Models.Vehicle.Engine;
using MobiPark.Domain.Models.Vehicle.LicensePlate;

namespace MobiPark.Infra.Entities;

public enum VehicleType
{
    Car,
    Motorcycle
}
public enum LicensePlateType
{
    FR,
    DE
}

public enum EngineType
{
    Thermal,
    Electrical
}
public class VehicleEntity
{
    public string Plate { get; set; }
    public LicensePlateType PlateType { get; set; }
    public string Maker { get; set; }
    public int BatteryCapacity { get; set; }
    public int CurrentBatteryCapacity { get; set; }
    public EngineType EngineType { get; set; }
    public VehicleType VehicleType { get; set; }
    public ReservationEntity Reservation { get; set; }

    public VehicleEntity() { }

    public VehicleEntity(Vehicle vehicle)
    {
        Maker = vehicle.Maker;    
        Plate = vehicle.LicensePlate.Value;
        PlateType = (vehicle.LicensePlate is FrLicensePlate) ? LicensePlateType.FR : LicensePlateType.DE;                    

        if (vehicle.Engine is ThermalEngine thermalEngine)
        {            
            EngineType = EngineType.Thermal;
        }
        else if (vehicle.Engine is ElectricalEngine electricalEngine)
        {           
            BatteryCapacity = electricalEngine.BatteryCapacity;
            CurrentBatteryCapacity = electricalEngine.CurrentBatteryCapacity;
            EngineType = EngineType.Electrical;
        }

        VehicleType = vehicle is Car ? VehicleType.Car : VehicleType.Motorcycle;
    }

    public Vehicle ToDomainModel()
    {
        AbstractLicensePlate plate;
        if(PlateType == LicensePlateType.FR)
            plate = new FrLicensePlate(Plate);
        else
            plate = new DeLicensePlate(Plate);

        Engine engine;
        if (EngineType == EngineType.Thermal)
            engine = new ThermalEngine();
        else
           engine = new ElectricalEngine(BatteryCapacity, CurrentBatteryCapacity);

        if(VehicleType == VehicleType.Car)        
            return new Car(Maker, plate, engine);        
        else
            return new Motorcycle(Maker, plate, engine);              
    }
}