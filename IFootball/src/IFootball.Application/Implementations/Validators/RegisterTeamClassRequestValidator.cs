using FluentValidation;
using IFootball.Application.Contracts.Documents.Requests.TeamClass;

namespace IFootball.Application.Implementations.Validators;

public class RegisterTeamClassRequestValidator : AbstractValidator<RegisterTeamClassRequest>
{
    public RegisterTeamClassRequestValidator()
    {
        RuleFor(x => x.IdGender)
            .NotNull().WithMessage("O gênero deve ser preenchido");

        RuleFor(x => x.IdClass)
            .NotNull().WithMessage("O turma deve ser preenchida");        
    }

}