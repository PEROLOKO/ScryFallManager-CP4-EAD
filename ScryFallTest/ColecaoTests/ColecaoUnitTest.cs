using Microsoft.EntityFrameworkCore;
using ScryFallManager.Data;
using ScryFallManager.Entities;
using ScryFallManager.Enum;
using ScryFallManager.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryFallTest.ColecaoTests
{
    public class ColecaoUnitTest
    {
        [Fact]
        public void Colecao_WithValidData_ShouldPassValidation()
        {
            // Arrange
            var colecao = new Colecao
            {
                Nome = "Nome Teste",
                DataLancamento = DateTime.Now,
                Idioma = IdiomaEnum.Korean
            };

            var validator = new ColecaoValidation();

            // Act
            var result = validator.Validate(colecao);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Colecao_WithInvalidData_ShouldNotPassValidation()
        {
            // Arrange
            var colecao = new Colecao
            {
                Nome = "",
                DataLancamento = null,
                Idioma = (IdiomaEnum)99
            };

            var validator = new ColecaoValidation();

            // Act
            var result = validator.Validate(colecao);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Colecao_WithEmptyNome_ShouldNotPassValidation()
        {
            // Arrange
            var colecao = new Colecao
            {
                Nome = "",
                DataLancamento = DateTime.Now,
                Idioma = IdiomaEnum.Korean
            };

            var validator = new ColecaoValidation();

            // Act
            var result = validator.Validate(colecao);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Colecao_WithNullNome_ShouldNotPassValidation()
        {
            // Arrange
            var colecao = new Colecao
            {
                Nome = null,
                DataLancamento = DateTime.Now,
                Idioma = IdiomaEnum.Korean
            };

            var validator = new ColecaoValidation();

            // Act
            var result = validator.Validate(colecao);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Colecao_WithNullDataLancamento_ShouldNotPassValidation()
        {
            // Arrange
            var colecao = new Colecao
            {
                Nome = "Nome Teste",
                DataLancamento = null,
                Idioma = IdiomaEnum.Korean
            };

            var validator = new ColecaoValidation();

            // Act
            var result = validator.Validate(colecao);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Colecao_WithInvalidIdioma_ShouldNotPassValidation()
        {
            // Arrange
            var colecao = new Colecao
            {
                Nome = "NomeTeste",
                DataLancamento = DateTime.Now,
                Idioma = (IdiomaEnum)99
            };

            var validator = new ColecaoValidation();

            // Act
            var result = validator.Validate(colecao);

            // Assert
            Assert.False(result.IsValid);
        }
    }
}
