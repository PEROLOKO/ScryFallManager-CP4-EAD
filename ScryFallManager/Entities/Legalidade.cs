using System.ComponentModel.DataAnnotations;

namespace ScryFallManager.Entities
{
    public class Legalidade
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Formato { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
