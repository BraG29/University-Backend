//1. Usings para trabajar con EntityFramework
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using University_API_Backend;
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
builder.Services.AddJwtTokenServices(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

//Añadir servicios customizados
builder.Services.AddScoped<IEstudiantesService, EstudiantesService>();
builder.Services.AddScoped<ICursosService, CursosService>();
builder.Services.AddScoped<IIndicesService, IndicesService>();


//Añadir politca de autorizacion
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Configurar Swagger para que tenga en cuenta la Auntenticacion
builder.Services.AddSwaggerGen(options =>
{
    //Definimos la seguridad
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization", 
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization using Bearer Scheme"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                }
            },
            new string[]{}
        }
    });
});

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
