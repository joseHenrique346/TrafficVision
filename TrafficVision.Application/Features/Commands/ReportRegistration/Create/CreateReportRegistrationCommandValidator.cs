using FluentValidation;

namespace TrafficVision.Application.Features.Commands;

public class CreateReportRegistrationCommandValidator : AbstractValidator<CreateReportRegistrationCommand>
{
    public CreateReportRegistrationCommandValidator()
    {
        RuleFor(report => report.UserId)
            .NotNull().WithMessage("O usuário precisa ser informado.");

        RuleFor(report => report.Plate)
            .NotEmpty().WithMessage("O campo da placa do carro não pode ser vazio.")
            .NotNull().WithMessage("A placa do carro precisa ser informada.");
    }
}