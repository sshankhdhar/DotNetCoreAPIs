using System;
using Domain.ApiModels;
using Domain.Converters;

namespace Domain.Entities
{
    public class WeatherForecast : IConvertModel<WeatherForecast, WeatherForecastApiModel>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }

        public WeatherForecastApiModel Convert() => new WeatherForecastApiModel()
        {
            Id = Id,
            Date = Date,
            TemperatureC = TemperatureC,
            Summary = Summary
        };
    }
}