using FluentValidation;
using IFootball.Application.Contracts.Documents.Requests;

namespace IFootball.Application.Implementations.Validators;

public class RegisterClassRequestValidator : AbstractValidator<RegisterClassRequest>
{
    public RegisterClassRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome deve ser preenchido")
            .MaximumLength(128).WithMessage("O nome deve possuir mais de 128 caracteres");
    }
    
}