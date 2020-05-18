using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.ApiModels;
using Domain.Entities;
using Domain.Extensions;

namespace Domain.Supervisor
{
    public partial class Supervisor
    {
        public async Task<IEnumerable<WeatherForecastApiModel>> GetAllWeatherForecastAsync(CancellationToken ct = default)
        {
            var forecasts = await _weatherRepository.GetAllAsync(ct);
            foreach (var forecast in forecasts)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(forecast.Id, forecast, cacheEntryOptions);
            }
            return forecasts.ConvertAll();
        }


        public async Task<WeatherForecastApiModel> GetWeatherForecastByIdAsync(int id, CancellationToken ct = default)
        {
            var weather = _cache.Get<WeatherForecast>(id);

            if (weather != null)
            {
                var weatherApiModel = weather.Convert();
                return weatherApiModel;
            }
            else
            {
                var weatherModel = (await _weatherRepository.GetByIdAsync(id, ct));

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(weatherModel.Id, weatherModel, cacheEntryOptions);
                return weatherModel.Convert();
            }
        }
    }
}