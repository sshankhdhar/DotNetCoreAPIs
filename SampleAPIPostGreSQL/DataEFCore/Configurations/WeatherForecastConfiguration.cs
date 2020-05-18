using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace DataEFCore.Configurations
{
    public class WeatherForecastConfiguration
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastConfiguration(EntityTypeBuilder<WeatherForecast> entity)
        {
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id);
            entity.HasData(Get());
        }

        private IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            int i = 0;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = ++i,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
