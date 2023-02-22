//Obtener temario de un curso concreto

using University_API_Backend.Models;

namespace University_API_Backend.Services
{
    public interface IIndicesService
    {
        Indice getIndiceDeCurso(Curso curso);
    }
}
