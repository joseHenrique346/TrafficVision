using MediatR;
using TrafficVision.Domain.Entities;

namespace TrafficVision.Application.Features.Commands;
public record class CreateUserCommand(string UserName, EnumUserRole UserRole, string UserEmail, string UserPassword) : IRequest<Result<User>>;