using University_API_Backend.Models;
/*
Obtener todos los Cursos de una categoría concreta
 
Obtener Cursos sin temarios
*/


namespace University_API_Backend.Services
{
    public interface ICursosService
    {
        IEnumerable<Curso> getCursosDeCategoria(Categoria categoria);
        IEnumerable<Curso> getCursosSinTemario();
    }
}
