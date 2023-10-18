using hg_brasil_finance.Domain.Entities;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace hg_brasil_finance.Aplication
{
    public class BaseIntegration<T>
    {
        private readonly ApiError _error;
        private readonly string _keyFinanceHG;
        private readonly CacheConfig _cache;
        private readonly RestClient _client;

        public BaseIntegration(string keyFinanceHG, CacheConfig cache)
        {
            _keyFinanceHG = keyFinanceHG;
            _client = new RestClient("https://api.hgbrasil.com/finance");
            _error = new ApiError();
            _cache = cache;
        }
        public BaseIntegration(string keyFinanceHG)
        {
            _keyFinanceHG = keyFinanceHG;
            _client = new RestClient("https://api.hgbrasil.com/finance");
            _error = new ApiError();
        }

        public ApiResponse<T> FetchData<T>(string endpoint, string cacheKey)
        {
            try
            {
                if (_cache != null)
                {
                    var cachedResponse = _cache.GetFromCache<ApiResponse<T>>(cacheKey);
                    if (cachedResponse != null) return cachedResponse;
                }

                var response = SendRequest(endpoint);

                if (!response.IsSuccessful)
                    return _error.HandleException<T>(response.ErrorMessage, response.StatusCode.ToString());

                var data = JsonConvert.DeserializeObject<Root<T>>(response.Content);

                var apiResponse = new ApiResponse<T>("Sucesso!", data, response.StatusCode.ToString(), false);
                if (_cache != null)
                    _cache.SetCacheValue(apiResponse, cacheKey);

                return apiResponse;
            }
            catch (Exception ex)
            {
                return _error.HandleException<T>(ex.Message, HttpStatusCode.InternalServerError.ToString());
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
