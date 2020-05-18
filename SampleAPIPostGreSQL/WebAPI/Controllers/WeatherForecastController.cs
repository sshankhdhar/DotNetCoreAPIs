using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.ApiModels;
using Domain.Supervisor;

namespace WebAPI.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ISupervisor _Supervisor;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISupervisor supervisor)
        {
            _logger = logger;
            _Supervisor = supervisor;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecastApiModel>> Get(CancellationToken ct = default)
        {
            return await _Supervisor.GetAllWeatherForecastAsync(ct);
        }

        [HttpGet("{id}")]
        public async Task<WeatherForecastApiModel> Get(int id, CancellationToken ct = default)
        {
            return await _Supervisor.GetWeatherForecastByIdAsync(id, ct);
        }
    }
}
