using MediatR;
using Microsoft.AspNetCore.Http;
using TrafficVision.Domain.Entities;

namespace TrafficVision.Application.Features.Commands;

public record class CreateReportRegistrationCommand(long UserId, string? Plate, IFormFile? File) : IRequest<Result<ReportRegistration>>;
