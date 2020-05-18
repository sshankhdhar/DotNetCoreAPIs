using System.Threading;
using Microsoft.Extensions.Caching.Memory;
using Domain.Repositories;

namespace Domain.Supervisor
{
    public partial class Supervisor : ISupervisor
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly IMemoryCache _cache;
        public Supervisor()
        {

        }

        public Supervisor(IWeatherRepository weatherRepository,
            IMemoryCache memoryCache)
        {
            _weatherRepository = weatherRepository;
            _cache = memoryCache;
        }

    }
}