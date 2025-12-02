using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required]
        public required string Nome { get; set; }

        [Range(1, 100)]
        public int Idade { get; set; }

        [Required]
        public required string Materia { get; set; }

        [Range(0, 10)]
        [Display(Name = "Nota Final")]
        public double Nota { get; set; }
    }
}
