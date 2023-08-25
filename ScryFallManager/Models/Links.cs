using System.ComponentModel.DataAnnotations;

namespace ScryFallManager.Models
{
    public class Links
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
