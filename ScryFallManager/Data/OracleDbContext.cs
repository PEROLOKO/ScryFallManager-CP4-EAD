﻿using Microsoft.EntityFrameworkCore;
using ScryFallManager.Entities;

namespace ScryFallManager.Data
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Carta> Cartas { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }

    }
}