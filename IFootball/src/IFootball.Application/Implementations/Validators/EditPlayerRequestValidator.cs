using FluentValidation;
using IFootball.Application.Contracts.Documents.Requests;
using Microsoft.AspNetCore.Routing.Matching;

namespace IFootball.Application.Implementations.Validators;

public class EditPlayerRequestValidator : AbstractValidator<EditPlayerRequest>
{
    public EditPlayerRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome deve ser preenchido")
            .MaximumLength(128).WithMessage("O nome deve possuir mais de 128 caracteres");
        
        RuleFor(x => x.Image)
            .MaximumLength(512).WithMessage("A imagem deve possuir mais de 512 caracteres");

        RuleFor(x => x.IdGender)
            .NotNull().WithMessage("O gênero deve ser preenchido")
            .GreaterThan(0).WithMessage("O gênero deve ser maior que 0.");
        
        RuleFor(x => x.IdTeamClass)
            .NotNull().WithMessage("O time deve ser preenchido")
            .GreaterThan(0).WithMessage("O time deve ser maior que 0.");

    }
    
}
