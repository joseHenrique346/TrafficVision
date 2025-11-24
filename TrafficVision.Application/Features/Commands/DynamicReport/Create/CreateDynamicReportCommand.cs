using MediatR;

namespace TrafficVision.Application.Features.Commands;

public record class CreateDynamicReportCommand(long UserId, DateTime InitialDate, DateTime? FinalDate, List<string> ListColor, bool Wrecked, bool JudicialRestriction, bool Auction, List<string> ListModel, List<string> ListBrand, List<string> ListMunicipality, List<string> ListState, EnumTheftVehicleCondition TheftVehicleCondition) : IRequest<Result<byte[]>> { }