using FluentValidation;
using ScryFallManager.Entities;

namespace ScryFallManager.Validation
{
    public class HabilidadeValidation : AbstractValidator<Habilidade>
    {
        public HabilidadeValidation() {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome não pode ser vazio");
            RuleFor(x => x.Nome).NotNull().WithMessage("O nome não pode ser nulo");
            RuleFor(x => x.Descricao).NotNull().WithMessage("A descrição não pode ser nula");
            RuleFor(x => x.Carta).NotNull().WithMessage("Habilidade precisa de uma Carta mãe");
        }
    }
}
