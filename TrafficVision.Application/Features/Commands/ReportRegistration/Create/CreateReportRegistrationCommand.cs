using MediatR;
using TrafficVision.Domain.Entities;

namespace TrafficVision.Application.Features.Commands;

public record class CreateReportRegistrationCommand(long UserId, string Plate) : IRequest<Result<ReportRegistration>>;
