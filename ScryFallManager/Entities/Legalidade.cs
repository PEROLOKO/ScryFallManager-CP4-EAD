using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScryFallManager.Entities
{
    public class Legalidade
    {
        public int Id { get; set; }

        public string Formato { get; set; }

        public bool Legal { get; set; }

        [ForeignKey("Carta")]
        public int CartaId { get; set; }
        public virtual Carta Carta { get; set; }
    }
}
