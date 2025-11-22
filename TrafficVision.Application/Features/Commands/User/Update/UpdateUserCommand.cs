using TrafficVision.Domain.Entities;

namespace TrafficVision.Application.Features.Commands;
public record UpdateUserCommand(long UserId, string UserName, EnumUserRole UserRole, string UserEmail, string UserPassword) { }
