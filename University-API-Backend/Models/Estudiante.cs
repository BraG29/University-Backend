using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace University_API_Backend.Models
{
    public class Estudiante : BaseEntity
    {
        [Required, StringLength(50)]
        public string nombre { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string apellido { get; set; } = string.Empty;
        [Required]
        public DateTime fechaNac { get; set; }
        public ICollection<Curso> cursos { get; set; } = new List<Curso>();

        public int getEdad()
        {
            DateTime fechaActual = DateTime.Now;
            DateTime fechaDiff = DateTime.Today.Add(fechaActual.Subtract(fechaNac));
            return fechaDiff.Year - fechaActual.Year;
        }
    }
}
