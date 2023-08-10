using FluentValidation;
using IFootball.Application.Contracts.Documents.Requests;

namespace IFootball.Application.Implementations.Validators;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome deve ser preenchido")
            .MaximumLength(128).WithMessage("O nome deve possuir mais de 128 caracteres");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O email deve ser preenchido")
            .MaximumLength(255).WithMessage("O email deve possuir mais de 128 caracteres");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("A senha deve ser preenchido")
            .MaximumLength(128).WithMessage("A nova deve possuir mais de 128 caracteres");
        
        RuleFor(x => x.IdClass)
            .NotNull().WithMessage("O turma deve ser preenchida");
    }
}