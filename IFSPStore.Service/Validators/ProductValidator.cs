using FluentValidation;
using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Service.Validatorrs
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome do produto é obrigatorio!");
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Valor do produto é obrigatorio");
            RuleFor(q => q.Quantity)
                .NotEmpty().WithMessage("Quantidade do produto é obrigatorio!");
            RuleFor(d => d.DateShop)
                .NotEmpty().WithMessage("Data da venda do protudo é obrigatorio!");
            RuleFor(s => s.SalesUnit)
                .NotEmpty().WithMessage("Tipo de unidade do produto é obrigatorio!");
            RuleFor(c => c.Category)
                .NotEmpty().WithMessage("Tipo de unidade do produto é obrigatorio!");
        }
    }
}
