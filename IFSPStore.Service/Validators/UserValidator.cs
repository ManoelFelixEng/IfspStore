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

            
            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("O Email é obrigatório!")
                .EmailAddress().WithMessage("O formato do email é inválido.");

            
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Sua senha não pode ser vazia.")
                .MinimumLength(8).WithMessage("Sua senha deve ter pelo menos 8 caracteres.")
                .MaximumLength(16).WithMessage("Sua senha deve ter no máximo 16 caracteres.")
                .Matches(@"[A-Z]+").WithMessage("Sua senha deve conter pelo menos uma letra maiúscula.")
                .Matches(@"[a-z]+").WithMessage("Sua senha deve conter pelo menos uma letra minúscula.")
                .Matches(@"[0-9]+").WithMessage("Sua senha deve conter pelo menos um número.")
                .Matches(@"[\!\?\*\.\@\#\$]+").WithMessage("Sua senha deve conter pelo menos um caractere especial (! ? * . @ # $).");
        }
    }
}