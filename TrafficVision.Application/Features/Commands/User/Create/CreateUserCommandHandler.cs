using MediatR;
using TrafficVision.Application.Result;
using TrafficVision.Domain.Entities;

namespace TrafficVision.Application.Features.Commands.User.Create;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<ReportRegistration>>
{
    public Task<Result<ReportRegistration>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
