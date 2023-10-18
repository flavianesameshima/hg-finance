using hg_brasil_finance.Domain.Entities;

namespace hg_brasil_finance.Aplication.Integration
{
    public class FinanceStock : IFinanceStock
    {
        private readonly BaseIntegration<Dictionary<string, StockResponse>> _integration;
        private readonly CacheConfig _cache;
        private readonly string _keyFinanceHG;
        public FinanceStock(string keyFinanceHG, CacheConfig cache)
        {
            _cache = cache;
            _keyFinanceHG = keyFinanceHG;
            _integration = new BaseIntegration<Dictionary<string, StockResponse>>(_keyFinanceHG, _cache);
        }

        public FinanceStock(string keyFinanceHG)
        {
            _keyFinanceHG = keyFinanceHG;
            _integration = new BaseIntegration<Dictionary<string, StockResponse>>(_keyFinanceHG);
        }

        public ApiResponse<Dictionary<string, StockResponse>> GetHistorical(short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date, string mode)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Dictionary<string, StockResponse>> GetHistoricalStocks(IEnumerable<string> symbols, short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Dictionary<string, StockResponse>> GetIbovespa()
        => _integration.FetchData<Dictionary<string, StockResponse>>("/ibovespa", "IbovespaCache");

        public ApiResponse<Dictionary<string, StockResponse>> GetIbovespa(short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date)
        => _integration.FetchData<Dictionary<string, StockResponse>>("/ibovespa", "IbovespaCache");

        public ApiResponse<Dictionary<string, StockResponse>> GetQuotations() 
            => _integration.FetchData<Dictionary<string, StockResponse>>("/quotations", "QuotationsCache");

        public ApiResponse<Dictionary<string, StockResponse>> GetStockDividends(IEnumerable<string> symbol)
            => _integration.FetchData<Dictionary<string, StockResponse>>($"/stock_dividends?symbol={string.Join(",", symbol)}", "StockDividendsCache");

        public ApiResponse<Dictionary<string, StockResponse>> GetStockPrice(IEnumerable<string> symbol)
            =>_integration.FetchData<Dictionary<string, StockResponse>>($"/stock_price?symbol={string.Join(",", symbol)}", "StockPriceCache");
        

        public ApiResponse<Dictionary<string, StockResponse>> GetTaxes()
            => _integration.FetchData<Dictionary<string, StockResponse>>("/taxes", "TaxesCache");
    }
}
