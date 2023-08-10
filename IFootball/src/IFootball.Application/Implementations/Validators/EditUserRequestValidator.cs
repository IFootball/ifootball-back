using FluentValidation;
using IFootball.Application.Contracts.Documents.Requests;

namespace IFootball.Application.Implementations.Validators;

public class EditUserRequestValidator : AbstractValidator<EditUserRequest>
{
    public EditUserRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome deve ser preenchido")
            .MaximumLength(128).WithMessage("O nome deve possuir mais de 128 caracteres");
        
        RuleFor(x => x.NewPassword)
            .Must(password => password == null || !string.IsNullOrWhiteSpace(password))
            .WithMessage("A nova senha não pode ser vazia")            
            .MaximumLength(128).WithMessage("A nova não deve possuir mais de 128 caracteres");
        
        RuleFor(x => x.OldPassword)
            .Must(password => password == null || !string.IsNullOrWhiteSpace(password))
            .WithMessage("A senha antiga não pode ser vazia")            
            .MaximumLength(128).WithMessage("A antiga senha não deve possuir mais de 128 caracteres");
    }
}

