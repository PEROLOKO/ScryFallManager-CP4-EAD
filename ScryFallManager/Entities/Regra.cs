using System.ComponentModel.DataAnnotations;

namespace ScryFallManager.Entities
{
    public class Regra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Texto { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
