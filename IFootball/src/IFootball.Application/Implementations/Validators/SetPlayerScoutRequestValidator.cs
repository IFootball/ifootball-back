using FluentValidation;
using IFootball.Application.Contracts.Documents.Requests.Player;

namespace IFootball.Application.Implementations.Validators;

public class SetPlayerScoutRequestValidator : AbstractValidator<SetPlayerScoutRequest>
{
    public SetPlayerScoutRequestValidator()
    {
        RuleFor(x => x.Goals)
            .NotNull().WithMessage("Insira o número de gols")
            .GreaterThan(0).WithMessage("O número de gols deve ser maior que 0.");

        RuleFor(x => x.Assists)
            .NotNull().WithMessage("Insira o número de assistencias")
            .GreaterThan(0).WithMessage("O número de assistencias deve ser maior que 0.");

        RuleFor(x => x.YellowCard)
            .NotNull().WithMessage("Insira o número de cartões amarelos")
            .GreaterThan(0).WithMessage("O número de cartões amarelos deve ser maior que 0.");
        
        RuleFor(x => x.RedCard)
            .NotNull().WithMessage("Insira o número de cartões vermelhos")
            .GreaterThan(0).WithMessage("O número de cartões vermelhos deve ser maior que 0.");

        RuleFor(x => x.Fouls)
            .NotNull().WithMessage("Insira o número de faltas")
            .GreaterThan(0).WithMessage("O número de faltas deve ser maior que 0.");
        
        RuleFor(x => x.Wins)
            .NotNull().WithMessage("Insira o número de vitórias")
            .GreaterThan(0).WithMessage("O número de vitórias deve ser maior que 0.");

    }   
}

