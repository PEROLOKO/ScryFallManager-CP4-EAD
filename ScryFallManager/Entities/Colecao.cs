using System.ComponentModel.DataAnnotations;

namespace ScryFallManager.Entities
{
    public class Colecao
    {
        /// <summary>
        /// Entidade de uma coleção de cartas de Magic
        /// </summary>
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }

        public DateTime? DataLancamento { get; set; }

        public virtual ICollection<Carta> Cartas { get; set; } = new List<Carta>();

        public virtual ICollection<Idioma> Idiomas { get; set; } = new List<Idioma>();

    }
}
