using System.ComponentModel.DataAnnotations;
using University_API_Backend.Enums;

namespace University_API_Backend.Models
{
    public class Curso : BaseEntity
    {
        [Required, StringLength(100)]
        public string nombre { get; set; } = string.Empty;
        [Required, StringLength(260)]
        public string descripcionCorta { get; set; } = string.Empty;
        public string? descripcionLarga { get; set; }
        [Required]
        public string publicoObjetivo { get; set; } = string.Empty;
        [Required]
        public string objetivos { get; set; } = string.Empty;
        [Required]
        public string requisitos { get; set; } = string.Empty;
        [Required]
        public NivelCursos nivel { get; set; } 
    }
}
