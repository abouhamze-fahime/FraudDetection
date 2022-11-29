using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace Fraud.Infrastructure.Cache
{
    public interface ICacheProvider
    {
        void Set(string cacheKey, object item, CacheEntryRemovedCallback removedCallback, TimeSpan? cacheTime);
        void Set(string cacheKey, object item, TimeSpan? cacheTime=null);
        object Get(string cacheKey);
        bool IsSetCache(string cacheKey);
        void Remove(string cacheKey);
        T Get<T>(string cacheKey);
        T SetAndGet<T>(TimeSpan cacheTime, Func<T> func, params string[] cacheKeys);
    }
}
