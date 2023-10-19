using hg_brasil_finance.Domain.Entities;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace hg_brasil_finance.Aplication
{
    public class BaseIntegration<T>
    {
        private readonly string _keyFinanceHG;
        private readonly CacheConfig _cache;
        private readonly RestClient _client;
        private readonly ReturnMessage<T> _returnMessage;

        public BaseIntegration(string keyFinanceHG, CacheConfig cache = null)
        {
            _keyFinanceHG = keyFinanceHG;
            _client = new RestClient("https://api.hgbrasil.com/finance");
            _cache = cache;
            _returnMessage = new ReturnMessage<T>();
        }

        public ApiResponse<T> FetchData(string endpoint, string cacheKey)
        {
            try
            {
                if (_cache != null)
                {
                    var cachedResponse = _cache.GetFromCache<ApiResponse<T>>(cacheKey);
                    if (cachedResponse != null) return cachedResponse;
                }

                var response = SendRequest(endpoint);

                var data = JsonConvert.DeserializeObject<Root<Dictionary<string, T>>>(response.Content);

                var apiResponse = _returnMessage.Message("Sucesso!", response.StatusCode.ToString(), data, false);

                if (_cache != null)
                    _cache.SetCacheValue(apiResponse, cacheKey);

                return apiResponse;
            }
            catch (Exception ex)
            {
                return _returnMessage.Message(ex.Message, HttpStatusCode.InternalServerError.ToString(), null);
            }
        }

        private RestResponse SendRequest(string endpoint = "")
        {
            var request = new RestRequest(endpoint, method: Method.Get);
            request.AddQueryParameter("key", _keyFinanceHG);
            return _client.Execute(request);
        }
    }
}
