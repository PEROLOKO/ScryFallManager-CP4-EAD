using Microsoft.EntityFrameworkCore;
using ScryFallManager.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScryFallManager.Entities
{
    public class Carta
    {
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Texto { get; set; }

        public RaridadeEnum Raridade { get; set; } = RaridadeEnum.Common;

        public string? CustoMana { get; set; }

        public DateTime? DataLancamento { get; set; }

        public virtual ICollection<Idioma> Idiomas { get; set; } = new List<Idioma>();

        public virtual ICollection<Habilidade> Habilidades { get; set; } = new List<Habilidade>();

        public virtual ICollection<Legalidade> Legalidades { get; set; } = new List<Legalidade>();

        [ForeignKey("Colecao")]
        public int? ColecaoId { get; set; }
        public virtual Colecao? Colecao { get; set; }

    }
}
