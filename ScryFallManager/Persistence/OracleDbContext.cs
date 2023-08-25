using ScryFallManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ScryFallManager.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Carta> Cartas { get; set; }

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }

    }
}
