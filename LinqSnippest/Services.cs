using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_API_Backend.DataAcces;
using University_API_Backend.Enums;
using University_API_Backend.Models;


namespace LinqSnippets
{
    public class Services
    {
        //Buscar usuarios por email
        public static Usuario GetUserByEmail(UniversityDBContext context, string email)
        {
            var resultado =
                from usr in context.Usuarios.DefaultIfEmpty()
                where usr.email.Equals(email)
                select usr;
            return (Usuario) resultado;
        }
        //Buscar alumnos mayores de edad 
        public static IEnumerable<Estudiante> GetAdultsStudents(UniversityDBContext context)
        {
            var resultado = context.Estudiantes
                .Select(estudiante => estudiante)
                .Where(estudiante => estudiante.getEdad() >= 18);
            return resultado;
        }
        //Buscar alumnos que tengan al menos un curso
        public static IEnumerable<Estudiante> GetStudentsWithCourse(UniversityDBContext context)
        {
            var resultado = context.Estudiantes
                .Select(estudiante => estudiante)
                .Where(estudiante => estudiante.cursos.Any());
            return resultado;
        }
        //Buscar cursos de un nivel determinado que al menos tengan un alumno inscrito
        public static IEnumerable<Curso> GetCoursesByLevel(UniversityDBContext context, NivelCursos level) 
        {
            var resultado = context.Cursos
                .Select(curso => curso)
                .Where(curso => curso.nivel == level && curso.estudiantes.Any());
            return resultado;
        }
        //Buscar cursos de un nivel determinado que sean de una categoría determinada
        public static IEnumerable<Curso> GetCoursesByCategory(
            UniversityDBContext context, NivelCursos level, Categoria category)
        {
            var resultado = context.Cursos
                .Select(curso => curso)
                .Where(curso => curso.nivel == level && curso.categorias.Contains(category));
            return resultado;
        }
        //Buscar cursos sin alumnos
        public static IEnumerable<Curso> GetCoursesWithoutStudents(UniversityDBContext context)
        {
            var resultado = context.Cursos
                .Select(curso => curso)
                .Where(curso => !curso.estudiantes.Any());
            return resultado;
        }
    }
}
