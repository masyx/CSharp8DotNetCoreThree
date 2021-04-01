using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindService.Controllers
{
    [ApiController] // Enables REST-specific behavior for controllers, like automatic HTTP 400 response for invalid models 
    // [Route("[controller]")] - uses characters before Controller in the class name,
    // in this case WeatherForcast or I can simply enter a different name
    [Route("api/forecast")]
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

        // GET /api/forecast
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Get(5);
        }

        // GET /api/forecast/7
        [HttpGet("{days:int}")]
        public IEnumerable<WeatherForecast> Get(int days)
        {
            var rng = new Random();
            var forecastArray = Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return forecastArray;
        }
    }
}
