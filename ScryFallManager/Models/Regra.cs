using System.ComponentModel.DataAnnotations;

namespace ScryFallManager.Models
{
    public class Regra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
