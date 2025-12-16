using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validatorrs
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome do comprador é obrigatorio!");
            RuleFor(a => a.Address)
                .NotEmpty().WithMessage("Endereço do comprador é obrigatorio");
            RuleFor(d => d.DocumentId)
                .NotEmpty().WithMessage("Documento do comprador é obrigatorio!");
            RuleFor(c => c.City)
                .NotEmpty().WithMessage("Cidade do comprador é obrigatorio");
            
        }
    }
}
