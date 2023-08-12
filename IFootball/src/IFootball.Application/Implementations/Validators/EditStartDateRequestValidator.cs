using FluentValidation;
using IFootball.Application.Contracts.Documents.Requests.StartDate;

namespace IFootball.Application.Implementations.Validators;

public class EditStartDateRequestValidator : AbstractValidator<EditStartDateRequest>
{
    public EditStartDateRequestValidator()
    {
        RuleFor(x => x.StartDateOfMatches)
            .NotNull().WithMessage("A data de início deve ser preenchida");
    }
}