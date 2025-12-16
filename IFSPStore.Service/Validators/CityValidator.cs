using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validatorrs
{
    public class CityValidator : AbstractValidator<City>

    {
        public CityValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome da cidade é obrigatorio!");
            RuleFor(c => c.State)
                .NotEmpty().WithMessage("Sigla do estado obrigatoria").Length(2).WithMessage("Estado deve conter 2 caracteres!");
        }
    }
}
