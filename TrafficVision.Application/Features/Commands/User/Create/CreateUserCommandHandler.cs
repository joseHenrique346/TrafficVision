using MediatR;
using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;

namespace TrafficVision.Application.Features.Commands.User.Create;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<ReportRegistration>>
{
    private readonly IWriteUserRepository _writeUserRepository;
    private readonly IReadUserRepository _readUserRepository;

    public CreateUserCommandHandler(IWriteUserRepository writeUserRepository, IReadUserRepository readUserRepository)
    {
        _writeUserRepository = writeUserRepository;
        _readUserRepository = readUserRepository;
    }

    public Task<Result<ReportRegistration>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
