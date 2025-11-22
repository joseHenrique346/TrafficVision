using FluentValidation;

namespace TrafficVision.Application.Features.Commands;

internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.UserName)
            .NotNull().WithMessage("O nome do usuário precisa ser informado");
        RuleFor(user => user.UserEmail)
            .NotEmpty().WithMessage("O campo de email do usuário não pode ser vazio.")
            .NotNull().WithMessage("O email do usuário precisa ser informado");
        RuleFor(user => user.UserPassword)
            .NotEmpty().WithMessage("O campo do password do usuário não pode ser vazio.")
            .NotNull().WithMessage("O password do usuário precisa ser informado");
        RuleFor(user => user.UserRole)
            .NotEmpty().WithMessage("O UserRole não pode ser vazio.");
    }
}