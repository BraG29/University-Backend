//1. Usings para trabajar con EntityFramework
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using University_API_Backend.DataAcces;
using University_API_Backend.Services;
using Serilog;


namespace University_API_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            //Configurar Serilog
            builder.Host.UseSerilog((hostBuilderCtx, loggerConf) =>
            {
                loggerConf
                    .WriteTo.Console()
                    .WriteTo.Debug()
                    .ReadFrom.Configuration(hostBuilderCtx.Configuration);
            });

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

            //Localization
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

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

            //Supported Cultures
            var supportedCultures = new[]
            {
                "en-US", "es-ES", "fr-FR", "de-DE"
            };
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[0]) //English by default
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            //Add localization to App 
            app.UseRequestLocalization(localizationOptions);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Decirle a la app que use Serilog
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            //Decirle a la aplicacion que use los CORS
            app.UseCors("CorsPolicy");

            app.Run();
        }
    }

}
