using System;
using Domain.Converters;
using Domain.Entities;

namespace Domain.ApiModels
{
    public class WeatherForecastApiModel : IConvertModel<WeatherForecastApiModel, WeatherForecast>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public WeatherForecast Convert() => new WeatherForecast()
        {
            Date = Date,
            TemperatureC = TemperatureC,
            Summary = Summary
        };
    }
}