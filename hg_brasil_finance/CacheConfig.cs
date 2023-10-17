using Microsoft.Extensions.Caching.Memory;

namespace hg_brasil_finance
{
    public class CacheConfig
    {
       public TimeSpan Expiration {  get; set; }
       private readonly MemoryCache _cache;
        public CacheConfig(int expiration)
        {
            Expiration = TimeSpan.FromSeconds(expiration);
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
            var teste = _cache.Set(key, value, Expiration);
        }
    }
}
