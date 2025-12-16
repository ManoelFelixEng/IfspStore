using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validatorrs
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("Nome de usuário é obrigatório!");
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Sua senha não poder ser vazia")
                .MaximumLength(16).WithMessage("Sua senha deve ter no máximo 16 caracteres.");
            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("O Email é obrigatória!");
        }
    }
}
