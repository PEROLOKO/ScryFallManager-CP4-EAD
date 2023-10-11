using Elfie.Serialization;
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
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        // TESTES DE INTEGRAÇÃO

        [Fact]
        public void Carta_InsertDB_ShouldBeInDB()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "Carta Teste",
                Texto = "Texto Teste",
                Raridade = RaridadeEnum.Rare,
                Idioma = IdiomaEnum.Italian,
                CustoMana = "{2}{W/U}",
                DataLancamento = DateTime.Now,
            };

            var options = new DbContextOptionsBuilder<OracleDbContext>().UseOracle("Data Source =//oracle.fiap.com.br:1521/ORCL;User Id=rm93443;Password=220504;").Options;

            var context = new OracleDbContext(options);

            // Act
            context.Cartas.Add(carta);
            context.SaveChanges();

            var cartas = context.Cartas.ToList();

            // Assert
            Assert.Contains(carta, cartas);

            context.Cartas.Remove(carta);
            context.SaveChanges();
        }

        [Fact]
        public void Carta_WithColecao_ShouldHaveColecao()
        {
            // Arrange
            var colecao = new Colecao
            {
                Nome = "Coleção Teste",
                Idioma = IdiomaEnum.Italian,
                DataLancamento = DateTime.Now,
            };

            var carta = new Carta
            {
                Nome = "Carta Teste",
                Texto = "Texto Teste",
                Raridade = RaridadeEnum.Rare,
                Idioma = IdiomaEnum.Italian,
                CustoMana = "{2}{W/U}",
                DataLancamento = DateTime.Now,
                Colecao = colecao
            };

            var options = new DbContextOptionsBuilder<OracleDbContext>().UseOracle("Data Source =//oracle.fiap.com.br:1521/ORCL;User Id=rm93443;Password=220504;").Options;

            var context = new OracleDbContext(options);

            // Act
            context.Colecao.Add(colecao);
            context.Cartas.Add(carta);
            context.SaveChanges();

            var cartas = context.Cartas.ToList();
            var colecoes = context.Colecao.ToList();

            // Assert
            Assert.Contains(carta, cartas);
            Assert.Contains(colecao, colecoes);
            Assert.True(carta.Colecao.Equals(colecao));
            Assert.True(colecao.Cartas.Contains(carta));

            context.Cartas.Remove(carta);
            context.Colecao.Remove(colecao);
            context.SaveChanges();
        }

        [Fact]
        public void Carta_WithHabilidade_ShouldHaveHabilidade()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "Carta Teste",
                Texto = "Texto Teste",
                Raridade = RaridadeEnum.Rare,
                Idioma = IdiomaEnum.Italian,
                CustoMana = "{2}{W/U}",
                DataLancamento = DateTime.Now,
            };

            var habilidade = new Habilidade
            {
                Nome = "Habilidade Teste",
                Carta = carta
            };

            var options = new DbContextOptionsBuilder<OracleDbContext>().UseOracle("Data Source =//oracle.fiap.com.br:1521/ORCL;User Id=rm93443;Password=220504;").Options;

            var context = new OracleDbContext(options);

            // Act
            context.Cartas.Add(carta);
            context.Habilidades.Add(habilidade);
            context.SaveChanges();

            var cartas = context.Cartas.ToList();
            var habilidades = context.Habilidades.ToList();

            // Assert
            Assert.Contains(carta, cartas);
            Assert.Contains(habilidade, habilidades);
            Assert.True(carta.Habilidades.Contains(habilidade));
            Assert.True(habilidade.Carta.Equals(carta));

            context.Cartas.Remove(carta);
            context.Habilidades.Remove(habilidade);
            context.SaveChanges();
        }

        [Fact]
        public void Carta_WithLegalidade_ShouldHaveLegalidade()
        {
            // Arrange
            var carta = new Carta
            {
                Nome = "Carta Teste",
                Texto = "Texto Teste",
                Raridade = RaridadeEnum.Rare,
                Idioma = IdiomaEnum.Italian,
                CustoMana = "{2}{W/U}",
                DataLancamento = DateTime.Now,
            };

            var legalidade = new Legalidade
            {
                Formato = "Padrão",
                Legal = true,
                Carta = carta,
            };

            var options = new DbContextOptionsBuilder<OracleDbContext>().UseOracle("Data Source =//oracle.fiap.com.br:1521/ORCL;User Id=rm93443;Password=220504;").Options;

            var context = new OracleDbContext(options);

            // Act
            context.Cartas.Add(carta);
            context.Legalidade.Add(legalidade);
            context.SaveChanges();

            var cartas = context.Cartas.ToList();
            var legalidades = context.Legalidade.ToList();

            // Assert
            Assert.Contains(carta, cartas);
            Assert.Contains(legalidade, legalidades);
            Assert.True(carta.Legalidades.Contains(legalidade));
            Assert.True(legalidade.Carta.Equals(carta));

            context.Cartas.Remove(carta);
            context.Legalidade.Remove(legalidade);
            context.SaveChanges();
        }

    }
}
