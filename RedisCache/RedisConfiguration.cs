using App.Domain.Core._Common.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCache
{
    public static class RedisConfiguration
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services)
        {
            services.AddScoped<IRedisCacheServices, RedisCacheServices>();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
                options.ConfigurationOptions = new ConfigurationOptions
                {
                    Password = string.Empty,
                    DefaultDatabase = 1,
                    ConnectTimeout = 5000,
                };
                options.ConfigurationOptions.EndPoints.Add("localhost:6379");

            });

            return services;
        }
    }
}
