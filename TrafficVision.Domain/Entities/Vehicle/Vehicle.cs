using TrafficVision.Domain.Entities.Base;

namespace TrafficVision.Domain.Entities;

public sealed class Vehicle : BaseEntity
{
    #region Properties
    public string Model { get; private set; }
    public int Year { get; private set; }
    public string Brand { get; private set; }
    public string Color { get; private set; }
    public VehicleSpec VehicleSpec { get; private set; }
    #endregion

    #region Constructors
    public Vehicle() { }

    public Vehicle(string model, int year, string brand, string color, VehicleSpec vehicleSpec)
    {
        BaseValidate.NullOrWhiteSpace(year.ToString(), $"{Year}");
        BaseValidate.AnnualPeriod(year);
        BaseValidate.NullOrWhiteSpace(model, $"{Model}");
        BaseValidate.NullOrWhiteSpace(brand, $"{Brand}");
        BaseValidate.NullOrWhiteSpace(color, $"{Color}");

        VehicleSpec specs = VehicleSpec.Create(vehicleSpec.Plate, vehicleSpec.Renavam, vehicleSpec.Chassis, vehicleSpec.Municipality, vehicleSpec.State, vehicleSpec.DataVehicleCondition, vehicleSpec.EnumTypeFuelVehicle, vehicleSpec.VehicleRestriction, vehicleSpec.Owner);

        Model = model;
        Year = year;
        Brand = brand;
        Color = color;
        VehicleSpec = specs;
    }
    #endregion

    #region Create/Update

    public static Vehicle Create(string model, int year, string brand, string color, VehicleSpec vehicleSpec)
    {
        return new Vehicle(model, year, brand, color, vehicleSpec);
    }

    public void Update(string model, int year, string brand, string color, VehicleSpec vehicleSpec)
    {
        BaseValidate.NullOrWhiteSpace(year.ToString(), $"{Year}");
        BaseValidate.AnnualPeriod(year);
        BaseValidate.NullOrWhiteSpace(model, $"{Model}");
        BaseValidate.NullOrWhiteSpace(brand, $"{Brand}");
        BaseValidate.NullOrWhiteSpace(color, $"{Color}");

        VehicleSpec specs = VehicleSpec.Create(vehicleSpec.Plate, vehicleSpec.Renavam, vehicleSpec.Chassis, vehicleSpec.Municipality, vehicleSpec.State, vehicleSpec.DataVehicleCondition, vehicleSpec.EnumTypeFuelVehicle, vehicleSpec.VehicleRestriction, vehicleSpec.Owner);

        Model = model;
        Year = year;
        Brand = brand;
        Color = color;
        VehicleSpec = specs;
    }

    #endregion
}