using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScryFallManager.Entities
{
    public class Carta
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string? CardTexto { get; set; }

        public string? RaridadeCarta { get; set; }

        public string? CustoMana { get; set; }

        public DateTime? DataLancamento { get; set; }

        public virtual ICollection<Idioma> Idiomas { get; set; } = new List<Idioma>();

        public virtual ICollection<Habilidade> Habilidades { get; set; } = new List<Habilidade>();

    }
}
