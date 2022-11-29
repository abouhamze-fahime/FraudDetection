using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace Fraud.Infrastructure.Cache
{
    public class CacheProvider : ICacheProvider
    {
        const string CentralContextCache = "CentralContextCache";
        const int DefaultCacheTime = 60;//seconds
        MemoryCache _cache;
        public CacheProvider()
        {
            _cache = new MemoryCache(CentralContextCache);
        }
        public object Get(string cacheKey)
        {
            return _cache.Get(cacheKey);
        }

        public bool IsSetCache(string cacheKey)
        {
            return _cache.Contains(cacheKey);
        }

        public void Remove(string cacheKey)
        {
            if (_cache.Contains(cacheKey))
                _cache.Remove(cacheKey);
        }

        public void Set(string cacheKey, object item, CacheEntryRemovedCallback removedCallback, TimeSpan? cacheTime)
        {
            if (cacheTime == null)
            {
                cacheTime = TimeSpan.FromSeconds(DefaultCacheTime);
            }
            var cachePolicy = new CacheItemPolicy()
            {
                RemovedCallback = removedCallback,
                AbsoluteExpiration = DateTime.Now.Add(cacheTime.Value)
            };
            _cache.Set(cacheKey, item, cachePolicy);
        }

        public void Set(string cacheKey, object item, TimeSpan? cacheTime)
        {
            if (cacheTime == null)
            {
                cacheTime = TimeSpan.FromSeconds(DefaultCacheTime);
            }
            var cachePolicy = new CacheItemPolicy()
            {
                AbsoluteExpiration = DateTime.Now.Add(cacheTime.Value)
            };
            _cache.Set(cacheKey, item, cachePolicy);
        }
        public T Get<T>(string cacheKey)
        {
            try
            {
                var res = (T)_cache.Get(cacheKey);
                return res;
            }
            catch
            {
                return default(T);
            }
        }

        public T SetAndGet<T>(TimeSpan cacheTime, Func<T> func, params string[] cacheKeys)
        {
            var cacheKey = string.Join(",", typeof(T).Name, string.Join(",", cacheKeys));
            if (_cache.Contains(cacheKey))
                return (T)_cache.Get(cacheKey);
            var res = func();
            var cachePolicy = new CacheItemPolicy()
            {
                AbsoluteExpiration = DateTime.Now.Add(cacheTime)
            };
            _cache.Set(cacheKey, res, cachePolicy);
            return res;
        }
    }

}
