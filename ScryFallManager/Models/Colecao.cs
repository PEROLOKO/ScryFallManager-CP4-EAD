using System.ComponentModel.DataAnnotations;

namespace ScryFallManager.Models
{
    public class Colecao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
