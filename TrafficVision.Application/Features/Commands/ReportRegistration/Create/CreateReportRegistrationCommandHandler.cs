using MediatR;
using TrafficVision.Application.Result;
using TrafficVision.Domain.Entities;

namespace TrafficVision.Application.Features.Commands;

public sealed class CreateReportRegistrationCommandHandler : IRequestHandler<CreateReportRegistrationCommand, Result<ReportRegistration>>
{
    public Task<Result<ReportRegistration>> Handle(CreateReportRegistrationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
