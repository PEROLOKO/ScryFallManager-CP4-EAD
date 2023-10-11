using ScryFallManager.Entities;
using ScryFallManager.Enum;
using ScryFallManager.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryFallTest.LegalidadeTests
{
    public class LegalidadeUnitTest
    {
        [Fact]
        public void Legalidade_WithValidData_ShouldPassValidation()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "Carta Teste",
                Texto = "Texto Teste",
                Raridade = RaridadeEnum.Rare,
                Idioma = IdiomaEnum.Italian,
                CustoMana = "{2}{W/U}",
                DataLancamento = DateTime.Now
            };

            var legalidade = new Legalidade
            {
                Formato = "Padrão",
                Legal = true,
                Carta = carta,
            };

            var validator = new LegalidadeValidation();

            // Act
            var result = validator.Validate(legalidade);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Legalidade_WithEmptyFormato_ShouldNotPassValidation()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "Carta Teste",
                Texto = "Texto Teste",
                Raridade = RaridadeEnum.Rare,
                Idioma = IdiomaEnum.Italian,
                CustoMana = "{2}{W/U}",
                DataLancamento = DateTime.Now
            };

            var legalidade = new Legalidade
            {
                Formato = "",
                Legal = true,
                Carta = carta,
            };

            var validator = new LegalidadeValidation();

            // Act
            var result = validator.Validate(legalidade);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Legalidade_WithNullFormato_ShouldNotPassValidation()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "Carta Teste",
                Texto = "Texto Teste",
                Raridade = RaridadeEnum.Rare,
                Idioma = IdiomaEnum.Italian,
                CustoMana = "{2}{W/U}",
                DataLancamento = DateTime.Now
            };

            var legalidade = new Legalidade
            {
                Formato = null,
                Legal = false,
                Carta = carta,
            };

            var validator = new LegalidadeValidation();

            // Act
            var result = validator.Validate(legalidade);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Legalidade_WithoutCarta_ShouldNotPassValidation()
        {
            // Arrange
            var legalidade = new Legalidade
            {
                Formato = "Formato Teste",
                Legal = false,
                Carta = null,
            };

            var validator = new LegalidadeValidation();

            // Act
            var result = validator.Validate(legalidade);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
