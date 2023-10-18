using Microsoft.Extensions.Caching.Memory;

namespace hg_brasil_finance
{
    public class CacheConfig
    {
       public TimeSpan ExpirationDate {  get; set; }
       private readonly MemoryCache _cache;
        public CacheConfig(int expirationDate)
        {
            ExpirationDate = TimeSpan.FromSeconds(expirationDate);
            var memoryCacheOptions = new MemoryCacheOptions();
            _cache = new MemoryCache(memoryCacheOptions);
        }

        public object TryGetValue(string key) 
        {
            var cache = _cache.TryGetValue(key, out var value);
            return value;
        }

        public void SetValue(object value, string key)
        {
            var teste = _cache.Set(key, value, ExpirationDate);
        }

        public T GetFromCache<T>(string cacheKey) where T : class
        {
            if (_cache != null)
            {
                return (T)TryGetValue(cacheKey);
            }
            return null;
        }

        public void SetCacheValue<T>(T value, string cacheKey)
        {
            if (_cache != null)
            {
                SetValue(value, cacheKey);
            }
        }
    }
}
