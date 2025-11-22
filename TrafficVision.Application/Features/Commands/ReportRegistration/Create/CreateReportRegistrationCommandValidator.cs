using FluentValidation;

namespace TrafficVision.Application.Features.Commands;

public class CreateReportRegistrationCommandValidator : AbstractValidator<CreateReportRegistrationCommand>
{
    public CreateReportRegistrationCommandValidator()
    {
        RuleFor(report => report.UserId)
            .NotNull().WithMessage("O usuário precisa ser informado.");
    }
}