//1. Usings para trabajar con EntityFramework
using Microsoft.EntityFrameworkCore;
using University_API_Backend.DataAcces;
using University_API_Backend.Services;

var builder = WebApplication.CreateBuilder(args);


//2. Coexion con SQL Server Express
const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//3. Añadir context a los servicios del builder
builder.Services.AddDbContext<UniversityDBContext>(
    options => options.UseSqlServer(connectionString));

//Añadir servicios de JWT Autorization
//TODO:
//builder.Services.AddJwtTokenServices(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

//Añadir servicios customizados
builder.Services.AddScoped<IEstudiantesService, EstudiantesService>();
builder.Services.AddScoped<ICursosService, CursosService>();
builder.Services.AddScoped<IIndicesService, IndicesService>();
//TODO: Añadir el resto de servicios

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//TODO: Configurar Swagger para que tenga en cuenta la Auntenticacion
builder.Services.AddSwaggerGen();

//Configuaracion de CORS
builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "CorsPolicy", builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Decirle a la aplicacion que use los CORS
app.UseCors("CorsPolicy");

app.Run();
