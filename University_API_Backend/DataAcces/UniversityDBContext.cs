using Microsoft.EntityFrameworkCore;
using University_API_Backend.Models;

namespace University_API_Backend.DataAcces
{
    public class UniversityDBContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options, ILoggerFactory loggerFactory) :
            base(options)
        {
            _loggerFactory = loggerFactory;
        }

        //"Add DbSets" -> Añadir tablas de nuestra BD
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Estudiante>? Estudiantes { get; set; }
        public DbSet<Indice>? Indices { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = _loggerFactory.CreateLogger<UniversityDBContext>();
            /*optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }));
            optionsBuilder.EnableSensitiveDataLogging();*/

            optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        //Con la funcion de OnModelCreationg se pueden especificar mas detalladamente las relaciones entre entidades

    }
}
