using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public required string Nome { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(4)]
        public required string Senha { get; set; }

        [Required]
        public required string Tipo { get; set; } // "Aluno" ou "Professor"
    }
}
