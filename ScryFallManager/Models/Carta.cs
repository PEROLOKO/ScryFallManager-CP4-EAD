using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScryFallManager.Models
{
    public class Carta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CardTexto { get; set; }

        [Required]
        public string Raridade { get; set; }

        [Required]
        public string CustoMana { get; set; }

        [Required]
        public DateTime DataLancamento { get; set; }

        [Required]
        public virtual ICollection<Idioma> Idiomas { get; set; }

        [Required]
        public virtual ICollection<Habilidade> Habilidades { get; set; }

    }
}
