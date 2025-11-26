namespace TrafficVision.Domain.Entities;

public sealed class VehicleRestriction
{
    #region Properties
    public EnumTheftVehicleCondition TheftVehicleCondition { get; private set; }
    public bool Wrecked { get; private set; }
    public bool JudicialRestriction { get; private set; }
    public bool Auction { get; private set; }
    #endregion

    #region Constructors
    public VehicleRestriction() { }

    public VehicleRestriction(EnumTheftVehicleCondition theftVehicleCondition, bool wrecked, bool judicialRestriction, bool auction)
    {
        EnumTheftVehicleCondition validatedTheftVehicleCondition = theftVehicleCondition != null ? theftVehicleCondition : EnumTheftVehicleCondition.Nenhum;
        bool validatedWrecked = wrecked != null ? wrecked : false;
        bool validatedJudicialRestriction = judicialRestriction != null ? judicialRestriction : false;
        bool validatedAuction = auction != null ? auction : false;


        TheftVehicleCondition = validatedTheftVehicleCondition;
        Wrecked = validatedWrecked;
        JudicialRestriction = validatedJudicialRestriction;
        Auction = validatedAuction;
    }
    #endregion

    #region Create/Update
    public static VehicleRestriction Create(EnumTheftVehicleCondition enumTheftVehicleCondition, bool wrecked, bool judicialRestriction, bool auction)
    {
        return new VehicleRestriction(enumTheftVehicleCondition, wrecked, judicialRestriction, auction);
    }

    public void Update(EnumTheftVehicleCondition enumTheftVehicleCondition, bool wrecked, bool judicialRestriction, bool auction)
    {
        EnumTheftVehicleCondition validatedTheftVehicleCondition = enumTheftVehicleCondition != null ? enumTheftVehicleCondition : EnumTheftVehicleCondition.Nenhum;
        bool validatedWrecked = wrecked != null ? wrecked : false;
        bool validatedJudicialRestriction = judicialRestriction != null ? judicialRestriction : false;
        bool validatedAuction = auction != null ? auction : false;

        TheftVehicleCondition = validatedTheftVehicleCondition;
        Wrecked = validatedWrecked;
        JudicialRestriction = validatedJudicialRestriction;
        Auction = validatedAuction;
    }
    #endregion
}
