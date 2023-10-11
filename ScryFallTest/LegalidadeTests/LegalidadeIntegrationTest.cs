using Microsoft.EntityFrameworkCore;
using ScryFallManager.Data;
using ScryFallManager.Entities;
using ScryFallManager.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryFallTest.LegalidadeTests
{
    public class LegalidadeIntegrationTest
    {
        [Fact]
        public void Legalidade_InsertDB_ShouldBeInDB()
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
            Assert.Contains(legalidade, legalidades);

            context.Cartas.Remove(carta);
            context.Legalidade.Remove(legalidade);
            context.SaveChanges();
        }

        [Fact]
        public void Legalidade_WithCarta_ShouldHaveCarta()
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
