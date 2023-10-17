using hg_brasil_finance.Domain.Entities;
using RestSharp;
using System.Net;

namespace hg_brasil_finance.Aplication.Integration
{
    public class FinanceHG : IFinanceHG
    {
        private readonly RestClient _client;

        public FinanceHG()
        {
            _client = new RestClient("https://api.hgbrasil.com/finance");
        }

        public ReturnAPI GetAll(string key)
        {
            try
            {
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("key", key);

                var response = _client.Execute<Root>(request);

                var returnAPI = new ReturnAPI("Sucesso!", response.Data, response.StatusCode.ToString());

                return returnAPI;
            }
            catch (Exception ex)
            {
                return new ReturnAPI(ex.Message, HttpStatusCode.InternalServerError.ToString());
            }
        }

        public ReturnAPI GetHistorical(string key, short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date, string mode)
        {
            throw new NotImplementedException();
        }

        public ReturnAPI GetHistoricalStocks(string key, IEnumerable<string> symbols, short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date)
        {
            throw new NotImplementedException();
        }

        public ReturnAPI GetIboves(string key, short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date)
        {
            throw new NotImplementedException();
        }

        public ReturnAPI GetQuotations(string key)
        {
            throw new NotImplementedException();
        }

        public ReturnAPI GetStockDividends(string key, IEnumerable<string> symbol)
        {
            throw new NotImplementedException();
        }

        public ReturnAPI GetStockPrice(string key, IEnumerable<string> symbol)
        {
            try
            {
                var request = new RestRequest("/stock_price", method: Method.Get);

                request.AddParameter("key", key);
                request.AddParameter("symbol", string.Join(",", symbol));

                var response = _client.Execute<Root>(request);

                var returnAPI = new ReturnAPI("Sucesso", response.Data, response.StatusCode.ToString());

                return returnAPI;

            }
            catch (Exception ex)
            {
               return new ReturnAPI(ex.Message, HttpStatusCode.InternalServerError.ToString());
            }
        }

        public ReturnAPI GetTaxes(string key)
        {
            throw new NotImplementedException();
        }
    }
}
