using Microsoft.Build.Framework;
using System.Collections.ObjectModel;

namespace University_API_Backend.Models
{
    public class Categoria : BaseEntity
    {
        [Required]
        public string nombre { get; set; } = string.Empty;
        public ICollection<Curso> cursos { get; set; } = new List<Curso>();
    }
}
