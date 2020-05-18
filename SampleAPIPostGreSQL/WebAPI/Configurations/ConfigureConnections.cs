using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.InteropServices;
using DataEFCore;

namespace WebAPI.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = String.Empty;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                connection = configuration.GetConnectionString("DbWindows") ??
                                 @"User ID =postgres;Password='MYpara1,';Server=localhost;Port=5432;Database='ShalabhTestDb';Integrated Security=true;Pooling=true;";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                connection = configuration.GetConnectionString("DbDocker") ??
                                 "User ID =postgres;Password='MYpara1,';Server=localhost;Port=5432;Database='ShalabhTestDb';Integrated Security=true;Pooling=true;";
            }

            services.AddDbContextPool<Context>(options => options.UseNpgsql(connection));

            return services;
        }
    }
}
