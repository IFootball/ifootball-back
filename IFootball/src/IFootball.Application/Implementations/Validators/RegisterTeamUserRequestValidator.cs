using FluentValidation;
using IFootball.Application.Contracts.Documents.Requests;

namespace IFootball.Application.Implementations.Validators;

public class RegisterTeamUserRequestValidator : AbstractValidator<RegisterTeamUserRequest>
{
    public RegisterTeamUserRequestValidator()
    {
        RuleFor(x => x.IdLinePlayerOne)
            .NotNull().WithMessage("O jogador um deve ser preenchido");
        RuleFor(x => x.IdLinePlayerTwo)
            .NotNull().WithMessage("O jogador dois deve ser preenchido");
        RuleFor(x => x.IdLinePlayerThree)
            .NotNull().WithMessage("O jogador três deve ser preenchido");
        RuleFor(x => x.IdLinePlayerFour)
            .NotNull().WithMessage("O jogador quatro deve ser preenchido");
        RuleFor(x => x.IdGoalkeeper)
            .NotNull().WithMessage("O goleiro um deve ser preenchido");

        RuleFor(x => x.IdCaptain)
            .Must((team, idCaptain) => IsCaptainValid(team, idCaptain.GetValueOrDefault()))
            .WithMessage("O capitão deve estar no time");
        
        RuleFor(x => x)
            .Must(AllIdsAreDifferent)
            .WithMessage("Todos os jogadores devem ser diferentes entre si");
    }
    
    private bool AllIdsAreDifferent(RegisterTeamUserRequest team)
    {
        var ids = new[]
        {
            team.IdLinePlayerOne,
            team.IdLinePlayerTwo,
            team.IdLinePlayerThree,
            team.IdLinePlayerFour,
            team.IdGoalkeeper,
            team.IdReservePlayerOne,
            team.IdReservePlayerTwo
        };

        return ids.Distinct().Count() == ids.Length;
    }
    
    private bool IsCaptainValid(RegisterTeamUserRequest team, long idCaptain)
    {
        var ids = new[]
        {
            team.IdLinePlayerOne,
            team.IdLinePlayerTwo,
            team.IdLinePlayerThree,
            team.IdLinePlayerFour,
            team.IdGoalkeeper
        };
        
        return ids.Contains(idCaptain);
    }
}

