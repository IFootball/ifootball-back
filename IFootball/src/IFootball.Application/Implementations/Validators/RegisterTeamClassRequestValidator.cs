using FluentValidation;
using IFootball.Application.Contracts.Documents.Requests.TeamClass;

namespace IFootball.Application.Implementations.Validators;

public class RegisterTeamClassRequestValidator : AbstractValidator<RegisterTeamClassRequest>
{
    public RegisterTeamClassRequestValidator()
    {
        RuleFor(x => x.IdGender)
            .NotNull().WithMessage("O gênero deve ser preenchido")
            .GreaterThan(0).WithMessage("O gênero deve ser maior que 0.");


        RuleFor(x => x.IdClass)
            .NotNull().WithMessage("O turma deve ser preenchida")
            .GreaterThan(0).WithMessage("A turma deve ser maior que 0.");

    }

}