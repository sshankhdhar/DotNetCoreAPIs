using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IWeatherRepository : IDisposable
    {
        Task<List<WeatherForecast>> GetAllAsync(CancellationToken ct = default);
        Task<WeatherForecast> GetByIdAsync(int id, CancellationToken ct = default);
    }
}