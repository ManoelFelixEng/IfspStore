using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validatorrs
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome da categoria é obrigatorio!");
        }
    }
}
