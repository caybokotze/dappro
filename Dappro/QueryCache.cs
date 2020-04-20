using System;
using System.Collections;
using System.Data;
using Microsoft.Extensions.Caching.Memory;

namespace Dappro
{
    public class QueryCache<T>
    {
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions()
        {
            SizeLimit = 1024
        });

        public T GetOrCreate(object key, Func<T> createItem)
        {
            T cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry)) //look for the cache key.
            {
                cacheEntry = createItem();

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSize(1)
                    //Priority on removal when reaching limit.
                    .SetPriority(CacheItemPriority.High)
                    .SetSlidingExpiration(TimeSpan.FromSeconds(5))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));
                //
                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }
        
        //Usage: var _avatarCache = new SimpleMemoryCache<byte[]>();
        //var myAvatar = _avatarCache.GetOrCreate(userId, () => _database.GetAvatar(userId));
    }
}