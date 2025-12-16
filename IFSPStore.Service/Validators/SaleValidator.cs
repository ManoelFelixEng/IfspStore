using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validatorrs
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(d => d.Date)
               .NotEmpty().WithMessage("Data da venda é obrigatorio!");
            RuleFor(t => t.TotalAmount)
                .NotEmpty().WithMessage("Valor total da venda é obrigatorio");
            RuleFor(s => s.Salesman)
                .NotEmpty().WithMessage("O vendendor é obrigatorio!");
            RuleFor(c => c.Customer)
                .NotEmpty().WithMessage("O comprador é obrigatorio!");
            RuleFor(s => s.SaleItens)
                .NotEmpty().WithMessage("Itens da vendo é obrigatorio!");
        }
    }
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            RuleFor(q => q.Quatity)
               .NotEmpty().WithMessage("Quantidade do item vendido é obrigatorio!");
            RuleFor(u => u.UnitPrice)
                .NotEmpty().WithMessage("Valor unitario do item é obrigatorio");
            RuleFor(t => t.TotalPrice)
                .NotEmpty().WithMessage("Valor total do item é obrigatorio!");
            RuleFor(s => s.Sale)
                .NotEmpty().WithMessage("A venda total é obrigatorio!");
            RuleFor(p => p.Product)
                .NotEmpty().WithMessage("O produto é obrigatorio!");
        }
    }
}
