using TrafficVision.Domain.Entities.Base;
using TrafficVision.Domain.Entities.Vehicle.Enum;

namespace TrafficVision.Domain.Entities.Vehicle;

public sealed class VehicleSpec
{
    #region Properties
    public string Plate { get; private set; }
    public string Renavam { get; private set; }
    public string Chassis { get; private set; }
    public string Municipality { get; private set; }
    public string State { get; private set; }
    public EnumDataVehicleCondition DataVehicleCondition { get; private set; }
    public EnumTypeFuelVehicle EnumTypeFuelVehicle { get; private set; }
    public VehicleRestriction VehicleRestriction { get; private set; }
    public VehicleOwner Owner { get; private set; }
    #endregion

    #region Constructors
    public VehicleSpec() { }

    public VehicleSpec(string plate, string renavam, string chassis, string municipality, string state, EnumDataVehicleCondition dataVehicleCondition, EnumTypeFuelVehicle enumTypeFuelVehicle, VehicleRestriction vehicleRestriction, VehicleOwner owner)
    {
        BaseValidate.NullOrWhiteSpace(plate, $"{Plate}");
        BaseValidate.NullOrWhiteSpace(renavam, $"{Renavam}");
        BaseValidate.NullOrWhiteSpace(chassis, $"{Chassis}");
        BaseValidate.NullOrWhiteSpace(municipality, $"{Municipality}");
        BaseValidate.NullOrWhiteSpace(state, $"{State}");

        EnumDataVehicleCondition validatedEnumDataVehicleCondition = dataVehicleCondition != null ? dataVehicleCondition : throw new ArgumentException("O dado do carro precisa ser válido");
        EnumTypeFuelVehicle validatedEnumTypeFuelVehicle = enumTypeFuelVehicle != null ? enumTypeFuelVehicle : throw new ArgumentException("O dado do carro precisa ser válido");

        VehicleRestriction validatedRestriction = VehicleRestriction.Create(vehicleRestriction.TheftVehicleCondition, vehicleRestriction.Wrecked, vehicleRestriction.JudicialRestriction, vehicleRestriction.Auction);
        VehicleOwner validatedOwner = VehicleOwner.Create(owner.Name, owner.CpfCnpj, owner.Cnh);

        Plate = plate;
        Renavam = renavam;
        Chassis = chassis;
        Municipality = municipality;
        State = state;
        DataVehicleCondition = validatedEnumDataVehicleCondition;
        EnumTypeFuelVehicle = validatedEnumTypeFuelVehicle;
        VehicleRestriction = validatedRestriction;
        Owner = validatedOwner;
    }
    #endregion

    #region Create/Update
    public static VehicleSpec Create(string plate, string renavam, string chassis, string municipality, string state, EnumDataVehicleCondition dataVehicleCondition, EnumTypeFuelVehicle enumTypeFuelVehicle, VehicleRestriction vehicleRestriction, VehicleOwner owner)
    {
        return new VehicleSpec(plate, renavam, chassis, municipality, state, dataVehicleCondition, enumTypeFuelVehicle, vehicleRestriction, owner);
    }

    public void Update(string plate, string renavam, string chassis, string municipality, string state, EnumDataVehicleCondition dataVehicleCondition, EnumTypeFuelVehicle enumTypeFuelVehicle, VehicleRestriction vehicleRestriction, VehicleOwner owner)
    {
        BaseValidate.NullOrWhiteSpace(plate, $"{Plate}");
        BaseValidate.NullOrWhiteSpace(renavam, $"{Renavam}");
        BaseValidate.NullOrWhiteSpace(chassis, $"{Chassis}");
        BaseValidate.NullOrWhiteSpace(municipality, $"{Municipality}");
        BaseValidate.NullOrWhiteSpace(state, $"{State}");

        EnumDataVehicleCondition validatedEnumDataVehicleCondition = dataVehicleCondition != null ? dataVehicleCondition : throw new ArgumentException("O dado do carro precisa ser válido");
        EnumTypeFuelVehicle validatedEnumTypeFuelVehicle = enumTypeFuelVehicle != null ? enumTypeFuelVehicle : throw new ArgumentException("O dado do carro precisa ser válido");

        VehicleRestriction validatedRestriction = VehicleRestriction.Create(vehicleRestriction.TheftVehicleCondition, vehicleRestriction.Wrecked, vehicleRestriction.JudicialRestriction, vehicleRestriction.Auction);
        VehicleOwner validatedOwner = VehicleOwner.Create(owner.Name, owner.CpfCnpj, owner.Cnh);

        Plate = plate;
        Renavam = renavam;
        Chassis = chassis;
        Municipality = municipality;
        State = state;
        DataVehicleCondition = validatedEnumDataVehicleCondition;
        EnumTypeFuelVehicle = validatedEnumTypeFuelVehicle;
        VehicleRestriction = validatedRestriction;
        Owner = validatedOwner;
    }
    #endregion
}