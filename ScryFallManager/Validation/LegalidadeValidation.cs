using FluentValidation;
using ScryFallManager.Entities;

namespace ScryFallManager.Validation
{
    public class LegalidadeValidation : AbstractValidator<Legalidade>
    {
        public LegalidadeValidation()
        {
            RuleFor(x => x.Formato).NotEmpty().WithMessage("Formato não pode ser vazio");
            RuleFor(x => x.Formato).NotNull().WithMessage("Formato não pode ser nulo");
            RuleFor(x => x.Carta).NotNull().WithMessage("Habilidade precisa de uma Carta mãe");
        }
    }
}
