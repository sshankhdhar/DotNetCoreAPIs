using Microsoft.EntityFrameworkCore;
using System.Threading;
using DataEFCore.Configurations;
using Domain.Entities;

namespace DataEFCore
{
    public class Context : DbContext
    {
        //public Context()
        //{

        //}
        public DbSet<WeatherForecast> WeatherForecast { get; set; }
        public static long InstanceCount;

        public Context(DbContextOptions options) : base(options)
            => Interlocked.Increment(ref InstanceCount);

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(@"User ID =postgres;Password='MYpara1,';Server=localhost;Port=5432;Database='ShalabhTestDb';Integrated Security=true;Pooling=true;").EnableSensitiveDataLogging();
        //}


        //defining entities and its relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new WeatherForecastConfiguration(modelBuilder.Entity<WeatherForecast>());
        }
    }
}
