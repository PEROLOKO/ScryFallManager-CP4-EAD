﻿using FluentValidation;
using ScryFallManager.Entities;

namespace ScryFallManager.Validation
{
    public class CartaValidation : AbstractValidator<Carta>
    {
        public CartaValidation() {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome nao pode ser vazio");
            RuleFor(x => x.Nome).NotNull().WithMessage("O nome nao pode ser nulo");
            RuleFor(x => x.Texto).NotEmpty().WithMessage("O texto nao pode ser vazio");
            RuleFor(x => x.Texto).NotNull().WithMessage("O texto nao pode ser nulo");
            RuleFor(x => x.DataLancamento).NotNull().WithMessage("A data nao pode ser nula");
            RuleFor(x => x.CustoMana).NotNull().WithMessage("O custo de mana nao pode ser nulo");
            RuleFor(x => x.Raridade).IsInEnum().WithMessage("A raridade está com um valor fora do enum");
            RuleFor(x => x.Idioma).IsInEnum().WithMessage("O idioma está com um valor fora do enum");
        }
    }
}
