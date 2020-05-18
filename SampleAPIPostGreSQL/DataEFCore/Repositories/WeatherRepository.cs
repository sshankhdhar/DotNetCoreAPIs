using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace DataEFCore.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly Context _context;

        public WeatherRepository(Context context)
        {
            _context = context;
        }
        public void Dispose() => _context.Dispose();

        public async Task<List<WeatherForecast>> GetAllAsync(CancellationToken ct = default) => await _context.WeatherForecast.AsNoTracking().ToListAsync(ct);

        public async Task<WeatherForecast> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.WeatherForecast.FindAsync(id);
        }
    }
}
