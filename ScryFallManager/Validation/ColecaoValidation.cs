using FluentValidation;
using ScryFallManager.Entities;

namespace ScryFallManager.Validation
{
    public class ColecaoValidation : AbstractValidator<Colecao>
    {
        public ColecaoValidation()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome nao pode ser vazio");
            RuleFor(x => x.Nome).NotNull().WithMessage("O nome nao pode ser nulo");
            RuleFor(x => x.DataLancamento).NotNull().WithMessage("A data nao pode ser nula");
            RuleFor(x => x.Idioma).IsInEnum().WithMessage("O idioma está com um valor fora do enum");
        }
    }
}
