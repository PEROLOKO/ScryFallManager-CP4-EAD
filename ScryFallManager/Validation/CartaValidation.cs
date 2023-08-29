using FluentValidation;
using ScryFallManager.Entities;

namespace ScryFallManager.Validation
{
    public class CartaValidation : AbstractValidator<Carta>
    {
        public CartaValidation() {
            RuleFor(x => x.Nome).NotNull().NotEmpty();
        }
    }
}
