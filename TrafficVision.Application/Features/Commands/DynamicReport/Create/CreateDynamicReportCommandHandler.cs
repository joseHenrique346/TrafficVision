using MediatR;
using TrafficVision.Application.Interface;
using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;

namespace TrafficVision.Application.Features.Commands;

public sealed class CreateDynamicReportCommandHandler : IRequestHandler<CreateDynamicReportCommand, Result<byte[]>>
{
    private readonly IDynamicReportQueryRepository _queryRepository;
    private readonly IDynamicReportExporter _exporter;

    public CreateDynamicReportCommandHandler(IDynamicReportQueryRepository queryRepository, IDynamicReportExporter exporter)
    {
        _queryRepository = queryRepository;
        _exporter = exporter;
    }

    public async Task<Result<byte[]>> Handle(CreateDynamicReportCommand request, CancellationToken cancellationToken)
    {
        var result = new Result<byte[]>();

        var dynamicReport = DynamicReport.Create(
            request.InitialDate,
            request.FinalDate,
            request.ListColor,
            request.Wrecked,
            request.JudicialRestriction,
            request.Auction,
            request.ListModel,
            request.ListBrand,
            request.ListMunicipality,
            request.ListState,
            request.TheftVehicleCondition
        );

        var vehicles = await _queryRepository.QueryAsync(dynamicReport, cancellationToken);

        var pdfBytes = await _exporter.ExportToPdfAsync(dynamicReport, vehicles);

        return result.Success(pdfBytes);
    }
}

