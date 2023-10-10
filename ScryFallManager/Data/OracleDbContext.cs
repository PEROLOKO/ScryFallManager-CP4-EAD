﻿using Microsoft.EntityFrameworkCore;
using ScryFallManager.Entities;

namespace ScryFallManager.Data
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Carta> Cartas { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }

        public DbSet<ScryFallManager.Entities.Colecao> Colecao { get; set; } = default!;

        public DbSet<ScryFallManager.Entities.Legalidade> Legalidade { get; set; } = default!;

    }
}
