using FluentValidation;
using ScryFallManager.Entities;

namespace ScryFallManager.Validation
{
    public class CartaValidation : AbstractValidator<Carta>
    {
        public CartaValidation() {
            RuleFor(x => x.Nome).NotEmpty().NotNull();
            RuleFor(x => x.Texto).NotEmpty().NotNull();
            RuleFor(x => x.Raridade).NotNull();
            RuleFor(x => x.DataLancamento).NotNull();
        }
    }
}
