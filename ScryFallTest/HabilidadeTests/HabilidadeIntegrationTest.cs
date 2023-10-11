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

namespace ScryFallTest.HabilidadeTests
{
    public class HabilidadeIntegrationTest
    {
        [Fact]
        public void Habilidade_InsertDB_ShouldBeInDB()
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
                Descricao = "Descricao Teste",
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
            Assert.Contains(habilidade, habilidades);

            context.Cartas.Remove(carta);
            context.Habilidades.Remove(habilidade);
            context.SaveChanges();
        }

        [Fact]
        public void Habilidade_WithCarta_ShouldHaveCarta()
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
                Descricao = "Descricao Teste",
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

    }
}
