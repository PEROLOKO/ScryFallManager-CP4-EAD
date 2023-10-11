using ScryFallManager.Entities;
using ScryFallManager.Enum;
using ScryFallManager.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ScryFallTest
{
    public class CartaTest
    {

        // TESTES UNITÁRIOS

        [Fact]
        public void Carta_WithValidData_ShouldPassValidation()
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

            var validator = new CartaValidation();

            // Act
            var result = validator.Validate(carta);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Carta_WithInvalidData_ShouldNotPassValidation()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "", // Nome vazio
                Texto = null, // Texto nulo
                Raridade = (RaridadeEnum)99, // Valor Inválido
                Idioma = (IdiomaEnum)99, // Valor Inválido
                DataLancamento = null // Valor nulo
            };

            var validator = new CartaValidation();

            // Act
            var result = validator.Validate(carta);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Carta_WithEmptyNome_ShouldNotPassValidation()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "", // Nome Vazio
                Texto = "Texto Teste",
                Raridade = RaridadeEnum.Rare,
                Idioma = IdiomaEnum.Italian,
                CustoMana = "{2}{W/U}",
                DataLancamento = DateTime.Now
            };

            var validator = new CartaValidation();

            // Act
            var result = validator.Validate(carta);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Carta_WithNullNome_ShouldNotPassValidation()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = null, // Nome nulo
                Texto = "Texto Teste",
                Raridade = RaridadeEnum.Rare,
                Idioma = IdiomaEnum.Italian,
                CustoMana = "{2}{W/U}",
                DataLancamento = DateTime.Now
            };

            var validator = new CartaValidation();

            // Act
            var result = validator.Validate(carta);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Carta_WithInvalidTexto_ShouldNotPassValidation()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "Nome Teste",
                Texto = null, // Texto nulo
                Raridade = RaridadeEnum.Rare,
                Idioma = IdiomaEnum.Italian,
                CustoMana = "{2}{W/U}",
                DataLancamento = DateTime.Now
            };

            var validator = new CartaValidation();

            // Act
            var result = validator.Validate(carta);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Carta_WithInvalidRaridade_ShouldNotPassValidation()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "Nome Teste",
                Texto = "Texto Teste",
                Raridade = (RaridadeEnum)99, // Raridade inválida
                Idioma = IdiomaEnum.Italian,
                CustoMana = "{2}{W/U}",
                DataLancamento = DateTime.Now
            };

            var validator = new CartaValidation();

            // Act
            var result = validator.Validate(carta);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Carta_WithInvalidIdioma_ShouldNotPassValidation()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "Nome Teste",
                Texto = "Texto Teste",
                Raridade = RaridadeEnum.Rare,
                Idioma = (IdiomaEnum)99, // Indioma inválido
                CustoMana = "{2}{W/U}",
                DataLancamento = DateTime.Now
            };

            var validator = new CartaValidation();

            // Act
            var result = validator.Validate(carta);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Carta_WithEmptyCustoMana_ShouldPassValidation()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "Nome Teste",
                Texto = "Texto Teste",
                Raridade = RaridadeEnum.Rare,
                Idioma = IdiomaEnum.Italian,
                CustoMana = "", // CustoMana Vazio
                DataLancamento = DateTime.Now
            };

            var validator = new CartaValidation();

            // Act
            var result = validator.Validate(carta);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Carta_WithNullCustoMana_ShouldPassValidation()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "Nome Teste",
                Texto = "Texto Teste",
                Raridade = RaridadeEnum.Rare,
                Idioma = IdiomaEnum.Italian,
                CustoMana = null, // CustoMana Nulo
                DataLancamento = DateTime.Now
            };

            var validator = new CartaValidation();

            // Act
            var result = validator.Validate(carta);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Carta_WithInvalidDataLancamento_ShouldNotPassValidation()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "Nome Teste",
                Texto = "Texto Teste",
                Raridade = RaridadeEnum.Rare,
                Idioma = IdiomaEnum.Italian,
                CustoMana = "{2}{W/U}",
                DataLancamento = null // DataLancamento nula
            };

            var validator = new CartaValidation();

            // Act
            var result = validator.Validate(carta);

            // Assert
            Assert.False(result.IsValid);
        }

    }
}
