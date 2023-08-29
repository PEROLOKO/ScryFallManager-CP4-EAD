using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScryFallManager.Entities
{
    public class Idioma
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [ForeignKey("Carta")]
        public int CartaId { get; set; }
        public virtual Carta Carta { get; set; }
    }
}
