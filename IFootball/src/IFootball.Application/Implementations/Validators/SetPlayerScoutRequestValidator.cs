using FluentValidation;
using IFootball.Application.Contracts.Documents.Requests.Player;

namespace IFootball.Application.Implementations.Validators;

public class SetPlayerScoutRequestValidator : AbstractValidator<SetPlayerScoutRequest>
{
    public SetPlayerScoutRequestValidator()
    {
        RuleFor(x => x.Goals)
            .NotNull().WithMessage("Insira o número de gols");
        
        RuleFor(x => x.Assists)
            .NotNull().WithMessage("Insira o número de assistencias");
        
        RuleFor(x => x.YellowCard)
            .NotNull().WithMessage("Insira o número de cartões amarelos");
        
        RuleFor(x => x.RedCard)
            .NotNull().WithMessage("Insira o número de cartões vermelhos");
        
        RuleFor(x => x.Fouls)
            .NotNull().WithMessage("Insira o número de faltas");
        
        RuleFor(x => x.Wins)
            .NotNull().WithMessage("Insira o número de gols");
    }   
}

