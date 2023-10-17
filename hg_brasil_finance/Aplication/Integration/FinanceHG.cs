using hg_brasil_finance.Domain.Entities;
using hg_brasil_finance.Extentions;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace hg_brasil_finance.Aplication.Integration
{
    public class FinanceHG : IFinanceHG
    {
        private readonly RestClient _client;
        private string message;
        private string statusCode;
        private Root<Dictionary<string, StockResponse>> responseStockResponse;
        private Root<Dictionary<string, DefaultResponse>> responseDefaultResponse;
        private Root<List<string>> responseListResponse;
        private readonly CacheConfig _cache;
        private readonly string _keyFinanceHG;

        public FinanceHG(string keyFinanceHG, CacheConfig cache)
        {
            _client = new RestClient("https://api.hgbrasil.com/finance");
            _cache = cache;
            _keyFinanceHG = keyFinanceHG;
        }

        public FinanceHG(string keyFinanceHG)
        {
            _client = new RestClient("https://api.hgbrasil.com/finance");
            _keyFinanceHG = keyFinanceHG;
        }

        public ApiResponse<Dictionary<string, DefaultResponse>> GetAll()
        {
            try
            {
                if (_cache != null)
                {
                    var result = (ApiResponse<Dictionary<string, DefaultResponse>>)_cache.TryGetValue("AllCache");
                    if (result != null)
                        return result;
                }
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("key", _keyFinanceHG);

                var response = _client.Execute(request);

                responseDefaultResponse = response.Content.DeserializeObjectDefault();
                message = response.IsSuccessful ? "Sucesso" : response.ErrorMessage;
                statusCode = response.StatusCode.ToString();

                if (_cache != null)
                    _cache.SetValue(new ApiResponse<Dictionary<string, DefaultResponse>>(message, responseDefaultResponse, statusCode, true), "AllCache");
            }
            catch (Exception ex)
            {
                message = ex.Message;
                statusCode = HttpStatusCode.InternalServerError.ToString();
            }

            return new ApiResponse<Dictionary<string, DefaultResponse>>(message, responseDefaultResponse, statusCode, false);
        }

        public ApiResponse<List<String>> GetAllTickers()
        {
            try
            {
                if (_cache != null)
                {
                    var result = (ApiResponse<List<String>>)_cache.TryGetValue("AllTickersCache");
                    if (result != null)
                        return result;
                }

                var request = new RestRequest("/ticker_list");
                request.Method = Method.Get;
                request.AddHeader("key", _keyFinanceHG);

                var response = _client.Execute(request);

                responseListResponse = response.Content.DeserializeObjectList();
                message = response.IsSuccessful ? "Sucesso" : response.ErrorMessage;
                statusCode = response.StatusCode.ToString();

                if (_cache != null)
                    _cache.SetValue(new ApiResponse<List<String>>(message, responseListResponse, statusCode, true), "AllCache");
            }
            catch (Exception ex)
            {
                message = ex.Message;
                statusCode = HttpStatusCode.InternalServerError.ToString();
            }

            return new ApiResponse<List<String>>(message, responseListResponse, statusCode, false);

        }

        public ApiResponse<Dictionary<string, StockResponse>> GetHistorical(short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date, string mode)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Dictionary<string, StockResponse>> GetHistoricalStocks(IEnumerable<string> symbols, short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Dictionary<string, StockResponse>> GetIboves(short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Dictionary<string, StockResponse>> GetQuotations()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Dictionary<string, StockResponse>> GetStockDividends(IEnumerable<string> symbol)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Dictionary<string, StockResponse>> GetStockPrice(IEnumerable<string> symbol)
        {
            try
            {
                if (_cache != null)
                {
                    var result = (ApiResponse<Dictionary<string, StockResponse>>)_cache.TryGetValue("StockPriceCache");
                    if (result != null)
                        return result;
                }

                var request = new RestRequest("/stock_price", method: Method.Get);

                request.AddParameter("key", _keyFinanceHG);
                request.AddParameter("symbol", string.Join(",", symbol));

                var response = _client.Execute(request);

                responseStockResponse = response.Content.DeserializeObjectStock();
                message = response.IsSuccessful ? "Sucesso" : response.ErrorMessage;
                statusCode = response.StatusCode.ToString();

                if (_cache != null)
                    _cache.SetValue(new ApiResponse<Dictionary<string, StockResponse>>(message, responseStockResponse, statusCode, true), "StockPriceCache");
            }
            catch (Exception ex)
            {
                message = ex.Message;
                statusCode = HttpStatusCode.InternalServerError.ToString();
            }

            return new ApiResponse<Dictionary<string, StockResponse>>(message, responseStockResponse, statusCode, false);
        }

        public ApiResponse<Dictionary<string, StockResponse>> GetTaxes()
        {
            throw new NotImplementedException();
        }
    }
}
