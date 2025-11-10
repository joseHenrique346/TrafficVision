using MediatR;

namespace TrafficVision.Application.Features.Commands;

public record class CreateReportRegistrationCommand(long userId, string plate) : IRequest<long>;