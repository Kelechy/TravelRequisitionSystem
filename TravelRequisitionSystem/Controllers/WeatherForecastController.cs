using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelRequisitionSystem.Data;

namespace TravelRequisitionSystem.Controllers
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
        private readonly ITravelRequestRepo _travel;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITravelRequestRepo travel)
        {
            _logger = logger;
            _travel = travel;
        }

        [HttpGet("[action]/{CountryName}")]
        public async Task<IActionResult> GetCountryDetails(string CountryName)
        {
            var response = await _travel.SearchCountryDetails(CountryName);
            return Ok(response);
        }

       

    }
}
