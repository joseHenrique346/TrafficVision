using TrafficVision.Domain.Entities;

namespace TrafficVision.Application.Features.Commands.User.Update;
public record UpdateUserCommand(long UserId, string UserName, EnumUserRole UserRole, string UserEmail, string UserPassword) { }
