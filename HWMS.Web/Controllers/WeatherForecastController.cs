using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HWMS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HWMS.Web.Controllers
{
    [ApiController]
    [Route("api/WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IOrderAppService _OrderAppService;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IOrderAppService OrderAppService)
        {
            _logger = logger;
            this._OrderAppService = OrderAppService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _OrderAppService.GetAll();
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
