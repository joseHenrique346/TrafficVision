using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TrafficVision.Application.Features.Commands.User.Create;

internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(report => report.UserId)
            .NotNull().WithMessage("O usuário precisa ser informado.");
        RuleFor(report => report.UserName)
            .NotNull().WithMessage("O nome do usuário precisa ser informado");
        RuleFor(report => report.UserEmail)
            .NotEmpty().WithMessage("O campo de email do usuário não pode ser vazio.")
            .NotNull().WithMessage("O email do usuário precisa ser informado");
        RuleFor(report => report.UserPassword)
            .NotEmpty().WithMessage("O campo do password do usuário não pode ser vazio.")
            .NotNull().WithMessage("O password do usuário precisa ser informado");
        RuleFor(report => report.UserRole)
            .NotEmpty().WithMessage("O UserRole não pode ser vazio.");

    }
}