using MediatR;
using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;

namespace TrafficVision.Application.Features.Commands;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<User>>
{
    private readonly IWriteUserRepository _writeUserRepository;
    private readonly IReadUserRepository _readUserRepository;

    public CreateUserCommandHandler(IWriteUserRepository writeUserRepository, IReadUserRepository readUserRepository)
    {
        _writeUserRepository = writeUserRepository;
        _readUserRepository = readUserRepository;
    }

    public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var result = new Result<User>();
        
        var existingUser = await _readUserRepository.GetByEmailAsync(request.UserEmail);
        if (existingUser != null)
            return result.ExternalError($"Usuário com o email: {request.UserEmail} já registrado");

        var validatedUser = User.Create(request.UserName, request.UserRole, request.UserEmail, request.UserPassword);

        await _writeUserRepository.AddAsync(validatedUser);
        return result.Success(validatedUser);
    }
}
