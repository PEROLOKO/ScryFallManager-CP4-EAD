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
    public class ColecaoIntegrationTest
    {
        [Fact]
        public void Colecao_InsertDB_ShouldBeInDB()
        {
            // Arrange
            var colecao = new Colecao
            {
                Nome = "Colecao Teste",
                DataLancamento = DateTime.Now,
                Idioma = IdiomaEnum.Korean
            };

            var options = new DbContextOptionsBuilder<OracleDbContext>().UseOracle("Data Source =//oracle.fiap.com.br:1521/ORCL;User Id=rm93443;Password=220504;").Options;

            var context = new OracleDbContext(options);

            // Act
            context.Colecao.Add(colecao);
            context.SaveChanges();

            var colecoes = context.Colecao.ToList();

            // Assert
            Assert.Contains(colecao, colecoes);

            context.Remove(colecao);
            context.SaveChanges();
        }

        [Fact]
        public void Colecao_WithCarta_ShouldHaveCarta()
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
    }
}
