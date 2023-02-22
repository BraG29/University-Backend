using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public ICollection<Categoria> categorias { get; set; } = new List<Categoria>();
        public ICollection<Estudiante> estudiantes { get; set; } = new List<Estudiante>();
        public int indiceId { get; set; }
        public virtual Indice indice { get; set; } = new Indice();
    }
}
