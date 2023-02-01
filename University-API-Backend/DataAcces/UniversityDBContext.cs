using Microsoft.EntityFrameworkCore;
using University_API_Backend.Models;

namespace University_API_Backend.DataAcces
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : 
            base(options)
        {
        }

        //"Add DbSets" -> Añadir tablas de nuestra BD
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
    }
}
