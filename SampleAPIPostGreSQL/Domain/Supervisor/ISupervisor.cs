using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.ApiModels;

namespace Domain.Supervisor
{
    public interface ISupervisor
    {
        Task<IEnumerable<WeatherForecastApiModel>> GetAllWeatherForecastAsync(CancellationToken ct = default);
        Task<WeatherForecastApiModel> GetWeatherForecastByIdAsync(int id, CancellationToken ct = default);
    }
}