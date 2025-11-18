using MediatR;
using TrafficVision.Domain.Entities;

namespace TrafficVision.Application.Features.Commands.User.Create;

internal record class CreateUserCommand(string UserName, EnumUserRole UserRole, string UserEmail, string UserPassword) : IRequest<Result<ReportRegistration>>;