using ScryFallManager.Entities;
using ScryFallManager.Enum;
using ScryFallManager.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryFallTest.HabilidadeTests
{
    public class HabilidadeUnitTest
    {
        [Fact]
        public void Habilidade_WithValidData_ShouldPassValidation()
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

            var habilidade = new Habilidade
            {
                Nome = "Habilidade Teste",
                Descricao = "Descrição Teste",
                Carta = carta
            };

            var validator = new HabilidadeValidation();

            // Act
            var result = validator.Validate(habilidade);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Habilidade_WithInvalidData_ShouldNotPassValidation()
        {
            // Arrange
            var habilidade = new Habilidade
            {
                Nome = "",
                Descricao = null,
                Carta = null
            };

            var validator = new HabilidadeValidation();

            // Act
            var result = validator.Validate(habilidade);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Habilidade_WithEmptyNome_ShouldNotPassValidation()
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

            var habilidade = new Habilidade
            {
                Nome = "",
                Descricao = "Descrição Teste",
                Carta = carta
            };

            var validator = new HabilidadeValidation();

            // Act
            var result = validator.Validate(habilidade);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Habilidade_WithNullNome_ShouldNotPassValidation()
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

            var habilidade = new Habilidade
            {
                Nome = null,
                Descricao = "Descrição Teste",
                Carta = carta
            };

            var validator = new HabilidadeValidation();

            // Act
            var result = validator.Validate(habilidade);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Habilidade_WithEmptyDescricao_ShouldPassValidation()
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

            var habilidade = new Habilidade
            {
                Nome = "Nome Teste",
                Descricao = "",
                Carta = carta
            };

            var validator = new HabilidadeValidation();

            // Act
            var result = validator.Validate(habilidade);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Habilidade_WithNullDescricao_ShouldNotPassValidation()
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

            var habilidade = new Habilidade
            {
                Nome = "Nome Teste",
                Descricao = null,
                Carta = carta
            };

            var validator = new HabilidadeValidation();

            // Act
            var result = validator.Validate(habilidade);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Habilidade_WithoutCarta_ShouldNotPassValidation()
        {
            // Arrange
            var habilidade = new Habilidade
            {
                Nome = "Nome Teste",
                Descricao = "Descrição Teste",
                Carta = null
            };

            var validator = new HabilidadeValidation();

            // Act
            var result = validator.Validate(habilidade);

            // Assert
            Assert.False(result.IsValid);
        }

    }
}
