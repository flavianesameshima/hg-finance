using hg_brasil_finance.Domain.Entities;

namespace hg_brasil_finance.Aplication.Integration
{
    public class FinanceStock : IFinanceStock
    {
        private readonly BaseIntegration<StockResponse> _integration;
        private readonly BaseIntegration<DividendsResponse> _integrationDividends;
        public FinanceStock(string keyFinanceHG, CacheConfig cache = null)
        {
            _integration = new BaseIntegration<StockResponse>(keyFinanceHG, cache);
            _integrationDividends = new BaseIntegration<DividendsResponse>(keyFinanceHG, cache);
        }

        public ApiResponse<StockResponse> GetIbovespa()
        => _integration.FetchData("/ibovespa", "IbovespaCache");

        public ApiResponse<StockResponse> GetIbovespa(short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date)
        => _integration.FetchData("/ibovespa", "IbovespaCache");

        public ApiResponse<StockResponse> GetQuotations() 
            => _integration.FetchData("/quotations", "QuotationsCache");

        public ApiResponse<DividendsResponse> GetStockDividends(IEnumerable<string> symbol)
            => _integrationDividends.FetchData($"/stock_dividends?symbol={string.Join(",", symbol)}", "StockDividendsCache");

        public ApiResponse<StockResponse> GetStockPrice(IEnumerable<string> symbol)
            =>_integration.FetchData($"/stock_price?symbol={string.Join(",", symbol)}", "StockPriceCache");        

        public ApiResponse<StockResponse> GetTaxes()
            => _integration.FetchData("/taxes", "TaxesCache");
    }
}
