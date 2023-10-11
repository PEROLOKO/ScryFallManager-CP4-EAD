using Microsoft.EntityFrameworkCore;
using ScryFallManager.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScryFallManager.Entities
{
    /// <summary>
    /// Entidade de uma carta de Magic
    /// </summary>
    public class Carta
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Nome { get; set; }

        [MaxLength(1000)]
        public string? Texto { get; set; }

        public RaridadeEnum Raridade { get; set; } = RaridadeEnum.Common;

        public IdiomaEnum Idioma { get; set; } = IdiomaEnum.English;

        [MaxLength(50)]
        public string? CustoMana { get; set; }

        public DateTime? DataLancamento { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; } = new List<Habilidade>();

        public virtual ICollection<Legalidade> Legalidades { get; set; } = new List<Legalidade>();

        [ForeignKey("Colecao")]
        public int? ColecaoId { get; set; }
        public virtual Colecao? Colecao { get; set; }

    }
}
