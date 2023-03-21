using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace University_API_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //Metodo: GET -> localhost:7157/WeatherForecast

        [HttpGet(Name = "GetWeatherForecast")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]
        public IEnumerable<WeatherForecast> Get()
        {
            
            _logger.LogTrace($"{nameof(WeatherForecastController)} - {nameof(Get)}: Trace level log");
            _logger.LogDebug($"{nameof(WeatherForecastController)} - {nameof(Get)}: Debug level log");
            _logger.LogInformation("Information level log");
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(Get)}: Waring level log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(Get)}: Error level log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(Get)}: Critical level log");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}