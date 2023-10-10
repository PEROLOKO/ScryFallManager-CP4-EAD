using System.ComponentModel.DataAnnotations.Schema;

namespace ScryFallManager.Entities
{
    /// <summary>
    /// Entidade de uma habilidade de uma carta de Magic
    /// </summary>
    public class Habilidade
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [ForeignKey("Carta")]
        public int CartaId { get; set; }
        public virtual Carta Carta { get; set; }
    }
}
