using App.Domain.Core._Common.Contracts.Services;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RedisCache
{
    public class RedisCacheServices :IRedisCacheServices
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheServices(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }


        public void SetSliding<T>(string key, T value, int expirationTime)
        {
            var cacheOptions = new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromDays(expirationTime)
            };
            _distributedCache.SetString(key, JsonSerializer.Serialize(value), cacheOptions);
        }

        public void Set<T>(string key, T value, int expirationTime)
        {
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(expirationTime)
            };
            _distributedCache.SetString(key, JsonSerializer.Serialize(value), cacheOptions);
        }

        public T Get<T>(string key)
        {
            var value = _distributedCache.GetString(key);

            if (value != null)
            {
                return JsonSerializer.Deserialize<T>(value);
            }

            return default;
        }

        public bool HasCache(string key)
        {
            var value = _distributedCache.GetString(key);

            return value != null;
        }

    }
}
