using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_API_Backend.Models
{
    public class Indice : BaseEntity
    {
        [Required]
        public string contenido { get; set; } = string.Empty;
        public int idCurso { get; set; }
        public virtual Curso curso { get; set; } = new Curso();
    }
}
