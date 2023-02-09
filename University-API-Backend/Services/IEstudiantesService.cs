using University_API_Backend.Models;

namespace University_API_Backend.Services
{
    public interface IEstudiantesService
    {
        IEnumerable<Estudiante> GetEstduiantesConCurso();
        IEnumerable<Estudiante> GetEstduiantesSinCurso();
        IEnumerable<Estudiante> GetEstudisntesEnCurso(Curso curso);
        IEnumerable<Estudiante> GetCursosDeAlumno(Estudiante estudiante);
    }
}
