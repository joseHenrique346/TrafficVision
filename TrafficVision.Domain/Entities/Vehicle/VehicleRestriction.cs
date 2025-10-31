using TrafficVision.Domain.Entities.Vehicle.Enum;

namespace TrafficVision.Domain.Entities.Vehicle;

public sealed class VehicleRestriction
{
    public EnumTheftVehicleCondition TheftVehicleCondition { get; private set; }
    public bool Wrecked { get; private set; }
    public bool JudicialRestriction { get; private set; }
    public bool Auction { get; private set; }

    public VehicleRestriction(EnumTheftVehicleCondition theftVehicleCondition, bool wrecked, bool judicialRestriction, bool auction)
    {
        EnumTheftVehicleCondition validatedTheftVehicleCondition = theftVehicleCondition != null ? theftVehicleCondition : EnumTheftVehicleCondition.None;
        bool validatedWrecked = wrecked != null ? wrecked : false;
        bool validatedJudicialRestriction = judicialRestriction != null ? judicialRestriction : false;
        bool validatedAuction = auction != null ? auction : false;


        TheftVehicleCondition = validatedTheftVehicleCondition;
        Wrecked = validatedWrecked;
        JudicialRestriction = validatedJudicialRestriction;
        Auction = validatedAuction;
    }
    
    public static VehicleRestriction Create(EnumTheftVehicleCondition enumTheftVehicleCondition, bool wrecked, bool judicialRestriction, bool auction)
    {
        return new VehicleRestriction(enumTheftVehicleCondition, wrecked, judicialRestriction, auction);
    }

    public void Update(EnumTheftVehicleCondition enumTheftVehicleCondition, bool wrecked, bool judicialRestriction, bool auction)
    {
        EnumTheftVehicleCondition validatedTheftVehicleCondition = enumTheftVehicleCondition != null ? enumTheftVehicleCondition : EnumTheftVehicleCondition.None;
        bool validatedWrecked = wrecked != null ? wrecked : false;
        bool validatedJudicialRestriction = judicialRestriction != null ? judicialRestriction : false;
        bool validatedAuction = auction != null ? auction : false;

        TheftVehicleCondition = validatedTheftVehicleCondition;
        Wrecked = validatedWrecked;
        JudicialRestriction = validatedJudicialRestriction;
        Auction = validatedAuction;
    }
}
