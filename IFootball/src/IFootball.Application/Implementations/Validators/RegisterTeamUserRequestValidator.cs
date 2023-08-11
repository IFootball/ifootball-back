using FluentValidation;
using IFootball.Application.Contracts.Documents.Requests;

namespace IFootball.Application.Implementations.Validators;

public class RegisterTeamUserRequestValidator : AbstractValidator<RegisterTeamUserRequest>
{
    public RegisterTeamUserRequestValidator()
    {
        RuleFor(x => x.IdLinePlayerOne)
            .NotNull().WithMessage("O jogador um deve ser preenchido")
            .GreaterThan(0).WithMessage("O jogador um deve ser maior que 0.");
        
        RuleFor(x => x.IdLinePlayerTwo)
            .NotNull().WithMessage("O jogador dois deve ser preenchido")
            .GreaterThan(0).WithMessage("O jogador dois deve ser maior que 0.");

        RuleFor(x => x.IdLinePlayerThree)
            .NotNull().WithMessage("O jogador três deve ser preenchido")
            .GreaterThan(0).WithMessage("O jogador três deve ser maior que 0.");

        RuleFor(x => x.IdLinePlayerFour)
            .NotNull().WithMessage("O jogador quatro deve ser preenchido")
            .GreaterThan(0).WithMessage("O jogador quatro deve ser maior que 0.");
        
        RuleFor(x => x.IdGoalkeeper)
            .NotNull().WithMessage("O goleiro um deve ser preenchido")
            .GreaterThan(0).WithMessage("O goleiro deve ser maior que 0.");
        
        RuleFor(x => x.IdReservePlayerTwo)
            .NotNull().When(x => x.IdReservePlayerTwo != null)
            .GreaterThan(0).WithMessage("O segundo jogador reserva deve ser maior que 0.");

        RuleFor(x => x.IdLinePlayerOne)
            .NotNull().When(x => x.IdLinePlayerOne != null)
            .GreaterThan(0).WithMessage("O primeiro jogador reserva deve ser maior que 0.");
        
        RuleFor(x => x.IdCaptain)
            .Must((team, idCaptain) => idCaptain == null || IsCaptainValid(team, idCaptain.GetValueOrDefault()))
            .WithMessage("O capitão deve estar no time");
        
        RuleFor(x => x)
            .Must(AllIdsAreDifferent)
            .WithMessage("Todos os jogadores devem ser diferentes entre si");
    }
    
    private bool AllIdsAreDifferent(RegisterTeamUserRequest team)
    {
        var ids = new List<long>
        {
            team.IdLinePlayerOne,
            team.IdLinePlayerTwo,
            team.IdLinePlayerThree,
            team.IdLinePlayerFour,
            team.IdGoalkeeper
        };

        if (team.IdReservePlayerOne is not null)
            ids.Add(team.IdReservePlayerOne.Value);
    
        if (team.IdReservePlayerTwo is not null)
            ids.Add(team.IdReservePlayerTwo.Value);

        return ids.Distinct().Count() == ids.Count;
    }
    
    private bool IsCaptainValid(RegisterTeamUserRequest team, long idCaptain)
    {
        var ids = new List<long>
        {
            team.IdLinePlayerOne,
            team.IdLinePlayerTwo,
            team.IdLinePlayerThree,
            team.IdLinePlayerFour,
            team.IdGoalkeeper
        };

        if (team.IdReservePlayerOne is not null)
            ids.Add(team.IdReservePlayerOne.Value);
    
        if (team.IdReservePlayerTwo is not null)
            ids.Add(team.IdReservePlayerTwo.Value);
        
        return ids.Contains(idCaptain);
    }
}

