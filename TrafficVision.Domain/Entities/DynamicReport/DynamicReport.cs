using TrafficVision.Domain.Entities.Base;

namespace TrafficVision.Domain.Entities;

public sealed class DynamicReport : BaseEntity
{
    #region Properties
    public DateTime InitialDate { get; private set; }
    public DateTime? FinalDate { get; private set; }
    public List<string> ListColor { get; private set; } = [];
    public bool Wrecked { get; private set; }
    public bool JudicialRestriction { get; private set; }
    public bool Auction { get; private set; }
    public List<string> ListModel { get; private set; } = [];
    public List<string> ListBrand { get; private set; } = [];
    public List<string> ListMunicipality { get; private set; } = [];
    public List<string> ListState { get; private set; } = [];
    public EnumTheftVehicleCondition TheftVehicleCondition { get; private set; }
    #endregion

    #region Constructors
    public DynamicReport() { }

    public DynamicReport(DateTime initialDate, DateTime? finalDate, List<string> listColor, bool wrecked, bool judicialRestriction, bool auction, List<string> listModel, List<string> listBrand, List<string> listMunicipality, List<string> listState, EnumTheftVehicleCondition theftVehicleCondition)
    {
        InitialDate = initialDate;
        FinalDate = finalDate;
        ListColor = listColor;
        Wrecked = wrecked;
        JudicialRestriction = judicialRestriction;
        Auction = auction;
        ListModel = listModel;
        ListBrand = listBrand;
        ListMunicipality = listMunicipality;
        ListState = listState;
        TheftVehicleCondition = theftVehicleCondition;
    }
    #endregion

    #region Create
    public static DynamicReport Create(DateTime initialDate, DateTime? finalDate, List<string> listColor, bool wrecked, bool judicialRestriction, bool auction, List<string> listModel, List<string> listBrand, List<string> listMunicipality, List<string> listState, EnumTheftVehicleCondition theftVehicleCondition)
    {
        BaseValidate.DateRange(initialDate, finalDate);

        BaseValidate.ListNullOrWhiteSpace(listColor);
        BaseValidate.ListNullOrWhiteSpace(listModel);
        BaseValidate.ListNullOrWhiteSpace(listBrand);
        BaseValidate.ListNullOrWhiteSpace(listMunicipality);
        BaseValidate.ListNullOrWhiteSpace(listState);

        return new DynamicReport(initialDate, finalDate, listColor, wrecked, judicialRestriction, auction, listModel, listBrand, listMunicipality, listState, theftVehicleCondition);
    }
    #endregion
}