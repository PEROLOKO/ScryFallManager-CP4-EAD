using FluentValidation;
using ScryFallManager.Entities;

namespace ScryFallManager.Validation
{
    public class CartaValidation : AbstractValidator<Carta>
    {
        public CartaValidation() {
            RuleFor(x => x.Nome).NotEmpty().NotNull();
            RuleFor(x => x.Texto).NotEmpty().NotNull();
            RuleFor(x => x.DataLancamento).NotNull();
            RuleFor(x => x.CustoMana).NotNull();
            RuleFor(x => x.Raridade).IsInEnum();
            RuleFor(x => x.Idioma).IsInEnum();
        }
    }
}
